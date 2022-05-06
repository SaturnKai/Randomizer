using System;
using System.IO;
using System.Collections.Generic;

using Randomizer.Core.Formats;

namespace Randomizer.Core.Modules
{
    public class LevelModule : Module
    {
        private string[] worlds = { "HIRO", "HILLS", "INCA", "ARCTIC", "COWBOY", "FIELD", "ATLANT", "HAZE", "MARS", "HELL" };

        public LevelModule(Random random, string original, string output, string temp)
            : base(random, original, output, temp)
        {

        }

        public void Randomize()
        {
            List<string> regular = new List<string>(), bonus = new List<string>(), hidden = new List<string>();
            for (int i = 0; i < worlds.Length; i++)
            {
                string world = worlds[i];
                Directory.CreateDirectory($"{temp}/{i}");
                List<string> levels = new PAK($"{original}/{world}/{world}.PAK").Extract($"{temp}/{i}");

                int index = 0;
                foreach (string level in levels)
                {
                    if (index < 15) regular.Add(level);
                    else if (index < 18) bonus.Add(level);
                    else if (index < 19) hidden.Add(level);
                    else break;
                    index++;
                }
            }

            for (int i = 0; i < worlds.Length; i++)
            {
                string world = worlds[i];
                int index = 0;

                PAK pak = new PAK();
                for (int x = 0; x < 15; x++)
                {
                    index = random.Next(0, regular.Count - 1);
                    pak.Add(regular[index]);
                    regular.RemoveAt(index);
                }

                for (int x = 0; x < 3; x++)
                {
                    index = random.Next(0, bonus.Count - 1);
                    pak.Add(bonus[index]);
                    bonus.RemoveAt(index);
                }

                index = random.Next(0, hidden.Count - 1);
                pak.Add(hidden[index]);
                hidden.RemoveAt(index);

                pak.Export($"{output}/{world}/{world}.PAK");
            }
        }
    }
}