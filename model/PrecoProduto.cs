using System;
using System.Collections.Generic;

namespace webservice_api.model;

public partial class PrecoProduto
{
    public int ProdutosId { get; set; }

    public int Id { get; set; }

    public decimal? Preco { get; set; }

    public int? UsuarioResponsavel { get; set; }

    public DateTime? DataLancamento { get; set; }

    public virtual Produto Produtos { get; set; } = null!;

    public virtual Usuario? UsuarioResponsavelNavigation { get; set; }
}
