using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.Repositories
{
    public class UserRepository
    {
        private readonly Context _dbContext;
        public UserRepository(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Login(LoginDto dto)
        {
            var model = _dbContext.Users.FirstOrDefault(u => u.Login == dto.Login && u.Password == dto.Password);
            if (model == null) return false;
            return true;
        }
    }
}
