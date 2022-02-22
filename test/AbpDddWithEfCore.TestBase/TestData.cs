using System;
using Volo.Abp.DependencyInjection;

namespace AbpDddWithEfCore;

public class TestData : ISingletonDependency
{
    public Guid SampleBlogId { get; set; } = Guid.NewGuid();
    public Guid FirstPostId { get; set; } = Guid.NewGuid();
    public Guid SecondPostId { get; set; } = Guid.NewGuid();
    public Guid ThirdPostId { get; set; } = Guid.NewGuid();
}