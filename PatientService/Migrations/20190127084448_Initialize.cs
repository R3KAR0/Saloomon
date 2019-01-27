using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PatientService.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PatientAddress",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Street = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    Town = table.Column<string>(nullable: true),
                    Country = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientAddress", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TopLevelFolders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ParentFolderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopLevelFolders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TopLevelFolders_TopLevelFolders_ParentFolderId",
                        column: x => x.ParentFolderId,
                        principalTable: "TopLevelFolders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    SocialInsuranceNumber = table.Column<string>(maxLength: 50, nullable: false),
                    GDPRAcceptedId = table.Column<int>(nullable: false),
                    StudyAccepted = table.Column<bool>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    AddressId = table.Column<int>(nullable: false),
                    ParentFolderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_PatientAddress_AddressId",
                        column: x => x.AddressId,
                        principalTable: "PatientAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Patients_TopLevelFolders_ParentFolderId",
                        column: x => x.ParentFolderId,
                        principalTable: "TopLevelFolders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientFolders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    ParentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientFolders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientFolders_Patients_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TopDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdOfOtherService = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    ParentId = table.Column<int>(nullable: true),
                    PatientTopDocument_ParentId = table.Column<int>(nullable: true),
                    TopFolderDocument_ParentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TopDocuments_PatientFolders_ParentId",
                        column: x => x.ParentId,
                        principalTable: "PatientFolders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TopDocuments_Patients_PatientTopDocument_ParentId",
                        column: x => x.PatientTopDocument_ParentId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TopDocuments_TopLevelFolders_TopFolderDocument_ParentId",
                        column: x => x.TopFolderDocument_ParentId,
                        principalTable: "TopLevelFolders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdInOtherService = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    ParentId = table.Column<int>(nullable: true),
                    PatientDocumentSubDocument_ParentId = table.Column<int>(nullable: true),
                    PatientFolderDocumentSubDocument_ParentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubDocuments_TopDocuments_ParentId",
                        column: x => x.ParentId,
                        principalTable: "TopDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubDocuments_TopDocuments_PatientDocumentSubDocument_ParentId",
                        column: x => x.PatientDocumentSubDocument_ParentId,
                        principalTable: "TopDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubDocuments_TopDocuments_PatientFolderDocumentSubDocument_ParentId",
                        column: x => x.PatientFolderDocumentSubDocument_ParentId,
                        principalTable: "TopDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientFolders_ParentId",
                table: "PatientFolders",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_AddressId",
                table: "Patients",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_ParentFolderId",
                table: "Patients",
                column: "ParentFolderId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDocuments_ParentId",
                table: "SubDocuments",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDocuments_PatientDocumentSubDocument_ParentId",
                table: "SubDocuments",
                column: "PatientDocumentSubDocument_ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDocuments_PatientFolderDocumentSubDocument_ParentId",
                table: "SubDocuments",
                column: "PatientFolderDocumentSubDocument_ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_TopDocuments_ParentId",
                table: "TopDocuments",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_TopDocuments_PatientTopDocument_ParentId",
                table: "TopDocuments",
                column: "PatientTopDocument_ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_TopDocuments_TopFolderDocument_ParentId",
                table: "TopDocuments",
                column: "TopFolderDocument_ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_TopLevelFolders_ParentFolderId",
                table: "TopLevelFolders",
                column: "ParentFolderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubDocuments");

            migrationBuilder.DropTable(
                name: "TopDocuments");

            migrationBuilder.DropTable(
                name: "PatientFolders");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "PatientAddress");

            migrationBuilder.DropTable(
                name: "TopLevelFolders");
        }
    }
}
