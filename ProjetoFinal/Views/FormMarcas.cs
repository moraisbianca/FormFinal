using System;
using System.Windows.Forms;
using ProjetoFinal.Models;

namespace ProjetoFinal.Views
{
    public partial class FormMarcas : Form
    {
        Marca c;
        public FormMarcas()
        {
            InitializeComponent();
        }

        void LimparControles()
        {
            txtID.Clear();
            txtMarca.Clear();
            txtPesquisar.Clear();
        }

        void CarregarGrid(string pesquisa)
        {
            c = new Marca()
            {
                marca = pesquisa
            };

            dgvMarcas.DataSource = c.Consultar();
        }

        private void FormMarcas_Load(object sender, EventArgs e)
        {
            LimparControles();
            CarregarGrid("");
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtMarca.Text == String.Empty) return;

            c = new Marca()
            {
                marca = txtMarca.Text,
            };
            c.Incluir();

            LimparControles();
            CarregarGrid("");
        }

        private void dgvMarcas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMarcas.RowCount > 0)
            {
                txtID.Text = dgvMarcas.CurrentRow.Cells["id"].Value.ToString();
                txtMarca.Text = dgvMarcas.CurrentRow.Cells["marca"].Value.ToString();

            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == String.Empty) return;

            c = new Marca()
            {
                id = int.Parse(txtID.Text),
                marca = txtMarca.Text,
            };
            c.Alterar();

            LimparControles();
            CarregarGrid("");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparControles();
            CarregarGrid("");
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            if (MessageBox.Show("Deseja excluir a marca?", "Exclusão",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                c = new Marca()
                {
                    id = int.Parse(txtID.Text)
                };

                c.Excluir();

                LimparControles();
                CarregarGrid("");

            }
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
