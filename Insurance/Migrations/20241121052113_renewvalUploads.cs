using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Insurance.Migrations
{
    /// <inheritdoc />
    public partial class renewvalUploads : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "renewval_upload",
                columns: table => new
                {
                    imgId = table.Column<string>(type: "Varchar(150)", nullable: false, defaultValueSql: "NEWID()"),
                    GroupId = table.Column<string>(type: "Varchar(150)", nullable: false),
                    imgPath = table.Column<string>(type: "Varchar(150)", nullable: false),
                    imgSource = table.Column<string>(type: "Varchar(150)", nullable: false),
                    CreatedDate = table.Column<string>(type: "Varchar(150)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_renewval_upload", x => x.imgId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "renewval_upload");
        }
    }
}
