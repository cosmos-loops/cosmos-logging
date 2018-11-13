using DeepCopy;

namespace Cosmos
{
    public static class DeepCopyExtensions
    {
        public static T DeepCopy<T>(this T original)
        {
            return DeepCopier.Copy(original);
        }
    }
}