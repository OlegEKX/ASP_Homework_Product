using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace ASP_Homework_Product
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseSerilog((hostingContext, loggerConfiguration) =>
            {
                loggerConfiguration
                    .ReadFrom.Configuration(hostingContext.Configuration) // ������������ ������� ����� ��������� � ������������� ���������� (appsettings.json)
                    .Enrich.FromLogContext() // ���������� � ���� ����� ��������� �� ������-�� ���������
                    .Enrich.WithProperty("ApplicationName", "ASP_Homework_Product"); // � ������ ��� ����� ����������� ���������� � ���, ��� ��� �� ����������
            })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
