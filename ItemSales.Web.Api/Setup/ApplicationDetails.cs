using System.Reflection;

namespace ItemSales.Web.Api.Setup;

public class ApplicationDetails
{
    public required string Version { get; set; }
    public required string CommitId { get; set; }
    public string ShortCommitId => !string.IsNullOrWhiteSpace(CommitId) && CommitId.Length > 7 ? CommitId[..8] : "";

    public ApplicationDetails()
    {
        var runtimeAssembly = Assembly.GetExecutingAssembly();

        var versionAttributeData = runtimeAssembly.CustomAttributes
            .First(attr => attr.AttributeType.Name == nameof(AssemblyInformationalVersionAttribute));

        var value = versionAttributeData.ConstructorArguments[0].Value?.ToString() ?? "badVersion+noCommitId";

        var versionDetails = value.Split('+');

        Version = versionDetails[0];
        try
        {
            CommitId = versionDetails[1];
        }
        catch
        {
            CommitId = "";
        }
    }
}