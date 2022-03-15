using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Urna;

namespace BuscaCep
{
    public partial class Form1 : Form
    {
        public string cep, num, nome, data, email;

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            cep = txtBusca.Text;
        }

        private void btnBusca_Click(object sender, EventArgs e)
        {
            BuscaCEP();
        }

        private void BuscaCEP()
        {
            pegacep pega = new pegacep();

            String[] dados = pega.pegaDados(cep);

            lbEndereco.Text = dados[1];
            lbBairro.Text = dados[3];
            lbCidade.Text = dados[4];
            lbUF.Text = dados[5];
        }
        
        /*private void Buscar()
        {
            Conexao comb = new Conexao();

            comb.sql = "SELECT * FROM tb01_dados WHERE tb01_cep = '" + cep + "' ";

            comb.open();

            MySqlDataReader dados = comb.Execsql();

            if (dados.HasRows)
            {
                while (dados.Read())
                {
                    lbEndereco.Text = dados["tb01_endereco"].ToString();
                    lbCidade.Text = dados["tb01_cidade"].ToString();
                    lbBairro.Text = dados["tb01_bairro"].ToString();
                    lbUF.Text = dados["tb01_uf"].ToString();
                }
            } else
            {
                MessageBox.Show("CEP não encontrado", "Erro na busca",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Exclamation);
            }
            comb.close();
        }*/


        private void txtNum_TextChanged(object sender, EventArgs e)
        {
            num = txtNum.Text;
        }

        private void lbEndereco_Click(object sender, EventArgs e)
        {

        }

        private void lbBairro_Click(object sender, EventArgs e)
        {

        }

        private void lbCidade_Click(object sender, EventArgs e)
        {

        }

        private void lbUF_Click(object sender, EventArgs e)
        {

        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            nome = txtNome.Text;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

             data = Convert.ToDateTime(tbData.Text).ToString("yyyy-MM-dd");
        }

        private void tbData_MouseClick(object sender, MouseEventArgs e)
        {
            DataNasc.Visible = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            email = txtEmail.Text;
        }

        private void DataNasc_DateChanged(object sender, DateRangeEventArgs e)
        {
            tbData.Text = DataNasc.SelectionRange.Start.Date.ToShortDateString();
            DataNasc.Visible = false;


        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            UpdateBanco();
        }

        /*
         * INSERT INTO `bd_cadastro`.`tb01_dados` 
         * (`tb01_nome`, `tb01_endereco`, `tb01_bairro`, `tb01_cidade`,
         * `tb01_email`, `tb01_uf`, `tb01_cep`, `tb01_numero`, `tb01_dt_nascimento`)
         * VALUES ('', '', '', '', '', '', '', '', '');
         * 
         * ende = lbEndereco.Text, bairro = lbBairro.Text, cidade = lbCidade, UF = lbUF;
         * */
        private void UpdateBanco()
        {
            data = Convert.ToDateTime(tbData.Text).ToString("yyyy-MM-dd");

            Conexao comb = new Conexao();

            comb.sql = "INSERT INTO tb01_dados (tb01_nome, tb01_endereco, tb01_bairro, tb01_cidade,";
            comb.sql += "tb01_email, tb01_uf, tb01_cep, tb01_numero, tb01_dt_nascimento) ";
            comb.sql += "VALUES ('" + nome + "', '" + lbEndereco.Text + "', '" + lbBairro.Text + "', '" + lbCidade.Text + "', ";
            comb.sql += "'" + email + "', '" + lbUF.Text + "', '" + cep + "', '" + num + "', '" + data + "')";

            MessageBox.Show(comb.sql);

            comb.open();

                int lin = comb.Runsql();

                if (lin > 0)
                {
                    MessageBox.Show("Dados registrados!", "Ação",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            else
            {
                MessageBox.Show("Erro! Desculpe, algo deu errado", "Ação",
                MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


            comb.close();
        } 
    }
}




/* comb.sql += " tb01_nome = tb01_nome + '" + nome + "'";
            comb.sql += " , tb01_endereco = tb01_endereco + '" + lbEndereco.Text + "'";
            comb.sql += " , tb01_bairro = tb01_bairro + '" + lbBairro.Text + "'";
            comb.sql += " , tb01_cidade = tb01_cidade + '" + lbCidade.Text + "'";
            comb.sql += " , tb01_uf = tb01_uf + '" + lbUF.Text + "'";
            comb.sql += " , tb01_email = tb01_email + '" + email + "'";
            comb.sql += " , tb01_numero = tb01_numero + '" + num + "'";
            comb.sql += " , tb01_dt_nascimento = tb01_dt_nascimento + '" + data + "'";
            comb.sql += " , tb01_cep = '" + cep + "'"; 
            
      */
