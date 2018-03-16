namespace Cosmos.I18N.Core.Extensions {
    public static class ObjectExtensions {
        public static bool EqualsSupportsNull(this object obj, object target) {
            if (obj == null && target == null) return true;
            if (obj == null || target == null) return false;
            return ReferenceEquals(obj, target) || obj.Equals(target);
        }
    }
}