using System;

namespace Randomizer.Core.Modules
{
    public class Module
    {
        public Random random;
        public string original;
        public string output;
        public string temp;

        public Module(Random random, string original, string output, string temp)
        {
            this.random = random;
            this.original = original;
            this.output = output;
            this.temp = temp;
        }
    }
}