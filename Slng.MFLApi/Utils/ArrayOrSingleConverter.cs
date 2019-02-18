using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Slng.MFLApi.Model;
using System;
using System.Collections.Generic;

namespace Slng.MFLApi.Utils
{
    public class ArrayOrSingleConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(List<T>);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            if (token.Type == JTokenType.Array)
            {
                return token.ToObject<List<T>>();
            }
            else if (typeof(T) == typeof(MFLPlayerScore))
            {
                if ((token.Last as JProperty)?.Name == "id" && string.IsNullOrEmpty((token.Last as JProperty)?.Value?.ToString()))
                {
                    return new List<T>();
                }
            }

            return new List<T>() { token.ToObject<T>() };
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
