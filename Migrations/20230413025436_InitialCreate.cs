using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webservice_api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    usuarioResponsavel = table.Column<int>(type: "int", nullable: true),
                    dataCadastro = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Estagios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    estagioPadrao = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: true),
                    proximoEstagio = table.Column<int>(type: "int", nullable: true),
                    usuarioResponsavel = table.Column<int>(type: "int", nullable: true),
                    dataCadastro = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estagios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "FormaPagamento",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    usuarioResponsavel = table.Column<int>(type: "int", nullable: true),
                    dataCadastro = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormaPagamento", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "UnidadesMedida",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    unidade = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    simbolo = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    grandeza = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadesMedida", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false, comment: "Identificação do usuário")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    tratamento = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    dataNascimento = table.Column<DateTime>(type: "date", nullable: true),
                    dataCadastro = table.Column<DateTime>(type: "datetime", nullable: true),
                    sexo = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    salt = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    hash = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Acessos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    dataCadastro = table.Column<DateTime>(type: "datetime", nullable: true),
                    usuarioResponsavel = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acessos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Acessos_Usuarios",
                        column: x => x.usuarioResponsavel,
                        principalTable: "Usuarios",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Grupos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    dataCadastro = table.Column<DateTime>(type: "datetime", nullable: true),
                    usuarioResponsavel = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Grupos_Usuarios",
                        column: x => x.usuarioResponsavel,
                        principalTable: "Usuarios",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    ano = table.Column<short>(type: "smallint", nullable: false),
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    formaPagamentoId = table.Column<int>(type: "int", nullable: true),
                    horarioRetirada = table.Column<DateTime>(type: "datetime", nullable: true),
                    usuarioSolicitante = table.Column<int>(type: "int", nullable: true),
                    dataSolicitante = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => new { x.ano, x.id });
                    table.ForeignKey(
                        name: "FK_Pedidos_Pedidos",
                        column: x => x.formaPagamentoId,
                        principalTable: "FormaPagamento",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Pedidos_Usuarios",
                        column: x => x.usuarioSolicitante,
                        principalTable: "Usuarios",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    descricao = table.Column<string>(type: "text", nullable: true),
                    caminhoFoto = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    situacao = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: true),
                    dataCadastro = table.Column<DateTime>(type: "datetime", nullable: true),
                    usuarioResponsavel = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Produtos_Usuarios",
                        column: x => x.usuarioResponsavel,
                        principalTable: "Usuarios",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "AcessosUsuarios",
                columns: table => new
                {
                    acessosId = table.Column<int>(type: "int", nullable: false),
                    usuariosId = table.Column<int>(type: "int", nullable: false),
                    dataLancamento = table.Column<DateTime>(type: "datetime", nullable: true),
                    usuarioResponsavel = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcessosUsuarios", x => new { x.acessosId, x.usuariosId });
                    table.ForeignKey(
                        name: "FK_AcessosUsuarios_Acessos",
                        column: x => x.acessosId,
                        principalTable: "Acessos",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_AcessosUsuarios_Usuarios",
                        column: x => x.usuariosId,
                        principalTable: "Usuarios",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_AcessosUsuarios_Usuarios1",
                        column: x => x.usuarioResponsavel,
                        principalTable: "Usuarios",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "AcessosGrupos",
                columns: table => new
                {
                    acessosId = table.Column<int>(type: "int", nullable: false),
                    gruposId = table.Column<int>(type: "int", nullable: false),
                    dataLancamento = table.Column<DateTime>(type: "datetime", nullable: true),
                    usuarioResponsavel = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcessosGrupos", x => new { x.acessosId, x.gruposId });
                    table.ForeignKey(
                        name: "FK_AcessosGrupos_Acessos",
                        column: x => x.acessosId,
                        principalTable: "Acessos",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_AcessosGrupos_Grupos",
                        column: x => x.gruposId,
                        principalTable: "Grupos",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_AcessosGrupos_Usuarios",
                        column: x => x.usuarioResponsavel,
                        principalTable: "Usuarios",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "GruposUsuarios",
                columns: table => new
                {
                    gruposId = table.Column<int>(type: "int", nullable: false),
                    usuariosId = table.Column<int>(type: "int", nullable: false),
                    dataCadastro = table.Column<DateTime>(type: "datetime", nullable: true),
                    usuarioResponsavel = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GruposUsuarios", x => new { x.gruposId, x.usuariosId });
                    table.ForeignKey(
                        name: "FK_GruposUsuarios_Grupos",
                        column: x => x.gruposId,
                        principalTable: "Grupos",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_GruposUsuarios_Usuarios",
                        column: x => x.usuariosId,
                        principalTable: "Usuarios",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_GruposUsuarios_Usuarios1",
                        column: x => x.usuarioResponsavel,
                        principalTable: "Usuarios",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "EstagiosPedido",
                columns: table => new
                {
                    pedidosAno = table.Column<short>(type: "smallint", nullable: false),
                    pedidosId = table.Column<int>(type: "int", nullable: false),
                    estagiosId = table.Column<int>(type: "int", nullable: false),
                    dataLancamento = table.Column<DateTime>(type: "datetime", nullable: false),
                    usuarioResponsavel = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstagiosPedido", x => new { x.pedidosAno, x.pedidosId, x.estagiosId, x.dataLancamento });
                    table.ForeignKey(
                        name: "FK_EstagiosPedido_EstagiosPedido",
                        column: x => x.estagiosId,
                        principalTable: "Estagios",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_EstagiosPedido_Pedidos",
                        columns: x => new { x.pedidosAno, x.pedidosId },
                        principalTable: "Pedidos",
                        principalColumns: new[] { "ano", "id" });
                    table.ForeignKey(
                        name: "FK_EstagiosPedido_Usuarios",
                        column: x => x.usuarioResponsavel,
                        principalTable: "Usuarios",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "CategoriasProdutos",
                columns: table => new
                {
                    produtosId = table.Column<int>(type: "int", nullable: false),
                    categoriasId = table.Column<int>(type: "int", nullable: false),
                    usuarioResponsavel = table.Column<int>(type: "int", nullable: true),
                    dataCadastro = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriasProdutos", x => new { x.produtosId, x.categoriasId });
                    table.ForeignKey(
                        name: "FK_CategoriasProdutos_Categorias",
                        column: x => x.categoriasId,
                        principalTable: "Categorias",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_CategoriasProdutos_Produtos",
                        column: x => x.produtosId,
                        principalTable: "Produtos",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_CategoriasProdutos_Usuarios",
                        column: x => x.usuarioResponsavel,
                        principalTable: "Usuarios",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Estoque",
                columns: table => new
                {
                    produtosId = table.Column<int>(type: "int", nullable: false),
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    saldo = table.Column<decimal>(type: "decimal(10,4)", nullable: true),
                    unidadesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estoque", x => new { x.produtosId, x.id });
                    table.ForeignKey(
                        name: "FK_Estoque_Produtos",
                        column: x => x.produtosId,
                        principalTable: "Produtos",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Estoque_UnidadesMedida",
                        column: x => x.unidadesId,
                        principalTable: "UnidadesMedida",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ItensPedidos",
                columns: table => new
                {
                    pedidosAno = table.Column<short>(type: "smallint", nullable: false),
                    pedidosId = table.Column<int>(type: "int", nullable: false),
                    produtosId = table.Column<int>(type: "int", nullable: false),
                    quantidade = table.Column<decimal>(type: "decimal(10,4)", nullable: true),
                    unidadesId = table.Column<int>(type: "int", nullable: true),
                    precoProduto = table.Column<decimal>(type: "decimal(10,5)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensPedidos", x => new { x.pedidosAno, x.pedidosId, x.produtosId });
                    table.ForeignKey(
                        name: "FK_ItensPedidos_ItensPedidos",
                        columns: x => new { x.pedidosAno, x.pedidosId },
                        principalTable: "Pedidos",
                        principalColumns: new[] { "ano", "id" });
                    table.ForeignKey(
                        name: "FK_ItensPedidos_Produtos",
                        column: x => x.produtosId,
                        principalTable: "Produtos",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "PrecoProduto",
                columns: table => new
                {
                    produtosId = table.Column<int>(type: "int", nullable: false),
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    preco = table.Column<decimal>(type: "decimal(10,5)", nullable: true),
                    usuarioResponsavel = table.Column<int>(type: "int", nullable: true),
                    dataLancamento = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrecoProduto", x => new { x.produtosId, x.id });
                    table.ForeignKey(
                        name: "FK_PrecoProduto_Produtos",
                        column: x => x.produtosId,
                        principalTable: "Produtos",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_PrecoProduto_Usuarios",
                        column: x => x.usuarioResponsavel,
                        principalTable: "Usuarios",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "EntradaEstoque",
                columns: table => new
                {
                    produtosId = table.Column<int>(type: "int", nullable: false),
                    estoqueId = table.Column<int>(type: "int", nullable: false),
                    id = table.Column<int>(type: "int", nullable: false),
                    quantidade = table.Column<decimal>(type: "decimal(10,4)", nullable: true),
                    unidadesId = table.Column<int>(type: "int", nullable: true),
                    usuarioResponsavel = table.Column<int>(type: "int", nullable: true),
                    dataEntrada = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntradaEstoque", x => new { x.produtosId, x.estoqueId, x.id });
                    table.ForeignKey(
                        name: "FK_EntradaEstoque_Estoque",
                        columns: x => new { x.produtosId, x.estoqueId },
                        principalTable: "Estoque",
                        principalColumns: new[] { "produtosId", "id" });
                    table.ForeignKey(
                        name: "FK_EntradaEstoque_UnidadesMedida",
                        column: x => x.unidadesId,
                        principalTable: "UnidadesMedida",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_EntradaEstoque_Usuarios",
                        column: x => x.usuarioResponsavel,
                        principalTable: "Usuarios",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ParticulariedadeItemPedido",
                columns: table => new
                {
                    pedidosAno = table.Column<short>(type: "smallint", nullable: false),
                    pedidosId = table.Column<int>(type: "int", nullable: false),
                    produtosId = table.Column<int>(type: "int", nullable: false),
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    particulariedade = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticulariedadeItemPedido", x => new { x.pedidosAno, x.pedidosId, x.produtosId, x.id });
                    table.ForeignKey(
                        name: "FK_ParticulariedadeItemPedido_ItensPedidos",
                        columns: x => new { x.pedidosAno, x.pedidosId, x.produtosId },
                        principalTable: "ItensPedidos",
                        principalColumns: new[] { "pedidosAno", "pedidosId", "produtosId" });
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acessos_usuarioResponsavel",
                table: "Acessos",
                column: "usuarioResponsavel");

            migrationBuilder.CreateIndex(
                name: "IX_AcessosGrupos_gruposId",
                table: "AcessosGrupos",
                column: "gruposId");

            migrationBuilder.CreateIndex(
                name: "IX_AcessosGrupos_usuarioResponsavel",
                table: "AcessosGrupos",
                column: "usuarioResponsavel");

            migrationBuilder.CreateIndex(
                name: "IX_AcessosUsuarios_usuarioResponsavel",
                table: "AcessosUsuarios",
                column: "usuarioResponsavel");

            migrationBuilder.CreateIndex(
                name: "IX_AcessosUsuarios_usuariosId",
                table: "AcessosUsuarios",
                column: "usuariosId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriasProdutos_categoriasId",
                table: "CategoriasProdutos",
                column: "categoriasId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriasProdutos_usuarioResponsavel",
                table: "CategoriasProdutos",
                column: "usuarioResponsavel");

            migrationBuilder.CreateIndex(
                name: "IX_EntradaEstoque_unidadesId",
                table: "EntradaEstoque",
                column: "unidadesId");

            migrationBuilder.CreateIndex(
                name: "IX_EntradaEstoque_usuarioResponsavel",
                table: "EntradaEstoque",
                column: "usuarioResponsavel");

            migrationBuilder.CreateIndex(
                name: "IX_EstagiosPedido_estagiosId",
                table: "EstagiosPedido",
                column: "estagiosId");

            migrationBuilder.CreateIndex(
                name: "IX_EstagiosPedido_usuarioResponsavel",
                table: "EstagiosPedido",
                column: "usuarioResponsavel");

            migrationBuilder.CreateIndex(
                name: "IX_Estoque_unidadesId",
                table: "Estoque",
                column: "unidadesId");

            migrationBuilder.CreateIndex(
                name: "IX_Grupos_usuarioResponsavel",
                table: "Grupos",
                column: "usuarioResponsavel");

            migrationBuilder.CreateIndex(
                name: "IX_GruposUsuarios_usuarioResponsavel",
                table: "GruposUsuarios",
                column: "usuarioResponsavel");

            migrationBuilder.CreateIndex(
                name: "IX_GruposUsuarios_usuariosId",
                table: "GruposUsuarios",
                column: "usuariosId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedidos_produtosId",
                table: "ItensPedidos",
                column: "produtosId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_formaPagamentoId",
                table: "Pedidos",
                column: "formaPagamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_usuarioSolicitante",
                table: "Pedidos",
                column: "usuarioSolicitante");

            migrationBuilder.CreateIndex(
                name: "IX_PrecoProduto_usuarioResponsavel",
                table: "PrecoProduto",
                column: "usuarioResponsavel");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_usuarioResponsavel",
                table: "Produtos",
                column: "usuarioResponsavel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcessosGrupos");

            migrationBuilder.DropTable(
                name: "AcessosUsuarios");

            migrationBuilder.DropTable(
                name: "CategoriasProdutos");

            migrationBuilder.DropTable(
                name: "EntradaEstoque");

            migrationBuilder.DropTable(
                name: "EstagiosPedido");

            migrationBuilder.DropTable(
                name: "GruposUsuarios");

            migrationBuilder.DropTable(
                name: "ParticulariedadeItemPedido");

            migrationBuilder.DropTable(
                name: "PrecoProduto");

            migrationBuilder.DropTable(
                name: "Acessos");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Estoque");

            migrationBuilder.DropTable(
                name: "Estagios");

            migrationBuilder.DropTable(
                name: "Grupos");

            migrationBuilder.DropTable(
                name: "ItensPedidos");

            migrationBuilder.DropTable(
                name: "UnidadesMedida");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "FormaPagamento");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
