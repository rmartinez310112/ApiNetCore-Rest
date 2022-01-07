﻿// <auto-generated />
using System;
using ApiTrueHome.Persistencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ApiTrueHome.Migrations
{
    [DbContext(typeof(ContextoProperty))]
    partial class ContextoPropertyModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("ApiTrueHome.Modelo.Activity", b =>
                {
                    b.Property<int>("activity_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("activityGuid")
                        .HasColumnType("text");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("property_id")
                        .HasColumnType("integer");

                    b.Property<int?>("property_id1")
                        .HasColumnType("integer");

                    b.Property<DateTime>("schedule")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("status")
                        .HasColumnType("text");

                    b.Property<string>("title")
                        .HasColumnType("text");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("activity_id");

                    b.HasIndex("property_id1");

                    b.ToTable("Activity");
                });

            modelBuilder.Entity("ApiTrueHome.Modelo.Property", b =>
                {
                    b.Property<int>("property_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("address")
                        .HasColumnType("text");

                    b.Property<DateTime>("create_at")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("description")
                        .HasColumnType("text");

                    b.Property<DateTime?>("disabled_at")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("propertyGuid")
                        .HasColumnType("text");

                    b.Property<string>("status")
                        .HasColumnType("text");

                    b.Property<string>("title")
                        .HasColumnType("text");

                    b.Property<DateTime?>("updated_at")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("property_id");

                    b.ToTable("Property");
                });

            modelBuilder.Entity("ApiTrueHome.Modelo.Survey", b =>
                {
                    b.Property<int>("survey_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("activity_id")
                        .HasColumnType("integer");

                    b.Property<int?>("activity_id1")
                        .HasColumnType("integer");

                    b.Property<string>("answer")
                        .HasColumnType("text");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("surveyGuid")
                        .HasColumnType("text");

                    b.HasKey("survey_id");

                    b.HasIndex("activity_id1");

                    b.ToTable("Survey");
                });

            modelBuilder.Entity("ApiTrueHome.Modelo.Activity", b =>
                {
                    b.HasOne("ApiTrueHome.Modelo.Property", "property")
                        .WithMany()
                        .HasForeignKey("property_id1");

                    b.Navigation("property");
                });

            modelBuilder.Entity("ApiTrueHome.Modelo.Survey", b =>
                {
                    b.HasOne("ApiTrueHome.Modelo.Activity", "activity")
                        .WithMany()
                        .HasForeignKey("activity_id1");

                    b.Navigation("activity");
                });
#pragma warning restore 612, 618
        }
    }
}
