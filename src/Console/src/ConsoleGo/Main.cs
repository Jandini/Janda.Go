using Microsoft.Extensions.Logging;
#if (all)
using Serilog;
#endif

namespace ConsoleGo
{
    internal class Main : IMain
    {
        readonly ILogger<Main> _logger;
#if (all)
        readonly ILoggerFactory _loggerFactory;
        readonly Settings _settings;
#endif

#if (all)
        public Main(ILogger<Main> logger, ILoggerFactory loggerFactory, Settings settings)
#else
        public Main(ILogger<Main> logger)
#endif
        {
            _logger = logger;
#if (all)
            _loggerFactory = loggerFactory;
            _settings = settings;
#endif
        }

        public void Run()
        {
#if (all)
            _logger.LogInformation(_settings.Message ?? "Message is missing in appsettings.json under Go section.");
#else
            _logger.LogInformation("Hello, World");
#endif
        }
#if (all)
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
#endif
    }
}
