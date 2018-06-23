using System;
using System.Net.Http.Headers;

#if NET45 || NETSTANDARD2_0
namespace Flurl.Http
{
    internal static class ReflectionExtensions
    {
        // https://github.com/dotnet/corefx/blob/master/src/System.Net.Http/src/System/Net/Http/Headers/MediaTypeWithQualityHeaderValue.cs
        internal static void AddPreserved(this HttpHeaderValueCollection<MediaTypeWithQualityHeaderValue> collection, string value)
        {
            var header = new MediaTypeWithQualityHeaderValue("text/plain");

            ReflectionCache.MediaTypeHeader.MediaTypeField.SetValue(header, value);

            collection.Add(header);
        }

        // https://github.com/dotnet/corefx/blob/master/src/System.Net.Http/src/System/Net/Http/Headers/StringWithQualityHeaderValue.cs
        internal static void AddPreserved(this HttpHeaderValueCollection<StringWithQualityHeaderValue> collection, string value)
        {
            var header = (StringWithQualityHeaderValue) Activator.CreateInstance(ReflectionCache.StringWithQualityHeader.Type, true);

            ReflectionCache.StringWithQualityHeader.ValueField.SetValue(header, value);

            collection.Add(header);
        }    
    }
}
#endif
