using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace AbpDddWithEfCore.Blogs;

public static class EfCoreBlogQueryableExtensions
{
    public static IQueryable<Blog> IncludePostDetails(this IQueryable<Blog> queryable, Expression<Func<Post, bool>> predicate, bool include = true)
    {
        if (!include)
        {
            return queryable;
        }

        return queryable
            .Include(q => q.Posts.AsQueryable()
                .Where(predicate));
    }
    
    public static IQueryable<Blog> IncludePostDetails(this IQueryable<Blog> queryable, bool include = true)
    {
        if (!include)
        {
            return queryable;
        }

        return queryable
            .Include(q => q.Posts);
    }
}