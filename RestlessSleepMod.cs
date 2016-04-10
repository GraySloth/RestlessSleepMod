using StardewValley;
using StardewModdingAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RestlessSleepMod
{
    public class RestlessSleepMod : Mod
    {
        public static RestlessSleepConfig ModConfig { get; private set; }
        private static int energy; //stores stamina at the end of the day to overwrite the filled stamina at the beginning of the day

        public override void Entry(params object[] objects)
        {
            ModConfig = new RestlessSleepConfig().InitializeConfig(BaseConfigPath);
            StardewModdingAPI.Events.TimeEvents.OnNewDay += Event_OnNewDay;
            StardewModdingAPI.Events.TimeEvents.DayOfMonthChanged += Event_DayOfMonthChanged;
        }

        //Gets player(s) and saves the average of their energy at the end of the day to energy
        static void Event_OnNewDay(object sender, EventArgs e)
        {
            List<Farmer> players;
            List<float> staminas = new List<float>();
            Farmer player;
            players = Game1.getAllFarmers();
            foreach (Farmer obj in players)
            {                
                player = (Farmer)obj;
                //Player stamina actually goes into the negative,
                //at a certain point any single stamina consuming action makes you pass out
                //This gives you a little bit of breathing room.
                if (player.stamina < 0){
                    staminas.Add(ModConfig.emergencyEnergy); //default: 0
                }
                else {
                    staminas.Add(player.stamina); 
                }                
            }
            //this adds the average of the player(s) stamina (Currently only one player) with the configurable energy from sleep and saves it to energy
            energy = (int)staminas.Average() + ModConfig.energyFromSleep; 
        }

        //sets player(s) stamina to the value stored in energy after it's been filled by sleep at the start of the day
        static void Event_DayOfMonthChanged(object sender, EventArgs e)
        {
            List<Farmer> players;
            Farmer player;
            players = Game1.getAllFarmers();
            foreach (Farmer obj in players)
            {
                player = (Farmer)obj;
                player.stamina = energy;
            }
        }

    }
}
