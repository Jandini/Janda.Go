using Microsoft.Extensions.Logging;
#if (allFeatures)
using Serilog;
#endif

namespace ConsoleGo
{
    internal class Main : IMain
    {
        readonly ILogger<Main> _logger;
#if (allFeatures)
        readonly ILoggerFactory _loggerFactory;
        readonly Settings _settings;
#endif

#if (allFeatures)
        public Main(ILogger<Main> logger, ILoggerFactory loggerFactory, Settings settings)
#else
        public Main(ILogger<Main> logger)
#endif
        {
            _logger = logger;
#if (allFeatures)
            _loggerFactory = loggerFactory;
            _settings = settings;
#endif
        }

        public void Run()
        {
#if (allFeatures)
            _logger.LogInformation(_settings.Message ?? "Message is missing in appsettings.json under Go section.");
#else
            _logger.LogInformation("Hello, World");
            _logger.LogWarning("No implementation");
            throw new NotImplementedException("Fix it");
#endif
        }
#if (allFeatures)
        public void Go(string name)
        {            
            _logger.LogInformation("Adding new file logger")

            _loggerFactory
              .AddSerilog(new LoggerConfiguration()
              .WriteTo.File(Path.ChangeExtension(Path.Combine(name, name), "log"))
              .CreateLogger(), dispose: true);
            
            _logger.LogWarning("New logger was added")
            _logger.LogInformation("Creating {name} directory in {path}", name, Directory.GetCurrentDirectory());
            var info = Directory.CreateDirectory(name);
            _logger.LogInformation("Directory {name} created successfully", info.FullName);
            
            throw new NotImplementedException();
        }
#endif
    }
}