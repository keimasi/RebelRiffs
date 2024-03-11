using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicManagement.Infrastructure.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class updata_relationBand : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlbumPicture",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlbumId = table.Column<long>(type: "bigint", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumPicture", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArtistPicture",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistId = table.Column<long>(type: "bigint", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistPicture", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BandCategory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BandId = table.Column<long>(type: "bigint", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BandCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Instruments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instruments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbBands",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    BandCategoryId = table.Column<long>(type: "bigint", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbBands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbBands_BandCategory_BandCategoryId",
                        column: x => x.BandCategoryId,
                        principalTable: "BandCategory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BandPicture",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BandId = table.Column<long>(type: "bigint", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BandPicture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BandPicture_tbBands_BandId",
                        column: x => x.BandId,
                        principalTable: "tbBands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbAlbums",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    ReleasedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    AlbumPictureId = table.Column<long>(type: "bigint", nullable: false),
                    AlbumCategoryId = table.Column<long>(type: "bigint", nullable: false),
                    BandId = table.Column<long>(type: "bigint", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbAlbums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbAlbums_AlbumPicture_AlbumPictureId",
                        column: x => x.AlbumPictureId,
                        principalTable: "AlbumPicture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbAlbums_Categories_AlbumCategoryId",
                        column: x => x.AlbumCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbAlbums_tbBands_BandId",
                        column: x => x.BandId,
                        principalTable: "tbBands",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tbArtists",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    State = table.Column<int>(type: "int", nullable: false),
                    Country = table.Column<long>(type: "bigint", nullable: false),
                    ArtistPictureId = table.Column<long>(type: "bigint", nullable: true),
                    BandId = table.Column<long>(type: "bigint", nullable: true),
                    InstrumentId = table.Column<long>(type: "bigint", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbArtists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbArtists_ArtistPicture_ArtistPictureId",
                        column: x => x.ArtistPictureId,
                        principalTable: "ArtistPicture",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tbArtists_Instruments_InstrumentId",
                        column: x => x.InstrumentId,
                        principalTable: "Instruments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tbArtists_tbBands_BandId",
                        column: x => x.BandId,
                        principalTable: "tbBands",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Audios",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    AlbumId = table.Column<long>(type: "bigint", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Audios_tbAlbums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "tbAlbums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Audios_AlbumId",
                table: "Audios",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_BandPicture_BandId",
                table: "BandPicture",
                column: "BandId");

            migrationBuilder.CreateIndex(
                name: "IX_tbAlbums_AlbumCategoryId",
                table: "tbAlbums",
                column: "AlbumCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tbAlbums_AlbumPictureId",
                table: "tbAlbums",
                column: "AlbumPictureId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbAlbums_BandId",
                table: "tbAlbums",
                column: "BandId");

            migrationBuilder.CreateIndex(
                name: "IX_tbArtists_ArtistPictureId",
                table: "tbArtists",
                column: "ArtistPictureId",
                unique: true,
                filter: "[ArtistPictureId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tbArtists_BandId",
                table: "tbArtists",
                column: "BandId");

            migrationBuilder.CreateIndex(
                name: "IX_tbArtists_InstrumentId",
                table: "tbArtists",
                column: "InstrumentId");

            migrationBuilder.CreateIndex(
                name: "IX_tbBands_BandCategoryId",
                table: "tbBands",
                column: "BandCategoryId",
                unique: true,
                filter: "[BandCategoryId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Audios");

            migrationBuilder.DropTable(
                name: "BandPicture");

            migrationBuilder.DropTable(
                name: "tbArtists");

            migrationBuilder.DropTable(
                name: "tbAlbums");

            migrationBuilder.DropTable(
                name: "ArtistPicture");

            migrationBuilder.DropTable(
                name: "Instruments");

            migrationBuilder.DropTable(
                name: "AlbumPicture");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "tbBands");

            migrationBuilder.DropTable(
                name: "BandCategory");
        }
    }
}
