using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using muvekkil_dava.Models;

namespace muvekkil_dava.Data
{
    public class VeritabaniContext : DbContext
    {
        public VeritabaniContext(DbContextOptions<VeritabaniContext> options) : base(options)
        {
        }

        public DbSet<Muvekkil> Muvekkiller { get; set; }
        public DbSet<Dava> Davalar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // İlişkileri burada özelleştirebilirsin (isteğe bağlı)
            modelBuilder.Entity<Dava>()
                .HasOne(d => d.Muvekkil)
                .WithMany()
                .HasForeignKey(d => d.MuvekkilId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
