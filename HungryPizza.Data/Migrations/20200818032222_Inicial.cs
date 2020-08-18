using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HungryPizza.Data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Endereco = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Sabor = table.Column<string>(type: "varchar(200)", nullable: false),
                    Valor = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ClienteId = table.Column<Guid>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    ValorTotal = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedidos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PedidoPizzas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PedidoId = table.Column<Guid>(nullable: false),
                    PizzaId = table.Column<Guid>(nullable: false),
                    TipoPizza = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoPizzas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidoPizzas_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PedidoPizzas_Pizzas_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizzas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Id", "Sabor", "Valor" },
                values: new object[,]
                {
                    { new Guid("5249adeb-8dc5-4db2-a1b1-97fd4a453846"), "3 Queijos", 50m },
                    { new Guid("bddb4457-4e57-4aa5-b645-224080b21bdb"), "Frango com requeijão", 59.99m },
                    { new Guid("fcf9e283-df6c-4529-9243-524c8426cfb7"), "Mussarela", 42.50m },
                    { new Guid("2a2f34a0-9669-4782-8a43-82a364ec2beb"), "Calabresa", 42.50m },
                    { new Guid("88152c7e-761b-4cf3-86ce-d399fbaf9ca7"), "Pepperoni", 55m },
                    { new Guid("1e461664-3836-4546-97bb-5a2da9407b7e"), "Portuguesa", 45m },
                    { new Guid("e5cdc739-08e8-4686-88b5-e4148376b2d8"), "Veggie", 59.99m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PedidoPizzas_PedidoId",
                table: "PedidoPizzas",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoPizzas_PizzaId",
                table: "PedidoPizzas",
                column: "PizzaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ClienteId",
                table: "Pedidos",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PedidoPizzas");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Pizzas");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
