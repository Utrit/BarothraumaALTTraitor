using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using Newtonsoft.Json;


namespace Traitor
{
    class Data
    {
        public string PathToData { get; set; } = "./Data.json";
        public LoadData SavedData { get; set; }
        public WebData WebData { get; set; }
        Mission[] Missions;
        MissionMod[] MissionsMod;
        string[] Jokes;
        string[] JokesMod;
        string JSON;
        string WebJSON;




        public void Load()
        {
            if (File.Exists(PathToData))
            {
                using (StreamReader sr = new StreamReader(PathToData)) { JSON = sr.ReadToEnd(); }
                SavedData = JsonConvert.DeserializeObject<LoadData>(JSON);
            }
            else
            {
                File.Create(PathToData);
            }
            SavedData = JsonConvert.DeserializeObject<LoadData>(JSON);
            WebRequest wr = WebRequest.Create(SavedData.URL);
            WebResponse response = wr.GetResponse();
            using(Stream s = response.GetResponseStream())
            {
                using(StreamReader sr = new StreamReader(s))
                {
                    WebJSON = sr.ReadToEnd();
                }
            }
            WebData = JsonConvert.DeserializeObject<WebData>(WebJSON);
            Jokes = WebData.Jokes;
            JokesMod = WebData.JokesMod;
            Missions = WebData.Missions;
            MissionsMod = WebData.MissionsMod;
        }
        public void Save(string name, string[] other)
        {
            SavedData.Pname = name;
            SavedData.OtherPlayers = other;
            if (File.Exists(PathToData))
            {
                using (StreamWriter sw = new StreamWriter(PathToData))
                {
                    sw.Write(JsonConvert.SerializeObject(SavedData, Formatting.Indented));
                }
            }
            else
            {
                File.Create(PathToData);
            }
        }






        public string GetJokes(int seed)
        {
            Random rnd = new Random(seed);
            string jokes = " " + (JokesMod.ElementAt(rnd.Next(JokesMod.Count()))).ToLower() + " ";
            jokes+= (Jokes.ElementAt(rnd.Next(Jokes.Count()))).ToLower() + " ";
            return jokes;
        }
        public Mission GetMission(int seed)
        {
            Mission msg = new Mission();
            MissionMod mod = new MissionMod();
            Random rnd = new Random(seed);
            Mission mis = Missions.ElementAt(rnd.Next(Missions.Count()));
            int chance = rnd.Next(100);
            while (chance > mis.procentage) {
                mis = Missions.ElementAt(rnd.Next(Missions.Count()));
                chance = rnd.Next(100);
            }
            for(int i = 0; i < 30; i++)
            {
                mod = MissionsMod.ElementAt(rnd.Next(MissionsMod.Count()));
                if (mod.MissionModType == mis.MissionType && rnd.Next(100)<mod.procentage)
                {
                    break;
                }
                else if(i==29)
                {
                    mod = new MissionMod();
                    mod.MissionModName = "";
                    break;
                }
            }
            msg.MissionName = " " + mis.MissionName.ToLower() + " " +  mod.MissionModName.ToLower() + " ";
            msg.AgainstPlayer = mis.AgainstPlayer;
            msg.MissionType = mis.MissionType;
            return msg;
        }
    }


    class LoadData
    {
        public string Pname { get; set; } = "None";
        public string URL { get; set; } = "https://paste.dimdev.org/raw/ekakometes";
        public string[] OtherPlayers { get; set; } = new string[] { "None" };

    }
    class WebData
    {
        public object[] Players { get; set; } = new object[] { "None" };
        public string[] Jokes { get; set; } = new string[] { "None" };
        public string[] JokesMod { get; set; } = new string[] { "None" };
        public Mission[] Missions { get; set; } = new Mission[] { new Mission() };
        public MissionMod[] MissionsMod { get; set; } = new MissionMod[] { new MissionMod() };
    }

    class Mission
    {
        public string MissionType { get; set; } = "None";
        public string MissionName { get; set; } = "None";
        public bool AgainstPlayer { get; set; } = true;
        public int procentage { get; set; } = 100;
    }
    class MissionMod
    {
        public string MissionModType { get; set; } = "None";
        public string MissionModName { get; set; } = "None";
        public int procentage { get; set; } = 100;
    }
}
