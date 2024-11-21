using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Insurance.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    companyId = table.Column<string>(type: "Varchar(150)", nullable: false, defaultValueSql: "NEWID()"),
                    companyName = table.Column<string>(type: "Varchar(150)", nullable: true),
                    companyDescription = table.Column<string>(type: "Varchar(150)", nullable: true),
                    companyActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.companyId);
                });

            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    customerId = table.Column<string>(type: "Varchar(150)", nullable: false, defaultValueSql: "NEWID()"),
                    name = table.Column<string>(type: "Varchar(150)", nullable: false),
                    fatherName = table.Column<string>(type: "Varchar(150)", nullable: true),
                    motherName = table.Column<string>(type: "Varchar(150)", nullable: true),
                    dateofBirth = table.Column<string>(type: "Varchar(150)", nullable: true),
                    qualification = table.Column<string>(type: "Varchar(150)", nullable: true),
                    bloodGroup = table.Column<string>(type: "Varchar(150)", nullable: true),
                    graduation = table.Column<string>(type: "Varchar(150)", nullable: true),
                    gender = table.Column<string>(type: "Varchar(150)", nullable: true),
                    mobileNumber = table.Column<string>(type: "Varchar(150)", nullable: false),
                    alternativeNo = table.Column<string>(type: "Varchar(150)", nullable: true),
                    EmailId = table.Column<string>(type: "Varchar(150)", nullable: true),
                    aadharNo = table.Column<string>(type: "Varchar(150)", nullable: true),
                    permanent_address_street = table.Column<string>(type: "Varchar(150)", nullable: false),
                    permanent_address_area = table.Column<string>(type: "Varchar(250)", nullable: true),
                    permanent_location = table.Column<string>(type: "Varchar(150)", nullable: true),
                    permanent_city = table.Column<string>(type: "Varchar(150)", nullable: true),
                    same_as_permanent_address = table.Column<string>(type: "Varchar(150)", nullable: true),
                    present_address_street = table.Column<string>(type: "Varchar(150)", nullable: true),
                    present_address_area = table.Column<string>(type: "Varchar(250)", nullable: true),
                    present_location = table.Column<string>(type: "Varchar(150)", nullable: true),
                    present_city = table.Column<string>(type: "Varchar(150)", nullable: true),
                    married_Uncheck_for_single = table.Column<string>(type: "Varchar(150)", nullable: true),
                    dateofWedding = table.Column<string>(type: "Varchar(150)", nullable: true),
                    spouse_name = table.Column<string>(type: "Varchar(150)", nullable: true),
                    spouse_dateofbirth = table.Column<string>(type: "Varchar(150)", nullable: true),
                    children = table.Column<string>(type: "Varchar(150)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.customerId);
                });

            migrationBuilder.CreateTable(
                name: "customer_multi_upload",
                columns: table => new
                {
                    customerUploadId = table.Column<string>(type: "Varchar(150)", nullable: false, defaultValueSql: "NEWID()"),
                    imgPath = table.Column<string>(type: "Varchar(150)", nullable: false),
                    imgSource = table.Column<string>(type: "Varchar(150)", nullable: false),
                    CreatedDate = table.Column<string>(type: "Varchar(150)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer_multi_upload", x => x.customerUploadId);
                });

            migrationBuilder.CreateTable(
                name: "Policy",
                columns: table => new
                {
                    policyId = table.Column<string>(type: "Varchar(150)", nullable: false, defaultValueSql: "NEWID()"),
                    policyName = table.Column<string>(type: "Varchar(150)", nullable: false),
                    policyDescription = table.Column<string>(type: "Varchar(150)", nullable: true),
                    policyActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policy", x => x.policyId);
                });

            migrationBuilder.CreateTable(
                name: "Renewal_upload",
                columns: table => new
                {
                    imgId = table.Column<string>(type: "Varchar(150)", nullable: false, defaultValueSql: "NEWID()"),
                    imgPath = table.Column<string>(type: "Varchar(150)", nullable: false),
                    imgSource = table.Column<string>(type: "Varchar(150)", nullable: false),
                    CreatedDate = table.Column<string>(type: "Varchar(150)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Renewal_upload", x => x.imgId);
                });

            migrationBuilder.CreateTable(
                name: "Renewal",
                columns: table => new
                {
                    renewalId = table.Column<string>(type: "Varchar(150)", nullable: false, defaultValueSql: "NEWID()"),
                    customerId = table.Column<string>(type: "Varchar(150)", nullable: false),
                    customer_name = table.Column<string>(type: "Varchar(150)", nullable: false),
                    companyId = table.Column<string>(type: "Varchar(150)", nullable: false),
                    policyId = table.Column<string>(type: "Varchar(150)", nullable: false),
                    policy_no = table.Column<string>(type: "Varchar(150)", nullable: false),
                    policy_for = table.Column<string>(type: "Varchar(150)", nullable: false),
                    renewal_date = table.Column<string>(type: "Varchar(150)", nullable: false),
                    duration_months = table.Column<string>(type: "Varchar(150)", nullable: false),
                    next_renewal = table.Column<string>(type: "Varchar(150)", nullable: false),
                    amount = table.Column<string>(type: "Varchar(150)", nullable: false),
                    description = table.Column<string>(type: "Varchar(300)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Renewal", x => x.renewalId);
                    table.ForeignKey(
                        name: "FK_Renewal_Company_companyId",
                        column: x => x.companyId,
                        principalTable: "Company",
                        principalColumn: "companyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Renewal_Policy_policyId",
                        column: x => x.policyId,
                        principalTable: "Policy",
                        principalColumn: "policyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Renewal_customer_customerId",
                        column: x => x.customerId,
                        principalTable: "customer",
                        principalColumn: "customerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Renewal_companyId",
                table: "Renewal",
                column: "companyId");

            migrationBuilder.CreateIndex(
                name: "IX_Renewal_customerId",
                table: "Renewal",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_Renewal_policyId",
                table: "Renewal",
                column: "policyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customer_multi_upload");

            migrationBuilder.DropTable(
                name: "Renewal");

            migrationBuilder.DropTable(
                name: "Renewal_upload");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Policy");

            migrationBuilder.DropTable(
                name: "customer");
        }
    }
}
