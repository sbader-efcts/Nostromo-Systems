using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;

namespace NostromoSystems
{
    public partial class ConfirmationLoadSave : Form
    {
        SoundPlayer buttonSound = new SoundPlayer(@".\Graphics\button-41.wav");
        public ConfirmationLoadSave()
        {
            InitializeComponent();
        }

        private void ConfirmationLoadSave_Load(object sender, EventArgs e)
        {
            buttonSound.Play();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            buttonSound.Play();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            buttonSound.Play();
            this.Hide();
        }

        private void Form3_OnVisibleChanged(object sender, EventArgs e)
        {
            string slotName = File.ReadAllText(@".\Data\slotname.txt");
            if (this.Visible == true)
            {
                switch (slotName)
                {
                    case "SaveSlot1":
                        File.WriteAllText(@".\Saves\Save1\data.nssave", String.Empty);
                        Console.WriteLine("IT WAS SLOT ONE!!");
                        break;
                    case "SaveSlot2":
                        File.WriteAllText(@".\Saves\Save2\data.nssave", String.Empty);
                        Console.WriteLine("IT WAS SLOT TWO!!");
                        break;
                    case "SaveSlot3":
                        File.WriteAllText(@".\Saves\Save3\data.nssave", String.Empty);
                        Console.WriteLine("IT WAS SLOT THREE!!");
                        break;
                }
            }
            else
            {
                //new game rewrite function callback
            }
        }
    }
}
