using System;
using System.Collections.Generic;

namespace Model
{
    public partial class TblProduto
    {
        public TblProduto()
        {
            TblPedidoItem = new HashSet<TblPedidoItem>();
        }

        public int IdProduto { get; set; }
        public string TxNome { get; set; }
        public string TxDescricao { get; set; }
        public decimal? NrPreco { get; set; }

        public virtual ICollection<TblPedidoItem> TblPedidoItem { get; set; }
    }
}
