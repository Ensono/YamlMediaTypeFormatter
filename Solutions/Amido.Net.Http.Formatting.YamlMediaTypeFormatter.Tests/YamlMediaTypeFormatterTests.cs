using System;
using System.Collections.Generic;
using System.Linq;

using Xunit;

using YamlDotNet.Serialization.NamingConventions;

namespace Amido.Net.Http.Formatting.YamlMediaTypeFormatter.Tests {
    public class YamlMediaTypeFormatterTests {
        [Fact]
        public void PublicPropertiesInitialized() {
            var formatter = new YamlMediaTypeFormatter();
            Assert.False(formatter.IgnoreUnmatched);
            Assert.IsType<CamelCaseNamingConvention>(formatter.NamingConvention); 
        }
    }
}