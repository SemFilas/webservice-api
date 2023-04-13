using System;
using System.Collections.Generic;

namespace webservice_api.model;

public partial class Produto
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public string? Descricao { get; set; }

    public string? CaminhoFoto { get; set; }

    public string? Situacao { get; set; }

    public DateTime? DataCadastro { get; set; }

    public int? UsuarioResponsavel { get; set; }

    public virtual ICollection<CategoriasProduto> CategoriasProdutos { get; set; } = new List<CategoriasProduto>();

    public virtual ICollection<Estoque> Estoques { get; set; } = new List<Estoque>();

    public virtual ICollection<ItensPedido> ItensPedidos { get; set; } = new List<ItensPedido>();

    public virtual ICollection<PrecoProduto> PrecoProdutos { get; set; } = new List<PrecoProduto>();

    public virtual Usuario? UsuarioResponsavelNavigation { get; set; }
}
