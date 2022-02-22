using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace AbpDddWithEfCore.Pages;

public class Index_Tests : AbpDddWithEfCoreWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
