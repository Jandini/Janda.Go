using Microsoft.Extensions.Logging;

namespace ConsoleGo
{
    internal class Main : IMain
    {
        readonly ILogger<Main> _logger;
        readonly Settings _settings;

        public Main(ILogger<Main> logger, Settings settings)
        {
            _logger = logger;
            _settings = settings;
        }

        public void Run()
        {
            _logger.LogInformation(_settings.Message ?? "Message is missing in appsettings.json under Go section.");
        }

        public void Run(string name)
        {
            _logger.LogInformation("Creating {name} directory in {path}", name, Directory.GetCurrentDirectory());
            Directory.CreateDirectory(name);
            _logger.LogInformation("Directory {name} created successfully", name);
        }
    }
}
