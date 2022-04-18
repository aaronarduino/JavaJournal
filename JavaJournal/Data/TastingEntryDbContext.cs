using System;
using JavaJournal.Models;
using Microsoft.EntityFrameworkCore;

namespace JavaJournal.Data
{
    public class TastingEntryDbContext: DbContext
    {
        public TastingEntryDbContext(DbContextOptions<TastingEntryDbContext> options)
            : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<TastingEntryModel>()
        //        .HasOne<BeanPresetModel>(s => s.BeanPreset)
        //        .WithMany(g => g.TastingEntries)
        //        .HasForeignKey(s => s.BeanPresetID);
        //}

        public DbSet<JavaJournal.Models.TastingEntry> TastingEntry { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<TastingEntryModel>()
        //        .HasOne<BeanPresetModel>(s => s.BeanPreset)
        //        .WithMany(g => g.TastingEntries)
        //        .HasForeignKey(s => s.BeanPresetID);
        //}

        public DbSet<JavaJournal.Models.BeanPreset> BeanPreset { get; set; }
    }
}
