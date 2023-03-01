using System.CommandLine;

namespace Koretech.Kraken.Kaml;
class Program
{
    static async Task Main(string[] args)
    {
        var kamlSourceOption = new Option<FileInfo>("--source-file");
        kamlSourceOption.Description = "The source kamlbo file to use";
        kamlSourceOption.AddAlias("-s");
        kamlSourceOption.IsRequired = true;
        var outputDirectoryOption = new Option<DirectoryInfo>("--output-directory");
        outputDirectoryOption.AddAlias("-o");
        outputDirectoryOption.IsRequired = false;
        outputDirectoryOption.Description = "The directory to write the generated files to";
        var namespaceOption = new Option<string>("--namespace");
        namespaceOption.IsRequired = true;
        namespaceOption.AddAlias("-ns");
        namespaceOption.Description = "The root namespace for generated types.";
        var enableEntityAnnotationsOption = new Option<bool?>("--entity-annotations");
        enableEntityAnnotationsOption.IsRequired = false;
        enableEntityAnnotationsOption.AddAlias("-ea");
        enableEntityAnnotationsOption.Description = "Set to true to enable annotations on entity properties.";

        var rootCommand = new RootCommand("KamlBoGen");
        rootCommand.AddOption(kamlSourceOption);
        rootCommand.AddOption(outputDirectoryOption);
        rootCommand.AddOption(namespaceOption);
        rootCommand.AddOption(enableEntityAnnotationsOption);

        rootCommand.SetHandler( (kamlSource, outputDirectory, rootns, entityAnnotations) => 
        {
            ProcessKamlBo(kamlSource, outputDirectory, rootns, entityAnnotations);
        }, 
        kamlSourceOption, outputDirectoryOption, namespaceOption, enableEntityAnnotationsOption);
        await rootCommand.InvokeAsync(args);
    }

    public static void ProcessKamlBo(FileInfo kamlSource, DirectoryInfo outputDirectory, string rootns, bool? entityAnnotations) {
        Console.WriteLine($"Source kaml file specified was {kamlSource.FullName}");
        if(!kamlSource.Exists) {
            Console.WriteLine("Specified file does not exist!");
        }
        if(outputDirectory == null) {
            Console.WriteLine("Output directory was not specified, using current directory");
        } else {
            Console.WriteLine($"Output directory is {outputDirectory.FullName}");
            if(!outputDirectory.Exists) {
                Console.WriteLine("Output directory does not exist!");
            }
        }
        KamlBoGen gen = new();
        gen.OutputRoot = outputDirectory ?? new DirectoryInfo(Directory.GetCurrentDirectory());
        gen.RootNamespace = rootns;
        gen.EntityAnnotations = entityAnnotations ?? false;
        gen.SourceKamlBo = kamlSource;
        gen.Generate();
    }
}
