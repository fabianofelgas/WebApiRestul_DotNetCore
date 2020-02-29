using System;
using System.Collections.Generic;

namespace Model
{
    public partial class TblPedidoItem
    {
        public int IdPedidoItem { get; set; }
        public int IdPedido { get; set; }
        public int IdProduto { get; set; }

        public virtual TblPedido IdPedidoNavigation { get; set; }
        public virtual TblProduto IdProdutoNavigation { get; set; }
    }
}
