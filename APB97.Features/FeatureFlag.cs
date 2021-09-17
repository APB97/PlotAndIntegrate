using System;

namespace APB97.Features
{
    [Serializable]
    public struct FeatureFlag
    {
        public string feature;
        public bool enabled;

        public FeatureFlag(string feature, bool enabled)
        {
            this.feature = feature;
            this.enabled = enabled;
        }

        public override bool Equals(object obj)
        {
            return obj is FeatureFlag other &&
                   feature == other.feature &&
                   enabled == other.enabled;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(feature, enabled);
        }

        public void Deconstruct(out string feature, out bool enabled)
        {
            feature = this.feature;
            enabled = this.enabled;
        }

        public static implicit operator (string feature, bool enabled)(FeatureFlag value)
        {
            return (value.feature, value.enabled);
        }

        public static implicit operator FeatureFlag((string feature, bool enabled) value)
        {
            return new FeatureFlag(value.feature, value.enabled);
        }
    }
}
