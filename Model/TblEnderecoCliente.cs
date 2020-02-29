using System;
using System.Collections.Generic;

namespace Model
{
    public partial class TblEnderecoCliente
    {
        public TblEnderecoCliente()
        {
            TblPedido = new HashSet<TblPedido>();
        }

        public int IdEnderecoCliente { get; set; }
        public int IdCliente { get; set; }
        public string TxEndereco { get; set; }

        public virtual TblCliente IdClienteNavigation { get; set; }
        public virtual ICollection<TblPedido> TblPedido { get; set; }
    }
}
