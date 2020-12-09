using System;
using System.Runtime.Serialization;

namespace Footballista.Game.Domain.Fixtures
{
    [Serializable]
    internal class CannotGenerateFixturesForSeason : Exception
    {
        public CannotGenerateFixturesForSeason()
        {
        }

        public CannotGenerateFixturesForSeason(string message) : base(message)
        {
        }

        public CannotGenerateFixturesForSeason(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CannotGenerateFixturesForSeason(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}