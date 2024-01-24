using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portal.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class addedImageFor2Ent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageFile",
                table: "Educations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageFile",
                table: "Educations");
        }
    }
}
