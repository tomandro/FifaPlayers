using System;
using System.Collections.Generic;
using System.Text;

namespace ImportFifaPlayers.Models
{
    public class League : IEquatable<League>, IComparable<League>
    {
        public int Id;
        public String AbbrName;
        public String Name;

        public int CompareTo(League other)
        {
            return this.Id.CompareTo(other.Id);
        }

        public bool Equals(League other)
        {
            return this.Id.Equals(other.Id);
        }
    }
}
