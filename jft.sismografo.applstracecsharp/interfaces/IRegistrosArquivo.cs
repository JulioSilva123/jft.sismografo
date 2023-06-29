using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jft.sismografo.applstracecsharp.interfaces
{
    public interface IRegistrosArquivo
    {

        double[] GetRegistros();

        bool SaveSupported();

        bool SalvarResultados(float[] registros, string path);

    }
}
