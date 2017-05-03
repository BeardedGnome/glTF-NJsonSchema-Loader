using NJsonSchema;
using NJsonSchema.CodeGeneration.CSharp;
using System;
using System.IO;
using System.Threading.Tasks;

namespace glTFCodeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task = new Task(ProcessSchemaAsync);
            task.Start();
            task.Wait();
            Console.ReadLine();
        }

        static async void ProcessSchemaAsync()
        {
            string schemaFilePath = @"D:\repos\glTF\specification\2.0\schema\glTF.schema.json";
            JsonSchema4 schema = await JsonSchema4.FromFileAsync(schemaFilePath);
            var settings = new CSharpGeneratorSettings { ClassStyle = CSharpClassStyle.Poco, Namespace = "glTFGeneratedLoader" };
            var generator = new CSharpGenerator(schema, settings);
            var file = generator.GenerateFile();

            string outputFileName = "GeneratedLoader.cs";
            File.WriteAllText(outputFileName, file);
        }
    }
}
