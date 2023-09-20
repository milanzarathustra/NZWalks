using System.Reflection;
using System.Runtime.Serialization;

namespace NZWalks.API.Enums
{
    public static class EnumMemberNames
    {
        public static string? GetEnumMemberValue<T>(this T value) where T : Enum
        {
            return typeof(T)
                .GetTypeInfo()
                .DeclaredMembers
                .SingleOrDefault(x => x.Name == value.ToString())
                ?.GetCustomAttribute<EnumMemberAttribute>(false)
                ?.Value;
        }
    }
}
