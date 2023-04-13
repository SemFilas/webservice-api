using System;
using System.Collections.Generic;

namespace webservice_api.model;

public partial class Categoria
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public int? UsuarioResponsavel { get; set; }

    public DateTime? DataCadastro { get; set; }

    public virtual ICollection<CategoriasProduto> CategoriasProdutos { get; set; } = new List<CategoriasProduto>();
}
