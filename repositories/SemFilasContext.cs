using Microsoft.EntityFrameworkCore;
using webservice_api.model;

namespace webservice_api.repositories;

public partial class SemFilasContext : DbContext
{

    public SemFilasContext(DbContextOptions<SemFilasContext> options) : base(options) {
        
    }

    public virtual DbSet<Acesso> Acessos { get; set; }

    public virtual DbSet<AcessosGrupo> AcessosGrupos { get; set; }

    public virtual DbSet<AcessosUsuario> AcessosUsuarios { get; set; }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<CategoriasProduto> CategoriasProdutos { get; set; }

    public virtual DbSet<EntradaEstoque> EntradaEstoques { get; set; }

    public virtual DbSet<Estagio> Estagios { get; set; }

    public virtual DbSet<EstagiosPedido> EstagiosPedidos { get; set; }

    public virtual DbSet<Estoque> Estoques { get; set; }

    public virtual DbSet<FormaPagamento> FormaPagamentos { get; set; }

    public virtual DbSet<Grupo> Grupos { get; set; }

    public virtual DbSet<GruposUsuario> GruposUsuarios { get; set; }

    public virtual DbSet<ItensPedido> ItensPedidos { get; set; }

    public virtual DbSet<ParticulariedadeItemPedido> ParticulariedadeItemPedidos { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<PrecoProduto> PrecoProdutos { get; set; }

    public virtual DbSet<Produto> Produtos { get; set; }

    public virtual DbSet<UnidadesMedida> UnidadesMedida { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Acesso>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("int")
                .HasColumnName("id");
            entity.Property(e => e.DataCadastro)
                .HasColumnType("datetime")
                .HasColumnName("dataCadastro");
            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.UsuarioResponsavel)
                .HasColumnType("int")
                .HasColumnName("usuarioResponsavel");

            entity.HasOne(d => d.UsuarioResponsavelNavigation).WithMany(p => p.Acessos)
                .HasForeignKey(d => d.UsuarioResponsavel)
                .HasConstraintName("FK_Acessos_Usuarios");
        });

        modelBuilder.Entity<AcessosGrupo>(entity =>
        {
            entity.HasKey(e => new { e.AcessosId, e.GruposId });

            entity.Property(e => e.AcessosId)
                .HasColumnType("int")
                .HasColumnName("acessosId");
            entity.Property(e => e.GruposId)
                .HasColumnType("int")
                .HasColumnName("gruposId");
            entity.Property(e => e.DataLancamento)
                .HasColumnType("datetime")
                .HasColumnName("dataLancamento");
            entity.Property(e => e.UsuarioResponsavel)
                .HasColumnType("int")
                .HasColumnName("usuarioResponsavel");

            entity.HasOne(d => d.Acessos).WithMany(p => p.AcessosGrupos)
                .HasForeignKey(d => d.AcessosId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AcessosGrupos_Acessos");

            entity.HasOne(d => d.Grupos).WithMany(p => p.AcessosGrupos)
                .HasForeignKey(d => d.GruposId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AcessosGrupos_Grupos");

            entity.HasOne(d => d.UsuarioResponsavelNavigation).WithMany(p => p.AcessosGrupos)
                .HasForeignKey(d => d.UsuarioResponsavel)
                .HasConstraintName("FK_AcessosGrupos_Usuarios");
        });

        modelBuilder.Entity<AcessosUsuario>(entity =>
        {
            entity.HasKey(e => new { e.AcessosId, e.UsuariosId });

            entity.Property(e => e.AcessosId)
                .HasColumnType("int")
                .HasColumnName("acessosId");
            entity.Property(e => e.UsuariosId)
                .HasColumnType("int")
                .HasColumnName("usuariosId");
            entity.Property(e => e.DataLancamento)
                .HasColumnType("datetime")
                .HasColumnName("dataLancamento");
            entity.Property(e => e.UsuarioResponsavel)
                .HasColumnType("int")
                .HasColumnName("usuarioResponsavel");

            entity.HasOne(d => d.Acessos).WithMany(p => p.AcessosUsuarios)
                .HasForeignKey(d => d.AcessosId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AcessosUsuarios_Acessos");

            entity.HasOne(d => d.UsuarioResponsavelNavigation).WithMany(p => p.AcessosUsuarioUsuarioResponsavelNavigations)
                .HasForeignKey(d => d.UsuarioResponsavel)
                .HasConstraintName("FK_AcessosUsuarios_Usuarios1");

            entity.HasOne(d => d.Usuarios).WithMany(p => p.AcessosUsuarioUsuarios)
                .HasForeignKey(d => d.UsuariosId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AcessosUsuarios_Usuarios");
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("int")
                .HasColumnName("id");
            entity.Property(e => e.DataCadastro)
                .HasColumnType("datetime")
                .HasColumnName("dataCadastro");
            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.UsuarioResponsavel)
                .HasColumnType("int")
                .HasColumnName("usuarioResponsavel");
        });

        modelBuilder.Entity<CategoriasProduto>(entity =>
        {
            entity.HasKey(e => new { e.ProdutosId, e.CategoriasId });

            entity.Property(e => e.ProdutosId)
                .HasColumnType("int")
                .HasColumnName("produtosId");
            entity.Property(e => e.CategoriasId)
                .HasColumnType("int")
                .HasColumnName("categoriasId");
            entity.Property(e => e.DataCadastro)
                .HasColumnType("datetime")
                .HasColumnName("dataCadastro");
            entity.Property(e => e.UsuarioResponsavel)
                .HasColumnType("int")
                .HasColumnName("usuarioResponsavel");

            entity.HasOne(d => d.Categorias).WithMany(p => p.CategoriasProdutos)
                .HasForeignKey(d => d.CategoriasId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CategoriasProdutos_Categorias");

            entity.HasOne(d => d.Produtos).WithMany(p => p.CategoriasProdutos)
                .HasForeignKey(d => d.ProdutosId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CategoriasProdutos_Produtos");

            entity.HasOne(d => d.UsuarioResponsavelNavigation).WithMany(p => p.CategoriasProdutos)
                .HasForeignKey(d => d.UsuarioResponsavel)
                .HasConstraintName("FK_CategoriasProdutos_Usuarios");
        });

        modelBuilder.Entity<EntradaEstoque>(entity =>
        {
            entity.HasKey(e => new { e.ProdutosId, e.EstoqueId, e.Id });

            entity.ToTable("EntradaEstoque");

            entity.Property(e => e.ProdutosId)
                .HasColumnType("int")
                .HasColumnName("produtosId");
            entity.Property(e => e.EstoqueId)
                .HasColumnType("int")
                .HasColumnName("estoqueId");
            entity.Property(e => e.Id)
                .HasColumnType("int")
                .HasColumnName("id");
            entity.Property(e => e.DataEntrada)
                .HasColumnType("datetime")
                .HasColumnName("dataEntrada");
            entity.Property(e => e.Quantidade)
                .HasColumnType("decimal(10, 4)")
                .HasColumnName("quantidade");
            entity.Property(e => e.UnidadesId)
                .HasColumnType("int")
                .HasColumnName("unidadesId");
            entity.Property(e => e.UsuarioResponsavel)
                .HasColumnType("int")
                .HasColumnName("usuarioResponsavel");

            entity.HasOne(d => d.Unidades).WithMany(p => p.EntradaEstoques)
                .HasForeignKey(d => d.UnidadesId)
                .HasConstraintName("FK_EntradaEstoque_UnidadesMedida");

            entity.HasOne(d => d.UsuarioResponsavelNavigation).WithMany(p => p.EntradaEstoques)
                .HasForeignKey(d => d.UsuarioResponsavel)
                .HasConstraintName("FK_EntradaEstoque_Usuarios");

            entity.HasOne(d => d.Estoque).WithMany(p => p.EntradaEstoques)
                .HasForeignKey(d => new { d.ProdutosId, d.EstoqueId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EntradaEstoque_Estoque");
        });

        modelBuilder.Entity<Estagio>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("int")
                .HasColumnName("id");
            entity.Property(e => e.DataCadastro)
                .HasColumnType("datetime")
                .HasColumnName("dataCadastro");
            entity.Property(e => e.EstagioPadrao)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("estagioPadrao");
            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.ProximoEstagio)
                .HasColumnType("int")
                .HasColumnName("proximoEstagio");
            entity.Property(e => e.UsuarioResponsavel)
                .HasColumnType("int")
                .HasColumnName("usuarioResponsavel");
        });

        modelBuilder.Entity<EstagiosPedido>(entity =>
        {
            entity.HasKey(e => new { e.PedidosAno, e.PedidosId, e.EstagiosId, e.DataLancamento });

            entity.ToTable("EstagiosPedido");

            entity.Property(e => e.PedidosAno).HasColumnName("pedidosAno");
            entity.Property(e => e.PedidosId)
                .HasColumnType("int")
                .HasColumnName("pedidosId");
            entity.Property(e => e.EstagiosId)
                .HasColumnType("int")
                .HasColumnName("estagiosId");
            entity.Property(e => e.DataLancamento)
                .HasColumnType("datetime")
                .HasColumnName("dataLancamento");
            entity.Property(e => e.UsuarioResponsavel)
                .HasColumnType("int")
                .HasColumnName("usuarioResponsavel");

            entity.HasOne(d => d.Estagios).WithMany(p => p.EstagiosPedidos)
                .HasForeignKey(d => d.EstagiosId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EstagiosPedido_EstagiosPedido");

            entity.HasOne(d => d.UsuarioResponsavelNavigation).WithMany(p => p.EstagiosPedidos)
                .HasForeignKey(d => d.UsuarioResponsavel)
                .HasConstraintName("FK_EstagiosPedido_Usuarios");

            entity.HasOne(d => d.Pedidos).WithMany(p => p.EstagiosPedidos)
                .HasForeignKey(d => new { d.PedidosAno, d.PedidosId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EstagiosPedido_Pedidos");
        });

        modelBuilder.Entity<Estoque>(entity =>
        {
            entity.HasKey(e => new { e.ProdutosId, e.Id });

            entity.ToTable("Estoque");

            entity.Property(e => e.ProdutosId)
                .HasColumnType("int")
                .HasColumnName("produtosId");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("int")
                .HasColumnName("id");
            entity.Property(e => e.Saldo)
                .HasColumnType("decimal(10, 4)")
                .HasColumnName("saldo");
            entity.Property(e => e.UnidadesId)
                .HasColumnType("int")
                .HasColumnName("unidadesId");

            entity.HasOne(d => d.Produtos).WithMany(p => p.Estoques)
                .HasForeignKey(d => d.ProdutosId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Estoque_Produtos");

            entity.HasOne(d => d.Unidades).WithMany(p => p.Estoques)
                .HasForeignKey(d => d.UnidadesId)
                .HasConstraintName("FK_Estoque_UnidadesMedida");
        });

        modelBuilder.Entity<FormaPagamento>(entity =>
        {
            entity.ToTable("FormaPagamento");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("int")
                .HasColumnName("id");
            entity.Property(e => e.DataCadastro)
                .HasColumnType("datetime")
                .HasColumnName("dataCadastro");
            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.UsuarioResponsavel)
                .HasColumnType("int")
                .HasColumnName("usuarioResponsavel");
        });

        modelBuilder.Entity<Grupo>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("int")
                .HasColumnName("id");
            entity.Property(e => e.DataCadastro)
                .HasColumnType("datetime")
                .HasColumnName("dataCadastro");
            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.UsuarioResponsavel)
                .HasColumnType("int")
                .HasColumnName("usuarioResponsavel");

            entity.HasOne(d => d.UsuarioResponsavelNavigation).WithMany(p => p.Grupos)
                .HasForeignKey(d => d.UsuarioResponsavel)
                .HasConstraintName("FK_Grupos_Usuarios");
        });

        modelBuilder.Entity<GruposUsuario>(entity =>
        {
            entity.HasKey(e => new { e.GruposId, e.UsuariosId });

            entity.Property(e => e.GruposId)
                .HasColumnType("int")
                .HasColumnName("gruposId");
            entity.Property(e => e.UsuariosId)
                .HasColumnType("int")
                .HasColumnName("usuariosId");
            entity.Property(e => e.DataCadastro)
                .HasColumnType("datetime")
                .HasColumnName("dataCadastro");
            entity.Property(e => e.UsuarioResponsavel)
                .HasColumnType("int")
                .HasColumnName("usuarioResponsavel");

            entity.HasOne(d => d.Grupos).WithMany(p => p.GruposUsuarios)
                .HasForeignKey(d => d.GruposId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GruposUsuarios_Grupos");

            entity.HasOne(d => d.UsuarioResponsavelNavigation).WithMany(p => p.GruposUsuarioUsuarioResponsavelNavigations)
                .HasForeignKey(d => d.UsuarioResponsavel)
                .HasConstraintName("FK_GruposUsuarios_Usuarios1");

            entity.HasOne(d => d.Usuarios).WithMany(p => p.GruposUsuarioUsuarios)
                .HasForeignKey(d => d.UsuariosId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GruposUsuarios_Usuarios");
        });

        modelBuilder.Entity<ItensPedido>(entity =>
        {
            entity.HasKey(e => new { e.PedidosAno, e.PedidosId, e.ProdutosId });

            entity.Property(e => e.PedidosAno).HasColumnName("pedidosAno");
            entity.Property(e => e.PedidosId)
                .HasColumnType("int")
                .HasColumnName("pedidosId");
            entity.Property(e => e.ProdutosId)
                .HasColumnType("int")
                .HasColumnName("produtosId");
            entity.Property(e => e.PrecoProduto)
                .HasColumnType("decimal(10, 5)")
                .HasColumnName("precoProduto");
            entity.Property(e => e.Quantidade)
                .HasColumnType("decimal(10, 4)")
                .HasColumnName("quantidade");
            entity.Property(e => e.UnidadesId)
                .HasColumnType("int")
                .HasColumnName("unidadesId");

            entity.HasOne(d => d.Produtos).WithMany(p => p.ItensPedidos)
                .HasForeignKey(d => d.ProdutosId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ItensPedidos_Produtos");

            entity.HasOne(d => d.Pedidos).WithMany(p => p.ItensPedidos)
                .HasForeignKey(d => new { d.PedidosAno, d.PedidosId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ItensPedidos_ItensPedidos");
        });

        modelBuilder.Entity<ParticulariedadeItemPedido>(entity =>
        {
            entity.HasKey(e => new { e.PedidosAno, e.PedidosId, e.ProdutosId, e.Id });

            entity.ToTable("ParticulariedadeItemPedido");

            entity.Property(e => e.PedidosAno).HasColumnName("pedidosAno");
            entity.Property(e => e.PedidosId)
                .HasColumnType("int")
                .HasColumnName("pedidosId");
            entity.Property(e => e.ProdutosId)
                .HasColumnType("int")
                .HasColumnName("produtosId");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("int")
                .HasColumnName("id");
            entity.Property(e => e.Particulariedade)
                .HasColumnType("text")
                .HasColumnName("particulariedade");

            entity.HasOne(d => d.P).WithMany(p => p.ParticulariedadeItemPedidos)
                .HasForeignKey(d => new { d.PedidosAno, d.PedidosId, d.ProdutosId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ParticulariedadeItemPedido_ItensPedidos");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => new { e.Ano, e.Id });

            entity.Property(e => e.Ano).HasColumnName("ano");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("int")
                .HasColumnName("id");
            entity.Property(e => e.DataSolicitante)
                .HasColumnType("datetime")
                .HasColumnName("dataSolicitante");
            entity.Property(e => e.FormaPagamentoId)
                .HasColumnType("int")
                .HasColumnName("formaPagamentoId");
            entity.Property(e => e.HorarioRetirada)
                .HasColumnType("datetime")
                .HasColumnName("horarioRetirada");
            entity.Property(e => e.UsuarioSolicitante)
                .HasColumnType("int")
                .HasColumnName("usuarioSolicitante");

            entity.HasOne(d => d.FormaPagamento).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.FormaPagamentoId)
                .HasConstraintName("FK_Pedidos_Pedidos");

            entity.HasOne(d => d.UsuarioSolicitanteNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.UsuarioSolicitante)
                .HasConstraintName("FK_Pedidos_Usuarios");
        });

        modelBuilder.Entity<PrecoProduto>(entity =>
        {
            entity.HasKey(e => new { e.ProdutosId, e.Id });

            entity.ToTable("PrecoProduto");

            entity.Property(e => e.ProdutosId)
                .HasColumnType("int")
                .HasColumnName("produtosId");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("int")
                .HasColumnName("id");
            entity.Property(e => e.DataLancamento)
                .HasColumnType("datetime")
                .HasColumnName("dataLancamento");
            entity.Property(e => e.Preco)
                .HasColumnType("decimal(10, 5)")
                .HasColumnName("preco");
            entity.Property(e => e.UsuarioResponsavel)
                .HasColumnType("int")
                .HasColumnName("usuarioResponsavel");

            entity.HasOne(d => d.Produtos).WithMany(p => p.PrecoProdutos)
                .HasForeignKey(d => d.ProdutosId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PrecoProduto_Produtos");

            entity.HasOne(d => d.UsuarioResponsavelNavigation).WithMany(p => p.PrecoProdutos)
                .HasForeignKey(d => d.UsuarioResponsavel)
                .HasConstraintName("FK_PrecoProduto_Usuarios");
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("int")
                .HasColumnName("id");
            entity.Property(e => e.CaminhoFoto)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("caminhoFoto");
            entity.Property(e => e.DataCadastro)
                .HasColumnType("datetime")
                .HasColumnName("dataCadastro");
            entity.Property(e => e.Descricao)
                .HasColumnType("text")
                .HasColumnName("descricao");
            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.Situacao)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("situacao");
            entity.Property(e => e.UsuarioResponsavel)
                .HasColumnType("int")
                .HasColumnName("usuarioResponsavel");

            entity.HasOne(d => d.UsuarioResponsavelNavigation).WithMany(p => p.Produtos)
                .HasForeignKey(d => d.UsuarioResponsavel)
                .HasConstraintName("FK_Produtos_Usuarios");
        });

        modelBuilder.Entity<UnidadesMedida>(entity =>
        {
            entity.Property(e => e.Id)
                .HasColumnType("int")
                .HasColumnName("id");
            entity.Property(e => e.Grandeza)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("grandeza");
            entity.Property(e => e.Simbolo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("simbolo");
            entity.Property(e => e.Unidade)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("unidade");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasComment("Identificação do usuário")
                .HasColumnType("int")
                .HasColumnName("id");
            entity.Property(e => e.DataCadastro)
                .HasColumnType("datetime")
                .HasColumnName("dataCadastro");
            entity.Property(e => e.DataNascimento)
                .HasColumnType("date")
                .HasColumnName("dataNascimento");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Hash)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("hash");
            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.Salt)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("salt");
            entity.Property(e => e.Sexo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("sexo");
            entity.Property(e => e.Tratamento)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("tratamento");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
