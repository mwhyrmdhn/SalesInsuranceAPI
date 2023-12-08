using Policy.Models;
using Microsoft.EntityFrameworkCore;

namespace Policy.Repository
{
    public class PolicyRepository : IPolicyRepository
    {
        private readonly ApiContext context;

        public PolicyRepository(ApiContext context)
        {
            this.context = context;
        }

        public async Task<MasterPolicy> PostPolicy(MasterPolicy policy)
        {
            var result = await context.MasterPolicy.AddAsync(policy);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<MasterPolicy> UpdatePolicy(MasterPolicy policy)
        {
            var result = await context.MasterPolicy.FirstOrDefaultAsync(e => e.Policy_Id == policy.Policy_Id);
            if (result != null)
            {
                result.Customer_Name = policy.Customer_Name;
                result.Date_Of_Birth = policy.Date_Of_Birth;
                result.Sex = policy.Sex;
                result.Id_Card = policy.Id_Card;
                result.Phone_Number = policy.Phone_Number;
                result.Premium = policy.Premium;
                result.Plan_Type = policy.Plan_Type;
                result.Updated_By = policy.Updated_By;
                result.Update_Date = policy.Update_Date;
                await context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<MasterPolicy> DeletePolicy(string policy)
        {
            var result = await context.MasterPolicy.FirstOrDefaultAsync(e => e.Policy_Id == policy);
            if (result != null)
            {
                context.MasterPolicy.Remove(result);
                await context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<MasterPolicy>> GetPolicies()
        {
            return await context.MasterPolicy.ToListAsync();
        }

        public async Task<IEnumerable<MasterPolicy>> SearchPolicy(string policy)
        {
            IQueryable<MasterPolicy> query = context.MasterPolicy;
            if (!string.IsNullOrEmpty(policy))
            {
                query = query.Where(e => e.Policy_Id == policy);
            }
            return await query.ToListAsync();
        }

    }

    public interface IPolicyRepository
    {
        Task<MasterPolicy> PostPolicy(MasterPolicy policy);
        Task<MasterPolicy> UpdatePolicy(MasterPolicy policy);
        Task<MasterPolicy> DeletePolicy(string policy);
        Task<IEnumerable<MasterPolicy>> GetPolicies();
        Task<IEnumerable<MasterPolicy>> SearchPolicy(string policy);
    }
}
