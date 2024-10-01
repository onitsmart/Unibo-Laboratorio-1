using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Xunit.Abstractions;

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
            // Inizializzazione risultato a 0 per poter avere un conteggio corretto
            var risultato = 0;

            // Esempio 1 Usiamo l'operatore modulo per capire se un numero è pari o dispari e aggiungiamo 1 a risultato solo se è pari con if
            //for (int i = 0; i < input.Count(); i++)
            //{
            //    if (input.ElementAt(i) % 2 == 0)
            //        risultato += 1;
            //}

            // Esempio 2 Usiamo l'operatore modulo per capire se un numero è pari o dispari e aggiungiamo 1 a risultato solo se è pari con operatore ternario
            for (int i = 0; i < input.Count(); i++)
                risultato += (input.ElementAt(i) % 2 == 0) ? 1 : 0;

            Assert.Equal(output, risultato);
        }
        public static IEnumerable<object[]> InputForNormalForElementInCollection = new List<object[]>
        {
            // C'erano 2 errori nel test.
            // 1 - Inizializzazione con int[ 1, 2, 3, 5, 7, 12 ] per qualche motivo non riesce a capire che è un IEnumerable. Non chiaro il perchè, sembra una peculiarità della libreria dei tests.
            // 2 - Nell'array seguente i numeri pari sono 2 e non 3 come era stato impostato
            new object[] {
                new int[6]{ 1, 2, 3, 5, 7, 12 },
                2
            },
            new object[] {
                new int[4]{ 1, 3, 5, 7 },
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
            // Inizializzazione risultato a 0 per poter avere un conteggio corretto
            var risultato = 0;

            // Esempio 1 Usiamo l'operatore modulo per capire se un numero è pari o dispari e aggiungiamo 1 a risultato solo se è pari con if
            //foreach (var elemento in input)
            //{
            //    if (elemento % 2 == 0)
            //        risultato += 1;
            //}

            // Esempio 2 Usiamo l'operatore modulo per capire se un numero è pari o dispari e aggiungiamo 1 a risultato solo se è pari con operatore ternario
            foreach (var elemento in input)
                risultato += elemento % 2 == 0 ? 1 : 0;

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
            // Inizializzazione risultati a 0 per poter avere un conteggio corretto
            var risultatoDaArray = 0;
            var risultatoDaDictionary = 0;

            // Sull'array, senza usare LINQ, il meglio che possiamo fare è ciclare su ogni oggetto e controllare.
            // Se ha 2 batterie allora aggiungiamo 1 al risultato.
            foreach (var toy in inputArray)
            {
                if (toy.NumberOfBatteries == 2)
                    risultatoDaArray++;
            }

            // Su un dictionary, se correttamente costruito, possiamo accedere direttamente agli elementi d'interesse, per cui non abbiamo bisogno di usare una if.
            // Una volta trovati gli elementi con chiave 2 (batterie richieste) ci basta contare tutti gli elementi presenti.
            if (inputDictionary.TryGetValue(2, out var toysWithTwoBatteries) && toysWithTwoBatteries != null)
                risultatoDaDictionary = toysWithTwoBatteries.Count();

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

        /// <summary>
        /// Convertire l'array in lista.
        /// </summary>
        [Fact]
        public void FromArrayToList()
        {
            var inputArray = new Toy[]
            {
                new Toy("Robot", 3),
                new Toy("Macchinina", 2),
                new Toy("Trottola", 0)
            };

            List<Toy> outputList = new List<Toy>();

            // Soluzione dell'esercizio usando il metodo toList della classe array
            outputList = inputArray.ToList();

            // NOTA
            // Esistono vari metodi per convertire da una collection all'altra.
            // Ad esempio ToArray sulla lista vi permette di generare un'array a partire da una lista..

            Assert.True(outputList is List<Toy>);
            Assert.True(outputList.Count == 3);
            Assert.True(outputList[0].Name == "Robot");
            Assert.True(outputList[1].Name == "Macchinina");
            Assert.True(outputList[2].Name == "Trottola");
        }
    }
}
