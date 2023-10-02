using Microsoft.OpenApi.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;
using System.Security.AccessControl;

namespace twitch_api.Models
{
    public class Vote : IComparable, IComparable<Vote>
    {
        [Required]
        public string UserID { get; set; }

        public DateTime TimeCreated { get; } = DateTime.Now;
        public DateTime TimeUpdated { get; } = DateTime.Now;

        [DefaultValue(1)]
        public int VoteWorth { get; set; }

        public Vote(string _userID, int? _voteValue)
        {
            UserID = _userID;
            VoteWorth = _voteValue ?? 1;
            TimeUpdated = DateTime.Now;

        }

        // CompareTo/Equals/Operator/etc overrides
        public int CompareTo(object? obj)
        {
            if (obj == null)
            {
                return 1;
            }

            if (obj is Vote other)
            {
                return CompareTo(other);
            }

            throw new ArgumentException("A Vote object is required for comparison", "obj");
        }

        public int CompareTo(Vote? other)
        {
            if (other is null)
            {
                return 1;
            }

            return -string.Compare(this.UserID, other.UserID, StringComparison.OrdinalIgnoreCase);
        }

        public static int Compare(Vote vote1, Vote vote2)
        {
            if (object.ReferenceEquals(vote1, vote2))
            {
                return 0;
            }
            if (vote1 is null)
            {
                return -1;
            }
            return vote1.CompareTo(vote2);
        }

        public override bool Equals(object? obj)
        {
            if (obj is Vote other)
            {
                return this.CompareTo(other) == 0;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.UserID.GetHashCode();
        }

        public static bool operator ==(Vote vote1, Vote vote2)
        {
            if (vote1 is null)
            {
                return vote2 is null;
            }
            return vote1.Equals(vote2);
        }
        
        public static bool operator !=(Vote vote1, Vote vote2)
        {
            return !(vote1 == vote2);
        }

        public static bool operator <(Vote vote1, Vote vote2)
        {
            return (Compare(vote1, vote2) < 0);
        }

        public static bool operator >(Vote vote1, Vote vote2)
        {
            return (Compare(vote1, vote2) > 0);
        }
    }
}
