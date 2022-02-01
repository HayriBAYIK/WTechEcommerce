using System;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace WTechECommerce.UI.Models.Helper
{
    public static class SessionExtensions
    {
        public static void SetCart(this ISession session, string key, UserCart value)
        {
            session.Set(key, JsonSerializer.SerializeToUtf8Bytes(value));
        }

        public static UserCart GetCart(this ISession session, string key)
        {
            var value = session.Get(key);

            return value == null ? null :
                JsonSerializer.Deserialize<UserCart>(value);
        }
    }


}
