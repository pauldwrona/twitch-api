using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using twitch_api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace twitch_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PollController : ControllerBase
{
    private readonly PollContext _context;
    // </snippet_PollController>

    public PollController(PollContext context) =>
        _context = context;

    // GET: api/<PollController>
    [HttpGet]
    public async Task<List<Poll>> Get() => 
        await _context.Polls.ToListAsync();

    // GET api/<PollController>/5/1
    [HttpGet("{id}/{pollName}")]
    public async Task<ActionResult<Poll>> Get(int id, string pollName)
    {
        var pollRead = await _context.Polls.FindAsync(pollName);
        if (pollRead == null)
        {
            return NotFound();
        }
        if (pollRead.OwnerId.Equals(id))
            return pollRead;

        return Unauthorized();
    }

    // POST api/<PollController>
    [HttpPost]
    public async Task<IActionResult> Create(/*string name, int id,*/ [FromBody] Poll newPoll)
    {
        _context.Polls.Add(newPoll);
        await _context.SaveChangesAsync();
        
        return CreatedAtAction(nameof(Get), new { name = newPoll.Name }, newPoll);
    }

    // PUT api/<PollController>/5
    [HttpPut("{id}")]
    public void Put(string name, [FromBody]int id, string value)
    {
    }

    // DELETE api/<PollController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
