using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Slackbot.Net.Endpoints.Abstractions;
using Slackbot.Net.Endpoints.Models;

namespace Slackbot.Net.Samples.Events
{
    public class OtherAppMentionHandler : IHandleEvent
    {
        public Task Handle(EventMetaData eventMetadata, SlackEvent slackEvent)
        {
            Console.WriteLine("Doing stuff from AppmentionHandler: " + JsonConvert.SerializeObject(slackEvent));
            return Task.CompletedTask;
        }

        public bool ShouldHandle(SlackEvent slackEvent) => slackEvent is AppMentionEvent appMentionEvent && appMentionEvent.Text == "test";
        
        public (string, string)  GetHelpDescription() => (HandlerKey: "donotshowinhelp", Description:  "hidden functionality");
    }
}