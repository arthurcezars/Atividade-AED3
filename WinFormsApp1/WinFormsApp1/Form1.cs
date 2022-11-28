using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private List<string> _Dicionario;
        public Form1()
        {
            InitializeComponent();

            _Dicionario = CarregaDicionario();
            CriaContextMenuStrip();
            ConfiguraOpenFileDialog();
            ConfiguraSaveFileDialog();
        }

        /*
         * Metodo para criar o botão de adicionar ao dicionario quando clickar com o botão direito
         * do mouse.
         */
        private void CriaContextMenuStrip()
        {
            ContextMenuStrip cm = new ContextMenuStrip();
            cm.Items.Add("Adicionar ao dicionario ");
            cm.ItemClicked += new ToolStripItemClickedEventHandler(AdicionarDicionario);
            richTextBox1.ContextMenuStrip = cm;
        }

        /*
         * Função para carregar o dicionario.
         */
        private List<string> CarregaDicionario()
        {
            return new List<string>();
        }

        /*
         * Metodo que configura o componente de carregamento de arquivos.
         */
        private void ConfiguraOpenFileDialog()
        {
            openFileDialog1.Title = "Selecione um arquivo de texto";
            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.DefaultExt = "txt";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt";
            openFileDialog1.FilterIndex = 2;

            openFileDialog1.ReadOnlyChecked = true;
            openFileDialog1.ShowReadOnly = true;
        }

        /*
         * Metodo que configura o componente de salvamento de arquivos.
         */
        private void ConfiguraSaveFileDialog()
        {
            saveFileDialog1.Title = "Escolha um local para salvar o arquivo";
            saveFileDialog1.InitialDirectory = @"C:\";
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.CheckFileExists = false;
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt";
            saveFileDialog1.AddExtension = true;
        }

        /*
         * Metodo responsavel por adicionar a palavra ao dicionario.
         */
        private void AdicionarDicionario(object sender, ToolStripItemClickedEventArgs e)
        {
            string texto = richTextBox1.SelectedText;
            DialogResult = MessageBox.Show("Você tem certeza que quer adicionar a palavra \"" + texto + "\" ao dicionario?",
                "Dicionario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (DialogResult == DialogResult.Yes)
            {
                _Dicionario.Add(texto);
                MessageBox.Show("Adicionado");
            }
        }

        /*
         * Metodo responsavel por encontrar e selecionar uma palavra ao clickar no campo de texto.
         */
        private void SelectWord(object sender, EventArgs e)
        {
            RichTextBox txtBox = (RichTextBox)sender;
            char[] strDataAsChars = txtBox.Text.ToCharArray();
            int i = 0;
            for (i = txtBox.SelectionStart - 1; ((i >= 0) && Regex.IsMatch(strDataAsChars[i].ToString(), @"([a-z]|[A-Z]|[0-9])")); --i) ;
            int selBegin = i + 1;
            for (i = txtBox.SelectionStart; ((i < strDataAsChars.Length) && Regex.IsMatch(strDataAsChars[i].ToString(), @"([a-z]|[A-Z]|[0-9])")); ++i) ;
            int selEnd = i;
            txtBox.Select(selBegin, selEnd - selBegin);
        }

        /*
         * Função que verifica o dicionario e retorna uma lista com as palavras que não estão no dicionario.
         */
        private string[] checkWords()
        {
            string text = richTextBox1.Text;
            string[] words = Regex.Matches(text, @"([a-z]|[A-Z]|[0-9])\w+").Cast<Match>().Select(m => m.Value).ToArray();
            return words.Where(word => !_Dicionario.Contains(word.ToString())).ToArray();
        }

        /*
         * Metodo on ao clickar no botão de verificar pinta as palavras que não estão no dicionario
         * de vermelho.
         */
        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Select(0, richTextBox1.Text.Length);
            richTextBox1.SelectionColor = Color.Black;

            string[] words = checkWords();
            foreach(string word in words)
            {
                int index = richTextBox1.Text.IndexOf(word);
                richTextBox1.Select(index, word.Length);
                richTextBox1.SelectionColor = Color.Red;
            }
        }

        // Metodo que permite carregar um arquivo txt no editor.
        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (Path.GetExtension(openFileDialog1.FileName) == ".txt")
                {
                    richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                }
            }
        }

        // Metodo que permite salvar o texto do editor como um arquivo txt.
        private void button3_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (Path.GetExtension(saveFileDialog1.FileName) == ".txt")
                {
                    richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                }
            }
        }
    }
}
