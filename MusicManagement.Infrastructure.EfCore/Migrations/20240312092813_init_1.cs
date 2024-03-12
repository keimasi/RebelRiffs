using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicManagement.Infrastructure.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class init_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbAlbums_AlbumPicture_AlbumPictureId",
                table: "tbAlbums");

            migrationBuilder.DropForeignKey(
                name: "FK_tbAlbums_Categories_AlbumCategoryId",
                table: "tbAlbums");

            migrationBuilder.DropForeignKey(
                name: "FK_tbArtists_ArtistPicture_ArtistPictureId",
                table: "tbArtists");

            migrationBuilder.DropForeignKey(
                name: "FK_tbBands_BandCategory_BandCategoryId",
                table: "tbBands");

            migrationBuilder.DropTable(
                name: "AlbumPicture");

            migrationBuilder.DropTable(
                name: "ArtistPicture");

            migrationBuilder.DropTable(
                name: "BandCategory");

            migrationBuilder.DropIndex(
                name: "IX_tbBands_BandCategoryId",
                table: "tbBands");

            migrationBuilder.DropIndex(
                name: "IX_tbArtists_ArtistPictureId",
                table: "tbArtists");

            migrationBuilder.DropIndex(
                name: "IX_tbAlbums_AlbumPictureId",
                table: "tbAlbums");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ArtistPictureId",
                table: "tbArtists");

            migrationBuilder.DropColumn(
                name: "AlbumPictureId",
                table: "tbAlbums");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "tbArtists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "tbAlbums",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Category",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_tbBands_BandCategoryId",
                table: "tbBands",
                column: "BandCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbAlbums_Category_AlbumCategoryId",
                table: "tbAlbums",
                column: "AlbumCategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbBands_Category_BandCategoryId",
                table: "tbBands",
                column: "BandCategoryId",
                principalTable: "Category",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbAlbums_Category_AlbumCategoryId",
                table: "tbAlbums");

            migrationBuilder.DropForeignKey(
                name: "FK_tbBands_Category_BandCategoryId",
                table: "tbBands");

            migrationBuilder.DropIndex(
                name: "IX_tbBands_BandCategoryId",
                table: "tbBands");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "tbArtists");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "tbAlbums");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.AddColumn<long>(
                name: "ArtistPictureId",
                table: "tbArtists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "AlbumPictureId",
                table: "tbAlbums",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AlbumPicture",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlbumId = table.Column<long>(type: "bigint", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BandCategory", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbBands_BandCategoryId",
                table: "tbBands",
                column: "BandCategoryId",
                unique: true,
                filter: "[BandCategoryId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tbArtists_ArtistPictureId",
                table: "tbArtists",
                column: "ArtistPictureId",
                unique: true,
                filter: "[ArtistPictureId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tbAlbums_AlbumPictureId",
                table: "tbAlbums",
                column: "AlbumPictureId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tbAlbums_AlbumPicture_AlbumPictureId",
                table: "tbAlbums",
                column: "AlbumPictureId",
                principalTable: "AlbumPicture",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbAlbums_Categories_AlbumCategoryId",
                table: "tbAlbums",
                column: "AlbumCategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbArtists_ArtistPicture_ArtistPictureId",
                table: "tbArtists",
                column: "ArtistPictureId",
                principalTable: "ArtistPicture",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbBands_BandCategory_BandCategoryId",
                table: "tbBands",
                column: "BandCategoryId",
                principalTable: "BandCategory",
                principalColumn: "Id");
        }
    }
}
