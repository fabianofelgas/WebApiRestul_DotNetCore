using System;
using DAO;
using Model;

namespace Business
{
    public class Cliente
    {
        public TblCliente GetClienteById(int idCliente)
        {
            return new DAO.Cliente().GetClienteById(idCliente);
        }

        public void addCliente(TblCliente cliente)
        {
            new DAO.Cliente().addCliente(cliente);
        }
    }
}
