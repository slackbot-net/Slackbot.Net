using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Slackbot.Net.Endpoints.Middlewares;

namespace Slackbot.Net.Endpoints.Hosting
{
    public static class IAppBuilderExtensions
    {
        public static IApplicationBuilder UseSlackbot(this IApplicationBuilder app, string path = "/events")
        {
            app.MapWhen(c => IsSlackRequest(c, path), a =>
            {
                a.UseMiddleware<HttpItemsManager>();
                a.MapWhen(Challenge.ShouldRun, b => b.UseMiddleware<Challenge>());
                a.MapWhen(Uninstall.ShouldRun, b => b.UseMiddleware<Uninstall>());
                a.MapWhen(AppMentionEvents.ShouldRun, b => b.UseMiddleware<AppMentionEvents>());
                a.MapWhen(MemberJoinedEvents.ShouldRun, b => b.UseMiddleware<MemberJoinedEvents>());
                a.MapWhen(ViewSubmissionEvents.ShouldRun, b => b.UseMiddleware<ViewSubmissionEvents>());
            });
   
            return app;
        }

        private static bool IsSlackRequest(HttpContext ctx, string path)
        {
            return ctx.Request.Path == path && ctx.Request.Method == "POST";
        }
    }
}