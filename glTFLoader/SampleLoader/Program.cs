using glTFGeneratedLoader;
using System;
using System.IO;

namespace SampleLoader
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"..\..\Triangle.gltf";
            string text = File.ReadAllText(filePath);
            GlTF gltf_data = GlTF.FromJson(text);

            Console.Write(gltf_data.ToString());
            Console.ReadLine();
        }
    }
}
