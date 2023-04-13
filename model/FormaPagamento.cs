using System;
using System.Collections.Generic;

namespace webservice_api.model;

public partial class FormaPagamento
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public int? UsuarioResponsavel { get; set; }

    public DateTime? DataCadastro { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
