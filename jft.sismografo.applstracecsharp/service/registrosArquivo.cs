using jft.sismografo.applstracecsharp.interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jft.sismografo.applstracecsharp.service
{
    public class registrosArquivo : IRegistrosService
    {

        public registrosArquivo()
        {
            this._registros = new List<double>();
        }




        private List<double> _registros;




        public bool SaveSupported() { 
            return true; 
        }

        public double[] GetRegistros() { 
            return this._registros.ToArray(); 
        }

        public bool SalvarResultados(float[] data, string path)
        {
            var csv = new StringBuilder();
            foreach (double d in data)
            {
                csv.AppendLine(d.ToString("E3"));
            }

            try
            {
                File.WriteAllText(path, csv.ToString());
            }
            catch (SystemException)
            {
                return false;
            }

            return true;
        }



        public bool CarregarArquivo(string path, bool ignore_first_line = true)
        {
            try
            {
                var lines = File.ReadAllLines(path);

                if (ignore_first_line)
                    lines = lines.Skip(1).ToArray();

                double result;
                foreach (string element in lines)
                {
                    if (!double.TryParse(element, System.Globalization.NumberStyles.Float, CultureInfo.CurrentCulture, out result) &&
                        //Then try in US english
                        !double.TryParse(element, System.Globalization.NumberStyles.Float, CultureInfo.GetCultureInfo("en-US"), out result) &&
                        //Then in neutral language
                        !double.TryParse(element, System.Globalization.NumberStyles.Float, CultureInfo.InvariantCulture, out result))
                    {
                        throw new SystemException();
                    }
                    this._registros.Add(result);
                }
            }
            catch (SystemException)
            {
                MessageBox.Show("Falha ao carregar");
                return false;
            }

            MessageBox.Show("Carregado com Sucesso");
            return true;
        }

    }
}
