using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace MappedBranches
{
    public class Startup
    {
        private static void HandleBranch1(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Branch 1.");
            });
        }

        private static void HandleBranch2(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Branch 2.");
            });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.Map("/mappedBranch1", HandleBranch1);

            app.Map("/mappedBranch2", HandleBranch2);

            app.Run(async context =>
            {
                await context.Response.WriteAsync("Terminating Run() method.");
            });
        }
    }
}
