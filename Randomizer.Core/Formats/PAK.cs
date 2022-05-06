using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

using Ionic.Zlib;

namespace Randomizer.Core.Formats
{
    public class FILE
    {
        public int offset, size, name;
    }

    public class PAK
    {
        private string path;
        private List<string> files;

        public PAK(string path = "")
        {
            this.path = path;
            files = new List<string>();
        }

        public void Add(string path) => files.Add(path);

        public bool Export(string path)
        {
            FileStream stream = File.Open(path, FileMode.Create);
            BinaryWriter writer = new BinaryWriter(stream);
            List<int> offsets = new List<int>(), sizes = new List<int>(), names = new List<int>();

            int count = files.Count;
            writer.Write(count);
            for (int i = 0; i < count * 12; i++) writer.Write((byte)0);

            for (int i = 0; i < count; i++)
            {
                names.Add((int)stream.Position);
                writer.Write(Encoding.ASCII.GetBytes(Path.GetFileName(files[i])));
                writer.Write((ushort)10);
            }

            for (int i = 0; i < count; i++)
            {
                byte[] data = ZlibStream.CompressBuffer(File.ReadAllBytes(files[i]));
                offsets.Add((int)stream.Position);
                sizes.Add(data.Length);
                writer.Write(data);
            }

            stream.Seek(4, SeekOrigin.Begin);
            for (int i = 0; i < count; i++)
            {
                writer.Write(offsets[i]);
                writer.Write(sizes[i]);
            }

            for (int i = 0; i < count; i++)
            {
                writer.Write(names[i]);
            }

            writer.Close();
            stream.Close();

            return true;
        }

        public List<string> Extract(string path)
        {
            FileStream stream = File.Open(this.path, FileMode.Open);
            BinaryReader reader = new BinaryReader(stream);

            List<FILE> files = new List<FILE>();

            int count = reader.ReadInt32();
            for (int i = 0; i < count; i++)
            {
                FILE file = new FILE();
                file.offset = reader.ReadInt32();
                file.size = reader.ReadInt32();
                files.Add(file);
            }

            for (int i = 0; i < count; i++)
            {
                files[i].name = reader.ReadInt32();
            }

            for (int i = 0; i < count; i++)
            {
                FILE file = files[i];
                stream.Seek(file.name, SeekOrigin.Begin);
                string name = "";
                while (true)
                {
                    byte character = reader.ReadByte();
                    if (character == 10 || character == 0) break;
                    name += Convert.ToChar(character);
                }

                byte[] data = new byte[file.size];
                stream.Seek(file.offset, SeekOrigin.Begin);
                stream.Read(data, 0, file.size);
                File.WriteAllBytes(path + "/" + name, ZlibStream.UncompressBuffer(data));
                this.files.Add(path + "/" + name);
            }

            reader.Close();
            stream.Close();

            return this.files;
        }
    }
}