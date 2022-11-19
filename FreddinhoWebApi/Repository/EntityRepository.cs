using FreddinhoWebApi.Models.Entity;
using FreddinhoWebApi.Repository.Context;
using FreddinhoWebApi.Util;
using Microsoft.EntityFrameworkCore;

namespace FreddinhoWebApi.Repository
{
    public class EntityRepository
    {
        private DataBaseContext? _repository { get; set; }

        public EntityRepository(DataBaseContext dataBaseContext) =>
            _repository = dataBaseContext;


        public async Task<Response> UserExist(string email, string password)
        {
            try{
                bool result = (await _repository.DbAccount.Where(u => u.Email == email
                    && u.Password == EncryptPassword(password)).ToListAsync()).Count >= 1 ? true : false;

                return new Response(result);
            }catch {
                throw;
            }
        }

        public async Task<Account> ReturnAccount(string email, string password) 
        {
            try{
                return await _repository.DbAccount
                    .Where(u => u.Email == email
                        && u.Password == EncryptPassword(password)).SingleOrDefaultAsync();
            }
            catch {
                throw;
            }
        }

        public async Task<(bool, string)> InsertUser(Account account) 
        {
            try
            {
                if ((await UserExist(account.Email, account.Password)).success)
                    return new(false, "Usuário já cadastrado no Freddinho!");

                account.Password = EncryptPassword(account.Password);

                await _repository.DbAccount.AddRangeAsync(account);

                await _repository.SaveChangesAsync();

                return new(true, "");
            }
            catch (Exception ex)
            {
                return new(false, ex.Message);
            }   
        }

        private static string EncryptPassword(string password) =>
            Encrypt.EncryptData(password);

        public async Task<(bool, string)> InsertUser(Dependent dependent)
        {
            try
            {
                await _repository.DbDependent.AddAsync(dependent);

                await _repository.SaveChangesAsync();

                return new(true, "");
            }
            catch (Exception ex)
            {
                return new(false, ex.Message);
            }
        }

        public async Task<IList<Dependent>> GetDependent(int userId)
        {
            try
            {
                return await _repository.DbDependent.Where(d => d.AccountModelId == userId).ToListAsync();
            }
            catch (Exception e)
            {
               throw new Exception(e.Message);
            }
        }
    }
}