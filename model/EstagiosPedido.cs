using System;
using System.Collections.Generic;

namespace webservice_api.model;

public partial class EstagiosPedido
{
    public short PedidosAno { get; set; }

    public int PedidosId { get; set; }

    public int EstagiosId { get; set; }

    public DateTime DataLancamento { get; set; }

    public int? UsuarioResponsavel { get; set; }

    public virtual Estagio Estagios { get; set; } = null!;

    public virtual Pedido Pedidos { get; set; } = null!;

    public virtual Usuario? UsuarioResponsavelNavigation { get; set; }
}
