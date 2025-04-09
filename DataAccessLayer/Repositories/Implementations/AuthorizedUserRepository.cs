using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.Implementations
{
    public class AuthorizedUserRepository: IAuthorizedUserRepository
    {
        private readonly AppDbContext _context;
        public AuthorizedUserRepository(AppDbContext context) 
        {
            _context = context;
        }

        public async Task<AuthorizedUser?> GetUserById(int userId)
        {
            return await _context.AuthorizedUsers.FindAsync(userId);
        }

        public async Task<AuthorizedUser?> GetUserByLogin(string login)
        {
            return await _context.AuthorizedUsers.Where(x => x.Login == login).FirstOrDefaultAsync();
        }

        public async Task InsertUser(AuthorizedUser user)
        {
            await _context.AuthorizedUsers.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}
