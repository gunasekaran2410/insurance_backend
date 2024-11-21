using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Insurance.Migrations
{
    /// <inheritdoc />
    public partial class up : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customer_multi_upload");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Renewal_upload",
                table: "Renewal_upload");

            migrationBuilder.RenameTable(
                name: "Renewal_upload",
                newName: "custome_upload");

            migrationBuilder.AddPrimaryKey(
                name: "PK_custome_upload",
                table: "custome_upload",
                column: "imgId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_custome_upload",
                table: "custome_upload");

            migrationBuilder.RenameTable(
                name: "custome_upload",
                newName: "Renewal_upload");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Renewal_upload",
                table: "Renewal_upload",
                column: "imgId");

            migrationBuilder.CreateTable(
                name: "customer_multi_upload",
                columns: table => new
                {
                    customerUploadId = table.Column<string>(type: "Varchar(150)", nullable: false, defaultValueSql: "NEWID()"),
                    CreatedDate = table.Column<string>(type: "Varchar(150)", nullable: true),
                    imgPath = table.Column<string>(type: "Varchar(150)", nullable: false),
                    imgSource = table.Column<string>(type: "Varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer_multi_upload", x => x.customerUploadId);
                });
        }
    }
}
