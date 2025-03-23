using Lab5TestTask.Data;
using Lab5TestTask.Models;
using Lab5TestTask.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Lab5TestTask.Services.Implementations;

/// <summary>
/// UserService implementation.
/// Implement methods here.
/// </summary>
public class UserService : IUserService
{
    private readonly ApplicationDbContext _dbContext;

    public UserService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<User> GetUserAsync()
    {
		var user = await _dbContext.Users.OrderBy(u => u.Sessions.Count).FirstOrDefaultAsync();

		if(user == null)
		{
			throw new NotImplementedException();
		}

		return user;
	}

	public async Task<List<User>> GetUsersAsync()
    {
		var users = await _dbContext.Users
			.Where(u => u.Sessions.Any(x=> x.DeviceType == Enums.DeviceType.Mobile))
			.ToListAsync();
		if (users == null)
		{
			throw new NotImplementedException();
		}
  
        return users;
	}
}
