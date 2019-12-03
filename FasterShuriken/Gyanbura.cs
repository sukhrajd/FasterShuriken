using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FasterShuriken
{
    class Gyanbura : Gyanburu
    {
        public string na { get; set; }
        public int okane { get; set; }
        public Gyanburu genzaiGyanburu;

        public RadioButton listOfBettors { get; set; }
        public Label activity { get; set; }

        public void UpdateActivity()
        {
            listOfBettors.Text = na + " has $" + okane;
        }

        public void ResetStats()
        {
            genzaiGyanburu = null;
            activity.Text = na + " has't placed a bet.";
        }

        public bool betting(int amount, int bittingVampire)
        {
            this.genzaiGyanburu = new Gyanburu() { Betto_gaku = amount, shuriken = bittingVampire };

            if (amount <= okane)
            {
                okane -= amount;
                activity.Text = this.na + " has placed $" + amount + " on Vampire #" + bittingVampire;
                this.UpdateActivity();
                return true;
            }
            else
            {
                MessageBox.Show(this.na + " doesn't have enough money to cover for the bet!");
                this.genzaiGyanburu = null;
                return false;
            }
        }

        public void collectWinningAmount(int winner)
        {
            if (this.genzaiGyanburu != null)
            {
                okane += genzaiGyanburu.Kyasshuauto(winner);
                ResetStats();
                UpdateActivity();
            }
        }
    }
}
