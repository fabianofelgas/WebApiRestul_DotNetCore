using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Model
{
    public partial class BDDotNetCore_GraphQLContext : DbContext
    {
        public BDDotNetCore_GraphQLContext()
        {
        }

        public BDDotNetCore_GraphQLContext(DbContextOptions<BDDotNetCore_GraphQLContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblCliente> TblCliente { get; set; }
        public virtual DbSet<TblEnderecoCliente> TblEnderecoCliente { get; set; }
        public virtual DbSet<TblPedido> TblPedido { get; set; }
        public virtual DbSet<TblPedidoItem> TblPedidoItem { get; set; }
        public virtual DbSet<TblProduto> TblProduto { get; set; }
        public virtual DbSet<TblStatusPedido> TblStatusPedido { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=FABIANO-ACER\\SQLEXPRESS;Database=BDDotNetCore_GraphQL;Trusted_Connection=False; Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblCliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__tblClien__E005FBFF01387B90");

                entity.ToTable("tblCliente");

                entity.Property(e => e.IdCliente).HasColumnName("ID_Cliente");

                entity.Property(e => e.DtCliente)
                    .HasColumnName("DT_Cliente")
                    .HasColumnType("datetime");

                entity.Property(e => e.TxCpfCnpj)
                    .IsRequired()
                    .HasColumnName("TX_CPF_CNPJ")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.TxEmail)
                    .IsRequired()
                    .HasColumnName("TX_Email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TxNome)
                    .IsRequired()
                    .HasColumnName("TX_Nome")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TxTipoPessoa)
                    .IsRequired()
                    .HasColumnName("TX_TipoPessoa")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TblEnderecoCliente>(entity =>
            {
                entity.HasKey(e => e.IdEnderecoCliente)
                    .HasName("PK__tblEnder__1E0AEA07DB5F51FD");

                entity.ToTable("tblEnderecoCliente");

                entity.Property(e => e.IdEnderecoCliente).HasColumnName("ID_EnderecoCliente");

                entity.Property(e => e.IdCliente).HasColumnName("ID_Cliente");

                entity.Property(e => e.TxEndereco)
                    .IsRequired()
                    .HasColumnName("TX_Endereco")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.TblEnderecoCliente)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblEndere__ID_Cl__398D8EEE");
            });

            modelBuilder.Entity<TblPedido>(entity =>
            {
                entity.HasKey(e => e.IdPedido)
                    .HasName("PK__tblPedid__FD768070937ECBCD");

                entity.ToTable("tblPedido");

                entity.Property(e => e.IdPedido).HasColumnName("ID_Pedido");

                entity.Property(e => e.DtEntrega)
                    .HasColumnName("DT_Entrega")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtPedido)
                    .HasColumnName("DT_Pedido")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtRecebimendto)
                    .HasColumnName("DT_Recebimendto")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdCliente).HasColumnName("ID_Cliente");

                entity.Property(e => e.IdEnderecoEntrega).HasColumnName("ID_EnderecoEntrega");

                entity.Property(e => e.IdStatusPedido).HasColumnName("ID_StatusPedido");

                entity.Property(e => e.NrPercentualDesconto).HasColumnName("NR_PercentualDesconto");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.TblPedido)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblPedido__ID_Cl__3F466844");

                entity.HasOne(d => d.IdEnderecoEntregaNavigation)
                    .WithMany(p => p.TblPedido)
                    .HasForeignKey(d => d.IdEnderecoEntrega)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblPedido__ID_En__3E52440B");

                entity.HasOne(d => d.IdStatusPedidoNavigation)
                    .WithMany(p => p.TblPedido)
                    .HasForeignKey(d => d.IdStatusPedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblPedido__ID_St__403A8C7D");
            });

            modelBuilder.Entity<TblPedidoItem>(entity =>
            {
                entity.HasKey(e => e.IdPedidoItem)
                    .HasName("PK__tblPedid__B07C3F93AB355582");

                entity.ToTable("tblPedidoItem");

                entity.Property(e => e.IdPedidoItem).HasColumnName("ID_PedidoItem");

                entity.Property(e => e.IdPedido).HasColumnName("ID_Pedido");

                entity.Property(e => e.IdProduto).HasColumnName("ID_Produto");

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.TblPedidoItem)
                    .HasForeignKey(d => d.IdPedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblPedido__ID_Pe__44FF419A");

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany(p => p.TblPedidoItem)
                    .HasForeignKey(d => d.IdProduto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblPedido__ID_Pr__45F365D3");
            });

            modelBuilder.Entity<TblProduto>(entity =>
            {
                entity.HasKey(e => e.IdProduto)
                    .HasName("PK__tblProdu__525292A17DFFF838");

                entity.ToTable("tblProduto");

                entity.Property(e => e.IdProduto).HasColumnName("ID_Produto");

                entity.Property(e => e.NrPreco)
                    .HasColumnName("NR_Preco")
                    .HasColumnType("decimal(15, 2)");

                entity.Property(e => e.TxDescricao)
                    .HasColumnName("TX_Descricao")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.TxNome)
                    .IsRequired()
                    .HasColumnName("TX_Nome")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblStatusPedido>(entity =>
            {
                entity.HasKey(e => e.IdStatusPedido)
                    .HasName("PK__tblStatu__E8471B90AC231234");

                entity.ToTable("tblStatusPedido");

                entity.Property(e => e.IdStatusPedido).HasColumnName("ID_StatusPedido");

                entity.Property(e => e.TxDescricao)
                    .HasColumnName("TX_Descricao")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
