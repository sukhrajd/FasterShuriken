using System;
using System.Windows.Forms;

namespace FasterShuriken
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Setup Defaults
            setup();
        }

        // Setup all the base elements for the race
        public void setup()
        {
            // Get's the start position
            int startPos = pictureBox1.Left;

            // Calculates the length of the race track
            int RaceTrackLength = TrackLengthPanel.Width - pictureBox1.Right;

            // Initializes all the racing vehicles
            Storage.shuriken[0] = new Shuriken() { shuriken_img = pictureBox1, kaishi = startPos, saigo_no = RaceTrackLength };
            Storage.shuriken[1] = new Shuriken() { shuriken_img = pictureBox2, kaishi = startPos, saigo_no = RaceTrackLength };
            Storage.shuriken[2] = new Shuriken() { shuriken_img = pictureBox3, kaishi = startPos, saigo_no = RaceTrackLength };
            Storage.shuriken[3] = new Shuriken() { shuriken_img = pictureBox4, kaishi = startPos, saigo_no = RaceTrackLength };

            // Initialize all the gamblers
            Storage.gyanbura[0] = new Gyanbura() { okane = 65, activity = label1, listOfBettors = radioButton1, na = "Player 1" };
            Storage.gyanbura[1] = new Gyanbura() { okane = 75, activity = label2, listOfBettors = radioButton2, na = "Player 2" };
            Storage.gyanbura[2] = new Gyanbura() { okane = 55, activity = label3, listOfBettors = radioButton3, na = "Player 3" };

            // Update all the activity labels to default
            Storage.gyanbura[0].UpdateActivity();
            Storage.gyanbura[1].UpdateActivity();
            Storage.gyanbura[2].UpdateActivity();

            // Reset all the starts to defaults
            Storage.gyanbura[0].ResetStats();
            Storage.gyanbura[1].ResetStats();
            Storage.gyanbura[2].ResetStats();
        }

        public void ResetPositions()
        {
            Storage.shuriken[0].MoveToStart();
            Storage.shuriken[1].MoveToStart();
            Storage.shuriken[2].MoveToStart();
            Storage.shuriken[3].MoveToStart();
        }

        public void ResetBidsText()
        {
            label1.Text = "Player 1 hasn't placed a bit.";
            label2.Text = "Player 2 hasn't placed a bit.";
            label3.Text = "Player 3 hasn't placed a bit.";
        }

        public void announceWinner(int winner)
        {
            MessageBox.Show("shuriken #" + winner + " is the winning shuriken!");
            for (int i = 0; i < Storage.gyanbura.Length; i++)
            {
                Storage.gyanbura[i].collectWinningAmount(winner);
                Storage.gyanbura[i].UpdateActivity();
                ResetPositions();
                ResetBidsText();
            }
        }

        private void RaceTime_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Storage.shuriken.Length; i++)
            {
                Storage.shuriken[Storage.rand.Next(0, 4)].isAccelerating();
                if (Storage.shuriken[i].isAccelerating())
                {
                    RaceTime.Stop();
                    RaceTime.Enabled = false;
                    BeginRace.Enabled = true;
                    announceWinner(i + 1);
                }
            }
        }

        private void PlaceBet_Click(object sender, EventArgs e)
        {
            Storage.gyanbura[Storage.genzaiGyanbura].betting((int)numericUpDown1.Value, (int)numericUpDown2.Value);
            Storage.gyanbura[Storage.genzaiGyanbura].UpdateActivity();
        }

        private void StartRace_Click(object sender, EventArgs e)
        {
            RaceTime.Start();
            BeginRace.Enabled = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Storage.genzaiGyanbura = 0;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Storage.genzaiGyanbura = 1;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Storage.genzaiGyanbura = 2;
        }
    }
}
