using Microsoft.AspNetCore.Mvc;

namespace twitch_api.Models;

public class PollChoice
{
    public string Name { get; set; }

    public string? Description { get; set; }

    public string? ImageUrl { get; set; }

    public PollChoice(string _name) => Name = _name;
}
