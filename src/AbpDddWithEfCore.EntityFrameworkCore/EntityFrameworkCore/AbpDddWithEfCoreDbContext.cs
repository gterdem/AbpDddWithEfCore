using System;
using AbpDddWithEfCore.Blogs;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace AbpDddWithEfCore.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class AbpDddWithEfCoreDbContext :
    AbpDbContext<AbpDddWithEfCoreDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion
    
    public virtual DbSet<Blog> Blogs { get; set; }

    public AbpDddWithEfCoreDbContext(DbContextOptions<AbpDddWithEfCoreDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureIdentityServer();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */

        builder.Entity<Blog>(b =>
        {
            b.ToTable(AbpDddWithEfCoreConsts.DbTablePrefix + "Blogs", AbpDddWithEfCoreConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(q => q.Name).IsRequired().HasMaxLength(BlogConstants.BlogNameMaxLength);
            
            b.Metadata.FindNavigation(nameof(Blog.Posts))?.SetPropertyAccessMode(PropertyAccessMode.Field);
            
            // Not needed. EFCore can automatically detect Foreign key from name convention
            // b.HasMany(q => q.Posts).WithOne().HasForeignKey("BlogId").IsRequired();
        });

        builder.Entity<Post>(b =>
        {
            b.ToTable(AbpDddWithEfCoreConsts.DbTablePrefix + "Posts", AbpDddWithEfCoreConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(q => q.Name).IsRequired().HasMaxLength(BlogConstants.PostNameMaxLength);
            b.Property<Guid>("BlogId").IsRequired();
        });
    }
}
