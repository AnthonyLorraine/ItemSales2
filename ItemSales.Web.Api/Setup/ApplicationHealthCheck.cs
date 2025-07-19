using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace ItemSales.Web.Api.Setup;

internal sealed class ApplicationHealthCheck : IHealthCheck
{
    private readonly ApplicationDetails _appDetails;

    public ApplicationHealthCheck(ApplicationDetails appDetails)
    {
        _appDetails = appDetails;
    }

    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var applicationData = new Dictionary<string, object>
        {
            { "AppVersion", _appDetails.Version },
            { "CommitId", _appDetails.ShortCommitId }
        };

        return Task.FromResult(HealthCheckResult.Healthy("Deployed Application Version", applicationData.AsReadOnly()));
    }
}