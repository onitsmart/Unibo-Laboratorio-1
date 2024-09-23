using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xunit.Abstractions;

namespace Laboratorio1.Tests.Fundamentals
{
    /// <summary>
    /// <see href="https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods"/>
    /// <seealso href="https://learn.microsoft.com/en-us/dotnet/csharp/advanced-topics/reflection-and-attributes/"/>"/>
    /// </summary>
    public class AttributeAndExtensionsMethod
    {
        private readonly ITestOutputHelper OutputHelper;

        public AttributeAndExtensionsMethod(ITestOutputHelper outputHelper)
        {
            OutputHelper = outputHelper;
        }

        public enum Animal
        {
            [Description("Cane")]
            [Call("Woof")]
            Dog = 1,
            [Description("Gatto")]
            [Call("Meow")]
            Cat = 2,
            [Description("Coccodrillo")]
            [Call("?")]
            Crocodile = 3
        }

        /// <summary>
        /// Prendendo come esempio l'extension method GetDescrizione, implementare un extension method che prenda l'attributo 
        /// </summary>
        /// <param name="outputHelper"></param>
        public static IEnumerable<object[]> InputForTestExtensionMethod = new List<object[]>
        {
            new object[] {
                Animal.Dog,
                "Woof"
            },
            new object[] {
                Animal.Cat,
                "Meow"
            },
            new object[] {
                Animal.Crocodile,
                "?"
            },
        };
        [Theory]
        [MemberData(nameof(InputForTestExtensionMethod))]
        public void TestExtensionMethod(Animal animal, string output)
        {
            Assert.Equal(animal.GetCall(), output);
        }
    }

    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            var risultato = string.Empty;

            var field = value.GetType().GetField(value.ToString());

            if (field != null)
            {
                var attribute = (DescriptionAttribute?)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));
                risultato = attribute?.Description ?? string.Empty;
            }

            return risultato;
        }

        public static string GetCall(this Enum value)
        {
            throw new NotImplementedException();
        }
    }

    [System.AttributeUsage(System.AttributeTargets.Field)]
    public class CallAttribute : System.Attribute
    {
        private string Call;

        public CallAttribute(string call)
        {
            Call = call;
        }
    }
}
