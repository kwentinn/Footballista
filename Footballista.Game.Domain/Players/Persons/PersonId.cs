using System;
using System.Diagnostics;

namespace Footballista.Game.Domain.Players.Persons
{
    [DebuggerDisplay("[{value}]")]
    public record PersonId
    {
        private readonly Guid value;
        public PersonId(Guid value)
        {
            this.value = value;
        }

        /// <summary>
        /// Creates a new PersonId
        /// </summary>
        /// <returns></returns>
        public static PersonId CreateNew()
        {
            return new PersonId(Guid.NewGuid());
        }

        public static implicit operator Guid(PersonId id) => id.value;
    }
}
