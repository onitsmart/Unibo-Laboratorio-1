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
            // Try-catch
            // Intercetta eventuali eccezioni lanciate dal codice posto nel blocco del try e gestisce eventuali eccezioni nel catch.
            // Attenzione che il lancio delle eccezioni è costoso, dove si può evitiamo di generarle.
            try
            {
                throw new Exception("Intercettami");
            }
            catch { }
            // Equivalente al catch sopra, con la differenza che creiamo una variabile per l'eccezione.
            // Viene usato se dobbiamo intercettare l'eccezione e ci interessa avere info su che tipo di eccezione ci sia stata.
            //catch (Exception ex) { }

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

            try
            {
                var test = input.Name;
            }
            catch (Exception ex)
            {
                risultato = true;
            }

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

            // Try-catch-finally 
            // Il codice posto nel finally abbiamo la certezza che venga sempre eseguito, sia che il codice finisca nel catch, sia che il codice non vada in eccezione.
            // Può essere usato per rilasciare eventuali risorse o chiudere stream.
            try
            {
                var buffer = new byte[100];
                fileStream.ReadExactly(buffer, 0, 100);
            }
            // Si possono concatenare N catch di seguito. 
            // Normalmente i più permissivi vengoono lasciati in fondo, in questo caso l'ultimo catcha Exception che è la classe base per tutte le eccezioni.
            // Questa struttura è "a cascata". Il codice eseguito sarà quello del primo catch abbastanza permissivo per gestire l'eccezione lanciata.
            catch (EndOfStreamException ex)
            {
            }
            catch (Exception ex)
            {
            }
            finally
            {
                fileStream.Close();
            }

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
