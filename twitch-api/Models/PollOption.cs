using Microsoft.AspNetCore.Mvc;

namespace twitch_api.Models;

public class PollOption
{
    public string Name { get; set; }

    public string? Description { get; set; }

    public string? ImageUrl { get; set; }

    public PollOption(string _name) => Name = _name;
}
