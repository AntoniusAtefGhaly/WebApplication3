using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApplication3
{
    public class Program
    {
        const string baseURL = "http://localhost:8000";
        public static async Task Main(string[] args)
        {
            using(var httpClient=new HttpClient())
            {
                swaggerClient restClient = new swaggerClient(baseURL, httpClient);
                //get all product
                var products=await restClient.CatalogAllAsync();
                foreach(var product in products)
                {
                    Console.WriteLine(product.Id+"  "+
                        product.Name + "  "+
                        product.Price + "  ");
                }
                //post product
                try
                {
                    var newProduct = await restClient.CatalogAsync(
                        new Product
                        {
                            Name = "product 1",
                            Price = 500,
                            Category = "clothes",
                            Description = "aaaaa"
                        });

                   
                }
                catch 
                {

                }
            }

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
