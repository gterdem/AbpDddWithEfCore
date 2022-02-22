using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace AbpDddWithEfCore.Blogs;

public class Blog : AggregateRoot<Guid>
{
    private readonly ICollection<Post> _posts;
    public string Name { get; private set; }
    public IReadOnlyCollection<Post> Posts => _posts.ToList();

    private Blog()
    {
        _posts = new Collection<Post>();
    }

    public Blog(Guid id, [NotNull] string name) : base(id)
    {
        Name = Check.NotNullOrEmpty(name, nameof(name),maxLength:BlogConstants.BlogNameMaxLength);
    }

    public Blog AddPost(Guid postId, string name, Guid? tenantId = null)
    {
        var post = new Post(id: postId, blogId: Id, name: name, tenantId: tenantId);
        _posts.AddIfNotContains(post);
        return this;
    }

    public void RemovePosts()
    {
        _posts.Clear();
    }
}