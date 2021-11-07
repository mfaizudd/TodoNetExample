using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TodoNetExample.Models;

namespace TodoNetExample.Data
{
    public class TodoContext : IdentityDbContext<User>
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        { }

        public DbSet<TodoList> TodoLists { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>()
                .HasData(new [] {
                    new IdentityRole 
                    {
                        Id = "2ec3739c-0f45-4357-b178-7f797858d10f",
                        Name = "Admin",
                        NormalizedName = "ADMIN"
                    },
                    new IdentityRole
                    {
                        Id = "153109d6-ef68-46c3-a8ef-491a85c55bfa",
                        Name = "User",
                        NormalizedName = "USER"
                    }
                });

            var hasher = new PasswordHasher<User>();
            var admin = new User
            {
                Id = "681d0641-bed3-452b-bdfe-cb65572a8e59",
                Name = "Faizud",
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true
            };
            admin.PasswordHash = hasher.HashPassword(admin, "Test123!");
            builder.Entity<User>()
                .HasData(admin);
            
            builder.Entity<IdentityUserRole<string>>()
                .HasData(new IdentityUserRole<string>
                {
                    RoleId = "2ec3739c-0f45-4357-b178-7f797858d10f",
                    UserId = "681d0641-bed3-452b-bdfe-cb65572a8e59"
                });
        }

    }
}