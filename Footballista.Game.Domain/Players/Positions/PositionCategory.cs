using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Footballista.Game.Domain.Players.Positions
{
    [DebuggerDisplay("{_name}")]
    public record PositionCategory
    {
        private readonly string _name;

        private PositionCategory(string name)
        {
            _name = name;
        }

        public static PositionCategory GoalKeeper => new PositionCategory(nameof(GoalKeeper));
        public static PositionCategory Defender => new PositionCategory(nameof(Defender));
        public static PositionCategory Midfielder => new PositionCategory(nameof(Midfielder));
        public static PositionCategory Forward => new PositionCategory(nameof(Forward));

        public static PositionCategory None => new PositionCategory(nameof(None));

        private static readonly Dictionary<PositionCategory, PlayerPosition[]> _positionCategoriesDefinitions = new Dictionary<PositionCategory, PlayerPosition[]>()
        {
            {
                GoalKeeper, new PlayerPosition[] { PlayerPosition.GoalKeeper }
            },
            {
                Defender, new PlayerPosition[]
                {
                    PlayerPosition.CentreBack, PlayerPosition.FullBack, PlayerPosition.Sweeper, PlayerPosition.WingBack
                }
            },
            {
                Midfielder, new PlayerPosition[]
                {
                    PlayerPosition.AttackingMidfield, PlayerPosition.CentreMidfield, PlayerPosition.DefensiveMidfield, PlayerPosition.WideMidfield
                }
            },
            {
                Forward, new PlayerPosition[]
                {
                    PlayerPosition.CentreForward, PlayerPosition.Winger, PlayerPosition.SecondStriker
                }
            },
        };

        public static PositionCategory FromPosition(PlayerPosition position)
        {
            foreach (KeyValuePair<PositionCategory, PlayerPosition[]> definition in _positionCategoriesDefinitions)
            {
                if (definition.Value.Any(pp => pp == position))
                {
                    return definition.Key;
                }
            }
            return default;
        }
    }
}
