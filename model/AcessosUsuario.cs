using System;
using System.Collections.Generic;

namespace webservice_api.model;

public partial class AcessosUsuario
{
    public int AcessosId { get; set; }

    public int UsuariosId { get; set; }

    public DateTime? DataLancamento { get; set; }

    public int? UsuarioResponsavel { get; set; }

    public virtual Acesso Acessos { get; set; } = null!;

    public virtual Usuario? UsuarioResponsavelNavigation { get; set; }

    public virtual Usuario Usuarios { get; set; } = null!;
}
