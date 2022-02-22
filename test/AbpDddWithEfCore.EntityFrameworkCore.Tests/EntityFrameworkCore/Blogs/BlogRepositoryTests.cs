using System.Threading.Tasks;
using AbpDddWithEfCore.Blogs;
using Shouldly;
using Volo.Abp.Uow;
using Xunit;

namespace AbpDddWithEfCore.EntityFrameworkCore.Blogs;

public class BlogRepositoryTests : AbpDddWithEfCoreEntityFrameworkCoreTestBase
{
    private readonly IBlogRepository _blogRepository;
    private readonly TestData _testData;
    private readonly IUnitOfWorkManager _unitOfWorkManager;

    public BlogRepositoryTests()
    {
        _testData = GetRequiredService<TestData>();
        _blogRepository = GetRequiredService<IBlogRepository>();
        _unitOfWorkManager = GetRequiredService<IUnitOfWorkManager>();
    }

    [Fact]
    public async Task Get_Sample_Blog_With_Posts()
    {
        using (_unitOfWorkManager.Begin())
        {
            var blog = await _blogRepository.GetAsync(_testData.SampleBlogId);
            blog.ShouldNotBeNull();
            blog.Posts.ShouldNotBeEmpty();
            blog.RemovePosts();
            await _blogRepository.UpdateAsync(blog, autoSave: true);
            await _unitOfWorkManager.Current.CompleteAsync();
        }

        var updatedBlog = await _blogRepository.GetAsync(_testData.SampleBlogId);
        updatedBlog.ShouldNotBeNull();
        updatedBlog.Posts.ShouldBeEmpty();
    }
}