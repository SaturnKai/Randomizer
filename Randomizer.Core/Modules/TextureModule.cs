using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Randomizer.Core.Modules
{
    public class TextureModule : Module
    {
        private string[] worlds = { "HIRO", "HILLS", "INCA", "ARCTIC", "COWBOY", "FIELD", "ATLANT", "HAZE", "MARS", "HELL" };

        public TextureModule(Random random, string original, string output, string temp)
            : base(random, original, output, temp)
        {

        }

        public void Randomize()
        {
            foreach (string world in worlds)
                File.Copy($"{original}/{world}/{world}.TGI", $"{temp}/{world}.TGI", true);

            List<string> list = worlds.ToList();
            foreach (string world in worlds)
            {
                int index = random.Next(0, list.Count - 1);
                File.Copy($"{temp}/{list[index]}.TGI", $"{output}/{world}/{world}.TGI", true);
                list.RemoveAt(index);
            }
        }
    }
}