using Microsoft.AspNetCore.Mvc.Razor;

namespace ItemSales2.Web.WebConfiguration;

public class FeatureViewLocationExpander : IViewLocationExpander
{
    public void PopulateValues(ViewLocationExpanderContext context)
    {
        // Nothing here
    }

    public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
    {
        var featureName = context.ActionContext.ActionDescriptor.Properties["feature"] as string;

        if (!string.IsNullOrEmpty(featureName))
        {
            yield return $"/Features/{featureName}/Views/{{0}}.cshtml";
            yield return $"/Features/{featureName}/Views/Shared/{{0}}.cshtml";
        }

        foreach (var location in viewLocations)
        {
            yield return location;
        }
    }
}