﻿// <auto-generated />
using System;
using JavaJournal.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JavaJournal.Migrations
{
    [DbContext(typeof(TastingEntryDbContext))]
    partial class TastingEntryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.14");

            modelBuilder.Entity("JavaJournal.Models.BeanPreset", b =>
                {
                    b.Property<uint>("BeanPresetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BeanType")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Grind")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Origin")
                        .HasColumnType("TEXT");

                    b.Property<string>("PresetName")
                        .HasColumnType("TEXT");

                    b.Property<int>("Roast")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Roastery")
                        .HasColumnType("TEXT");

                    b.HasKey("BeanPresetId");

                    b.ToTable("BeanPreset");
                });

            modelBuilder.Entity("JavaJournal.Models.Process", b =>
                {
                    b.Property<uint>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<uint?>("BeanPresetId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("BeanPresetId");

                    b.ToTable("Process");
                });

            modelBuilder.Entity("JavaJournal.Models.TastingEntry", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<uint?>("BeanPresetId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EntryDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BeanPresetId");

                    b.ToTable("TastingEntry");
                });

            modelBuilder.Entity("JavaJournal.Models.Variety", b =>
                {
                    b.Property<uint>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<uint?>("BeanPresetId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("BeanPresetId");

                    b.ToTable("Variety");
                });

            modelBuilder.Entity("JavaJournal.Models.Process", b =>
                {
                    b.HasOne("JavaJournal.Models.BeanPreset", null)
                        .WithMany("Process")
                        .HasForeignKey("BeanPresetId");
                });

            modelBuilder.Entity("JavaJournal.Models.TastingEntry", b =>
                {
                    b.HasOne("JavaJournal.Models.BeanPreset", "BeanPreset")
                        .WithMany()
                        .HasForeignKey("BeanPresetId");

                    b.Navigation("BeanPreset");
                });

            modelBuilder.Entity("JavaJournal.Models.Variety", b =>
                {
                    b.HasOne("JavaJournal.Models.BeanPreset", null)
                        .WithMany("Variety")
                        .HasForeignKey("BeanPresetId");
                });

            modelBuilder.Entity("JavaJournal.Models.BeanPreset", b =>
                {
                    b.Navigation("Process");

                    b.Navigation("Variety");
                });
#pragma warning restore 612, 618
        }
    }
}
