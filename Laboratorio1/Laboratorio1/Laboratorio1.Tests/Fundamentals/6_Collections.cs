using Laboratorio1.Tests.Fundamentals.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Xunit.Abstractions;
using static Laboratorio1.Tests.Fundamentals.AttributeAndExtensionsMethod;

namespace Laboratorio1.Tests.Fundamentals
{
    /// <summary>
    /// <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/collections"/>
    /// </summary>
    public class Collections
    {
        private readonly ITestOutputHelper OutputHelper;

        public Collections(ITestOutputHelper outputHelper)
        {
            this.OutputHelper = outputHelper;
        }

        public class Toy
        {
            public string Name { get; set; }

            public int NumberOfBatteries { get; set; }

            public Toy(string name, int numberOfBatteries)
            {
                Name = name;
                NumberOfBatteries = numberOfBatteries;
            }
        }

        /// <summary>
        /// Conta i numeri pari presenti nell'array utilizzando un ciclo for/while/do while, a scelta.
        /// </summary>
        [Theory]
        [MemberData(nameof(InputForNormalForElementInCollection))]
        public void NormalForElementInCollection(IEnumerable<int> input, int output)
        {
            var risultato = -1;

            // TO-DO

            Assert.Equal(output, risultato);
        }
        public static IEnumerable<object[]> InputForNormalForElementInCollection = new List<object[]>
        {
            new object[] {
                new int[ 1, 2, 3, 5, 7, 12 ],
                3
            },
            new object[] {
                new int[ 1, 3, 5, 7 ],
                0
            },
            new object[] {
                Array.Empty<int>(),
                0
            }
        };

        /// <summary>
        /// Conta i numeri pari presenti nell'array utilizzando un foreach.
        /// <see href="https://learn.microsoft.com/it-it/dotnet/csharp/language-reference/statements/iteration-statements#the-foreach-statement"/>
        /// </summary>
        [Theory]
        [MemberData(nameof(InputForNormalForElementInCollection))]
        public void ForeachElementInCollection(IEnumerable<int> input, int output)
        {
            var risultato = -1;

            // TO-DO

            Assert.Equal(output, risultato);
        }

        /// <summary>
        /// Conta i giocattoli che richiedono 2 batterie presenti nell'array e nel dizionario.
        /// Il dizionario ha come chiave il numero di batterie necessarie e come valore i giocattoli che richiedono quel numero di batterie.
        /// <see href="https://learn.microsoft.com/it-it/dotnet/api/system.collections.generic.dictionary-2?view=net-8.0"/>
        /// </summary>
        [Theory]
        [MemberData(nameof(InputForArrayVsDictionary))]
        public void ArrayVsDictionary(ImmutableArray<Toy> inputArray, ImmutableDictionary<int, IEnumerable<Toy>> inputDictionary, int output)
        {
            var risultatoDaArray = -1;
            var risultatoDaDictionary = -1;

            // TO-DO

            Assert.Equal(output, risultatoDaArray);
            Assert.Equal(output, risultatoDaDictionary);
        }
        public static IEnumerable<object[]> InputForArrayVsDictionary = new List<object[]>
        {
            new object[] {
                new Toy[3]
                {
                    new Toy("Robot", 3),
                    new Toy("Macchinina", 2),
                    new Toy("Trottola", 0)
                }.ToImmutableArray(),
                new Dictionary<int, IEnumerable<Toy>> {
                    { 3, new Toy[1] { new Toy("Robot", 3) } },
                    { 2, new Toy[1] { new Toy("Macchinina", 2) } },
                    { 0, new Toy[1] { new Toy("Trottola", 0) } }
                }.ToImmutableDictionary(),
                1
            },
            new object[] {
                new Toy[3]
                {
                    new Toy("Robot", 2),
                    new Toy("Macchinina", 2),
                    new Toy("Trottola", 0)
                }.ToImmutableArray(),
                new Dictionary<int, IEnumerable<Toy>> {
                    { 2, new Toy[2] { new Toy("Robot", 2), new Toy("Macchinina", 2) } },
                    { 0, new Toy[1] { new Toy("Trottola", 0) } }
                }.ToImmutableDictionary(),
                2
            },
        };
    }
}
