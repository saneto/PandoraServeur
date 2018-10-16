using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using ServeurPandora.Models;

namespace ServeurPandora.Migrations
{
    [DbContext(typeof(DataModel))]
    partial class DataModelModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ServeurPandora.Models.Acces", b =>
                {
                    b.Property<int>("AccesId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("IDProfile");

                    b.Property<string>("Identifiant");

                    b.Property<string>("Mdp");

                    b.Property<string>("Type");

                    b.HasKey("AccesId");
                });

            modelBuilder.Entity("ServeurPandora.Models.HistoriqueAcces", b =>
                {
                    b.Property<int>("IdHistorique")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Connexion");

                    b.Property<DateTime>("Deconnexion");

                    b.Property<int>("IdAcces");

                    b.HasKey("IdHistorique");
                });

            modelBuilder.Entity("ServeurPandora.Models.HistoriqueCompte", b =>
                {
                    b.Property<int>("IdHistorique")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Connexion");

                    b.Property<DateTime>("Deconnexion");

                    b.Property<int>("IDProfile");

                    b.HasKey("IdHistorique");
                });

            modelBuilder.Entity("ServeurPandora.Models.profile", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Mdp");

                    b.Property<string>("Name");

                    b.Property<string>("Prenom");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("ServeurPandora.ModelVersionPro.AccesPro", b =>
                {
                    b.Property<int>("IdAcces")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("IdProfilePro");

                    b.Property<string>("Mdp");

                    b.Property<string>("login");

                    b.HasKey("IdAcces");
                });

            modelBuilder.Entity("ServeurPandora.ModelVersionPro.HistoriqueAccesPro", b =>
                {
                    b.Property<int>("IdHistorique")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AccesIdAcces");

                    b.Property<DateTime>("Connexion");

                    b.Property<DateTime>("Deconnexion");

                    b.Property<int>("IdAccesPro");

                    b.HasKey("IdHistorique");
                });

            modelBuilder.Entity("ServeurPandora.ModelVersionPro.HistoriqueComptePro", b =>
                {
                    b.Property<int>("IdHistorique")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Connexion");

                    b.Property<DateTime>("Deconnexion");

                    b.Property<int>("IDUser");

                    b.HasKey("IdHistorique");
                });

            modelBuilder.Entity("ServeurPandora.ModelVersionPro.ProfilePro", b =>
                {
                    b.Property<int>("IdProfilePro")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("IdUser");

                    b.Property<string>("nom");

                    b.HasKey("IdProfilePro");
                });

            modelBuilder.Entity("ServeurPandora.ModelVersionPro.User", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Mdp");

                    b.Property<string>("Nom");

                    b.Property<string>("prenom");

                    b.HasKey("IdUser");
                });

            modelBuilder.Entity("ServeurPandora.Models.Acces", b =>
                {
                    b.HasOne("ServeurPandora.Models.profile")
                        .WithMany()
                        .HasForeignKey("IDProfile")
                        .HasAnnotation("Relational:Name", "ForeignKey_profile_Acces");
                });

            modelBuilder.Entity("ServeurPandora.Models.HistoriqueAcces", b =>
                {
                    b.HasOne("ServeurPandora.Models.Acces")
                        .WithMany()
                        .HasForeignKey("IdAcces")
                        .HasAnnotation("Relational:Name", "ForeignKey_Acces_Historique");
                });

            modelBuilder.Entity("ServeurPandora.Models.HistoriqueCompte", b =>
                {
                    b.HasOne("ServeurPandora.Models.profile")
                        .WithMany()
                        .HasForeignKey("IDProfile")
                        .HasAnnotation("Relational:Name", "ForeignKey_profile_Historique");
                });

            modelBuilder.Entity("ServeurPandora.ModelVersionPro.AccesPro", b =>
                {
                    b.HasOne("ServeurPandora.ModelVersionPro.ProfilePro")
                        .WithMany()
                        .HasForeignKey("IdProfilePro");
                });

            modelBuilder.Entity("ServeurPandora.ModelVersionPro.HistoriqueAccesPro", b =>
                {
                    b.HasOne("ServeurPandora.ModelVersionPro.AccesPro")
                        .WithMany()
                        .HasForeignKey("AccesIdAcces");
                });

            modelBuilder.Entity("ServeurPandora.ModelVersionPro.HistoriqueComptePro", b =>
                {
                    b.HasOne("ServeurPandora.ModelVersionPro.User")
                        .WithMany()
                        .HasForeignKey("IDUser");
                });

            modelBuilder.Entity("ServeurPandora.ModelVersionPro.ProfilePro", b =>
                {
                    b.HasOne("ServeurPandora.ModelVersionPro.User")
                        .WithMany()
                        .HasForeignKey("IdUser");
                });
        }
    }
}
