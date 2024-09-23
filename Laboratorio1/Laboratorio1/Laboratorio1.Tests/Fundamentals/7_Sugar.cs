using System;
using System.Collections.Generic;
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
            Assert.Equal("You gota bee-lieve", bee.Motto);
        }
    }
}
