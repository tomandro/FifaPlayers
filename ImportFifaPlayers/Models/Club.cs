using System;
using System.Collections.Generic;
using System.Text;

namespace ImportFifaPlayers.Models
{
    public class Club :IEquatable<Club>,IComparable<Club>
    {
        public int Id;
        public String AbbrName;
        public String Name;
        public League League;

        public int CompareTo(Club other)
        {
            return this.Id.CompareTo(other.Id);
        }

        public bool Equals(Club other)
        {
            return this.Id.Equals(other.Id);
        }
    }
}
