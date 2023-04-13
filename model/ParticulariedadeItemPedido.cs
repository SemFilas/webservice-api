using System;
using System.Collections.Generic;

namespace webservice_api.model;

public partial class ParticulariedadeItemPedido
{
    public short PedidosAno { get; set; }

    public int PedidosId { get; set; }

    public int ProdutosId { get; set; }

    public int Id { get; set; }

    public string? Particulariedade { get; set; }

    public virtual ItensPedido P { get; set; } = null!;
}
