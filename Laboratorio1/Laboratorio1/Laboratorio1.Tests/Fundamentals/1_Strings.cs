﻿using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace Laboratorio1.Tests.Fundamentals
{
    /// <summary>
    /// <see href="https://learn.microsoft.com/en-us/dotnet/api/system.string?view=net-8.0"
    /// </summary>
    public class Strings
    {
        private readonly ITestOutputHelper OutputHelper;

        public Strings(ITestOutputHelper outputHelper)
        {
            this.OutputHelper = outputHelper;
        }

        /// <summary>
        /// Utilizzando il metodo string.Concat() oppure l'operatore +, concatenare le stringhe string1, string2 e string3 per ottenere l'output atteso.
        /// <see href="https://learn.microsoft.com/en-us/dotnet/api/system.string.concat?view=net-8.0"
        /// </summary>
        [Fact]
        public void ConcatenateBasic()
        {
            string string1 = "Pippo";
            string string2 = "pluto";
            string string3 = "paperino";
            var risultato = string.Empty;

            // TO-DO

            Assert.Equal("Ciao Pippo pluto & paperino!", risultato, ignoreCase: true);
        }

        /// <summary>
        /// Utilizzando la string interpolation ottenere l'output atteso.
        /// <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/interpolated"
        /// </summary>
        [Fact]
        public void ConcatenateClever()
        {
            string string1 = "Pippo";
            string string2 = "pluto";
            string string3 = "paperino";
            var risultato = string.Empty;

            // TO-DO

            Assert.Equal("Ciao Pippo pluto & paperino!", risultato, ignoreCase: true);
        }

        /// <summary>
        /// Utilizzando la tecnica che più preferite concatenate l'input inserendo uno spazio tra ogni stringa.
        /// </summary>
        [Fact]
        public async Task ConcatenateInALoop()
        {
            var filename = "./Resources/LoremIpsum.txt";
            var input = await File.ReadAllTextAsync(filename);
            var strings = input.Split(" ");

            var risultato = string.Empty;

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            // TO-DO

            var elapsed = stopWatch.ElapsedMilliseconds;
            stopWatch.Stop();

            OutputHelper.WriteLine($"Tempo trascorso: {elapsed}");

            Assert.Equal(input, risultato, ignoreCase: true);
        }

        /// <summary>
        /// Utilizzando lo StringBuilder concatenate l'input inserendo uno spazio tra ogni stringa.
        /// <see href="https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder?view=net-8.0"/>
        /// </summary>
        [Fact]
        public async Task ConcatenateInALoopWithStringBuilder()
        {
            var filename = "./Resources/LoremIpsum.txt";
            var input = await File.ReadAllTextAsync(filename);
            var strings = input.Split(" ");

            var risultato = string.Empty;
            var stringBuilder = new StringBuilder();

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            // TO-DO

            var elapsed = stopWatch.ElapsedMilliseconds;
            stopWatch.Stop();

            OutputHelper.WriteLine($"Tempo trascorso: {elapsed}");

            Assert.Equal(input, risultato, ignoreCase: true);
        }

        /// <summary>
        /// Utilizzando il metodo Contains verificare se la stringa "pippo" è contenuta nell'input ignorando il case.
        /// <see href="https://learn.microsoft.com/en-us/dotnet/api/system.string.contains?view=net-8.0"/>
        /// </summary>
        [Theory]
        [MemberData(nameof(InputForContains))]
        public void Contains(string input, bool output)
        {
            var risultato = false;
            var stringToCheck = "pippo";

            // TO-DO

            Assert.Equal(output, risultato);
        }
        public static IEnumerable<object?[]> InputForContains = new List<object?[]>
        {
            new object?[] {
                "Test 1",
                false
            },
            new object?[] {
                "Test pippo 2",
                true
            },
            new object?[] {
                "Pippo",
                true
            },
            new object?[] {
                "pluto test paperino 3",
                false
            },
            new object?[] {
                "TEST PIppo",
                true
            },
        };

        /// <summary>
        /// Utilizzando un metodo della classe string trasformare il testo in input in uppercase.
        /// </summary>
        [Fact]
        public void Uppercase()
        {
            var input = "pippo";
            var risultato = string.Empty;

            // TO-DO

            Assert.Equal("PIPPO", risultato);
        }

        /// <summary>
        /// Utilizzando un metodo della classe string trasformare il testo in input in lowercase.
        /// </summary>
        [Fact]
        public void Lowercase()
        {
            var input = "PIPPO";
            var risultato = string.Empty;

            // TO-DO

            Assert.Equal("pippo", risultato);
        }

        /// <summary>
        /// Utilizzando un metodo della classe string ritornare true se il testo in input è vuoto o null, altrimenti false.
        /// </summary>
        [Theory]
        [MemberData(nameof(InputForEmptyTest))]
        public async Task EmptyCheck(string? input, bool output)
        {
            var risultato = false;

            // TO-DO

            Assert.Equal(output, risultato);
        }
        public static IEnumerable<object?[]> InputForEmptyTest = new List<object?[]>
        {
            new object?[] {
                null,
                true
            },
            new object?[] {
                string.Empty,
                true
            },
            new object?[] {
                "Pippo",
                false
            },
            new object?[] {
                "",
                true
            },
            new object?[] {
                " ",
                false
            },
        };

        /// <summary>
        /// Utilizzando un metodo della classe string ritornare true se il testo in input contiene almeno un carattere.
        /// </summary>
        [Theory]
        [MemberData(nameof(InputForWhitespaceTest))]
        public void WhitespaceCheck(string? input, bool output)
        {
            var risultato = false;

            // TO-DO

            Assert.Equal(output, risultato);
        }
        public static IEnumerable<object?[]> InputForWhitespaceTest = new List<object?[]>
        {
            new object?[] {
                null,
                false
            },
            new object?[] {
                string.Empty,
                false
            },
            new object?[] {
                "Pippo",
                true
            },
            new object?[] {
                "",
                false
            },
            new object?[] {
                " ",
                false
            },
        };

        /// <summary>
        /// Utilizzando il metodo Equals verificare se le 2 stringhe in input sono uguali, considerando il case. 
        /// Pippo != pippo.
        /// <see href="https://learn.microsoft.com/en-us/dotnet/api/system.string.equals?view=net-8.0"/>
        /// </summary>
        [Theory]
        [MemberData(nameof(InputForEquals))]
        public void EqualsCheck(string input1, string input2, bool output)
        {
            var risultato = false;

            // TO-DO

            Assert.Equal(output, risultato);
        }
        public static IEnumerable<object?[]> InputForEquals = new List<object?[]>
        {
            new object?[] {
                "Test 1",
                "Test 2",
                false
            },
            new object?[] {
                "Pippo",
                "pippo",
                false
            },
            new object?[] {
                "pippo",
                "pippo",
                true
            }
        };
    }
}
