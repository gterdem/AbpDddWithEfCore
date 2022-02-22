using System;
using AbpDddWithEfCore.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace AbpDddWithEfCore.Blogs;

public class EfCoreBlogRepository : EfCoreRepository<AbpDddWithEfCoreDbContext, Blog, Guid>, IBlogRepository
{
    public EfCoreBlogRepository(IDbContextProvider<AbpDddWithEfCoreDbContext> dbContextProvider) : base(
        dbContextProvider)
    {
    }
}