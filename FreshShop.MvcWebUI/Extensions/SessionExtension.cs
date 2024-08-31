using FreshShop.Business.Concrete;
using FreshShop.Model.Entity;
using Newtonsoft.Json;

namespace FreshShop.MvcWebUI.Extensions
{
    public static class SessionExtension
    {
        public static void SetObject(this ISession session, string key , object value)
        {
            string jsonStr = JsonConvert.SerializeObject(value);

            session.SetString(key, jsonStr);
        }

        public static T? GetObject<T>(this ISession session, string key) where T : class
        {
            string? jsonStr = session.GetString(key);

            if (!string.IsNullOrEmpty(jsonStr))
            {
                return JsonConvert.DeserializeObject<T>(jsonStr)!;
            }

            return null;
            
        }
    }
}
