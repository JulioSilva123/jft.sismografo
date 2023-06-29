using Accord;
using Accord.Audio;
using jft.sismografo.applstracecsharp.controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jft.sismografo.applstracecsharp.utils
{
    public static class funcoes
    {

        public static float float_conv(string s, float def)
        {
            float val;
            if (float.TryParse(s, out val))
                return val;
            return def;
        }


        public static double[,] Matriz_View(float[] vetor, bool transpose = false)
        {
            double[,] mat = new double[vetor.Length, 2];
            int i;

            if (transpose == false)
            {
                for (i = 0; i < vetor.Length; i++)
                {
                    mat[i, 0] = i;
                    mat[i, 1] = vetor[i];
                }
            }
            else
            {
                for (i = 0; i < vetor.Length; i++)
                {
                    mat[i, 1] = i;
                    mat[i, 0] = vetor[i];
                }
            }

            return mat;
        }


        public static void UpdateGrafico(Accord.Controls.Chart chart,
                                         System.Windows.Forms.Label lbl_amp_a,
                                         System.Windows.Forms.Label lbl_amp_b,
                                         System.Windows.Forms.CheckBox check_Rotate,
                                         float freq_low, 
                                         float freq_high)
        {

            var dados_n_filtrados = Array.ConvertAll(servicos.GetInstance().registros, x => (float)x);

            if (dados_n_filtrados.Length == 0)
            {
                chart.UpdateDataSeries("wave_filtered", null);
                chart.UpdateDataSeries("wave_no_filter", null);
                MessageBox.Show("Sem dados para a análise, verifique a fonte de dados.");
                return;
            }

            // Freq = 1 / T, onde T=4ms, assim temos Freq = 1/0.004 = 250
            var dados_filtrados = registrosFiltro.FiltraDados(dados_n_filtrados, freq_low, freq_high, 250);


            Signal sig = Signal.FromArray(dados_n_filtrados, 1, 250);

            var vec_no_filter = sig.ToFloat();

            var x_range_filter = Math.Max(dados_filtrados.Min(), dados_filtrados.Max());
            var x_range_no_filter = Math.Max(vec_no_filter.Min(), vec_no_filter.Max());
            var x_range = Math.Max(x_range_filter, x_range_no_filter) * 1.2f;

            // Copia o range para os labels de amplitude, equivalente a "%f.2"
            lbl_amp_a.Text = lbl_amp_b.Text = x_range.ToString("F2");

            var mat_filt = funcoes.Matriz_View(dados_filtrados, !check_Rotate.Checked);
            var mat_n_filt = funcoes.Matriz_View(dados_n_filtrados, !check_Rotate.Checked);

            chart.UpdateDataSeries("wave_filtered", mat_filt);
            chart.UpdateDataSeries("wave_no_filter", mat_n_filt);

            if (!check_Rotate.Checked)
            {
                chart.RangeY = new Range(0, dados_filtrados.Length);
                chart.RangeX = new Range(-x_range, x_range);
            }
            else
            {
                chart.RangeX = new Range(0, dados_filtrados.Length);
                chart.RangeY = new Range(-x_range, x_range);
            }
        }

    }
}
