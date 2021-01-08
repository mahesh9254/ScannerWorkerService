using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.WindowsServices;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ScannerWorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            
            while (!stoppingToken.IsCancellationRequested)
            {
                if (WindowsServiceHelpers.IsWindowsService())
                {
                    _logger.LogInformation("Running as window service");
                }
                else { 
                _logger.LogInformation("Not Running as window service");
                }
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
