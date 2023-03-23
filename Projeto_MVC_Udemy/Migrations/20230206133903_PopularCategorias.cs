﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoLanchesMacUdemy.Migrations
{
    /// <inheritdoc />
    public partial class PopularCategorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categorias(Nome, Descricao) " +
                "Values('Normal', 'Lanche feito com ingredientes normais')");
            
            migrationBuilder.Sql("INSERT INTO Categorias(Nome, Descricao) " +
                "Values('Natural', 'Lanche feito com ingredientes integrais e naturais')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categorias");
        }
    }
}
