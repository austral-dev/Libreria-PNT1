using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Libreria_PNT1.Extensions
{
    public static class SessionExtensions
    {
        // Guarda cualquier objeto en Session como JSON
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        // Recupera un objeto de Session deserializando el JSON
        public static T? GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }
    }
}
