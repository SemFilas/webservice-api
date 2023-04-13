using System;
using System.Collections.Generic;

namespace webservice_api.model;

public partial class UnidadesMedida
{
    public int Id { get; set; }

    public string? Unidade { get; set; }

    public string? Simbolo { get; set; }

    public string? Grandeza { get; set; }

    public virtual ICollection<EntradaEstoque> EntradaEstoques { get; set; } = new List<EntradaEstoque>();

    public virtual ICollection<Estoque> Estoques { get; set; } = new List<Estoque>();
}
