using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IAccountDao
    {
        List<Account> GetByIdDvPb(int Id);
        Account GetById(int Id);  
    }
}
