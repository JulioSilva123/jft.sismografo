﻿using jft.sismografo.applstracecsharp.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jft.sismografo.applstracecsharp.service
{
    public class registrosMock : IRegistrosService
    {
        public double[] GetRegistros() { 
            return registrosMock._registrosDados; 
        }

        public bool SaveSupported() { return false; }

        public bool SalvarResultados(float[] data, string path) { return false; }

        /* Replace por RegEx: $ -> ,*/
        static double[] _registrosDados = {
            -4.7469604e-7,
            -1.306379e-6,
            5.5409564e-6,
            3.520742e-5,
            5.2020758e-5,
            6.0402552e-5,
            -4.3129519e-5,
            -0.0001125016,
            -0.00018260432,
            -0.00015841764,
            -0.00011617896,
            -0.00013290522,
            -0.00037435323,
            -0.00068153447,
            -0.00031832643,
            0.00046329558,
            -0.00037943243,
            -0.00378769,
            -0.00547472,
            0.00042749097,
            0.01129542,
            0.01534481,
            0.00580368,
            -0.00856397,
            -0.01388226,
            -0.00761286,
            0.00137434,
            0.00595682,
            0.00596679,
            0.0031812,
            -0.00125056,
            -0.00466955,
            -0.00398068,
            -6.5110777e-5,
            0.00263525,
            0.00135817,
            -0.00222557,
            -0.00419043,
            -0.00252298,
            0.00150468,
            0.00427969,
            0.00348717,
            0.00047537009,
            -0.00111418,
            -0.00012526485,
            0.00067645544,
            -0.00110193,
            -0.00380943,
            -0.00426841,
            -0.00202688,
            0.0010157,
            0.00342666,
            0.00453182,
            0.00341483,
            -9.0311965e-5,
            -0.00399398,
            -0.00504003,
            -0.00176624,
            0.00331933,
            0.00576494,
            0.00382156,
            0.0001423753,
            -0.00211393,
            -0.00250719,
            -0.00185713,
            -0.00013720396,
            0.00231429,
            0.00343645,
            0.00150276,
            -0.00219182,
            -0.00395536,
            -0.00174808,
            0.00208693,
            0.00311306,
            4.1200336e-5,
            -0.00379334,
            -0.00467363,
            -0.00218674,
            0.00148802,
            0.00418122,
            0.00460599,
            0.00209465,
            -0.00219807,
            -0.00469068,
            -0.00215968,
            0.00351081,
            0.00612001,
            0.00310432,
            -0.00089744007,
            -0.00096810103,
            0.00038296447,
            -0.00236524,
            -0.0079986,
            -0.00873421,
            -0.00056528149,
            0.01055785,
            0.01466104,
            0.00731156,
            -0.00676257,
            -0.01739577,
            -0.01596056,
            -0.00286475,
            0.01101428,
            0.01418228,
            0.00656275,
            -0.00172098,
            -0.00346449,
            -0.00097349909,
            0.00043476542,
            -0.00024356153,
            -0.00087278237,
            -0.00062934903,
            -0.00022400485,
            -0.00018248211,
            -0.00022873518,
            -0.00019961091,
            -0.00019236178,
            -0.00014879073,
            -9.5523988e-5,
            -1.2213283e-5,
            1.0215717e-5
        };
    }
}

