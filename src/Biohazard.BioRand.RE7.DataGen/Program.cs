using Biohazard.BioRand.RE7.DataGen.Commands;
using Spectre.Console.Cli;

namespace Biohazard.BioRand.RE7.DataGen
{
    internal static class Program
    {
        public static int Main(string[] args)
        {
            var app = new CommandApp();

            app.Configure(config =>
            {
                config.SetApplicationName("Biohazard.BioRand.RE7.DataGen");

                config.AddCommand<RszToCsCommand>("rsz-to-cs")
                      .WithDescription("Generate C# class from RSZ type");

                config.AddCommand<GenerateCommand>("generate")
                      .WithDescription("Run file generator(s)");
            });

            return app.Run(args);
        }
    }
}