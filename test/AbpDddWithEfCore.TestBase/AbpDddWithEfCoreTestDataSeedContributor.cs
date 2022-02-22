using System.Threading.Tasks;
using AbpDddWithEfCore.Blogs;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace AbpDddWithEfCore;

public class AbpDddWithEfCoreTestDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly TestData _testData;
    private readonly IBlogRepository _blogRepository;

    public AbpDddWithEfCoreTestDataSeedContributor(IBlogRepository blogRepository, TestData testData)
    {
        _blogRepository = blogRepository;
        _testData = testData;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        await SeedSampleBlogAsync(context);
        await SeedSamplePostsAsync(context);
    }

    private async Task SeedSampleBlogAsync(DataSeedContext context)
    {
        await _blogRepository.InsertAsync(
            new Blog(_testData.SampleBlogId, "My super Blog"), autoSave: true
        );
    }

    private async Task SeedSamplePostsAsync(DataSeedContext context)
    {
        var blog = await _blogRepository.GetAsync(_testData.SampleBlogId);
        blog.AddPost(_testData.FirstPostId, "My First Blog POST!");
        blog.AddPost(_testData.SecondPostId, "My First Blog POST!");
        blog.AddPost(_testData.ThirdPostId, "My First Blog POST!");

        await _blogRepository.UpdateAsync(blog);
    }
}