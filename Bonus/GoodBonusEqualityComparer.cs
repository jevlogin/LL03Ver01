using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public sealed class GoodBonusEqualityComparer : IEqualityComparer<GoodBonus>
    {
        public bool Equals(GoodBonus x, GoodBonus y) => x.Point == y.Point;

        public int GetHashCode(GoodBonus obj)
        {
            return obj.Point.GetHashCode();
        }
    }
}