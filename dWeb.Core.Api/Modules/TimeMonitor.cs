using Nancy;

namespace dWeb.Core.Api.Modules
{
    public class TimeMonitor : NancyModule
    {
        public TimeMonitor()
        {
            Get["/Up"] = _ => "Hello!";

            Get["/Down"] = _ => "Down!";
        }
    }
}