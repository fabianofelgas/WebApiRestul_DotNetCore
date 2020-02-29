using System;
using Model;
using System.Linq;
using System.Collections.Generic;

namespace DAO
{
    public class Cliente
    {
        public TblCliente GetClienteById(int idCliente)
        {
            using (BDDotNetCore_GraphQLContext db = new BDDotNetCore_GraphQLContext())
            {
                var cliente = (from c in db.TblCliente
                                where c.IdCliente == idCliente
                                select c).SingleOrDefault();
                
                return cliente ?? new TblCliente();
            }
        }

        public List<TblCliente> getClienteByName(string nome)
        {
            using (var db = new BDDotNetCore_GraphQLContext())
            {
                var cliente = (from c in db.TblCliente
                              where c.TxNome.Contains(nome)
                              select c).ToList();

                return cliente;
            }
        }

        public TblCliente getClienteByCPF_CNPJ(string cpf_cnpj)
        {
            using (var db = new BDDotNetCore_GraphQLContext())
            {
                var cliente = (from c in db.TblCliente
                            where c.TxCpfCnpj == cpf_cnpj
                            select c).Single();
                
                return cliente;
            }
        }

        public void addCliente(TblCliente cliente)
        {
            using (var db = new BDDotNetCore_GraphQLContext())
            {
                try
                {
                db.TblCliente.Add(cliente);
                db.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new Exception("Um problema impediu inserir o registro de Cliente. \n Analise a excessão para obter maiores detalhes. \n" + e.Message);
                }
            }
        }

        public void updateCliente(TblCliente cliente)
        {
            using (var db = new BDDotNetCore_GraphQLContext())
            {
                db.TblCliente.Update(cliente);
                db.SaveChanges();                
            }
        }

        public List<TblEnderecoCliente> getEnderecoCliente(int idCliente)
        {
            using (var db = new BDDotNetCore_GraphQLContext())
            {
                var endereco = (from ec in db.TblEnderecoCliente
                                where ec.IdCliente == idCliente
                                select ec).ToList();
                return endereco;
            }
        }
    }
}
