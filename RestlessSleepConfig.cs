using StardewValley;
using StardewModdingAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestlessSleepMod
{
    public class RestlessSleepConfig : Config
    {
        public int energyFromSleep { get; set; }
        public int emergencyEnergy { get; set; }
        

        public override T GenerateDefaultConfig<T>()
        {
            energyFromSleep = 0;
            emergencyEnergy = 0;
            return this as T;
        }
    }

}
