using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace Laboratorio1.Tests.Fundamentals
{
    public class Sugar
    {
        private readonly ITestOutputHelper OutputHelper;

        public Sugar(ITestOutputHelper outputHelper)
        {
            this.OutputHelper = outputHelper;
        }

        /// <summary>
        /// <see href="https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/properties#auto-implemented-properties"/>
        /// </summary>
        public class Bee
        {
            public string Name { get; set; } = string.Empty;

            public int PollenGathered { get; set; }

            public string Motto { get; set; } = string.Empty;
        }

        /// <summary>
        /// Crea un nuovo oggetto di tipo Ape e valorizza le proprietà Name e PollenGathered usando la sintassi al link seguente.
        /// <see href="https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/object-and-collection-initializers#object-initializers"/>
        /// </summary>
        [Fact]
        public void FastWayToSetupAClass()
        {
            Bee bee = null;

            // TO-DO

            Assert.NotNull(bee);
            Assert.Equal("Bzz", bee.Name);
            Assert.Equal(5, bee.PollenGathered);
            Assert.Equal("You gotta bee-lieve in yourself!", bee.Motto);
        }

        /// <summary>
        /// Usare lo using per assicurarsi di avere chiuso il file.
        /// <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/using"/>
        /// </summary>
        [Fact]
        public void EnsureClosure()
        {
            var fileStream = File.Open("./Resources/FileEmpty.txt", FileMode.Open);

            var buffer = new byte[100];
            fileStream.Read(buffer, 0, 0);

            Assert.True(fileStream.CanRead == false);
        }
    }
}
