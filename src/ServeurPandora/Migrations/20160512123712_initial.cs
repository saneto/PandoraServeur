using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace ServeurPandora.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "profile",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    Mdp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Prenom = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profile", x => x.ID);
                });
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    IdUser = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    Mdp = table.Column<string>(nullable: true),
                    Nom = table.Column<string>(nullable: true),
                    prenom = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.IdUser);
                });
            migrationBuilder.CreateTable(
                name: "Acces",
                columns: table => new
                {
                    AccesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IDProfile = table.Column<int>(nullable: false),
                    Identifiant = table.Column<string>(nullable: true),
                    Mdp = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acces", x => x.AccesId);
                    table.ForeignKey(
                        name: "ForeignKey_profile_Acces",
                        column: x => x.IDProfile,
                        principalTable: "profile",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "HistoriqueCompte",
                columns: table => new
                {
                    IdHistorique = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Connexion = table.Column<DateTime>(nullable: false),
                    Deconnexion = table.Column<DateTime>(nullable: false),
                    IDProfile = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoriqueCompte", x => x.IdHistorique);
                    table.ForeignKey(
                        name: "ForeignKey_profile_Historique",
                        column: x => x.IDProfile,
                        principalTable: "profile",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "HistoriqueComptePro",
                columns: table => new
                {
                    IdHistorique = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Connexion = table.Column<DateTime>(nullable: false),
                    Deconnexion = table.Column<DateTime>(nullable: false),
                    IDUser = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoriqueComptePro", x => x.IdHistorique);
                    table.ForeignKey(
                        name: "FK_HistoriqueComptePro_User_IDUser",
                        column: x => x.IDUser,
                        principalTable: "User",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "ProfilePro",
                columns: table => new
                {
                    IdProfilePro = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdUser = table.Column<int>(nullable: false),
                    nom = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfilePro", x => x.IdProfilePro);
                    table.ForeignKey(
                        name: "FK_ProfilePro_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "HistoriqueAcces",
                columns: table => new
                {
                    IdHistorique = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Connexion = table.Column<DateTime>(nullable: false),
                    Deconnexion = table.Column<DateTime>(nullable: false),
                    IdAcces = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoriqueAcces", x => x.IdHistorique);
                    table.ForeignKey(
                        name: "ForeignKey_Acces_Historique",
                        column: x => x.IdAcces,
                        principalTable: "Acces",
                        principalColumn: "AccesId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "AccesPro",
                columns: table => new
                {
                    IdAcces = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdProfilePro = table.Column<int>(nullable: false),
                    Mdp = table.Column<string>(nullable: true),
                    login = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccesPro", x => x.IdAcces);
                    table.ForeignKey(
                        name: "FK_AccesPro_ProfilePro_IdProfilePro",
                        column: x => x.IdProfilePro,
                        principalTable: "ProfilePro",
                        principalColumn: "IdProfilePro",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "HistoriqueAccesPro",
                columns: table => new
                {
                    IdHistorique = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccesIdAcces = table.Column<int>(nullable: true),
                    Connexion = table.Column<DateTime>(nullable: false),
                    Deconnexion = table.Column<DateTime>(nullable: false),
                    IdAccesPro = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoriqueAccesPro", x => x.IdHistorique);
                    table.ForeignKey(
                        name: "FK_HistoriqueAccesPro_AccesPro_AccesIdAcces",
                        column: x => x.AccesIdAcces,
                        principalTable: "AccesPro",
                        principalColumn: "IdAcces",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("HistoriqueAcces");
            migrationBuilder.DropTable("HistoriqueCompte");
            migrationBuilder.DropTable("HistoriqueAccesPro");
            migrationBuilder.DropTable("HistoriqueComptePro");
            migrationBuilder.DropTable("Acces");
            migrationBuilder.DropTable("AccesPro");
            migrationBuilder.DropTable("profile");
            migrationBuilder.DropTable("ProfilePro");
            migrationBuilder.DropTable("User");
        }
    }
}
