using System;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace PlumPack.Web.Mvc
{
    public class FeatureConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            controller.Properties.Add("feature", GetFeatureName(controller.ControllerType));
        }

        private string GetFeatureName(TypeInfo controllerType)
        {
            var tokens = controllerType.FullName.Split('.');
            if (tokens.All(t => t.Equals("features", StringComparison.CurrentCultureIgnoreCase))) return "";
            var featureName = tokens
                .SkipWhile(t => !t.Equals("features", StringComparison.CurrentCultureIgnoreCase))
                .Skip(1)
                .Take(1)
                .FirstOrDefault();
            return featureName;
        }
    }
}