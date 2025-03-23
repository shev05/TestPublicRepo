using Lab5TestTask.Data;
using Lab5TestTask.Enums;
using Lab5TestTask.Models;
using Lab5TestTask.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lab5TestTask.Services.Implementations;

/// <summary>
/// SessionService implementation.
/// Implement methods here.
/// </summary>
public class SessionService : ISessionService
{
    private readonly ApplicationDbContext _dbContext;

    public SessionService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Session> GetSessionAsync()
    {
        var session = await _dbContext.Sessions.FirstOrDefaultAsync();
        if (session == null)
        {
            throw new NotImplementedException();
        }
        return session;

	}

	public async Task<List<Session>> GetSessionsAsync()
	{
		var endDateFilter = new DateTime(2025, 1, 1);

		var sessions = await _dbContext.Sessions
			.Where(s => s.EndedAtUTC < endDateFilter && s.User.Status == UserStatus.Active)
			.ToListAsync();

		if (sessions == null)
		{
			throw new NotImplementedException();
		}

		return sessions;
	}
}
