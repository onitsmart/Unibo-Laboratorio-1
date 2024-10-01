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
        [Theory]
        [MemberData(nameof(InputForTestExtensionMethod))]
        public void TestExtensionMethod(Animal animal, string output)
        {
            Assert.Equal(animal.GetCall(), output);
        }
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

        // Finezza vista a lezione.
        // Invece di usare la generica Enum, si può specificare la specifica enum Animal in quanto solo gli animali prevediamo abbiano un verso
        public static string GetCall(this AttributeAndExtensionsMethod.Animal value)
        {
            var risultato = string.Empty;

            // Reflection per arrivare al campo dell'enum (Cane, Gatto... dell'enum Animal)
            // La reflection è molto potente in quanto vi permette di accedere al codice durante l'esecuzione dell'applicativo. 
            // Impatta le performance. ATTENZIONE ad usarla solo se indispensabile.
            var field = value.GetType().GetField(value.ToString());

            if (field != null)
            {
                // Su questo campo andiamo a prendere l'attributo call.
                // La presenza o meno dell'attributo viene controllata nella riga successiva con null conditional e null coalescing.
                var attribute = (CallAttribute?)Attribute.GetCustomAttribute(field, typeof(CallAttribute));
                risultato = attribute?.Call ?? string.Empty;
            }

            return risultato;
        }
    }

    [System.AttributeUsage(System.AttributeTargets.Field)]
    public class CallAttribute : System.Attribute
    {
        private string CallValue;
        public string Call
        {
            get
            {
                return CallValue;
            }
        }

        public CallAttribute(string call)
        {
            CallValue = call;
        }
    }
}
