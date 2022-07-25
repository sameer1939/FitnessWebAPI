﻿using FitnessWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessWebAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<ShortArticle> ShortArticles { get; set; }
    }
}
