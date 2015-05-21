using System.Diagnostics.CodeAnalysis;

using AutoPoco.Engine;

namespace Amido.Net.Http.Formatting.YamlMediaTypeFormatter.Samples.Infrastructure {
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public class ProductNameDataSource : DatasourceBase<string> {
        private readonly string[] names = { "T-Shirt", "Jumper", "Polo Neck" };

        public override string Next(IGenerationSession session) {
            return this.names.PickRandom();
        }
    }
}