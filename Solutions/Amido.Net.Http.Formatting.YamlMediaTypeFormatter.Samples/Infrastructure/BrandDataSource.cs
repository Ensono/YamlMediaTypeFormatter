using System.Diagnostics.CodeAnalysis;

using AutoPoco.Engine;

namespace Amido.Net.Http.Formatting.YamlMediaTypeFormatter.Samples.Infrastructure {
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public class BrandDataSource : DatasourceBase<string> {
        private readonly string[] brands = { "Microsoft", "CafePress", "Google", "Apple" };

        public override string Next(IGenerationSession session) {
            return brands.PickRandom();
        }
    }
}