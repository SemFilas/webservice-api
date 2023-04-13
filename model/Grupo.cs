using System;
using System.Collections.Generic;

namespace webservice_api.model;

public partial class Grupo
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public DateTime? DataCadastro { get; set; }

    public int? UsuarioResponsavel { get; set; }

    public virtual ICollection<AcessosGrupo> AcessosGrupos { get; set; } = new List<AcessosGrupo>();

    public virtual ICollection<GruposUsuario> GruposUsuarios { get; set; } = new List<GruposUsuario>();

    public virtual Usuario? UsuarioResponsavelNavigation { get; set; }
}
