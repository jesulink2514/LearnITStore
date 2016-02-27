using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(LearnITStore.WebUI.Startup))]

namespace LearnITStore.WebUI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Auth.Configure(app);
        }
    }
}
