﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApiAngular.Models
{
    public partial class Fualumni_demoContext : DbContext
    {
        public Fualumni_demoContext()
        {
        }

        public Fualumni_demoContext(DbContextOptions<Fualumni_demoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Notification> Notifications { get; set; } = null!;
        public virtual DbSet<Post> Posts { get; set; } = null!;
        public virtual DbSet<Tag> Tags { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                Console.WriteLine(Directory.GetCurrentDirectory());
                IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
                var strConn = config["ConnectionStrings:MyDatabase"];
                optionsBuilder.UseSqlServer(strConn);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Notification>(entity =>
            {
                entity.ToTable("Notification");

                entity.Property(e => e.NotificationId).HasColumnName("NotificationID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Message)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PostId).HasColumnName("PostID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("FK__Notificat__PostI__412EB0B6");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Notificat__UserI__403A8C7D");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("Post");

                entity.HasIndex(e => e.ImageName, "UQ__Post__F92C660077BA96D0")
                    .IsUnique();

                entity.Property(e => e.PostId).HasColumnName("PostID");

                entity.Property(e => e.Content).HasColumnType("text");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ImageName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Post__UserID__3C69FB99");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.ToTable("Tag");

                entity.HasIndex(e => new { e.UserId, e.PostId }, "UQ__Tag__8D29EAAE47299928")
                    .IsUnique();

                entity.Property(e => e.TagId).HasColumnName("TagID");

                entity.Property(e => e.PostId).HasColumnName("PostID");

                entity.Property(e => e.TaggedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Tags)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("FK__Tag__PostID__46E78A0C");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Tags)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Tag__UserID__45F365D3");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasIndex(e => e.Email, "UQ__User__A9D105341B3001FD")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StudentNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}