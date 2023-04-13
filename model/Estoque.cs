using System;
using System.Collections.Generic;

namespace webservice_api.model;

public partial class Estoque
{
    public int ProdutosId { get; set; }

    public int Id { get; set; }

    public decimal? Saldo { get; set; }

    public int? UnidadesId { get; set; }

    public virtual ICollection<EntradaEstoque> EntradaEstoques { get; set; } = new List<EntradaEstoque>();

    public virtual Produto Produtos { get; set; } = null!;

    public virtual UnidadesMedida? Unidades { get; set; }
}
