using System;
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
        static string CertPath = "bundle.pfx";
        public static void Main(string[] args)
        {
            Console.WriteLine($"THis is run {0}");
            Console.WriteLine($"THis is the cert we are looking for: {CertPath}");
            Console.WriteLine($"FileExists: {File.Exists(CertPath)}");
            Console.WriteLine($"current directory: {Directory.GetCurrentDirectory()}");

            //PrintFileStructure(Directory.GetCurrentDirectory());

            CreateWebHostBuilder(args)
                .Build()
                .Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

        public static void PrintFileStructure(string directory)
        {
            var subDirectories = Directory.GetDirectories(directory).OrderBy(x => x);
            var files = Directory.GetFiles(directory).OrderBy(x => x);
            if (files.Any())
            {
                Console.WriteLine($"exploring {directory}  files: {files.Aggregate((x, y) => $"{x}{System.Environment.NewLine}{y}") }");
            }
            if (subDirectories.Any())
            {
                Console.WriteLine($"exploring {directory} directories: {subDirectories.Aggregate((x, y) => $"{x}{System.Environment.NewLine}{y}")}");
            }

            foreach (var subDir in subDirectories)
                PrintFileStructure(subDir);
        }
    }
}