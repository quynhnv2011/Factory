using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business;
using System.Data;
using Common;

namespace DataAccess.Ado.Net
{
    public class AccountDao : IAccountDao
    {
        private IConnectionFactory _connectionFactory;
        public AccountDao(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        static Func<IDataReader, Account> Make = reader =>
              new Account
              {
                  Id = reader["ID"].AsInt(),
                  Email = reader["EMAIL"].ToString(),
                  Password = reader["PASSWORD"].ToString(),
                  PasswordExpireddate = reader["PASSWORDEXPIREDDATE"].ToString(),
                  CreatedDate = reader["CREATEDDATE"].AsDateTime(),
                  CreatedBy = reader["CREATEDBY"].AsInt(),
                  ModifiedDate = reader["MODIFIEDDATE"].AsDateTime(),
                  ModifiedBy = reader["MODIFIEDBY"].AsInt(),
                  AccountType = reader["ACCOUNTTYPE"].AsInt(),
                  IsLocked = reader["ISLOCKED"].ToString(),
                  Status=reader["STATUS"].ToString(),
                  DisplayName=reader["DISPLAYNAME"].ToString(),
                  ActivatedBy=reader["ACTIVATEDBY"].AsInt(),
                  ActivatedDate=reader["ACTIVATEDDATE"].AsDateTime(),
                  IsActivated=reader["ISACTIVATED"].ToString(),
                  LockedDate=reader["LOCKEDDATE"].AsDateTime(),
                  LockedBy=reader["LOCKEDBY"].AsInt(),
                  LastLogin=reader["LASTLOGINDATE"].AsDateTime(),
                  DonViPhongBanId=reader["DONVIPHONGBANID"].AsInt()
              };
        public List<Account> GetByIdDvPb(int id)
        {
            try
            {
                using (var cnn = _connectionFactory.Create())
                {
                    var cmd = cnn.CreateCommand();
                    cmd.CommandText = "SELECT * FROM ACCOUNT WHERE DONVIPHONGBANID=:DONVIPHONGBANID";
                    cmd.CommandType = CommandType.Text;
                    cmd.AddParameter(":DONVIPHONGBANID", id);        
                    var reader = cmd.ExecuteReader();
                    var lstResult = new List<Account>();
                    while (reader.Read())
                    {
                        lstResult.Add(Make(reader));
                    }
                    return lstResult;
                }
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public Account GetById(int Id)
        {
            try
            {
                using (var cnn = _connectionFactory.Create())
                {
                    var cmd = cnn.CreateCommand();
                    cmd.CommandText = "SELECT * FROM ACCOUNT WHERE ID=:ID";
                    cmd.CommandType = CommandType.Text;
                    cmd.AddParameter(":ID", Id);
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        return Make(reader);
                    }
                    return null;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
