﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SpringBlog.Models
{
    // ApplicationUser sınıfınıza daha fazla özellik ekleyerek kullanıcıya profil verileri ekleyebilirsiniz. Daha fazla bilgi için lütfen https://go.microsoft.com/fwlink/?LinkID=317594 adresini ziyaret edin.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // authenticationType özelliğinin CookieAuthenticationOptions.AuthenticationType içinde tanımlanmış olanla eşleşmesi gerektiğini unutmayın
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Özel kullanıcı taleplerini buraya ekle
            userIdentity.AddClaim(new Claim("DisplayName", DisplayName));
            return userIdentity;
        }

        [Required]
        [MaxLength(30)]
        public string DisplayName { get; set; }
        [MaxLength(100)]
        public string ProfilePhoto { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("ApplicationDbContext", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasRequired(x => x.Category)
                .WithMany(x => x.Posts)
                .HasForeignKey(x => x.CategoryId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Comment>()
                 .HasRequired(x => x.Author)
                 .WithMany(x => x.Comments)
                 .HasForeignKey(x => x.AuthorId)
                 .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}