using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using Xunit;

using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Serialization.ObjectFactories;

// ReSharper disable MemberCanBePrivate.Global

namespace Amido.Net.Http.Formatting.YamlMediaTypeFormatter.Tests
{
    public class YamlMediaTypeFormatterTests {
        [Fact]
        public void PublicPropertiesInitialized() {
            var formatter = new YamlMediaTypeFormatter();
            Assert.False(formatter.IgnoreUnmatched);
            Assert.IsType(typeof(CamelCaseNamingConvention), formatter.NamingConvention);
            Assert.Null(formatter.ObjectFactory);
            Assert.Equal(SerializationOptions.DisableAliases, formatter.SerializationOptions);
        }

        [Fact]
        public void PublicPropertiesCanBeSet()
        {
            var formatter = new YamlMediaTypeFormatter();
            formatter.IgnoreUnmatched = true;
            formatter.NamingConvention = new NullNamingConvention();
            formatter.ObjectFactory = new DefaultObjectFactory();
            formatter.SerializationOptions = SerializationOptions.DefaultToStaticType;
            Assert.True(formatter.IgnoreUnmatched);
            Assert.IsType(typeof(NullNamingConvention), formatter.NamingConvention);
            Assert.IsType(typeof(DefaultObjectFactory), formatter.ObjectFactory);
            Assert.Equal(SerializationOptions.DefaultToStaticType, formatter.SerializationOptions);
        }

        [Fact]
        public void ThrowsExceptionWhenPassingNullTypeToCanRead() {
            var formatter = new YamlMediaTypeFormatter();
            var exception = Assert.Throws<ArgumentNullException>(() => formatter.CanReadType(null));
            Assert.Equal("type", exception.ParamName);
        }

        [Fact]
        public void ThrowsExceptionWhenPassingNullTypeToCanWrite()
        {
            var formatter = new YamlMediaTypeFormatter();
            var exception = Assert.Throws<ArgumentNullException>(() => formatter.CanWriteType(null));
            Assert.Equal("type", exception.ParamName);
        }

        public static IEnumerable<object[]> TypeData =>
            new [] {
                    new [] { typeof(int) },
                    new [] { typeof(bool) },
                    new [] { typeof(string) },
                    new [] { typeof(IEnumerable<string>) }
                };

        [Theory, MemberData(nameof(TypeData))]
        public void ReturnsTrueWhenCanReadTypePassedTypeOf(Type type) {
            var formatter = new YamlMediaTypeFormatter();
            Assert.True(formatter.CanReadType(type));
        }

        [Theory, MemberData(nameof(TypeData))]
        public void ReturnsTrueWhenCanWriteTypePassedTypeOf(Type type) {
            var formatter = new YamlMediaTypeFormatter();
            Assert.True(formatter.CanWriteType(type));
        }

        public static IEnumerable<object[]> ObjectData =>
            new [] {
                    new object[] { typeof(int), 10, "10" + YamlCloseDocument },
                    new object[] { typeof(double), 9.8, "9.8" + YamlCloseDocument },
                    new object[] { typeof(string), "AAA", "AAA" + YamlCloseDocument }
                   };

        public static readonly string YamlCloseDocument = string.Format("{0}...{0}", Environment.NewLine);

        [Theory, MemberData(nameof(ObjectData))]
        public async void ReturnsStringRepresentationOfSimpleData(Type type, object input, string output) {
            var formatter = new YamlMediaTypeFormatter();
            var testStream = new MemoryStream();
            await formatter.WriteToStreamAsync(type, input, testStream, null, null);
            var stringRepresentation = Encoding.UTF8.GetString(testStream.ToArray());
            Assert.Equal(output, stringRepresentation);
        }

        [Theory, MemberData(nameof(ObjectData))]
        public async void ReturnsSimpleDataFromStringRepresentation(Type type, object output, string input) {
            var formatter = new YamlMediaTypeFormatter();
            var testStream = new MemoryStream(Encoding.UTF8.GetBytes(input));
            var actual = await formatter.ReadFromStreamAsync(type, testStream, null, null);
            Assert.Equal(output, actual);
        }
    }
}