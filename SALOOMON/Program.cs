﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace GatewayService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseSetting("https_port", "443") // Configure HTTPS Port
                .UseStartup<Startup>();
    }
}
