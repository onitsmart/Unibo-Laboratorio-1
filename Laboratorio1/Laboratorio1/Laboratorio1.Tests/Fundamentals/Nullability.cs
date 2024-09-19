using System.Collections.Generic;
using Xunit.Abstractions;

namespace Laboratorio1.Tests.Fundamentals
{
    public class Nullability
    {
        private readonly ITestOutputHelper output;

        public Nullability(ITestOutputHelper output)
        {
            this.output = output;
        }

        private class Person
        {
            public string Name { get; set; }

            public Person(string name)
            {
                Name = name;
            }
        }

        /// <summary>
        /// Ritornare true solo se l'input non è null.
        /// </summary>
        public static IEnumerable<object?[]> InputForCheckNotNull = new List<object?[]>
        {
            new object?[] {
                1,
                true
            },
            new object?[] {
                null,
                false
            }
        };
        [Theory]
        [MemberData(nameof(InputForCheckNotNull))]
        public void CheckNotNull(int? input, bool output)
        {
            var risultato = false;

            // TO-DO

            Assert.Equal(output, risultato);
        }

        /// <summary>
        /// Ritornare il campo name dell'oggetto se l'oggetto non è nullo e null altrimenti.
        /// </summary>
        public static IEnumerable<object?[]> InputForReturnNameIfNotNull = new List<object?[]>
        {
            new object?[] {
                new Person("Test"),
                true
            },
            new object?[] {
                new Person("Pippo"),
                false
            }
        };
        [Theory]
        [MemberData(nameof(InputForReturnNameIfNotNull))]
        public void ReturnNameIfNotNull(int? input, bool output)
        {
            var risultato = false;

            // TO-DO

            Assert.Equal(output, risultato);
        }
    }
}
