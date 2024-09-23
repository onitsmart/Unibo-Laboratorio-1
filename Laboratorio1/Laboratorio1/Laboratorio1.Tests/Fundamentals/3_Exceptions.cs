using Laboratorio1.Tests.Fundamentals.Models;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit.Abstractions;

namespace Laboratorio1.Tests.Fundamentals
{
    /// <summary>
    /// <see href="https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/exceptions/"
    /// <seealso href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/exception-handling-statements"/>
    /// </summary>
    public class Exceptions
    {
        private readonly ITestOutputHelper OutputHelper;

        public Exceptions(ITestOutputHelper outputHelper)
        {
            this.OutputHelper = outputHelper;
        }

        /// <summary>
        /// Intercettare l'eccezione in modo che il test termini con successo.
        /// </summary>
        [Fact]
        public void InterceptAnException()
        {
            throw new Exception("Intercettami");

            Assert.True(true);
        }

        /// <summary>
        /// Intercettare eventuali eccezioni generate dal codice seguente.
        /// Risultato dovrà avere valore false se nessuna eccezione è stata generata e true se viene lanciata almeno un'eccezione.
        /// </summary>
        [Theory]
        [MemberData(nameof(InputForInterceptAndDoSomethingOnException))]
        public void InterceptAndDoSomethingOnException(Person? input, bool output)
        {
            var risultato = false;

            var test = input!.Name;

            Assert.Equal(risultato, output);
        }
        public static IEnumerable<object?[]> InputForInterceptAndDoSomethingOnException = new List<object?[]>
        {
            new object?[] {
                new Person("Pippo"),
                false
            },
            new object?[] {
                null,
                true
            }
        };

        /// <summary>
        /// Intercettare l'eccezione in modo che il test termini con successo.
        /// Usare l'istruzione finally.
        /// </summary>
        [Theory]
        [MemberData(nameof(InputForInterceptAndDoSomethingAlways))]
        public void InterceptAndDoSomethingAlways(string filename)
        {
            var fileStream = File.Open(filename, FileMode.Open);

            var buffer = new byte[100];
            fileStream.ReadExactly(buffer, 0, 100);

            Assert.True(fileStream.CanRead == false);
        }
        public static IEnumerable<object[]> InputForInterceptAndDoSomethingAlways = new List<object[]>
        {
            new object[] {
                "./Resources/LoremIpsum.txt"
            },
            new object[] {
                "./Resources/FileEmpty.txt"
            }
        };
    }
}
