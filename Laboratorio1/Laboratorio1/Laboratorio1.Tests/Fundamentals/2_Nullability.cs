﻿using Laboratorio1.Tests.Fundamentals.Models;
using System.Collections.Generic;
using Xunit.Abstractions;

namespace Laboratorio1.Tests.Fundamentals
{
    /// <summary>
    /// <see href="https://learn.microsoft.com/en-us/dotnet/csharp/nullable-references"
    /// </summary>
    public class Nullability
    {
        private readonly ITestOutputHelper OutputHelper;
        
        public Nullability(ITestOutputHelper outputHelper)
        {
            this.OutputHelper = outputHelper;
        }

        /// <summary>
        /// Ritornare true solo se l'input non è null.
        /// </summary>
        [Theory]
        [MemberData(nameof(InputForCheckNotNull))]
        public void CheckNotNull(int? input, bool output)
        {
            var risultato = false;

            // TO-DO

            Assert.Equal(output, risultato);
        }
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

        /// <summary>
        /// Ritornare il campo name dell'oggetto se l'oggetto non è nullo e null altrimenti.
        /// Usate il metodo classico con controlli di nullabilità.
        /// </summary>
        [Theory]
        [MemberData(nameof(InputForReturnNameIfNotNull))]
        public void ReturnNameIfNotNull(Person? input, string output)
        {
            string? risultato = null;

            // TO-DO

            Assert.Equal(output, risultato);
        }
        public static IEnumerable<object?[]> InputForReturnNameIfNotNull = new List<object?[]>
        {
            new object?[] {
                new Person("Pippo"),
                "Pippo"
            },
            new object?[] {
                null,
                null
            }
        };

        /// <summary>
        /// Ritornare il campo name dell'oggetto se l'oggetto non è nullo e null altrimenti.
        /// Usate il null conditional operator per accedere al campo name.
        /// <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/member-access-operators#null-conditional-operators--and-"
        /// </summary>
        [Theory]
        [MemberData(nameof(InputForReturnNameIfNotNull))]
        public void ReturnNameIfNotNullWithNullConditionalOperator(Person? input, string output)
        {
            string? risultato = null;

            // TO-DO

            Assert.Equal(output, risultato);
        }

        /// <summary>
        /// Ritornare il campo name dell'oggetto se l'oggetto non è nullo e la stringa "Test" altrimenti.
        /// Usate il null conditional operator per accedere al campo name e il null coalescing operator per ritornare la stringa 
        /// <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/null-coalescing-operator"
        /// </summary>
        [Theory]
        [MemberData(nameof(InputForReturnNameIfNotNullWithNullConditionalOperatorAndNullCoalescingOperator))]
        public void ReturnNameIfNotNullWithNullConditionalOperatorAndNullCoalescingOperator(Person? input, string output)
        {
            var altString = "Test";
            string? risultato = null;

            // TO-DO

            Assert.Equal(output, risultato);
        }
        public static IEnumerable<object?[]> InputForReturnNameIfNotNullWithNullConditionalOperatorAndNullCoalescingOperator = new List<object?[]>
        {
            new object?[] {
                new Person("Pippo"),
                "Pippo"
            },
            new object?[] {
                null,
                "Test"
            }
        };
    }
}
