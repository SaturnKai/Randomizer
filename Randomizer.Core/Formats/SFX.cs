using System.IO;
using System.Collections.Generic;

namespace Randomizer.Core.Formats
{
    public class SOUND
    {
        public int offset, pitch;
    }

    public class SFX
    {
        private string path;
        private List<(string, int)> sounds;

        public SFX(string path = "")
        {
            this.path = path;
            this.sounds = new List<(string, int)>();
        }

        public void Add(string path, int pitch) => sounds.Add((path, pitch));

        public void Insert(string path, int pitch, int index) => sounds.Insert(index, (path, pitch));

        public bool Export(string path)
        {
            FileStream stream = File.Open(path, FileMode.Create);
            BinaryWriter writer = new BinaryWriter(stream);
            List<int> offsets = new List<int>();

            int count = sounds.Count;
            writer.Write(count);
            for (int i = 0; i < count * 8; i++) writer.Write((byte)0);

            for (int i = 0; i < count; i++)
            {
                byte[] data = File.ReadAllBytes(sounds[i].Item1);
                offsets.Add((int)stream.Position);
                writer.Write(data);
            }

            stream.Seek(4, SeekOrigin.Begin);
            for (int i = 0; i < count; i++)
            {
                writer.Write(offsets[i]);
                writer.Write(sounds[i].Item2);
            }

            writer.Close();
            stream.Close();

            return true;
        }

        public List<(string, int)> Extract(string path)
        {
            FileStream stream = File.Open(this.path, FileMode.Open);
            BinaryReader reader = new BinaryReader(stream);

            List<SOUND> sounds = new List<SOUND>();

            int count = reader.ReadInt32();
            for (int i = 0; i < count; i++)
            {
                SOUND sound = new SOUND();
                sound.offset = reader.ReadInt32();
                sound.pitch = reader.ReadInt32();
                sounds.Add(sound);
            }

            bool finished = false;
            for (int i = 0; i < count; i++)
            {
                SOUND sound = sounds[i];

                if (sounds.Count == i + 1)
                    finished = true;

                FileStream sStream = File.Create($"{path}/S-{i + 1}");
                BinaryWriter writer = new BinaryWriter(sStream);

                stream.Seek(sound.offset, SeekOrigin.Begin);

                while (true)
                {
                    if (stream.Length == stream.Position) break;
                    writer.Write(reader.ReadByte());
                    if (!finished && (int)stream.Position == sounds[i + 1].offset) break;
                }

                sStream.Close();
                writer.Close();

                this.sounds.Add(($"{path}/S-{i + 1}", sound.pitch));
            }

            reader.Close();
            stream.Close();

            return this.sounds;
        }
    }
}
