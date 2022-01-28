using CommandLine;

namespace ConsoleGo
{

    class Options
    {

        [Verb("say", isDefault: true, HelpText = "Say hello.")]
        internal class Say
        {

        }


        [Verb("go", isDefault: false, HelpText = "Create a new directory.")]
        internal class Go
        {
            [Option('n', "name", HelpText = "Directory name.", Required = true)]
            public string? Name { get; set; }
        }

    }
}
