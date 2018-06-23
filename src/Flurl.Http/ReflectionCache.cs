using System;
using System.Net.Http.Headers;
using System.Reflection;

#if NET45 || NETSTANDARD2_0
namespace Flurl.Http
{
    internal static class ReflectionCache
    {
        internal static class MediaTypeHeader
        {
            static MediaTypeHeader()
            {
                Type = typeof(MediaTypeHeaderValue).GetTypeInfo();
                MediaTypeField = Type.GetField("_mediaType", BindingFlags.NonPublic | BindingFlags.Instance);

                if (MediaTypeField == null)
                {
                    throw new NullReferenceException("Could not find the _mediaType field in MediaTypeField.");
                }
            }

            internal static TypeInfo Type { get; }

            internal static FieldInfo MediaTypeField { get; }
        }

        internal static class MediaTypeWithQualityHeader
        {
            static MediaTypeWithQualityHeader()
            {
                Type = typeof(MediaTypeWithQualityHeader).GetTypeInfo();
            }

            internal static TypeInfo Type { get; }
        }
        
        internal static class StringWithQualityHeader
        {
            static StringWithQualityHeader()
            {
                Type = typeof(StringWithQualityHeaderValue).GetTypeInfo();
                ValueField = Type.GetField("_value", BindingFlags.NonPublic | BindingFlags.Instance);

                if (ValueField == null)
                {
                    throw new NullReferenceException("Could not find the _value field in StringWithQualityHeader.");
                }
            }

            internal static TypeInfo Type { get; }

            internal static FieldInfo ValueField { get; }
        }
    }
}
#endif
