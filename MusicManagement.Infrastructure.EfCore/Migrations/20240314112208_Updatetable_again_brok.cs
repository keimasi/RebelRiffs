using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicManagement.Infrastructure.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class Updatetable_again_brok : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbAlbums_Category_AlbumCategoryId",
                table: "tbAlbums");

            migrationBuilder.DropForeignKey(
                name: "FK_tbBands_Category_BandCategoryId",
                table: "tbBands");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbAlbums_Categories_AlbumCategoryId",
                table: "tbAlbums",
                column: "AlbumCategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbBands_Categories_BandCategoryId",
                table: "tbBands",
                column: "BandCategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbAlbums_Categories_AlbumCategoryId",
                table: "tbAlbums");

            migrationBuilder.DropForeignKey(
                name: "FK_tbBands_Categories_BandCategoryId",
                table: "tbBands");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

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
    }
}
