using Microsoft.Extensions.Logging;

namespace ConGo
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
            _logger.LogInformation(_settings.Message);
        }
    }
}
