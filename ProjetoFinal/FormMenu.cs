using System;
using System.Windows.Forms;
using ProjetoFinal.Views;

namespace ProjetoFinal
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            Banco.CriarBanco();
        }

        private void cidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCidades form = new FormCidades();
            form.Show();
        }

        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMarcas form = new FormMarcas();
            form.Show();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCategorias form = new FormCategorias();
            form.Show();
        }
    }
}
