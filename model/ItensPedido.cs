using System;
using System.Collections.Generic;

namespace webservice_api.model;

public partial class ItensPedido
{
    public short PedidosAno { get; set; }

    public int PedidosId { get; set; }

    public int ProdutosId { get; set; }

    public decimal? Quantidade { get; set; }

    public int? UnidadesId { get; set; }

    public decimal? PrecoProduto { get; set; }

    public virtual ICollection<ParticulariedadeItemPedido> ParticulariedadeItemPedidos { get; set; } = new List<ParticulariedadeItemPedido>();

    public virtual Pedido Pedidos { get; set; } = null!;

    public virtual Produto Produtos { get; set; } = null!;
}
