using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace APB97.Features
{
    public class FeatureManager
    {
        private static readonly HashSet<string> enabledFeatures = new HashSet<string>();

        public FeatureManager(string path)
        {
            Path = path;
         
            if (!File.Exists(Path))
            {
                FeatureFlag[] allFeatures = typeof(FeaturesList).GetFields().Select(field => new FeatureFlag(field.Name, false)).ToArray();
                File.WriteAllLines(Path, allFeatures.Select(f => $"{f.feature} {f.enabled}"));
            }

            var features = File.ReadAllLines(Path).Select(line => line.Split(' ')).Select(split => (split[0], split[1]));
            if (features != null)
                foreach (var (feature, enabled) in features)
                    if (bool.TryParse(enabled, out bool isEnabled) && isEnabled)
                        enabledFeatures.Add(feature);
                    else
                        enabledFeatures.Remove(feature);
        }

        public string Path { get; private set; }

        public static bool IsEnabled(string featureName) => enabledFeatures.Contains(featureName);
    }
}
