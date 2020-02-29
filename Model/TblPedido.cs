using System;
using System.Collections.Generic;

namespace Model
{
    public partial class TblPedido
    {
        public TblPedido()
        {
            TblPedidoItem = new HashSet<TblPedidoItem>();
        }

        public int IdPedido { get; set; }
        public DateTime DtPedido { get; set; }
        public DateTime DtEntrega { get; set; }
        public DateTime? DtRecebimendto { get; set; }
        public int IdEnderecoEntrega { get; set; }
        public int IdCliente { get; set; }
        public int IdStatusPedido { get; set; }
        public int? NrPercentualDesconto { get; set; }

        public virtual TblCliente IdClienteNavigation { get; set; }
        public virtual TblEnderecoCliente IdEnderecoEntregaNavigation { get; set; }
        public virtual TblStatusPedido IdStatusPedidoNavigation { get; set; }
        public virtual ICollection<TblPedidoItem> TblPedidoItem { get; set; }
    }
}
