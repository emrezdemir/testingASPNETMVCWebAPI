﻿using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TestAPIUsingWebApplicationFactory.Data;
using TestAPIUsingWebApplicationFactory.Models;

namespace Products.API.Tests
{
   public class ProductTestContext : ProductDbContext
    {
        public ProductTestContext(DbContextOptions<ProductDbContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            seedData<Product>(modelBuilder, "../../../data/products.json");
        }

        private void seedData<T>(ModelBuilder modelBuilder, string file) where T:class
        {
            using (StreamReader reader = new StreamReader(file))
            {
                var json = reader.ReadToEnd();
                var data = JsonConvert.DeserializeObject<T[]>(json);
                modelBuilder.Entity<T>().HasData(data);
            }


        }
    }
}
