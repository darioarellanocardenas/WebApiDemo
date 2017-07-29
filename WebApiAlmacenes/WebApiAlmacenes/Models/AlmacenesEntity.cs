namespace WebApiAlmacenes.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AlmacenesEntity : DbContext
    {
        public AlmacenesEntity()
            : base("name=AlmacenesEntity")
        {
        }

        public virtual DbSet<Almacenes> Almacenes { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Equipos> Equipos { get; set; }
        public virtual DbSet<Marcas> Marcas { get; set; }
        public virtual DbSet<Modelos> Modelos { get; set; }
        public virtual DbSet<Proveedores> Proveedores { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Almacenes>()
                .Property(e => e.vchClave)
                .IsUnicode(false);

            modelBuilder.Entity<Almacenes>()
                .Property(e => e.vchNombre)
                .IsUnicode(false);

            modelBuilder.Entity<Almacenes>()
                .HasMany(e => e.Equipos)
                .WithRequired(e => e.Almacenes)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetRoles>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Equipos>()
                .Property(e => e.vchNoSerie)
                .IsUnicode(false);

            modelBuilder.Entity<Marcas>()
                .Property(e => e.vchNombre)
                .IsUnicode(false);

            modelBuilder.Entity<Marcas>()
                .Property(e => e.vchClave)
                .IsUnicode(false);

            modelBuilder.Entity<Marcas>()
                .HasMany(e => e.Equipos)
                .WithRequired(e => e.Marcas)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Modelos>()
                .Property(e => e.vchNombre)
                .IsUnicode(false);

            modelBuilder.Entity<Modelos>()
                .Property(e => e.vchClave)
                .IsUnicode(false);

            modelBuilder.Entity<Modelos>()
                .HasMany(e => e.Equipos)
                .WithRequired(e => e.Modelos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Proveedores>()
                .Property(e => e.vchNombre)
                .IsUnicode(false);

            modelBuilder.Entity<Proveedores>()
                .HasMany(e => e.Equipos)
                .WithRequired(e => e.Proveedores)
                .WillCascadeOnDelete(false);
        }
    }
}
