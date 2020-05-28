﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using My_Bees_Diary.Services;

namespace MyBeesDiary.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4");

            modelBuilder.Entity("My_Bees_Diary.Models.Entities.Apiary", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Location")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Number")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Production")
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Apiaries");
                });

            modelBuilder.Entity("My_Bees_Diary.Models.Entities.AreaPlants", b =>
                {
                    b.Property<int>("PlantsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ApiaryID")
                        .HasColumnType("INTEGER");

                    b.HasKey("PlantsID");

                    b.HasIndex("ApiaryID")
                        .IsUnique();

                    b.ToTable("AreaPlants");
                });

            modelBuilder.Entity("My_Bees_Diary.Models.Entities.Beehive", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ApiaryID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Feedings")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Number")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Power")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Production")
                        .HasColumnType("TEXT");

                    b.Property<int>("Reviews")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Stores")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Treatments")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TypeBeehive")
                        .HasColumnType("TEXT");

                    b.Property<string>("TypeBees")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("ApiaryID");

                    b.ToTable("Beehives");
                });

            modelBuilder.Entity("My_Bees_Diary.Models.Entities.Notes", b =>
            {
                b.Property<int>("ID")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("INTEGER");

                b.Property<string>("Summary")
                    .HasColumnType("TEXT");

                b.Property<string>("Description")
                    .HasColumnType("TEXT");

                b.Property<DateTime>("Date")
                    .HasColumnType("DATETIME");

                b.HasKey("ID");

                b.ToTable("Notes");
            });


            modelBuilder.Entity("My_Bees_Diary.Models.Entities.Plant", b =>
                {
                    b.Property<string>("PlantName")
                        .HasColumnType("TEXT");

                    b.ToTable("Plant");
                });

            modelBuilder.Entity("My_Bees_Diary.Models.Entities.AreaPlants", b =>
                {
                    b.HasOne("My_Bees_Diary.Models.Entities.Apiary", "Apiary")
                        .WithOne("PlantsInArea")
                        .HasForeignKey("My_Bees_Diary.Models.Entities.AreaPlants", "ApiaryID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("My_Bees_Diary.Models.Entities.Beehive", b =>
                {
                    b.HasOne("My_Bees_Diary.Models.Entities.Apiary", "Apiary")
                        .WithMany("Beehives")
                        .HasForeignKey("ApiaryID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
