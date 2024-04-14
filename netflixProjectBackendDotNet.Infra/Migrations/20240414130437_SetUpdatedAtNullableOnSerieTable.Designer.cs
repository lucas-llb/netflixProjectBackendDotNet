﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using netflixProjectBackendDotNet.Infra.Context;

#nullable disable

namespace netflixProjectBackendDotNet.Infra.Migrations
{
    [DbContext(typeof(ContextDB))]
    [Migration("20240414130437_SetUpdatedAtNullableOnSerieTable")]
    partial class SetUpdatedAtNullableOnSerieTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("netflixProjectBackendDotNet.Domain.Entities.Category.CategoryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("character varying(70)");

                    b.Property<int>("Position")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Categories", (string)null);
                });

            modelBuilder.Entity("netflixProjectBackendDotNet.Domain.Entities.Episode.EpisodeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<int>("Order")
                        .HasColumnType("integer");

                    b.Property<int>("SecondsLong")
                        .HasColumnType("integer");

                    b.Property<int>("SerieId")
                        .HasColumnType("integer");

                    b.Property<string>("Synopsis")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)");

                    b.Property<string>("ThumbnailUrl")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<DateTime?>("UpdateAt")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("VideoUrl")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("Id");

                    b.HasIndex("SerieId");

                    b.ToTable("Episodes", (string)null);
                });

            modelBuilder.Entity("netflixProjectBackendDotNet.Domain.Entities.Favorite.FavoriteEntity", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("SerieId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("UserId", "SerieId");

                    b.HasIndex("SerieId");

                    b.ToTable("Favorites", (string)null);
                });

            modelBuilder.Entity("netflixProjectBackendDotNet.Domain.Entities.Like.LikeEntity", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("SerieId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("UserId", "SerieId");

                    b.HasIndex("SerieId");

                    b.ToTable("Likes", (string)null);
                });

            modelBuilder.Entity("netflixProjectBackendDotNet.Domain.Entities.Serie.SerieEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<bool>("Featured")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("character varying(70)");

                    b.Property<string>("Synopsis")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<string>("ThumbnailUrl")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("character varying(70)");

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Series", (string)null);
                });

            modelBuilder.Entity("netflixProjectBackendDotNet.Domain.Entities.User.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Birth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("character varying(70)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("netflixProjectBackendDotNet.Domain.Entities.WatchTime.WatchTimeEntity", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("EpisodeId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("SecondsLong")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("UserId", "EpisodeId");

                    b.HasIndex("EpisodeId");

                    b.ToTable("WatchTimes", (string)null);
                });

            modelBuilder.Entity("netflixProjectBackendDotNet.Domain.Entities.Episode.EpisodeEntity", b =>
                {
                    b.HasOne("netflixProjectBackendDotNet.Domain.Entities.Serie.SerieEntity", "Serie")
                        .WithMany()
                        .HasForeignKey("SerieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Serie");
                });

            modelBuilder.Entity("netflixProjectBackendDotNet.Domain.Entities.Favorite.FavoriteEntity", b =>
                {
                    b.HasOne("netflixProjectBackendDotNet.Domain.Entities.Serie.SerieEntity", "Serie")
                        .WithMany()
                        .HasForeignKey("SerieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("netflixProjectBackendDotNet.Domain.Entities.User.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Serie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("netflixProjectBackendDotNet.Domain.Entities.Like.LikeEntity", b =>
                {
                    b.HasOne("netflixProjectBackendDotNet.Domain.Entities.Serie.SerieEntity", "Serie")
                        .WithMany()
                        .HasForeignKey("SerieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("netflixProjectBackendDotNet.Domain.Entities.User.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Serie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("netflixProjectBackendDotNet.Domain.Entities.Serie.SerieEntity", b =>
                {
                    b.HasOne("netflixProjectBackendDotNet.Domain.Entities.Category.CategoryEntity", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("netflixProjectBackendDotNet.Domain.Entities.WatchTime.WatchTimeEntity", b =>
                {
                    b.HasOne("netflixProjectBackendDotNet.Domain.Entities.Episode.EpisodeEntity", "Episode")
                        .WithMany()
                        .HasForeignKey("EpisodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("netflixProjectBackendDotNet.Domain.Entities.User.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Episode");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
