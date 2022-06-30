using Reactive.Provider.Kafka.Extension;
using Reactive.Provider.Kafka.Test.TypeTests;
using Xunit;

namespace Reactive.Provider.Kafka.Test
{
    public class TypeSimpleTest
    {
        [Fact]
        public void Is_Simple_Type_Examples()
        {
            Assert.True(typeof(TestEnum).IsSimpleType());
            Assert.True(typeof(string).IsSimpleType());
            Assert.True(typeof(char).IsSimpleType());
            Assert.True(typeof(Guid).IsSimpleType());

            Assert.True(typeof(bool).IsSimpleType());
            Assert.True(typeof(byte).IsSimpleType());
            Assert.True(typeof(short).IsSimpleType());
            Assert.True(typeof(int).IsSimpleType());
            Assert.True(typeof(long).IsSimpleType());
            Assert.True(typeof(float).IsSimpleType());
            Assert.True(typeof(double).IsSimpleType());
            Assert.True(typeof(decimal).IsSimpleType());

            Assert.True(typeof(sbyte).IsSimpleType());
            Assert.True(typeof(ushort).IsSimpleType());
            Assert.True(typeof(uint).IsSimpleType());
            Assert.True(typeof(ulong).IsSimpleType());

            Assert.True(typeof(DateTime).IsSimpleType());
            Assert.True(typeof(DateTimeOffset).IsSimpleType());
            Assert.True(typeof(TimeSpan).IsSimpleType());

            Assert.True(typeof(TestEnum?).IsSimpleType());
            Assert.True(typeof(char?).IsSimpleType());
            Assert.True(typeof(Guid?).IsSimpleType());

            Assert.True(typeof(bool?).IsSimpleType());
            Assert.True(typeof(byte?).IsSimpleType());
            Assert.True(typeof(short?).IsSimpleType());
            Assert.True(typeof(int?).IsSimpleType());
            Assert.True(typeof(long?).IsSimpleType());
            Assert.True(typeof(float?).IsSimpleType());
            Assert.True(typeof(double?).IsSimpleType());
            Assert.True(typeof(decimal?).IsSimpleType());

            Assert.True(typeof(sbyte?).IsSimpleType());
            Assert.True(typeof(ushort?).IsSimpleType());
            Assert.True(typeof(uint?).IsSimpleType());
            Assert.True(typeof(ulong?).IsSimpleType());
            
            Assert.True(typeof(DateTime?).IsSimpleType());
            Assert.True(typeof(DateTimeOffset?).IsSimpleType());
            Assert.True(typeof(TimeSpan?).IsSimpleType());

            Assert.False(typeof(TestStruct?).IsSimpleType());
            Assert.False(typeof(TestStruct).IsSimpleType());
            Assert.False(typeof(TestClass1).IsSimpleType());
        }
    }
}