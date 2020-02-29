using System;
using System.Collections.Generic;

namespace Model
{
    public partial class TblCliente
    {
        public TblCliente()
        {
            TblEnderecoCliente = new HashSet<TblEnderecoCliente>();
            TblPedido = new HashSet<TblPedido>();
        }

        public int IdCliente { get; set; }
        public string TxNome { get; set; }
        public string TxCpfCnpj { get; set; }
        public string TxEmail { get; set; }
        public string TxTipoPessoa { get; set; }
        public DateTime DtCliente { get; set; }

        public virtual ICollection<TblEnderecoCliente> TblEnderecoCliente { get; set; }
        public virtual ICollection<TblPedido> TblPedido { get; set; }
    }
}
