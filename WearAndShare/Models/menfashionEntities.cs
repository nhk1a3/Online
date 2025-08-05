using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WearAndShare.Models
{
    public partial class menfashionEntities : DbContext
    {
        public menfashionEntities()
            : base("name=menfashionEntities1")
        {
        }

        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Invoince> Invoinces { get; set; }
        public virtual DbSet<InvoinceDetail> InvoinceDetails { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Slide> Slides { get; set; }
        public virtual DbSet<vDoanhThuTheoNgay> vDoanhThuTheoNgays { get; set; }
        public virtual DbSet<vHoaDonTrongNgay> vHoaDonTrongNgays { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>()
                .Property(e => e.userName)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<Invoince>()
                .Property(e => e.invoinceNo)
                .IsUnicode(false);

            modelBuilder.Entity<Invoince>()
                .Property(e => e.userName)
                .IsUnicode(false);

            modelBuilder.Entity<Invoince>()
                .HasMany(e => e.InvoinceDetails)
                .WithRequired(e => e.Invoince)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InvoinceDetail>()
                .Property(e => e.invoinceNo)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.userName)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.identityNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.Articles)
                .WithRequired(e => e.Member)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Member)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.image)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.userName)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.InvoinceDetails)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductCategory>()
                .HasMany(e => e.Articles)
                .WithRequired(e => e.ProductCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductCategory>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.ProductCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Members)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Slide>()
                .Property(e => e.url)
                .IsUnicode(false);

            modelBuilder.Entity<vDoanhThuTheoNgay>()
                .Property(e => e.dateOrder)
                .IsUnicode(false);

            modelBuilder.Entity<vHoaDonTrongNgay>()
                .Property(e => e.invoinceNo)
                .IsUnicode(false);

            modelBuilder.Entity<vHoaDonTrongNgay>()
                .Property(e => e.userName)
                .IsUnicode(false);

        }
    }
}
