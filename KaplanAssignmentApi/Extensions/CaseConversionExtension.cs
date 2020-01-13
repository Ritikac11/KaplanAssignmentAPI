using System.Linq;

namespace KaplanAssignmentApi.Extensions
{
    public static class CaseConversionExtension
    {
        public static string[] ToLowerCase(this string[] input)
        {
            return input.Select(s => s.ToLower()).ToArray();
        }
    }
}
