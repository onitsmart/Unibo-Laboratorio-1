using System;

namespace Laboratorio1.Tests.Fundamentals.Models
{
    /// <summary>
    /// Ereditarietà
    /// <see href="https://learn.microsoft.com/en-us/dotnet/standard/design-guidelines/member-overloading"/>
    /// </summary>
    /// <param name="name"></param>
    /// <param name="age"></param>
    public class Kid : Person
    {
        public bool CanWalk { get; set; }

        // Costruttore richiama il costruttore base impostando anche il permesso di guida a false
        public Kid(string name, DateTime dateOfBirth) : base (name, false, dateOfBirth)
        {
        }

        public Kid(string name, DateTime dateOfBirth, bool canWalk) : base(name, false, dateOfBirth)
        {
            this.CanWalk = canWalk;
        }

        // Esempio di sovrascrittura di un metodo di una classe base non predisposto per essere overridato.
        // Con la parola chiave new gli stiamo dicendo di nascondere il metodo base e usare questo.
        // Per poter usare la parola chiave override il metodo della classe base doveva essere marcato come virtual.
        public new void DrinkAlchool()
        {
            // Non facciamo nulla in quanto non vogliamo che il bambino beva alchool
        }
    }
}
