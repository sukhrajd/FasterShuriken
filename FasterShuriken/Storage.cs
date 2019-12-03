using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FasterShuriken
{
    abstract class Storage
    {
        public static Shuriken[] shuriken = new Shuriken[4];
        public static Gyanbura[] gyanbura = new Gyanbura[3];
        public static Random rand = new Random();
        public static int genzaiGyanbura { get; set; }
    }
}
