using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FasterShuriken
{
    class Gyanburu : Shuriken
    {
        public int Betto_gaku { get; set; }
        public Gyanburu gyanburu { get; set; }
        public int shuriken { get; set; }
        public int rewardMultiplier = 4;

        public int Kyasshuauto(int winningChevilry)
        {
            if (winningChevilry == shuriken)
                return Betto_gaku * rewardMultiplier;
            else
                return (0 - Betto_gaku);
        }
    }
}
