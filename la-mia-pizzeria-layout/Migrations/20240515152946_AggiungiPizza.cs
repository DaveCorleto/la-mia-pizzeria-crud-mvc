using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Test_MVC_2.Data;

#nullable disable

namespace Test_MVC_2.Migrations
{
    /// <inheritdoc />
    [DbContext(typeof(PizzaContext))]
    public partial class AggiungiPizza : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
