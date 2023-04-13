using System;
using System.Collections.Generic;

namespace webservice_api.model;

public partial class CategoriasProduto
{
    public int ProdutosId { get; set; }

    public int CategoriasId { get; set; }

    public int? UsuarioResponsavel { get; set; }

    public DateTime? DataCadastro { get; set; }

    public virtual Categoria Categorias { get; set; } = null!;

    public virtual Produto Produtos { get; set; } = null!;

    public virtual Usuario? UsuarioResponsavelNavigation { get; set; }
}
