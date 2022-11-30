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
        public DicionarioForms(string[] dicionario)
        {
            InitializeComponent();

            DataTable dt = new DataTable();
            dt.Columns.Add("Palavra");
            foreach (string palavra in dicionario)
            {
                dt.Rows.Add(palavra);
            }    
            dataGridView1.DataSource = dt;
        }
    }
}
