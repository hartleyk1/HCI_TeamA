using HCI_Alpha.Models;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HCI_Alpha.Services
{
    public class RestaurantsDbContext : DbContext
    {
        public RestaurantsDbContext(DbContextOptions<RestaurantsDbContext> options) : base(options)
        {
        }

        public DbSet<cities> Cities { get; set; }
        public DbSet<covid19> Covid19 { get; set; }
        public DbSet<cuisines> Cuisines { get; set; }
        public DbSet<restaurants> Restaurants { get; set; }
        public DbSet<reviews> Reviews { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
   
}
