﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;


namespace ASP_CRUD
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string connString =
               JObject.Parse(File.ReadAllText("appsettings.Development.json"))["ConnectionString"]["DefaultConnection"].ToString();

            ShoppingCartItemRepository.connectionString = connString;
            LocationRepository.connectionString = connString;



            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
