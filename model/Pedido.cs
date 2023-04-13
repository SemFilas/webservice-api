using System;
using System.Collections.Generic;

namespace webservice_api.model;

public partial class Pedido
{
    public short Ano { get; set; }

    public int Id { get; set; }

    public int? FormaPagamentoId { get; set; }

    public DateTime? HorarioRetirada { get; set; }

    public int? UsuarioSolicitante { get; set; }

    public DateTime? DataSolicitante { get; set; }

    public virtual ICollection<EstagiosPedido> EstagiosPedidos { get; set; } = new List<EstagiosPedido>();

    public virtual FormaPagamento? FormaPagamento { get; set; }

    public virtual ICollection<ItensPedido> ItensPedidos { get; set; } = new List<ItensPedido>();

    public virtual Usuario? UsuarioSolicitanteNavigation { get; set; }
}
