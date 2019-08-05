﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Autofac;
using CommonCore.IOC;
using CommonCore.Repo.Repository;
using CommonCore.Services.Interfaces;
using DatingApp.API.Services;
using DatingAppCore.BLL.Services;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DatingAppCore.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var currentDirectory = Directory.GetCurrentDirectory();

            Console.WriteLine($"current directory: {currentDirectory} : certExists: {File.Exists(Path.Combine(currentDirectory, "cert.pfx"))}");

            CreateWebHostBuilder(args)
                .Build()
                .Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureKestrel((context, options) =>
                {
                    options.Listen(IPAddress.Loopback, 5001, listenOptions =>
                    {
                        listenOptions.UseHttps(Path.Combine(Directory.GetCurrentDirectory(), "cert.pfx"), "Matty30!");
                    });
                })
                .UseStartup<Startup>();
    }
}