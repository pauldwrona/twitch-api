using System;
using System.Collections;
using System.Security.Cryptography.X509Certificates;
using twitch_api.Models;

/// <summary>
/// Summary description for Class1
/// </summary>
public class PollService
{
	private List<Poll> pollList = new List<Poll>();
	private readonly ILogger _logger =;



	public addPoll(Poll poll)
	{
		pollList.Add(poll);
	}

	public addVote(, Vote vote)
	{
		pollList
	}
}
