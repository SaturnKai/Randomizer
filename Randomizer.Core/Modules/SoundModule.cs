using System;
using System.Collections.Generic;

using Randomizer.Core.Formats;

namespace Randomizer.Core.Modules
{
    public class SoundModule : Module
    {
        public SoundModule(Random random, string original, string output, string temp)
            : base(random, original, output, temp)
        {

        }

        public void Randomize()
        {
            SFX sfx = new SFX($"{original}/HIRO/HIRO.SFX");
            List<(string, int)> sounds = sfx.Extract(temp);

            sfx = new SFX();

            int[] ignored = { 0, 11, 12, 22, 23, 27, 28 };
            List<(string, int)> list = new List<(string, int)>();

            for (int i = 0; i < ignored.Length; i++)
                list.Add(sounds[ignored[i]]);

            for (int i = 0; i < ignored.Length; i++)
                sounds.RemoveAt(ignored[i] - i);

            for (int i = 0; i < 26; i++)
            {
                int index = random.Next(0, sounds.Count - 1);
                (string, int) sound = sounds[index];
                sfx.Add(sound.Item1, sound.Item2);
                sounds.RemoveAt(index);
            }

            for (int i = 0; i < ignored.Length; i++)
                sfx.Insert(list[i].Item1, list[i].Item2, ignored[i]);

            sfx.Export($"{output}/HIRO/HIRO.SFX");
        }
    }
}