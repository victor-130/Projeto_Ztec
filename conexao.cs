using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;//usa o forms
//usa o mysq
using MySql.Data.MySqlClient;

namespace Projeto01
{
    internal class conexao
    {
        public string conec = "SERVER = localhost; DATABASE = aula; UID = root;PWD = ;PORT = ;";

        public MySqlConnection con = null;

        //abrir conexao
        public void abrirConexao()
        {
            //testar conexao
            try
            {
                con = new MySqlConnection(conec);
                con.Open();
            }
            catch (Exception ex)
            {
                //erro
                MessageBox.Show("Erro no servidor "+ex.Message);
            }
        }
        //fechar conexao
        public void fecharConexao()
        {
            try
            {
                con = new MySqlConnection(conec);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no servidor " + ex.Message);

            }
        }
    }
}
