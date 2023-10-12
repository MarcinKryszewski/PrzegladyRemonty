using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrzegladyRemonty.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActionsCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Frequency = table.Column<int>(type: "INTEGER", nullable: false),
                    MyProperty = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionsCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Active = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Value = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Login = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Surname = table.Column<string>(type: "TEXT", nullable: true),
                    Active = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Active = table.Column<int>(type: "INTEGER", nullable: false),
                    LineId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Areas_Lines_LineId",
                        column: x => x.LineId,
                        principalTable: "Lines",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UsersPermissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    PermissionId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersPermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersPermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersPermissions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkOrders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Transporters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Active = table.Column<bool>(type: "INTEGER", nullable: false),
                    LastMaintenance = table.Column<string>(type: "TEXT", nullable: true),
                    AreaId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transporters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transporters_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TransportersActions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TransporterId = table.Column<int>(type: "INTEGER", nullable: false),
                    ActionId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportersActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransportersActions_ActionsCategories_ActionId",
                        column: x => x.ActionId,
                        principalTable: "ActionsCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransportersActions_Transporters_TransporterId",
                        column: x => x.TransporterId,
                        principalTable: "Transporters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Maintenances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MaintenanceDate = table.Column<string>(type: "TEXT", nullable: true),
                    Completed = table.Column<int>(type: "INTEGER", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", nullable: true),
                    MechanicId = table.Column<int>(type: "INTEGER", nullable: true),
                    ActionId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maintenances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Maintenances_TransportersActions_ActionId",
                        column: x => x.ActionId,
                        principalTable: "TransportersActions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Maintenances_Users_MechanicId",
                        column: x => x.MechanicId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WorkOrdersMaintenances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WorkOrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    MaintenanceId = table.Column<int>(type: "INTEGER", nullable: false),
                    WorkOrderMaintenanceId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrdersMaintenances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkOrdersMaintenances_Maintenances_MaintenanceId",
                        column: x => x.MaintenanceId,
                        principalTable: "Maintenances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkOrdersMaintenances_WorkOrdersMaintenances_WorkOrderMaintenanceId",
                        column: x => x.WorkOrderMaintenanceId,
                        principalTable: "WorkOrdersMaintenances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorkOrdersMaintenances_WorkOrders_WorkOrderId",
                        column: x => x.WorkOrderId,
                        principalTable: "WorkOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Areas_LineId",
                table: "Areas",
                column: "LineId");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenances_ActionId",
                table: "Maintenances",
                column: "ActionId");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenances_MechanicId",
                table: "Maintenances",
                column: "MechanicId");

            migrationBuilder.CreateIndex(
                name: "IX_Transporters_AreaId",
                table: "Transporters",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportersActions_ActionId",
                table: "TransportersActions",
                column: "ActionId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportersActions_TransporterId",
                table: "TransportersActions",
                column: "TransporterId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersPermissions_PermissionId",
                table: "UsersPermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersPermissions_UserId",
                table: "UsersPermissions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_UserId",
                table: "WorkOrders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrdersMaintenances_MaintenanceId",
                table: "WorkOrdersMaintenances",
                column: "MaintenanceId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrdersMaintenances_WorkOrderId",
                table: "WorkOrdersMaintenances",
                column: "WorkOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrdersMaintenances_WorkOrderMaintenanceId",
                table: "WorkOrdersMaintenances",
                column: "WorkOrderMaintenanceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersPermissions");

            migrationBuilder.DropTable(
                name: "WorkOrdersMaintenances");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Maintenances");

            migrationBuilder.DropTable(
                name: "WorkOrders");

            migrationBuilder.DropTable(
                name: "TransportersActions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ActionsCategories");

            migrationBuilder.DropTable(
                name: "Transporters");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "Lines");
        }
    }
}
