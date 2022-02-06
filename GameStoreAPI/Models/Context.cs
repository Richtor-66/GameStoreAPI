using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API;

namespace GameStoreAPI.Models
{
    public class Context: DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) 
        {
        }

        public DbSet<GameStore> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Genre>()
                .HasOne(x => x.gameStore)
                .WithMany(x => x.ListGenre)
                .HasForeignKey(x => x.GameStoreGuid);
        }
    }
}
