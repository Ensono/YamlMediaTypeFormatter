using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

using Amido.Net.Http.Formatting.YamlMediaTypeFormatter.Samples.Models;

using AutoPoco.Engine;

namespace Amido.Net.Http.Formatting.YamlMediaTypeFormatter.Samples.Infrastructure {
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public class VariantDataSource : DatasourceBase<IEnumerable<Variant>> {
        private readonly string[] colours = { "Red", "Orange", "Yellow", "Green", "Blue", "Purple" };

        private readonly List<Variant> possibleVariants = new List<Variant>();

        private readonly string[] sizes = { "XX-Small", "X-Small", "Small", "Medium", "Large", "X-Large", "XX-Large", "XXX-Large" };

        public VariantDataSource() {
            for (var i = 0; i < 100; i++) {
                possibleVariants.Add(new Variant { Colour = colours.PickRandom(), Size = sizes.PickRandom() });
            }
        }

        public override IEnumerable<Variant> Next(IGenerationSession session) {
            return possibleVariants.PickRandom(3);
        }
    }
}