using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using ppedv.UniversalBookManager.Domain;

namespace ppedv.UniversalBookManager.Data.EF
{
    public class EFContext : DbContext // Konfiguration für das EF
    {
        // "Update" auf 6.2 ;)

        // Für TN: (Richtige SQL-DB)
        // "Server=.;Database=UBM;Trusted_Connection=true"

        // Trainerrechner: SQL-Express Edition (minimaler SQL-Server auf LocalDB-Basis)
        public EFContext() : this(@"Server=(localdb)\MSSQLLocalDB;Database=UBM;Trusted_Connection=true;AttachDbFilename=C:\temp\UBM.mdf") { }
        public EFContext(string connectionString) : base(connectionString) { } // Parameter aus dem eigenen Konstruktor wird an den Konstruktor der Basisklasse weitergegeben

        public DbSet<Book> Book { get; set; }
        public DbSet<Store> Store { get; set; }
        public DbSet<Inventory> Inventory { get; set; }

        // Konfiguration:
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Inventory>()
                        .HasRequired<Book>(x => x.Book)
                        .WithMany()
                        .WillCascadeOnDelete();
        }
    }
}
