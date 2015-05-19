using System;
using System.Collections.Generic;
using System.Linq;

namespace Amido.Net.Http.Formatting.YamlMediaTypeFormatter.Samples.Infrastructure {
    public static class EnumerableExtensions {
        public static T PickRandom<T>(this IEnumerable<T> source) {
            return source.OrderBy(x => Guid.NewGuid()).First();
        }

        public static IEnumerable<T> PickRandom<T>(this IEnumerable<T> source, int count) {
            return source.OrderBy(x => Guid.NewGuid()).Take(count);
        }
    }
}