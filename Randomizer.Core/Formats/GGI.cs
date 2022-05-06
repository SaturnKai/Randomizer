using System.IO;
using System.Collections.Generic;

namespace Randomizer.Core.Formats
{
    public class MODEL
    {
        public int offset, data;

        public List<MODEL> models = new List<MODEL>();

        public MODEL(int offset, int data)
        {
            this.offset = offset;
            this.data = data;
        }
    }

    public class GGI
    {
        private string path;

        public GGI(string path) => this.path = path;

        public void ReplaceModel(MODEL model, MODEL original)
        {
            FileStream stream = File.Open(this.path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryWriter writer = new BinaryWriter(stream);

            stream.Seek(original.offset, SeekOrigin.Begin);
            writer.Write(model.data);

            for (int i = 0; i < model.models.Count; i++)
            {
                stream.Seek(original.models[i].offset, SeekOrigin.Begin);
                writer.Write(model.models[i].data);
            }

            stream.Close();
            writer.Close();
        }
    }
}
