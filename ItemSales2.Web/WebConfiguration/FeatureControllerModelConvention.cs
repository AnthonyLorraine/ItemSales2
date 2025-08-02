using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace ItemSales2.Web.WebConfiguration;

public class FeatureControllerModelConvention : IControllerModelConvention
{
    public void Apply(ControllerModel controller)
    {
        var featureName = GetFeatureName(controller.ControllerType.Namespace);
        if (string.IsNullOrEmpty(featureName)) return;
        
        controller.Properties["feature"] = featureName;
    }
    private static string? GetFeatureName(string? namespaceName)
    {
        if (namespaceName is null) return null;
        var parts = namespaceName.Split('.');
        var featureIndex = Array.IndexOf(parts, "Features");
        if (featureIndex > -1 && featureIndex + 1 < parts.Length)
        {
            return parts[featureIndex + 1];
        }
        return null;
    }
}