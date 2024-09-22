using System;

namespace Laboratorio1.Tests.Fundamentals.Models
{
    /// <summary>
    /// Ereditarietà
    /// <see href="https://learn.microsoft.com/en-us/dotnet/standard/design-guidelines/member-overloading"/>
    /// </summary>
    /// <param name="name"></param>
    /// <param name="age"></param>
    public class Kid
    {
        public bool CanWalk { get; set; }

        public Kid(string name, DateTime dateOfBirth)
        {
        }

        public Kid(string name, DateTime dateOfBirth, bool canWalk)
        {
            this.CanWalk = canWalk;
        }
    }
}
