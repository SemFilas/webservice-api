using System;
using System.Collections.Generic;

namespace webservice_api.model;

public partial class EntradaEstoque
{
    public int ProdutosId { get; set; }

    public int EstoqueId { get; set; }

    public int Id { get; set; }

    public decimal? Quantidade { get; set; }

    public int? UnidadesId { get; set; }

    public int? UsuarioResponsavel { get; set; }

    public DateTime? DataEntrada { get; set; }

    public virtual Estoque Estoque { get; set; } = null!;

    public virtual UnidadesMedida? Unidades { get; set; }

    public virtual Usuario? UsuarioResponsavelNavigation { get; set; }
}
