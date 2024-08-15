using ProjetoClean.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoClean.Domain.Interfaces;
public interface IUserRepository
{
    Task<User> GetUserByEmailAsync(string email);
}
