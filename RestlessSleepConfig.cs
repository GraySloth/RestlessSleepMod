using StardewValley;
using StardewModdingAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestlessSleepMod
{
    public class RestlessSleepConfig
    {
        public bool energyGainRelative { get; set; }
        public int energyFromSleep { get; set; }
        public int minimumEnergy { get; set; }

        public RestlessSleepConfig()
        {
            this.energyGainRelative = false;
            this.energyFromSleep = 0;
            this.minimumEnergy = 0;
        }
    }
}