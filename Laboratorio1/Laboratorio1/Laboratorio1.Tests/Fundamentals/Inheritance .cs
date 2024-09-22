using Laboratorio1.Tests.Fundamentals.Models;
using System;
using Xunit.Abstractions;

namespace Laboratorio1.Tests.Fundamentals
{
    public class Inheritance
    {
        private readonly ITestOutputHelper OutputHelper;

        public Inheritance(ITestOutputHelper outputHelper)
        {
            this.OutputHelper = outputHelper;
        }

        /// <summary>
        /// Modificando la classe Kid, fai sì che il test seguente abbia successo.
        /// Hint: usa l'ereditarietà per far sì che la classe Kid estenda la classe Person. 
        /// Configura correttamente i costruttori per evitare che il bambino guidi.
        /// <see href="https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/tutorials/inheritance"/>
        /// </summary>
        [Fact]
        public void TestInheritance()
        {
            var kid = new Kid("Pippo", DateTime.Now.AddYears(-6));

            // TO-DO Decommenta il codice sottostante
            //if (kid.DrivingLicence)
            //{
            //    OutputHelper.WriteLine(kid.Drive());
            //}

            //Assert.False(kid.IsDriving());
        }

        /// <summary>
        /// Modificando la classe Kid, fai sì' che il test seguente abbia successo.
        /// Hint: usa l'override per evitare che il metodo DrinkAlchool lasci bere il bambino.
        /// </summary>
        [Fact]
        public void TestInheritance2()
        {
            var kid = new Kid("Pippo", DateTime.Now.AddYears(-6));

            // TO-DO Decommenta il codice sottostante
            //kid.DrinkAlchool();

            //Assert.False(kid.IsDrinking());
        }
    }
}
