using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LucAdm.Infrastructure;
using AutoMapper;
using FluentAssertions;

namespace LucAdm.Tests
{
    [TestClass]
    public class ValidatedTests
    {
        public class ExampleViewModel
        {
            public string IntProperty { get; set; }
            public string NullableIntProperty { get; set; }
        }

        public class ExampleRequest
        {
            public Validated<int> IntProperty { get; set; }
            public Validated<int?> NullableIntProperty { get; set; }
        }

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            Mapper.CreateMap<ExampleViewModel, ExampleRequest>();
        }

        [TestMethod]
        public void Should_Map_Valid_String_Int()
        {
            // arrange
            var source = new ExampleViewModel() { IntProperty = "5" };

            // act
            var destination = Mapper.Map(source, new ExampleRequest());

            // assert
            destination.IntProperty.IsValid.Should().BeTrue();
            destination.IntProperty.Value.Should().Be(5);
        }

        [TestMethod]
        public void Should_Map_Invalid_String_Int_As_Invalid_Value()
        {
            // arrange
            var source = new ExampleViewModel() { IntProperty = "fsdfd" };

            // act
            var destination = Mapper.Map(source, new ExampleRequest());

            // assert
            destination.IntProperty.IsValid.Should().BeFalse();
            destination.IntProperty.Value.Should().Be(default(int));
        }

        [TestMethod]
        public void Should_Map_Invalid_Null_String_Int_As_Invalid_NonNullable_Value()
        {
            // arrange
            var source = new ExampleViewModel() { IntProperty = null };

            // act
            var destination = Mapper.Map(source, new ExampleRequest());

            // assert
            destination.IntProperty.IsValid.Should().BeFalse();
            destination.IntProperty.Value.Should().Be(default(int));
        }

        [TestMethod]
        public void Should_Map_Null_String_As_Valid_Nullable_Value()
        {
            // arrange
            var source = new ExampleViewModel() { NullableIntProperty = null };

            // act
            var destination = Mapper.Map(source, new ExampleRequest());

            // assert
            destination.NullableIntProperty.IsValid.Should().BeTrue();
            destination.NullableIntProperty.Value.Should().Be(null);
        }
    }
}
