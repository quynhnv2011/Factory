using Business;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AccountService
    {
        private IAccountDao _accountDao;
        public AccountService(string dataProvider)
        {
            _accountDao = DaoFactories.GetFactory(dataProvider).AccountDao;
        }
        public List<Account> GetByIdPbDv(int Id)
        {
            try
            {
                return _accountDao.GetByIdDvPb(Id);
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        public Account GetById(int Id)
        {
            try
            {
                return _accountDao.GetById(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
