using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using ServeurPandora.Models;
using Microsoft.Data.Entity.Infrastructure;
using ServeurPandora.ModelVersionPro;

namespace ServeurPandora.Models
{
    public class DataModel: DbContext
    {
       
        public DbSet<profile> Profiles { get; set; }
        public DbSet<Acces> Acces { get; set;}
        public DbSet<HistoriqueCompte> HisotirqueCOmpte { set; get; }
        public DbSet<HistoriqueAcces> HisotirqueAcces { set; get; }
        public DbSet<User> Users { set; get; }
        public DbSet<ProfilePro> ProfilesPro { get; set; }
        public DbSet<AccesPro> AccesPro { get; set; }
        public DbSet<HistoriqueComptePro> HisotirqueComptePro { set; get; }
        public DbSet<HistoriqueAccesPro> HisotirqueAccesPro { set; get; }
        public DataModel()
        : base() { }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server = (localdb)\MSSQLLocalDB;Database=pandor; Trusted_Connection = True;MultipleActiveResultSets=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Acces>()
                .HasOne(p => p.Profile)
                .WithMany(b => b.acces)
                .HasForeignKey(p => p.IDProfile)
                .HasConstraintName("ForeignKey_profile_Acces");

            modelBuilder.Entity<HistoriqueCompte>()
                .HasOne(m=>m.Profile)
                .WithMany(l=>l.HistoriqueCompte)
                .HasForeignKey(w=>w.IDProfile)
                .HasConstraintName("ForeignKey_profile_Historique");

            modelBuilder.Entity<HistoriqueAcces>()
                .HasOne(m => m.Acces)
                .WithMany(l => l.HistoriqueAcces)
                .HasForeignKey(w => w.IdAcces)
                .HasConstraintName("ForeignKey_Acces_Historique");


            // modelBuilder.Entity<profile>().Property(p => p.idprofile).ValueGeneratedOnAddOrUpdate();

            //            modelBuilder.Entity<profile>().Property(p => p.Id).ValueGeneratedNever();
            // modelBuilder.Entity<profile>().Property(p => p.Mdp).ValueGeneratedNever();
            //  modelBuilder.Entity<profile>().Property(p => p.Email).ValueGeneratedNever();
            //  modelBuilder.Entity<profile>().Property(p => p.Name).ValueGeneratedNever();
            //  modelBuilder.Entity<profile>().Property(p => p.Prenom).ValueGeneratedNever();
        }
    }
}
        
