using Master.Models;
using Microsoft.EntityFrameworkCore;

namespace Master.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApiContext context;

        public UserRepository(ApiContext context)
        {
            this.context = context;
        }

        public async Task<MasterUser> PostUser(MasterUser user)
        {
            var result = await context.MUser.AddAsync(user);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<MasterUser> UpdateUser(MasterUser user)
        {
            var result = await context.MUser.FirstOrDefaultAsync(e => e.User_Id == user.User_Id);
            if (result != null)
            {
                result.Name = user.Name;
                result.Password = user.Password;
                result.User_Level = user.User_Level;
                result.Updated_By = user.Updated_By;
                result.Update_Date = user.Update_Date;
                await context.SaveChangesAsync();
                return result;
            }
            //context.Entry(user).State = EntityState.Modified;
            return null;
        }

        public async Task<MasterUser> DeleteUser(string userid)
        {
            var result = await context.MUser.FirstOrDefaultAsync(e => e.User_Id == userid);
            if (result != null)
            {
                context.MUser.Remove(result);
                await context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<MasterUser>> GetUsers()
        {
            return await context.MUser.ToListAsync();
        }

        public async Task<IEnumerable<MasterUser>> SearchId(string userid)
        {
            IQueryable<MasterUser> query = context.MUser;
            if (!string.IsNullOrEmpty(userid))
            {
                query = query.Where(e => e.User_Id == userid);
            }
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<MasterUser>> Login(string userid, string password)
        {
            IQueryable<MasterUser> query = context.MUser;

            if (!string.IsNullOrEmpty(userid))
            {
                query = query.Where(e => e.User_Id == userid);

                if (!string.IsNullOrEmpty(password))
                {
                    query = query.Where(e => e.Password == password);
                }
            }
            return await query.ToListAsync();
        }

    }

    public interface IUserRepository
    {
        Task<MasterUser> PostUser(MasterUser user);
        Task<MasterUser> UpdateUser(MasterUser user);
        Task<MasterUser> DeleteUser(string userid);
        Task<IEnumerable<MasterUser>> GetUsers();
        Task<IEnumerable<MasterUser>> SearchId(string userid);
        Task<IEnumerable<MasterUser>> Login(string userid, string password);
    }
}
