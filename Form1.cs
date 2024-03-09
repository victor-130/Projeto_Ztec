using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Projeto01
{
    public partial class pricipal : Form
    {
        conexao con = new conexao();
        MySqlCommand cmd;
        string sql;

        string id;//variavel que pega o id do registro
        public pricipal()
        {
            InitializeComponent();
        }
        private void formatarGD()
        {
            grid.Columns[0].HeaderText = "Código";
            grid.Columns[1].HeaderText = "Nome";
            grid.Columns[2].HeaderText = "End.";
            grid.Columns[4].HeaderText = "CPF";
            grid.Columns[3].HeaderText = "Tel.";

            grid.Columns[0].Visible = false;
        }
        private void ListarGrid() {
            con.abrirConexao();
            sql = "SELECT * FROM clientes ORDER BY NOME ASC";
            cmd = new MySqlCommand(sql, con.con);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            grid.DataSource = dt;
            con.fecharConexao();

            formatarGD();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ListarGrid();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtcpf_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
        private void txttelefone_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnnovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
            HabilitarCampos();

            txtnome.Focus();

            HabilitarBotoes();
            btnnovo.Enabled = false;
        }

        private void btnsalvar_Click(object sender, EventArgs e)
        {
            if (txtnome.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Digite o nome");
                txtnome.Text = "";
                txtnome.Focus();
                return;
            }
            if (txtcpf.Text.ToString().Trim() == "   .   .   -" || txtcpf.Text.Length < 14)
            {
                MessageBox.Show("Digite o cpf");
                txtcpf.Focus();
                return;
            }

            con.abrirConexao();
            sql = "INSERT INTO clientes(nome, endereco, cpf, telefone) VALUES(@nome,@endereco,@cpf,@telefone)";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@nome",txtnome.Text);
            cmd.Parameters.AddWithValue("@endereco", txtendereco.Text);
            cmd.Parameters.AddWithValue("@cpf", txtcpf.Text);
            cmd.Parameters.AddWithValue("@telefone", txttelefone.Text);
            cmd.ExecuteNonQuery();
            con.fecharConexao();
            Voltanovo();
            ListarGrid();
            MessageBox.Show("Salvo com sucesso","Salvar",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        private void alterar(object sender, EventArgs e)
        {
            if (txtnome.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Digite o nome");
                txtnome.Text = "";
                txtnome.Focus();
                return;
            }
            if (txtcpf.Text.ToString().Trim() == "   .   .   -  " || txtcpf.Text.Length < 14)
            {
                MessageBox.Show("Digite o cpf");
                txtcpf.Focus();
                return;
            }

            con.abrirConexao();
            sql = "UPDATE clientes SET nome = @nome, endereco = @endereco, cpf = @cpf, telefone = @telefone WHERE id = @id";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@nome", txtnome.Text);
            cmd.Parameters.AddWithValue("@endereco", txtendereco.Text);
            cmd.Parameters.AddWithValue("@cpf", txtcpf.Text);
            cmd.Parameters.AddWithValue("@telefone", txttelefone.Text);
            cmd.ExecuteNonQuery();
            con.fecharConexao();
            Voltanovo();
            ListarGrid();
            MessageBox.Show("Alterado com sucesso", "Alterar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void Excluir_Click(object sender, EventArgs e)
        {
           
            Voltanovo();
            var resposta = MessageBox.Show("Desaja realmente excluir esse cadastro?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resposta == DialogResult.Yes)
            {
                sql = "DELETE FROM clientes WHERE clientes.id = @id";
                cmd = new MySqlCommand(sql, con.con);
                MessageBox.Show("Cadastro excluido");
            }
            ListarGrid();
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            Voltanovo();
            //Limpar os campos

        }
        //metodo que desabilita botões
        private void DesabilitarBotoes()
        {
            btncancelar.Enabled = false;
            btnsalvar.Enabled=false;
            btnnovo.Enabled=false;
            btnexcluir.Enabled=false;
            btnalterar.Enabled=false;
        } 
        private void HabilitarBotoes()
        {
            btncancelar.Enabled=true;
            btnexcluir.Enabled=true;
            btnsalvar.Enabled =true;
            btnnovo.Enabled = true;
            btnalterar.Enabled=true;   
        }
        //metodo habilitar os campos
        private void HabilitarCampos()
        {
            txtendereco.Enabled = true;
            txtnome.Enabled = true;
            txtcpf.Enabled = true;
            txttelefone.Enabled = true;
        }
        private void DesabilitarCampos()
        {
            txtendereco.Enabled = false;
            txtnome.Enabled = false;
            txtcpf.Enabled = false;
            txttelefone.Enabled = false;
        }
        //Limpar campos
        private void LimparCampos()
        {
            txtcpf.Text = "";
            txtendereco.Text = "";
            txtnome.Text = "";
            txttelefone.Text = "";
        }
        private void Voltanovo()
        {
            
            DesabilitarBotoes();
            DesabilitarCampos();
            btnnovo.Enabled = true;
            btnexcluir.Enabled = true;
            btnalterar.Enabled = true;
            LimparCampos();
        }
        

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtbusca_TextChanged(object sender, EventArgs e)
        {

        }

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            HabilitarBotoes();
            btnnovo.Enabled = false;
            btnsalvar.Enabled = false;
            HabilitarCampos();

            id = grid.CurrentRow.Cells[0].Value.ToString();
            txtnome.Text = grid.CurrentRow.Cells[1].Value.ToString();
            txtendereco.Text = grid.CurrentRow.Cells[2].Value.ToString();
            txtcpf.Text = grid.CurrentRow.Cells[3].Value.ToString();
            txttelefone.Text = grid.CurrentRow.Cells[4].Value.ToString();
        }

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
