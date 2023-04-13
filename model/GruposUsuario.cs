using System;
using System.Collections.Generic;

namespace webservice_api.model;

public partial class GruposUsuario
{
    public int GruposId { get; set; }

    public int UsuariosId { get; set; }

    public DateTime? DataCadastro { get; set; }

    public int? UsuarioResponsavel { get; set; }

    public virtual Grupo Grupos { get; set; } = null!;

    public virtual Usuario? UsuarioResponsavelNavigation { get; set; }

    public virtual Usuario Usuarios { get; set; } = null!;
}
