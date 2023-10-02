using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;

// <snippet_PragmaWarningDisable>
namespace twitch_api.Models;

#pragma warning disable CS1591
public class PollContext : DbContext
{
    public PollContext(DbContextOptions<PollContext> options) : base(options) { }

    public DbSet<Poll> Polls => Set<Poll>();
}
#pragma warning restore CS1591
// </snippet_PragmaWarningDisable>
