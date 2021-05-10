using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Traitor
{

    public partial class Window : Form
    {
        string Player = "None";
        string Version = "1.5";
        int pnum = 0;
        List<string> otherPlayers = new List<string>();
        Data saveddata = new Data();
        object[] players = new object[]{
            "None1",
            };

        public Window()
        {
            InitializeComponent();
        }

        private void Window_Load(object sender, EventArgs e)
        {
            Random rnd = new Random();
            SeedTextBox.Text = rnd.Next(999999999).ToString();
            saveddata.Load();
            players = saveddata.WebData.Players;
            Player = saveddata.SavedData.Pname;
            PlayerNameInput.Text = Player;
            PlayersCheckList.Items.AddRange(players);

            for (int i = 0; i < saveddata.WebData.Players.Count(); i++)
            {
                if (saveddata.SavedData.OtherPlayers.Contains(saveddata.WebData.Players[i]))
                {
                    PlayersCheckList.SetItemChecked(i, true);
                }
            }
            VersionLabel.Text = "ver:"+saveddata.WebData.GetHashCode().ToString() + "/" + Version;
            UpdChecks();
        }

        private void Checklist_MouseUp(object sender, MouseEventArgs e)
        {
            UpdChecks();
        }

        private void TextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            
            if (players.Contains(PlayerNameInput.Text))
            {
                Player = PlayerNameInput.Text;
            }
            UpdChecks();
        }
        private void UpdChecks()
        {
            int chec = 0;
            otherPlayers = new List<string>();
            string label = Player + ", и \n";
            for (int i = 0; i < PlayersCheckList.Items.Count; i++)
            {
                if (Player == (string)PlayersCheckList.Items[i])
                {
                    pnum = chec;
                    PlayersCheckList.SetItemChecked(i, true);
                    otherPlayers.Add((string)PlayersCheckList.Items[i]);
                }
                else
                if (PlayersCheckList.GetItemChecked(i))
                {
                    chec++;
                    string str = (string)PlayersCheckList.Items[i] + "\n";
                    otherPlayers.Add((string)PlayersCheckList.Items[i]);
                    label += str;
                }
            }
            SelectedLabel.Text = label;
        }
        private void MakeRandom()
        {
            saveddata.Save(Player, otherPlayers.ToArray());
            if (otherPlayers.Count() > 2)
            {

                int seed = int.Parse(SeedTextBox.Text);
                string prevtype = "";
                string prevname = "";
                int misnum = 1;
                Random rnd = new Random(seed);
                string answer = "ТРЕЙТОР!!!";
                int count = rnd.Next(5) + 2;
                int target = rnd.Next(otherPlayers.Count());
                int trator = rnd.Next(otherPlayers.Count());
                int strator = rnd.Next(otherPlayers.Count());
                if (rnd.Next(100) > 10 || otherPlayers.Count() < 4)
                {
                    strator = -1;
                }
                while (trator == target || strator == target) { target = rnd.Next(otherPlayers.Count()); }
                if (trator == pnum || strator == pnum)
                {
                    for (int i = 0; i < count + 1; i++)
                    {

                        Mission randmission = saveddata.GetMission(seed + i * 100);
                        if (randmission.AgainstPlayer && prevtype != randmission.MissionType && prevname != randmission.MissionName)
                        {
                            if (strator != -1 && strator != trator)
                            {
                                answer += "\n" + (misnum).ToString() + " Ты и " + otherPlayers.ElementAt(strator != pnum ? strator : trator) + " Должны" + randmission.MissionName + otherPlayers.ElementAt(target);
                            }
                            else
                            {
                                answer += "\n" + (misnum).ToString() + " Ты Должeн" + randmission.MissionName + otherPlayers.ElementAt(target);
                            }
                            prevtype = randmission.MissionType;
                            prevname = randmission.MissionName;
                            misnum++;
                        }
                        else if (!randmission.AgainstPlayer && prevname != randmission.MissionName)
                        {
                            if (strator != -1)
                            {
                                answer += "\n" + (misnum).ToString() + " Ты и " + otherPlayers.ElementAt(strator != pnum ? strator : trator) + " Должны" + randmission.MissionName;
                            }
                            else
                            {
                                answer += "\n" + (misnum).ToString() + " Ты Должeн" + randmission.MissionName;
                            }
                            prevname = randmission.MissionName;
                            misnum++;
                        }
                    }
                }
                else
                {
                    answer = "Ты бля даже не челове ты блядь -\n" + saveddata.GetJokes(seed + pnum);
                    if (rnd.Next(100) < 30 && target == pnum)
                    {
                        if (rnd.Next(100) < 60)
                        {
                            answer += "\n Ты можешь быть целью - " + otherPlayers.ElementAt(trator);
                        }
                        else
                        {
                            int fake = rnd.Next(otherPlayers.Count());
                            while (fake == pnum) { fake = rnd.Next(otherPlayers.Count()); }
                            answer += "\n Ты можешь быть целью - " + otherPlayers.ElementAt(fake);
                        }
                    }
                }
                QuestRichTextBox.Text = answer;
            }
            //QuestRichTextBox.Text = Player + saveddata.GetJokes(seed)+ "\n" + randmission.MissionName;
        }
        private void RandomSeed_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            SeedTextBox.Text = rnd.Next(999999999).ToString();
            Clipboard.SetText(SeedTextBox.Text);
        }

        private void RandomButton_Click(object sender, EventArgs e)
        {
            MakeRandom();
        }

        private void InsertRandom_Click(object sender, EventArgs e)
        {
            SeedTextBox.Text = Clipboard.GetText();
            MakeRandom();
        }
    }
}
