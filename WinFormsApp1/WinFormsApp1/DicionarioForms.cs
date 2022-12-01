using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class DicionarioForms : Form
    {
        string[] _dicionario;
        public DicionarioForms(string[] dicionario)
        {
            InitializeComponent();

            _dicionario = dicionario;

            CarregaDicionarioNaTabela(_dicionario);
            CriaContextMenuStrip();
        }

        private void CarregaDicionarioNaTabela(string[] dicionario)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Palavra");
            foreach (string palavra in dicionario)
            {
                dt.Rows.Add(palavra);
            }
            dataGridView1.DataSource = dt;

            dataGridView1.AllowUserToAddRows = false;
        }

        private void CriaContextMenuStrip()
        {
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            contextMenuStrip.Items.Add("Remover Palavra");
            contextMenuStrip.Items[0].Click += new EventHandler(RemovePalavraDoDicionario);

            dataGridView1.ContextMenuStrip = contextMenuStrip;
        }

        private void RemovePalavraDoDicionario(object sender, EventArgs e)
        {
            foreach (DataGridViewTextBoxCell palavra in dataGridView1.SelectedCells)
            {
                if (palavra.Value.ToString() != null)
                {
                    _dicionario = _dicionario.Where(x => x.ToString() != palavra.Value.ToString()).ToArray();
                }
            }
            Form1._Dicionario = _dicionario;
            CarregaDicionarioNaTabela(_dicionario);

            MessageBox.Show("Palavra(s) removida(s) com sucesso!");
        }
    }
}
