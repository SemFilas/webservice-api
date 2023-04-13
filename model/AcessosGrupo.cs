using System;
using System.Collections.Generic;

namespace webservice_api.model;

public partial class AcessosGrupo
{
    public int AcessosId { get; set; }

    public int GruposId { get; set; }

    public DateTime? DataLancamento { get; set; }

    public int? UsuarioResponsavel { get; set; }

    public virtual Acesso Acessos { get; set; } = null!;

    public virtual Grupo Grupos { get; set; } = null!;

    public virtual Usuario? UsuarioResponsavelNavigation { get; set; }
}
