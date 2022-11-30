using ProjetoFinal.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoFinal.Views
{
    public partial class FormCategorias : Form
    {
        Categoria c;
        public FormCategorias()
        {
            InitializeComponent();
            CarregarGrid("");
        }

        void LimparControles()
        {
            txtID.Clear();
            txtCategoria.Clear();
            txtPesquisar.Clear();
        }

        void CarregarGrid(string pesquisa)
        {
            c = new Categoria()
            {
                categoria = pesquisa
            };

            dgvCategoria.DataSource = c.Consultar();
        }

        private void FormCategorias_Load(object sender, EventArgs e)
        {
            LimparControles();
            CarregarGrid("");
        }

        private void dgvCategoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCategoria.RowCount > 0)
            {
                txtID.Text = dgvCategoria.CurrentRow.Cells["id"].Value.ToString();
                txtCategoria.Text = dgvCategoria.CurrentRow.Cells["categoria"].Value.ToString();

            }
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtCategoria.Text == String.Empty) return;

            c = new Categoria()
            {
                categoria = txtCategoria.Text,
            };
            c.Incluir();

            LimparControles();
            CarregarGrid("");
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == String.Empty) return;

            c = new Categoria()
            {
                id = int.Parse(txtID.Text),
                categoria = txtCategoria.Text,
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

            if (MessageBox.Show("Deseja excluir a categoria?", "Exclusão",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                c = new Categoria()
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
