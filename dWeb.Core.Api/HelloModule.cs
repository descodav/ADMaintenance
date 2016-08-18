using Nancy;

namespace dWeb.Core.Api
{
    public class HelloModule : NancyModule
    {
        public HelloModule()
        {
            Get["/"] = _ => "Hello World!";
        }
    }
}