using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Amido.Net.Http.Formatting.YamlMediaTypeFormatter {
    public class YamlMediaTypeFormatter : MediaTypeFormatter {
        public YamlMediaTypeFormatter() {
            var supportedMediaTypes = new[] { "text/yaml", "text/x-yaml", "application/yaml", "application/x-yaml" };

            foreach (var mt in supportedMediaTypes) {
                SupportedMediaTypes.Add(new MediaTypeHeaderValue(mt));
            }
        }

        public override bool CanReadType(Type type) {
            NullGuard(type, nameof(type));

            return true;
        }

        public override bool CanWriteType(Type type) {
            NullGuard(type, nameof(type));

            return true;
        }

        public SerializationOptions SerializationOptions { get; set; } = SerializationOptions.DisableAliases;

        public INamingConvention NamingConvention { get; set; } = new CamelCaseNamingConvention();

        public IObjectFactory ObjectFactory { get; set; } = null;

        public bool IgnoreUnmatched { get; set; } = false;

        public override Task WriteToStreamAsync(
            Type type,
            object value,
            Stream writeStream,
            HttpContent content,
            TransportContext transportContext) {
            NullGuard(type, nameof(type));
            NullGuard(writeStream, nameof(writeStream));

            return TaskHelper.RunSynchronously(
                () => {
                    using (var writer = new StreamWriter(writeStream)) {
                        var serializer = new Serializer(SerializationOptions, NamingConvention);
                        serializer.Serialize(writer, value);
                    }
                });
        }

        public override Task<object> ReadFromStreamAsync(
            Type type,
            Stream readStream,
            HttpContent content,
            IFormatterLogger formatterLogger) {
            NullGuard(type, nameof(type));
            NullGuard(readStream, nameof(readStream));

            return TaskHelper.RunSynchronously(
                () => {
                    using (var reader = new StreamReader(readStream)) {
                        var deserializer = new Deserializer(ObjectFactory, NamingConvention, IgnoreUnmatched);
                        var completionSource = new TaskCompletionSource<object>();
                        var result = deserializer.Deserialize(reader, type);
                        completionSource.SetResult(result);
                        return completionSource.Task;
                    }
                });
        }

        private static void NullGuard(object type, string paramName) {
            if (type == null) {
                throw new ArgumentNullException(paramName);
            }
        }
    }
}