using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

using Newtonsoft.Json;
using Randomizer.Core.Formats;

namespace Randomizer.Core.Modules
{
    public class ModelModule : Module
    {
        private GGI ggi;

        public ModelModule(Random random, string original, string output, string temp)
            : base(random, original, output, temp)
        {

        }

        public void RandomizeGroup(dynamic group)
        {
            FileStream stream = File.Open($"{output}/HIRO/HIRO.GGI", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryReader reader = new BinaryReader(stream);

            List<MODEL> models = new List<MODEL>();
            foreach (dynamic modelData in group)
            {
                int offset = Convert.ToInt32("0x" + modelData.offset, 16);
                stream.Seek(offset, SeekOrigin.Begin);
                MODEL model = new MODEL(offset, reader.ReadInt32());

                foreach (dynamic subModelData in modelData.models)
                {
                    offset = Convert.ToInt32("0x" + subModelData.offset, 16);
                    stream.Seek(offset, SeekOrigin.Begin);
                    MODEL sModel = new MODEL(offset, reader.ReadInt32());
                    model.models.Add(sModel);
                }

                models.Add(model);
            }

            reader.Close();
            stream.Close();

            List<MODEL> list = models.ToList();
            for (int i = 0; i < group.Count; i++)
            {
                int index = random.Next(0, list.Count - 1);
                MODEL original = models[i];
                MODEL model = list[index];
                list.RemoveAt(index);

                ggi.ReplaceModel(original, model);
            }
        }

        public void Randomize()
        {
            dynamic data = JsonConvert.DeserializeObject(File.ReadAllText("Model_DB.json"));

            ggi = new GGI($"{output}/HIRO/HIRO.GGI");

            RandomizeGroup(data.models.balls);
            RandomizeGroup(data.models.enemies);
            RandomizeGroup(data.models.objects);
        }
    }
}