using System;
using System.Collections.Generic;

namespace Model
{
    public partial class TblStatusPedido
    {
        public TblStatusPedido()
        {
            TblPedido = new HashSet<TblPedido>();
        }

        public int IdStatusPedido { get; set; }
        public string TxDescricao { get; set; }

        public virtual ICollection<TblPedido> TblPedido { get; set; }
    }
}
