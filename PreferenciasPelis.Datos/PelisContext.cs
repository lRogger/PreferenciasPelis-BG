using System.Data;
using Microsoft.EntityFrameworkCore;
using PreferenciaPeli.Entidades;

namespace PreferenciaPeli.Datos
{
    public partial class PelisContext : DbContext
    {
        public PelisContext() { }

        public PelisContext(DbContextOptions<PelisContext> options) : base(options)
        {
            
        }

        public virtual DbSet<CategoriaPeli> CategoriasPelis { get; set; }
        public virtual DbSet<Peli> Pelis { get; set; }
        public virtual DbSet<PelisRecomendadas> PelisRecomendadas { get; set; }
        public virtual DbSet<PreferenciaUsuario> PreferenciaUsuarios { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Name=Pelis");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoriaPeli>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("pk_CategoriaPelicula");
                entity.ToTable("CategoriaPelicula");
                entity.Property(e => e.Descripcion).HasMaxLength(60).IsUnicode(false);

            });

            modelBuilder.Entity<Peli>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("pk_Pelicula");
                entity.ToTable("Pelicula");
                entity.Property(e => e.Nombre).HasMaxLength(150).IsUnicode(false);
            });

            modelBuilder.Entity<PelisRecomendadas>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("pk_PelisRecomendadas");
                entity.ToTable("PelisRecomendadas");
                entity.HasOne(d => d.IdCategoriaPeliNav).WithMany(p => p.PelisRecomendadas)
                .HasForeignKey(d => d.IdCategoriaPeli).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("pk_PelisRecomendadas_CategoriaPelicula");
                
                entity.HasOne(d => d.IdPeliNav).WithMany(p => p.PelisRecomendadas)
                .HasForeignKey(d => d.IdPelicula).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("pk_PelisRecomendadas_Pelicula");
            });

            modelBuilder.Entity<PreferenciaUsuario>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("pk_PreferenciaUsuario");
                entity.ToTable("PreferenciaUsuario");
                entity.HasOne(d => d.IdCategoriaPeliNav).WithMany(p => p.PreferenciaUsuarios)
                .HasForeignKey(d => d.IdCategoriaPeli).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_PreferenciaUsuario_CategoriaPelicula");

                entity.HasOne(d => d.IdUserNav).WithMany(p => p.PreferenciaUsuarios)
                .HasForeignKey(d => d.IdUsuario).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_PreferenciaUsuario_Usuario");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("pk_User");
                entity.ToTable("User");
                entity.HasIndex(e => e.Nombre, "un_usuario").IsUnique();
                entity.Property(e => e.Pwd).HasMaxLength(30).IsUnicode(false);
                entity.Property(e => e.Nombre).HasMaxLength(20).IsUnicode(false);
            });

            modelBuilder.Entity<UserRegistradoDS>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<TextoDesplegableDS>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<PeliDS>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<UsertInDS>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<DataSet>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<DataTable>(entity =>
            {
                entity.HasNoKey();
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    
    }

    
}
