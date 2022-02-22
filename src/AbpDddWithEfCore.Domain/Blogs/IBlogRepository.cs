using System;
using Volo.Abp.Domain.Repositories;

namespace AbpDddWithEfCore.Blogs;

public interface IBlogRepository : IRepository<Blog, Guid>
{
}