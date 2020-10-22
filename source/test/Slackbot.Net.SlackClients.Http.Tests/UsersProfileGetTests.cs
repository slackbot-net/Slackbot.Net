using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace CronBackgroundServices.Tests
{
    public class UsersProfileGetTests : Setup
    {
        public UsersProfileGetTests(ITestOutputHelper helper) : base(helper)
        {
        }
        
        [Fact]
        public async Task UsersProfileWorks()
        {
            var response = await SlackClient.UserProfile("USRAR1YTV");
            Assert.True(response.Ok);
        }
        
        [Fact]
        public async Task FindsApp()
        {
            var response = await SlackClient.UserProfile("USRAR1YTV");
            Assert.Equal("AREFP62B1",response.Profile.Api_App_Id);
        }
    }
}