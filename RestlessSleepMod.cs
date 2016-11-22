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
        public RestlessSleepConfig config;
        private float pre_stam; //stores stamina at the end of the day to overwrite the filled stamina at the beginning of the day

        public override void Entry(IModHelper helper)
        {
            config = helper.ReadConfig<RestlessSleepConfig>();
            StardewModdingAPI.Events.TimeEvents.OnNewDay += Event_OnNewDay;
        }

        private void Event_OnNewDay(object sender, EventArgs e)
        {
            Farmer Player = Game1.player;

            if (Game1.newDay) //Gets player and saves their energy at the end of the day to pre_stam
            {
                double sleep_stam = (config.energyGainRelative) ? config.energyFromSleep * (Player.maxStamina / 270.0) : config.energyFromSleep;
                if (Player.exhausted)
                    sleep_stam = (sleep_stam < 0) ? (sleep_stam * 1.5) : (sleep_stam / 2.0);
                if (Game1.timeOfDay > 2400)
                    sleep_stam = sleep_stam - ((sleep_stam < 0) ? -1 : 1) * (1.0 - (2600 - Math.Min(2600, Game1.timeOfDay)) / 200.0) * (sleep_stam / 2);
                pre_stam = (float)Math.Min(Math.Max(Player.stamina, 0) + sleep_stam, Player.maxStamina);

                double min_stam = (config.energyGainRelative) ? config.minimumEnergy * (Player.maxStamina / 270.0) : config.minimumEnergy;
                if (pre_stam <= min_stam)
                    pre_stam = (float)min_stam;
            }
            else //sets player(s) stamina to the value stored in pre_stam after it's been filled by sleep at the start of the day
            {
                Player.stamina = pre_stam;
            }
        }
    }
}