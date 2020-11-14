using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MyApp.Helper
{
    public static class DataSeeder
    {
        public static async Task SeedSomeData(this IApplicationBuilder app)
        {
            try
            {
                using var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                await context.Database.MigrateAsync();
                await context.Database.EnsureCreatedAsync();

                var articles = GetArticles();

                foreach (var item in articles)
                {
                    var exist = await context.Articles.AnyAsync(a => a.Title.ToLower() == item.Title.ToLower());

                    if (exist)
                    {
                        continue;
                    }

                    await context.Articles.AddAsync(item);
                }

                await context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                var logger = app.ApplicationServices.GetRequiredService<ILogger<AppDbContext>>();
                logger.LogError(ex, "An error occurred seeding data to the DB.");

            }
        }

        private static List<Article> GetArticles()
        {
            return new List<Article>()
            {
                new Article
                {
                    Title  = "My First Article",
                    Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
                },
                new Article
                {
                    Title  = "My Second Article",
                    Body = "Purus faucibus ornare suspendisse sed nisi lacus sed viverra. Morbi tempus iaculis urna id volutpat. Vitae tempus quam pellentesque nec nam aliquam sem et tortor. Aliquam eleifend mi in nulla posuere. Feugiat sed lectus vestibulum mattis ullamcorper velit. Sed id semper risus in. Habitant morbi tristique senectus et."
                },
                new Article
                {
                    Title  = "My Third Article",
                    Body = "Arcu dui vivamus arcu felis bibendum. Blandit aliquam etiam erat velit scelerisque in dictum non. Elit sed vulputate mi sit amet mauris. In dictum non consectetur a. Volutpat diam ut venenatis tellus in metus. Mollis aliquam ut porttitor leo a diam sollicitudin tempor id. Id velit ut tortor pretium viverra suspendisse potenti"
                },
                new Article
                {
                    Title  = "My Fourth Article",
                    Body = "Sagittis eu volutpat odio facilisis mauris sit. Placerat duis ultricies lacus sed turpis tincidunt id aliquet risus. Volutpat blandit aliquam etiam erat. Dignissim diam quis enim lobortis scelerisque. Metus dictum at tempor commodo ullamcorper. Gravida dictum fusce ut placerat orci nulla pellentesque dignissim enim. Sed risus ultricies tristique nulla. Fringilla ut morbi tincidunt augue interdum velit. Ut etiam sit amet nisl purus in mollis nunc"
                },
                new Article
                {
                    Title  = "My Fifth Article",
                    Body = "Fringilla phasellus faucibus scelerisque eleifend donec pretium. Non sodales neque sodales ut. In dictum non consectetur a erat nam at lectus urna. Facilisis leo vel fringilla est. Lorem ipsum dolor sit amet consectetur adipiscing elit. Faucibus ornare suspendisse sed nisi lacus sed viverra. Viverra suspendisse"
                },
                new Article
                {
                    Title  = "My Sixth Article",
                    Body = "Tempor orci eu lobortis elementum nibh tellus molestie nunc non. Commodo odio aenean sed adipiscing diam donec. Malesuada pellentesque elit eget gravida cum sociis. Porttitor massa id neque aliquam vestibulum morbi blandit cursus. Sollicitudin tempor id eu nisl nunc mi ipsum faucibus. Sed id semper risus in hendrerit. Scelerisque in dictum non consectetur a "
                },
                new Article
                {
                    Title  = "My Seventh Article",
                    Body = "Arcu dui vivamus arcu felis bibendum. Blandit aliquam etiam erat velit scelerisque in dictum non. Elit sed vulputate mi sit amet mauris. In dictum non consectetur a. Volutpat diam ut venenatis tellus in metus. Mollis aliquam ut porttitor leo a diam sollicitudin tempor id. Id velit ut tortor pretium viverra suspendisse potenti"
                },
                new Article
                {
                    Title  = "My Eight Article",
                    Body = "Elementum eu facilisis sed odio morbi. Elementum nisi quis eleifend quam adipiscing vitae proin sagittis. Ac turpis egestas integer eget aliquet nibh. At lectus urna duis convallis convallis tellus id interdum. Vitae tempus quam pellentesque nec. Vestibulum sed arcu non odio euismod lacinia at quis risus. "
                },
            };
        }






    }
}
