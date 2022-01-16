using Microsoft.Extensions.Logging;

namespace Janda.Go
{
    internal class Main : IMain
    {
        readonly ILogger<Main> _logger;

        public Main(ILogger<Main> logger)
        {
            _logger = logger;
        }

        public void Run()
        {
            _logger.LogInformation("Hello, World!");
        }
    }
}
