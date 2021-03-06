using System.Threading.Tasks;
using Slackbot.Net.Models.BlockKit;
using Slackbot.Net.SlackClients.Http.Models.Requests.ViewPublish;
using Slackbot.Net.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Slackbot.Net.Tests
{
    public class ViewPublishTests: Setup
    {
        public ViewPublishTests(ITestOutputHelper helper) : base(helper)
        {
        }
        
        [Fact(Skip = "Integration test")]
        public async Task ViewPublishWorks()
        {
            var response = await SlackClient.ViewPublish(new ViewPublishRequest("U0EBWMGG4")
            {
                View = new View
                {
                    Type = PublishViewConstants.Home,
                    Blocks = new IBlock[]
                    {
                        new Block
                        {
                            type = BlockTypes.Section,
                            text = new Text
                            {
                                text = "This is some other text"
                            }
                        }
                    }
                }
            });
            Assert.True(response.Ok);
        }
    }
}