using StardewValley;
using StardewModdingAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestlessSleepMod
{
    class RestlessSleepConfig : Config
    {
        public int emergencyEnergy { get; set; }
        public int energyFromSleep { get; set; }

        public override T GenerateDefaultConfig<T>()
        {
            emergencyEnergy = 0;
            energyFromSleep = 0;
            return this as T;
        }
    }

}
