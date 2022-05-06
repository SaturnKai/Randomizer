using System;
using System.IO;

using Randomizer.Core.Modules;

namespace Randomizer.Core
{
    public class Randomizer
    {
        private Random random;
        private string original;
        private string output;
        private string temp;

        private string[] worlds = { "HIRO", "HILLS", "INCA", "ARCTIC", "COWBOY", "FIELD", "ATLANT", "HAZE", "MARS", "HELL" };

        public bool[] options = { false, false, false, false };

        public Randomizer(int seed, string original, string output, string temp)
        {
            random = new Random(seed);
            this.original = original;
            this.output = output;
            this.temp = temp;
        }

        public void SetSeed(int seed)
        {
            random = new Random(seed);
        }

        public void Clean()
        {
            foreach (string world in worlds)
            {
                File.Copy($"{original}/{world}/{world}.PAK", $"{output}/{world}/{world}.PAK", true);
                File.Copy($"{original}/{world}/{world}.TGI", $"{output}/{world}/{world}.TGI", true);
            }

            File.Copy($"{original}/HIRO/HIRO.SFX", $"{output}/HIRO/HIRO.SFX", true);
            File.Copy($"{original}/HIRO/HIRO.GGI", $"{output}/HIRO/HIRO.GGI", true);
        }

        public (bool, Exception) Randomize()
        {
            try
            {
                Clean();

                Directory.CreateDirectory(temp);

                if (options[0]) new LevelModule(random, original, output, temp).Randomize();
                if (options[1]) new TextureModule(random, original, output, temp).Randomize();
                if (options[2]) new SoundModule(random, original, output, temp).Randomize();
                if (options[3]) new ModelModule(random, original, output, temp).Randomize();
            } catch (Exception ex)
            {
                return (false, ex);
            }

            Directory.Delete(temp, true);

            return (true, null);
        }
    }
}