using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace AbpDddWithEfCore.Blogs;

public class Post : AuditedEntity<Guid>, IMultiTenant, ISoftDelete
{
    public string Name { get; private set; }
    public Guid BlogId { get; private set; }
    public Guid? TenantId { get; private set; }
    public bool IsDeleted { get; set; }

    private Post()
    {
    }

    public Post(Guid id, Guid blogId, [NotNull] string name, Guid? tenantId = null) : base(id)
    {
        Name = Check.NotNullOrEmpty(name, nameof(name),maxLength:BlogConstants.PostNameMaxLength);
        BlogId = blogId;
        TenantId = tenantId;
    }
}