using jft.sismografo.applstracecsharp.interfaces;
using jft.sismografo.applstracecsharp.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jft.sismografo.applstracecsharp.controller
{
    public class servicos
    {

        public servicos()
        {
            _registro = new registrosMock();
            _arquivo = new registrosArquivo();
        }


        private static servicos _self;



        private registrosArquivo _arquivo;        
        private IRegistrosService _registro;


        public double[] registros { get => _registro.GetRegistros(); }


        public IRegistrosService servico { get => this._registro; }
        public registrosArquivo arquivo { get => this._arquivo; }


        public static servicos GetInstance()
        {
            if (_self == null)
            {
                _self = new servicos();
            }
            return _self;
        }

        

        public void UsarMockData()
        {
            _registro = new registrosMock();
        }

        public void UsarArquivos()
        {
            _registro = this._arquivo;
        }

    }
}
