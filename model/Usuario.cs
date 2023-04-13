﻿using System;
using System.Collections.Generic;

namespace webservice_api.model;

public partial class Usuario
{
    /// <summary>
    /// Identificação do usuário
    /// </summary>
    public int Id { get; set; }

    public string? Nome { get; set; }

    public string? Tratamento { get; set; }

    public DateTime? DataNascimento { get; set; }

    public DateTime? DataCadastro { get; set; }

    public string? Sexo { get; set; }

    public string? Email { get; set; }

    public string? Salt { get; set; }

    public string? Hash { get; set; }

    public virtual ICollection<Acesso> Acessos { get; set; } = new List<Acesso>();

    public virtual ICollection<AcessosGrupo> AcessosGrupos { get; set; } = new List<AcessosGrupo>();

    public virtual ICollection<AcessosUsuario> AcessosUsuarioUsuarioResponsavelNavigations { get; set; } = new List<AcessosUsuario>();

    public virtual ICollection<AcessosUsuario> AcessosUsuarioUsuarios { get; set; } = new List<AcessosUsuario>();

    public virtual ICollection<CategoriasProduto> CategoriasProdutos { get; set; } = new List<CategoriasProduto>();

    public virtual ICollection<EntradaEstoque> EntradaEstoques { get; set; } = new List<EntradaEstoque>();

    public virtual ICollection<EstagiosPedido> EstagiosPedidos { get; set; } = new List<EstagiosPedido>();

    public virtual ICollection<Grupo> Grupos { get; set; } = new List<Grupo>();

    public virtual ICollection<GruposUsuario> GruposUsuarioUsuarioResponsavelNavigations { get; set; } = new List<GruposUsuario>();

    public virtual ICollection<GruposUsuario> GruposUsuarioUsuarios { get; set; } = new List<GruposUsuario>();

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

    public virtual ICollection<PrecoProduto> PrecoProdutos { get; set; } = new List<PrecoProduto>();

    public virtual ICollection<Produto> Produtos { get; set; } = new List<Produto>();
}
