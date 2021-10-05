using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Resources;
using System.IO;

namespace NostromoSystems
{
    public partial class StartMenu : Form
    {
        SoundPlayer buttonSound = new SoundPlayer(@".\Graphics\button-41.wav");
        private bool isNewSaveMenu = false;
        private bool isLoadSaveMenu = false;
        private bool isViewSaveMenu = false;
        private bool isFullscreen = true;
        private bool isWindowed = false;
        string popupTEXT = File.ReadAllText(@".\Data\popup.txt");
        string voiceTEXT = File.ReadAllText(@".\Data\voice.txt");
        string iltgTEXT = File.ReadAllText(@".\Data\iltg.txt");
        string slotName;
        ConfirmationNewSave ConfirmationNewSave = new ConfirmationNewSave();
        ConfirmationLoadSave ConfirmationLoadSave = new ConfirmationLoadSave();




        public StartMenu()
        {
            InitializeComponent();
            TabStop = false;
            Console.WriteLine(popupTEXT + "\n" + voiceTEXT + "\n" + iltgTEXT);
            File.WriteAllText(@".\Data\confirmationNSpopupIsActive.txt", "no, sadly it is not active");
        }

        private void popup_Click(object sender, EventArgs e)
        {
            buttonSound.Play();
            if (popupboxChBxexception.Checked)
            {
                File.WriteAllText(@".\Data\popup.txt", "checked p");
                popupTEXT = File.ReadAllText(@".\Data\popup.txt");
                voiceTEXT = File.ReadAllText(@".\Data\voice.txt");
                iltgTEXT = File.ReadAllText(@".\Data\iltg.txt");
            }
            else
            {
                File.WriteAllText(@".\Data\popup.txt", "unchecked p");
                popupTEXT = File.ReadAllText(@".\Data\popup.txt");
                voiceTEXT = File.ReadAllText(@".\Data\voice.txt");
                iltgTEXT = File.ReadAllText(@".\Data\iltg.txt");
            }
        }

        private void voice_Click(object sender, EventArgs e)
        {
            buttonSound.Play();
            if (noRobotslabelexception.Checked)
            {
                File.WriteAllText(@".\Data\voice.txt", "checked v");
                popupTEXT = File.ReadAllText(@".\Data\popup.txt");
                voiceTEXT = File.ReadAllText(@".\Data\voice.txt");
                iltgTEXT = File.ReadAllText(@".\Data\iltg.txt");
            }
            else
            {
                File.WriteAllText(@".\Data\voice.txt", "unchecked v");
                popupTEXT = File.ReadAllText(@".\Data\popup.txt");
                voiceTEXT = File.ReadAllText(@".\Data\voice.txt");
                iltgTEXT = File.ReadAllText(@".\Data\iltg.txt");
            }
        }

        private void iltg_Click(object sender, EventArgs e)
        {
            buttonSound.Play();
            if (IRLTGlabelexception.Checked)
            {
                File.WriteAllText(@".\Data\iltg.txt", "checked g");
                popupTEXT = File.ReadAllText(@".\Data\popup.txt");
                voiceTEXT = File.ReadAllText(@".\Data\voice.txt");
                iltgTEXT = File.ReadAllText(@".\Data\iltg.txt");
            }
            else
            {
                File.WriteAllText(@".\Data\iltg.txt", "unchecked g");
                popupTEXT = File.ReadAllText(@".\Data\popup.txt");
                voiceTEXT = File.ReadAllText(@".\Data\voice.txt");
                iltgTEXT = File.ReadAllText(@".\Data\iltg.txt");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            {
                buttonSound.Play();
                if (File.ReadAllText(@".\Data\voice.txt") == "checked v")
                {
                    noRobotslabelexception.CheckState = CheckState.Checked;
                }
                else
                {
                    noRobotslabelexception.CheckState = CheckState.Unchecked;
                }

                if (File.ReadAllText(@".\Data\popup.txt") == "checked p")
                {
                    popupboxChBxexception.CheckState = CheckState.Checked;
                }
                else
                {
                    popupboxChBxexception.CheckState = CheckState.Unchecked;
                }

                if (File.ReadAllText(@".\Data\iltg.txt") == "checked g")
                {
                    IRLTGlabelexception.CheckState = CheckState.Checked;
                }
                else
                {
                    IRLTGlabelexception.CheckState = CheckState.Unchecked;
                }
            }
            {
                Screen[] Screens = Screen.AllScreens;
                ActiveForm.WindowState = FormWindowState.Normal;
                ActiveForm.FormBorderStyle = FormBorderStyle.None;
                ActiveForm.WindowState = FormWindowState.Maximized;
                foreach (Control c in Controls)
                {
                    if (c.Name.Contains("Graphicsexception") || c.Name.Contains("Preferancesexception"))
                    {
                        Font Font = new Font("Lucida Console", 20, FontStyle.Bold);
                        c.Font = Font;
                    }
                    else if (c.Name.Contains("exception"))
                    {
                        Font Font = new Font("Lucida Console", 10, FontStyle.Regular);
                        c.Font = Font;
                    }
                    else if (c.Name.Contains("NSoptions"))
                    {
                        Font Font = new Font("Lucida Console", 26, FontStyle.Bold);
                        c.Font = Font;
                    }
                    else if (c.Name == "Fbutton" || c.Name == "Wbutton" || c.Name == "ReturnToMenu" || c.Name == "SavesListButton")
                    {
                        Font Font = new Font("Lucida Console", 10, FontStyle.Bold);
                        c.Font = Font;
                    }
                    else if (c is Button)
                    {
                        Font Font = new Font("Lucida Console", 36, FontStyle.Bold);
                        c.Font = Font;
                    }
                    else if (c is Label)
                    {
                        Font Font = new Font("Lucida Console", 36, FontStyle.Bold);
                        c.Font = Font;
                    }
                }
            }
            Console.WriteLine(File.ReadAllText(@".\Saves\Save1\data.yutani"));
            //File.ReadLines(string path).Skip(int lines).Take(1).First();
        }

        private void button1_Click(object sender, EventArgs e)//fullscreenbutton
        {
            buttonSound.Play();
            if(isFullscreen == true)
            {
                return;
            }
            else
            {
                ActiveForm.WindowState = FormWindowState.Normal;
                ActiveForm.FormBorderStyle = FormBorderStyle.None;
                ActiveForm.WindowState = FormWindowState.Maximized;
                isFullscreen = true;
                isWindowed = false;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)//windowedbutton
        {
            buttonSound.Play();
            if (isWindowed == true)
            {
                return;
            }
            else
            {
                ActiveForm.StartPosition = FormStartPosition.CenterScreen;
                ActiveForm.FormBorderStyle = FormBorderStyle.Sizable;
                ActiveForm.WindowState = FormWindowState.Normal;
                isFullscreen = false;
                isWindowed = true;
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)//exitbutton
        {
            buttonSound.PlaySync();
            this.Close();
        }
        
        private void Saves_Click(object sender, EventArgs e)//savesbutton
        {
            buttonSound.Play();
            foreach (Control control in Controls)
            {
                if (control.Name == "Fbutton" || control.Name == "Windowed" || control.Name == "PictureBox")
                {
                    return;
                }
                else
                {
                    control.Hide();
                }
                ReturnToMenu.Show();
                SaveSlot1.Show();
                SaveSlot2.Show();
                SaveSlot3.Show();
                MenuTitleLabel.Show();
                isViewSaveMenu = true;
            }
            
        }

        private void ReturnToMenu_Click(object sender, EventArgs e)
        {
            buttonSound.Play();
            foreach (Control control in Controls)
            {
                control.Show();
                ReturnToMenu.Hide();
                SaveSlot1.Hide();
                SaveSlot2.Hide();
                SaveSlot3.Hide();
                popupboxChBxexception.Hide();
                PBChBxDescexception.Hide();
                Graphicsexception.Hide();
                NSoptions.Hide();
                wymenulogo.Hide();
                hahafunnydescexception.Hide();
                IRLTGlabelexception.Hide();
                Preferancesexception.Hide();
                noRobotslabelexception.Hide();
                NRLdescexception.Hide();
                isLoadSaveMenu = false;
                isViewSaveMenu = false;
                isNewSaveMenu = false;
            }
            
        }

        private void NewSaveButton_Click(object sender, EventArgs e)
        {
            buttonSound.Play();
            foreach (Control control in Controls)
            {
                if (control.Name == "Fbutton" || control.Name == "Windowed" || control.Name == "PictureBox")
                {
                    return;
                }
                else
                {
                    control.Hide();
                }
                ReturnToMenu.Show();
                SaveSlot1.Show();
                SaveSlot2.Show();
                SaveSlot3.Show();
                MenuTitleLabel.Show();
                isNewSaveMenu = true;
            }

        }

        private void LoadSaveButton_Click(object sender, EventArgs e)
        {
            buttonSound.Play();
            foreach (Control control in Controls)
            {
                if (control.Name == "Fbutton" || control.Name == "Windowed" || control.Name == "PictureBox")
                {
                    return;
                }
                else
                {
                    control.Hide();
                }
                ReturnToMenu.Show();
                SaveSlot1.Show();
                SaveSlot2.Show();
                SaveSlot3.Show();
                MenuTitleLabel.Show();
                isLoadSaveMenu = true;
            }
        }

        private void Slot_Click(object sender, EventArgs e)
        {
            void NewSave_SlotClick()
            {
                buttonSound.Play();
                var slot = (Label)sender;
                slotName = slot.Name;
                File.WriteAllText(@".\Data\slotname.txt", slotName);
                Console.WriteLine(slotName);
                if (isFullscreen == true)
                {
                    ConfirmationNewSave.StartPosition = FormStartPosition.CenterScreen;
                }
                else
                {
                    ConfirmationNewSave.StartPosition = FormStartPosition.CenterParent;
                }

                ConfirmationNewSave.Show();
            }
            void LoadSave_SlotClick()
            {
                buttonSound.Play();
                var slot = (Label)sender;
                slotName = slot.Name;
                File.WriteAllText(@".\Data\slotname.txt", slotName);
                Console.WriteLine(slotName);
                if (isFullscreen == true)
                {
                    ConfirmationNewSave.StartPosition = FormStartPosition.CenterScreen;
                }
                else
                {
                    ConfirmationNewSave.StartPosition = FormStartPosition.CenterParent;
                }

                ConfirmationLoadSave.Show();
            }
            void ViewSave_SlotClick()
            {
                buttonSound.Play();
                Console.WriteLine("You're attempting to view a save's information!");
            }
            buttonSound.Play();
            if (isLoadSaveMenu == true)
            {
                LoadSave_SlotClick();
            }
            else if(isViewSaveMenu == true)
            {
                ViewSave_SlotClick();
            }
            else if(isNewSaveMenu == true)
            {
                NewSave_SlotClick();
            }
        }

        private void SaveSlot_Enter(object sender, EventArgs e)
        {
            Label ss = (Label)sender;
            ss.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private void OptionsButton_Click(object sender, EventArgs e)
        {
            buttonSound.Play();

            

            foreach (Control control in Controls)
                {
                    if (control.Name == "Fbutton" || control.Name == "Windowed" || control.Name == "PictureBox")
                    {
                        return;
                    }
                    else
                    {
                        control.Hide();
                    }
                    ReturnToMenu.Show();
                    MenuTitleLabel.Show();
                    popupboxChBxexception.Show();
                    PBChBxDescexception.Show();
                    NSoptions.Show();
                    wymenulogo.Show();
                    hahafunnydescexception.Show();
                    IRLTGlabelexception.Show();
                    Preferancesexception.Show();
                    noRobotslabelexception.Show();
                    NRLdescexception.Show();
                    Graphicsexception.Show();
                }
        }

        

        //Inside the class.
    }

    //Inside the namespace.
}
