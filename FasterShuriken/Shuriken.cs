using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FasterShuriken
{
    class Shuriken
    {
        public int kaishi { get; set; }
        public int saigo_no { get; set; }
        public PictureBox shuriken_img { get; set; }
        private Random rand = new Random();

        // Checks if Jeep is in Motion
        public bool isAccelerating()
        {
            Point updatedLoc = shuriken_img.Location;
            updatedLoc.X += rand.Next(1, 8);
            shuriken_img.Location = updatedLoc;

            // Checks whether the location of right side of Jeep is same as final destination
            if (updatedLoc.X >= saigo_no)
                return true;
            else
                return false;
        }

        public void MoveToStart()
        {
            shuriken_img.Left = kaishi;
        }
    }
}
