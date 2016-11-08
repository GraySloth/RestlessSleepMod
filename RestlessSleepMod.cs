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
        public static RestlessSleepConfig ModConfig { get; protected set; }
        private static float pre_stam; //stores stamina at the end of the day to overwrite the filled stamina at the beginning of the day

        public override void Entry(params object[] objects)
        {
            ModConfig = new RestlessSleepConfig().InitializeConfig(BaseConfigPath);
            StardewModdingAPI.Events.TimeEvents.OnNewDay += Event_OnNewDay;
            StardewModdingAPI.Events.TimeEvents.DayOfMonthChanged += Event_DayOfMonthChanged;
        }

        //Gets player and saves their energy at the end of the day to pre_stam
        static void Event_OnNewDay(object sender, EventArgs e)
        {
            Farmer Player = Game1.player;

            if (Player.stamina < 0) Player.stamina = ModConfig.emergencyEnergy; //default: 0    

            pre_stam = Player.stamina;
        }

        //sets player(s) stamina to the value stored in pre_stam after it's been filled by sleep at the start of the day
        static void Event_DayOfMonthChanged(object sender, EventArgs e)
        {
            Farmer Player = Game1.player;
            Player.stamina = pre_stam + ModConfig.energyFromSleep;
        }

    }
}
