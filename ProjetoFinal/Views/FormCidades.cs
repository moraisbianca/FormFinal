using System;
using System.Windows.Forms;
using ProjetoFinal.Models;

namespace ProjetoFinal.Views
{
    public partial class FormCidades : Form
    {
        Cidade c;
        public FormCidades()
        {
            InitializeComponent();
        }

        void LimparControles()
        {
            txtID.Clear();
            txtNome.Clear();
            txtUF.Clear();
            txtPesquisar.Clear();
        }

        void CarregarGrid(string pesquisa)
        {
            c = new Cidade()
            {
                nome = pesquisa
            };

            dgvCidades.DataSource = c.Consultar();
        }

        private void FormCidades_Load(object sender, EventArgs e)
        {
            LimparControles();
            CarregarGrid("");
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == String.Empty) return;

            c = new Cidade()
            {
                nome = txtNome.Text,
                uf = txtUF.Text
            };
            c.Incluir();

            LimparControles();
            CarregarGrid("");
        }

        private void dgvCidades_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCidades.RowCount > 0)
            {
                txtID.Text = dgvCidades.CurrentRow.Cells["id"].Value.ToString();
                txtNome.Text = dgvCidades.CurrentRow.Cells["nome"].Value.ToString();
                txtUF.Text = dgvCidades.CurrentRow.Cells["uf"].Value.ToString();

            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == String.Empty) return;

            c = new Cidade()
            {
                id = int.Parse(txtID.Text),
                nome = txtNome.Text,
                uf = txtUF.Text
            };
            c.Alterar();

            LimparControles();
            CarregarGrid("");
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if(txtID.Text == "") return;

            if (MessageBox.Show("Deseja excluir a cidade?", "Exclusão",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                c = new Cidade()
                {
                    id = int.Parse(txtID.Text)
                };

                c.Excluir();

                LimparControles();
                CarregarGrid("");

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparControles();
            CarregarGrid("");
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            CarregarGrid(txtPesquisar.Text);
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
