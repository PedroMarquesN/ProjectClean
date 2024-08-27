using ProjetoClean.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoClean.Domain.Interfaces;
public interface IAuthenticate
{
    Task<User> Authenticate(string email, string password);
}
