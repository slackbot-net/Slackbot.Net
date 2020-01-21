using System.Threading.Tasks;
using Slackbot.Net.SlackClients.Http.Models.Requests.OAuthAccess;
using Slackbot.Net.SlackClients.Http.Models.Responses.OAuthAccess;

namespace Slackbot.Net.SlackClients.Http
{
    public interface ISlackOAuthAccessClient
    {
        /// <summary>
        /// https://api.slack.com/methods/oauth.access
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Task<OAuthAccessResponse> OAuthAccess(OauthAccessRequest req);
    }
}