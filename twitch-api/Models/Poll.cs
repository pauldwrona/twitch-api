using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Eventing.Reader;
using System.Numerics;

namespace twitch_api.Models;

[Serializable]
public class Poll
{
    enum pollStatus
    {
        Creating, Open, Closed
    }

    
    public int OwnerId { get; set; }
    [Key]
    public string Name { get; set; }
    public string? Description { get; set; }

    [DefaultValue("started")]
    public string? Status { get; set; } // enumerator
    public Dictionary<int, PollOption> Options { get; set; }
    [NotMapped]
    public Dictionary<int, int> VoteCount { get; set; }
    [NotMapped]
    public Dictionary<int, Vote> VoterBallot { get; set; } // UserId, Vote

    // In memory structures, pass to database at some point

    public Poll() : this(0, "", null, null) { }

    public Poll(int _ownerId, string _name, string? _description, string? _status)
    {
        OwnerId = _ownerId;
        Name = _name;
        Description = _description; 
        Status = _status;
        Options = new Dictionary<int, PollOption>(); // static
        VoteCount = new Dictionary<int, int>(); // cumulative
        VoterBallot = new Dictionary<int /* TODO - make user class to replace int, or associate string name with */, Vote>();
        // Want closer to ->
        //  Votes = new Dictionary<int, Dictionary<UserId, Vote>>>();
        // can get Votes.KeySet()
        // foreach key and independent lists
        // -------
        // Instead, keep options and count of each vote type, but associate each vote/votes to user id and track on that basis
    }

    // PollResults option

    // Converter -> https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.typeconverter?view=netframework-4.8.1
    // Json Converter -> https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/converters-how-to?pivots=dotnet-7-0
    // Want a generic deserializer so can potentially handle plaintext, YAML, and XML on top of JSON
    //  otherwise might have to settle for just JSON deserialization

    // https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/polymorphism?pivots=dotnet-7-0
}
