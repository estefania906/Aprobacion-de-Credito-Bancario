using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace ModeloDB
{
   
    public class ModeloDB : DbContext
    {
        public ModeloDB()
        {

        }

        public ModeloDB(DbContextOptions options)
            : base(options)
        {

        }

        // Se asegura el borrado y la creación de la base de datos
        public void PreparaDB()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        public DbSet<Cliente> cliente { get; set; }
        public DbSet<Cliente_Det> cliente_det { get; set; }
        public DbSet<VigenciaTasaAnual> vigencia { get; set; }
        public DbSet<Configuracion> configuracion { get; set; }
        public DbSet<Credito> credito { get; set; }
        public DbSet<Costo_Cuota> costo_cuota { get; set; }
        public DbSet<Garante> garante { get; set; }
        public DbSet<Garante_Det> garante_det { get; set; }
        public DbSet<Validaciones> validaciones { get; set; }
        public DbSet<Historial_Cliente> historial_cliente { get; set; }
        public DbSet<Historial_Garante> historial_garante { get; set; }
        
       override protected void OnConfiguring(DbContextOptionsBuilder options)

        {

            if (!options.IsConfigured)
            {

                options.UseSqlServer("Server = ACER\\MSSQLSERVER2; initial catalog= Credito ; trusted_connection=true;");
            }
        }
       
        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Cliente_Det 1 : n
            modelBuilder.Entity<Cliente_Det>()
                .HasOne(cliente_det => cliente_det.Cliente)
                .WithMany(cliente => cliente.Cliente_Det)
                .HasForeignKey(cliente_det => cliente_det.ClienteId);

            // Historial Cliente 1 : n
            modelBuilder.Entity<Historial_Cliente>()
                .HasOne(historial_cliente => historial_cliente.Cliente)
                .WithMany(cliente => cliente.Historial_Cliente)
                .HasForeignKey(historial_cliente => historial_cliente.ClienteId);

            // Cliente 1 : 1 
            modelBuilder.Entity<Cliente>()
                .HasOne(cliente => cliente.Garante)
                .WithOne(garante => garante.Cliente)
                .HasForeignKey<Cliente>(cliente => cliente.GaranteId);

            // Garante Det 1 : n 
            modelBuilder.Entity<Garante_Det>()
                .HasOne(garante_det => garante_det.Garante)
                .WithMany(garante => garante.Garante_Det)
                .HasForeignKey(garante_det => garante_det.GaranteId);


            // Historial Garante 1 : n
            modelBuilder.Entity<Historial_Garante>()
                .HasOne(historial_garante => historial_garante.Garante)
                .WithMany(garante => garante.Historial_Garante)
                .HasForeignKey(historial_garante => historial_garante.GaranteId);

            // Costo Cuota
            modelBuilder.Entity<Costo_Cuota>()
                .HasOne(costo_cuota => costo_cuota.Cliente)
                .WithMany(cliente => cliente.Costo_Cuota)
                .HasForeignKey(costo_cuota => costo_cuota.ClienteId);

            // Costo Cuota
            modelBuilder.Entity<Costo_Cuota>()
                .HasOne(costo_cuota => costo_cuota.VigenciaTasaAnual)
                .WithMany(vigencia => vigencia.Costo_Cuota)
                .HasForeignKey(costo_cuota => costo_cuota.VigenciaTasaAnualId);

            // Validaciones
            modelBuilder.Entity<Validaciones>()
                .HasOne(validaciones => validaciones.Cliente)
                .WithMany(cliente => cliente.Validaciones)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(validaciones => validaciones.ClienteId);

            // Validaciones
            modelBuilder.Entity<Validaciones>()
                .HasOne(validaciones => validaciones.Garante)
                .WithMany(garante => garante.Validaciones)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(validaciones => validaciones.GaranteId);

            // Validaciones
            modelBuilder.Entity<Validaciones>()
                .HasOne(validaciones => validaciones.Historial_Cliente)
                .WithMany(historial_cliente => historial_cliente.Validaciones)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(validaciones => validaciones.HistorialClienteId);

            // Validaciones
            modelBuilder.Entity<Validaciones>()
                .HasOne(validaciones => validaciones.Historial_Garante)
                .WithMany(historial_garante => historial_garante.Validaciones)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(validaciones => validaciones.HistorialGaranteId);

            //Configuracion
            modelBuilder.Entity<Configuracion>()
               .HasKey(configuracion => configuracion.BancoNombre);

            //Credito
            modelBuilder.Entity<Credito>()
                           .HasKey(credito => new { credito.ClienteId, credito.Costo_CuotaId});

            modelBuilder.Entity<Credito>()
                .HasOne(credito => credito.Cliente)
                .WithMany(cliente => cliente.Credito)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(credito => credito.ClienteId);

            modelBuilder.Entity<Credito>()
                .HasOne(credito => credito.Costo_Cuota)
                .WithMany(costo_cuota => costo_cuota.Credito)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(credito => credito.Costo_CuotaId);


        }

    }
}
