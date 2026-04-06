using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeLeaveManagement.Migrations
{
    /// <inheritdoc />
    public partial class AddedLeaveBalances : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LeaveBalances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SickLeave = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CasualLeave = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EarnedLeave = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AssociateId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveBalances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveBalances_Employees_AssociateId",
                        column: x => x.AssociateId,
                        principalTable: "Employees",
                        principalColumn: "AssociateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeaveBalances_AssociateId",
                table: "LeaveBalances",
                column: "AssociateId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaveBalances");
        }
    }
}
