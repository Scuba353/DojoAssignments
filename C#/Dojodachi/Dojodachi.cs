using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Dojodachi
{
    public class Dojodachi{
        public int fullness;
        public int happiness;
        public int energy;
        public int meals;


        public Dojodachi(int full=20, int happ= 20, int ener=50, int meal=3)
        {
            fullness=full;
            happiness=happ;
            energy=ener;
            meals=meal;
        }

    }
}