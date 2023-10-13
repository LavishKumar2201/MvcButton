using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcButton.Data;
using System;
using System.Linq;

namespace MvcButton.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcButtonContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcButtonContext>>()))
            {
                // Look for any Button.
                if (context.Button.Any())
                {
                    return;   // DB has been seeded
                }

                context.Button.AddRange(
                    new Button
                    {
                   
                        Brand = "Gucci",
                        Colour = "Green",
                        Shape = "Circle",
                        Price = 132.7M
                    },

                    new Button
                    {
                     
                        Brand = "Tommy",
                        Colour = "Red",
                        Shape = "Square",
                        Price = 115.6M
                    },

                    new Button
                    {
                  
                        Brand = "Burberry",
                        Colour = "Yellow",
                        Shape = "Circle",
                        Price = 162.45M
                    },

                    new Button
                    {
                        
                        Brand = "Hollister",
                        Colour = "White",
                        Shape = "Heart",
                        Price = 72.6M
                    },

                     new Button
                     {
                    
                         Brand = "Puma",
                         Colour = "Black",
                         Shape = "Circle",
                         Price = 98.9M
                     },

                      new Button
                      {
                     
                          Brand = "Nike",
                          Colour = "Blue",
                          Shape = "Square",
                          Price = 112.2M
                      },

                       new Button
                       {
                      
                           Brand = "Addidas",
                           Colour = "Grey",
                           Shape = "Circle",
                           Price = 109.2M
                       },

                        new Button
                        {
                  
                            Brand = "Disel",
                            Colour = "Black",
                            Shape = "Circle",
                            Price = 72.4M
                        },
                        new Button
                        {
                         
                            Brand = "Old Navy",
                            Colour = "Grey",
                            Shape = "Circle",
                            Price = 72.9M
                        },

                        new Button
                        {
                         
                            Brand = "Jockey",
                            Colour = "Blue",
                            Shape = "Heart",
                            Price = 72.9M
                        }



                );
                context.SaveChanges();
            }
        }
    }
}