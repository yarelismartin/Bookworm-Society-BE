using Bookworm_Society_API.Interfaces;

namespace Bookworm_Society_API.Services
{
    public class VotingSessionChecker : BackgroundService
    {

        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<VotingSessionChecker> _logger;

        public VotingSessionChecker(IServiceProvider serviceProvider, ILogger<VotingSessionChecker> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("VotingSessionChecker service has started");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using(var scope = _serviceProvider.CreateScope())
                    {
                        var votingService = scope.ServiceProvider.GetRequiredService<IVotingSessionService>();

                        await votingService.CheckAndUpdateVotingSessionAsync(stoppingToken);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occured with this VotingSessionCheckern");
                }

                await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
            }

            _logger.LogInformation("VotingSessionChecker service is stopped");
        }
    }
}
