using jft.sismografo.applstracecsharp.controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jft.sismografo.applstracecsharp.view
{
    public partial class MainForm : Form
    {


        private float freq_low, freq_high;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;


        public MainForm()
        {
            InitializeComponent();


            this.chart.AddDataSeries("wave_filtered", Color.Red, Accord.Controls.Chart.SeriesType.Line, 1);
            this.chart.AddDataSeries("wave_no_filter", Color.Blue, Accord.Controls.Chart.SeriesType.Line, 1);

            this.check_Rotate.Checked = Properties.Settings.Default.chk_transpose;

            this.text_highFilter.Text = Properties.Settings.Default.freq_high.ToString();
            this.text_lowFilter.Text = Properties.Settings.Default.freq_low.ToString();

        }


        private void atualizaGrafico()
        {
            utils.funcoes.UpdateGrafico(this.chart, this.lbl_amp_a, this.lbl_amp_b, this.check_Rotate, freq_low, freq_high);
        }



        private void MainForm_Load(object sender, EventArgs e)
        {
            this.atualizaGrafico();

        }


        private void check_Transpose_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.chk_transpose = check_Rotate.Checked;
            Properties.Settings.Default.Save();
            atualizaGrafico();
        }

        private void text_lowFilter_TextChanged(object sender, EventArgs e)
        {
            this.freq_low = Properties.Settings.Default.freq_low = utils.funcoes.float_conv(text_lowFilter.Text, 0);
            Properties.Settings.Default.Save();
            this.slider_low.Value = (int)this.freq_low;
            this.atualizaGrafico();
        }

         

        private void abrir_MenuItem_Click(object sender, EventArgs e)
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            openFileDialog1.Title = "Arquivo de texto / CSV Sem cabeçalho";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt| Arquivo CSV *.csv|*.csv";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                servicos.GetInstance().arquivo.CarregarArquivo(openFileDialog1.FileName);
        }

        private void comHeader_MenuItem_Click(object sender, EventArgs e)
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            openFileDialog1.Title = "CSV com cabeçalho";
            openFileDialog1.Filter = "Arquivo CSV *.csv|*.csv";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                servicos.GetInstance().arquivo.CarregarArquivo(openFileDialog1.FileName, true);
        }

        private void database_MenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Não implementado.");
        }

        private void mockData_MenuItem_Click(object sender, EventArgs e)
        {
            servicos.GetInstance().UsarMockData();
            this.atualizaGrafico();
        }

        private void arquivoDeEntr_MenuItem_Click(object sender, EventArgs e)
        {
            servicos.GetInstance().UsarArquivos();
            this.atualizaGrafico();
        }

        private void salvar_MenuItem_Click(object sender, EventArgs e)
        {
            var svc = servicos.GetInstance().servico;

            if (!svc.SaveSupported())
            {
                MessageBox.Show("Porfavor selecione outra fonte de dados");
                return;
            }

            saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Arquivo CSV |*.csv";
            saveFileDialog1.Title = "Salvar Arquivo CSV";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                var dados_n_filtrados = Array.ConvertAll(servicos.GetInstance().registros, x => (float)x);
                var dados_filtrados = registrosFiltro.FiltraDados(dados_n_filtrados, freq_low, freq_high, 250);
                if (svc.SalvarResultados(dados_filtrados, saveFileDialog1.FileName))
                {
                    MessageBox.Show("Arquivo salvo com sucesso!");
                    return;
                }
                MessageBox.Show("Falha ao salvar arquivo");
            }
        }

        private void slider_low_Scroll(object sender, EventArgs e)
        {
            freq_low = Properties.Settings.Default.freq_low = slider_low.Value;
            Properties.Settings.Default.Save();
            text_lowFilter.Text = freq_low.ToString();
            this.atualizaGrafico();
        }

        private void slider_high_Scroll(object sender, EventArgs e)
        {
            freq_high = Properties.Settings.Default.freq_high = slider_high.Value;
            Properties.Settings.Default.Save();
            text_highFilter.Text = freq_high.ToString();
            this.atualizaGrafico();
        }

        private void text_highFilter_TextChanged(object sender, EventArgs e)
        {
            freq_high = Properties.Settings.Default.freq_high = utils.funcoes.float_conv(text_highFilter.Text, 25);
            slider_high.Value = (int)freq_high;
            Properties.Settings.Default.Save();
            this.atualizaGrafico();
        }

    }
}
