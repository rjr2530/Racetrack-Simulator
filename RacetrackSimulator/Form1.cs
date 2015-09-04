using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RacetrackSimulator
{
    public partial class Form1 : Form
    {
        Greyhound[] racers;
        Guy[] bettors;
        Random MyRandomizer = new Random();

        public Form1()
        {
            InitializeComponent();

            racers = new Greyhound[4];
            bettors = new Guy[3];

            racers[0] = new Greyhound()
            {
                MyPictureBox = pictureBox1,
                StartingPosition = pictureBox1.Left,
                RacetrackLength = racetrackPictureBox.Width - pictureBox1.Width,
                Randomizer = MyRandomizer
            };

            racers[1] = new Greyhound()
            {
                MyPictureBox = pictureBox2,
                StartingPosition = pictureBox2.Left,
                RacetrackLength = racetrackPictureBox.Width - pictureBox2.Width,
                Randomizer = MyRandomizer
            };

            racers[2] = new Greyhound()
            {
                MyPictureBox = pictureBox3,
                StartingPosition = pictureBox3.Left,
                RacetrackLength = racetrackPictureBox.Width - pictureBox3.Width,
                Randomizer = MyRandomizer
            };

            racers[3] = new Greyhound()
            {
                MyPictureBox = pictureBox4,
                StartingPosition = pictureBox4.Left,
                RacetrackLength = racetrackPictureBox.Width - pictureBox4.Width,
                Randomizer = MyRandomizer
            };

            bettors[0] = new Guy()
            {
                Name = "Joe",
                Cash = 100,
                MyLabel = joeLabel,
                MyRadioButton = joeRadioButton,
                MyBet = null
            };

            bettors[1] = new Guy()
            {
                Name = "Bob",
                Cash = 100,
                MyLabel = bobLabel,
                MyRadioButton = bobRadioButton,
                MyBet = null
            };

            bettors[2] = new Guy()
            {
                Name = "Al",
                Cash = 100,
                MyLabel = alLabel,
                MyRadioButton = alRadioButton,
                MyBet = null
            };


            for(int i = 0; i < bettors.Length; i++)
            {
                bettors[i].ClearBet();
                bettors[i].UpdateLabels();
            }
        }

        private void joeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            nameLabel.Text = bettors[0].Name;         
        }

        private void bobRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            nameLabel.Text = bettors[1].Name; 
        }

        private void alRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            nameLabel.Text = bettors[2].Name; 
        }

        private void betButton_Click(object sender, EventArgs e)
        {
            if(joeRadioButton.Checked)
            {
                bettors[0].PlaceBet((int)numericUpDown1.Value, (int)numericUpDown2.Value);
                bettors[0].UpdateLabels();
            }

            if (bobRadioButton.Checked)
            {
                bettors[1].PlaceBet((int)numericUpDown1.Value, (int)numericUpDown2.Value);
                bettors[1].UpdateLabels();
            }

            if (alRadioButton.Checked)
            {
                bettors[2].PlaceBet((int)numericUpDown1.Value, (int)numericUpDown2.Value);
                bettors[2].UpdateLabels();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for(int i = 0; i < racers.Length; i++)
            {
                if(racers[i].Run())
                {
                    timer1.Stop();
                    MessageBox.Show("Dog " + (i + 1) + " has won!!!");
                    for (int h = 0; h < racers.Length; h++)
                    {
                        racers[h].TakeStartingPosition();
                    }
                    groupBox1.Enabled = true;

                    for(int w = 0; w < bettors.Length; w++)
                    {
                        bettors[w].Collect(i);
                    }

                    numericUpDown1.Value = 5;
                    numericUpDown2.Value = 1;                   
                }
            }
        }

        private void raceButton_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;

            timer1.Start();
        }
    }
}
