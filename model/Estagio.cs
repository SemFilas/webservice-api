using System;
using System.Collections.Generic;

namespace webservice_api.model;

public partial class Estagio
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public string? EstagioPadrao { get; set; }

    public int? ProximoEstagio { get; set; }

    public int? UsuarioResponsavel { get; set; }

    public DateTime? DataCadastro { get; set; }

    public virtual ICollection<EstagiosPedido> EstagiosPedidos { get; set; } = new List<EstagiosPedido>();
}
