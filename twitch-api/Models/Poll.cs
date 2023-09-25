using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using System.Collections;
using System.Diagnostics.Eventing.Reader;
using System.Numerics;

namespace twitch_api.Models
{
    public class Poll
    {
        public int OwnerId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public Dictionary<int, List<PollOption>> Options { get; set; }
        public Dictionary<int, List<Vote>> Votes { get; set; }
        protected void addVote(int optionSelected, Vote _vote)
        {

            Votes.TryGetValue(optionSelected, out List<Vote>? editVotes);
            if (editVotes != null)
            {
                editVotes.Add(_vote);
            }
            else throw new InvalidDataException();
            
        }
        public Poll(int _id, string _name, string? _description, string? _status)
        {
            OwnerId = _id;
            Name = _name;
            Description = _description; 
            Status = _status;
            Options = new Dictionary<int, List<PollOption>>();
            Votes = new Dictionary<int, List<Vote>>();
        }
    }
}
