using Microsoft.Extensions.Logging;
using Serilog;

namespace ConsoleGo
{
    internal class Main : IMain
    {
        readonly ILogger<Main> _logger;
        readonly ILoggerFactory _loggerFactory;
        readonly Settings _settings;

        public Main(ILogger<Main> logger, Settings settings, ILoggerFactory loggerFactory)
        {
            _logger = logger;
            _settings = settings;
            _loggerFactory = loggerFactory;
        }

        public void Run()
        {
            _logger.LogInformation(_settings.Message ?? "Message is missing in appsettings.json under Go section.");
        }

        public void Go(string name)
        {            
            using var logger = _loggerFactory
              .AddSerilog(new LoggerConfiguration()
              .WriteTo.File(Path.ChangeExtension(Path.Combine(name, name), "log"))
              .CreateLogger(), dispose: true);
            
            _logger.LogInformation("Creating {name} directory in {path}", name, Directory.GetCurrentDirectory());
            var info = Directory.CreateDirectory(name);
            _logger.LogInformation("Directory {name} created successfully", info.FullName);
        }
    }
}
