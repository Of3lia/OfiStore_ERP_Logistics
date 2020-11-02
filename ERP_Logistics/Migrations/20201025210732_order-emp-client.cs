using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP_Logistics.Migrations
{
    public partial class orderempclient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ApplicationUserOrders_ApplicationUsersOrderId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "ApplicationUserOrders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ApplicationUsersOrderId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ApplicationUsersOrderId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "OrderClientId",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderEmployeeId",
                table: "Orders",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OrderClients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderClients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderClients_AspNetUsers_ClientId",
                        column: x => x.ClientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderEmployees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderEmployees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderEmployees_AspNetUsers_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderClientId",
                table: "Orders",
                column: "OrderClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderEmployeeId",
                table: "Orders",
                column: "OrderEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderClients_ClientId",
                table: "OrderClients",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderEmployees_EmployeeId",
                table: "OrderEmployees",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderClients_OrderClientId",
                table: "Orders",
                column: "OrderClientId",
                principalTable: "OrderClients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderEmployees_OrderEmployeeId",
                table: "Orders",
                column: "OrderEmployeeId",
                principalTable: "OrderEmployees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderClients_OrderClientId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderEmployees_OrderEmployeeId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "OrderClients");

            migrationBuilder.DropTable(
                name: "OrderEmployees");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderClientId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderEmployeeId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderClientId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderEmployeeId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUsersOrderId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ApplicationUserOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationUserOrders_AspNetUsers_ClientId",
                        column: x => x.ClientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApplicationUserOrders_AspNetUsers_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ApplicationUsersOrderId",
                table: "Orders",
                column: "ApplicationUsersOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserOrders_ClientId",
                table: "ApplicationUserOrders",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserOrders_EmployeeId",
                table: "ApplicationUserOrders",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ApplicationUserOrders_ApplicationUsersOrderId",
                table: "Orders",
                column: "ApplicationUsersOrderId",
                principalTable: "ApplicationUserOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
