using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.Implementations
{
    public class RegistrationKeyRepository : IRegistrationKeyRepository
    {
        private readonly AppDbContext _context;
        public RegistrationKeyRepository(AppDbContext context) 
        {
            _context = context;
        }

        public async Task<RegistrationKey?> getKeyFirst()
        {
            return await _context.RegistrationKeys.FirstOrDefaultAsync();
        }
    }
}
