using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTelefoneBD
{
    internal class Banco
    {
        string Conexao = "Data Source=192.168.25.7; Initial Catalog=AgendaTelefone; User Id=pestana; Password=P35t4n40;";

        public Banco()
        {
        
        }
        public string Caminho()
        {
            return Conexao;
        }
    }
}
