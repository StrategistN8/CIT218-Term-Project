using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AbyssRunSite.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AbyssRunSite.DataAccessLayer
{
    public class AbyssContext : DbContext
    {
        public AbyssContext() : base("DefaultConnection") // Formerly AbyssContext
        {

        }

        public DbSet<EnemyModel> Enemies { get; set; }
        public DbSet<LevelModel> Levels { get; set; }
        public DbSet<ItemModel> Items { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
  