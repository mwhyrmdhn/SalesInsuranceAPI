using InstallmentPolicy.Models;
using Microsoft.EntityFrameworkCore;

namespace InstallmentPolicy.Repository
{
    public class InstallmentPolicyRepository : IInstallmentPolicyRepository
    {
        private readonly ApiContext context;

        public InstallmentPolicyRepository(ApiContext context)
        {
            this.context = context;
        }

        public async Task<Installment> PostInstallment(Installment installment)
        {
            var result = await context.InstallmentPolicy.AddAsync(installment);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Installment> UpdateInstallment(Installment installment)
        {
            var result = await context.InstallmentPolicy.FirstOrDefaultAsync(e => e.Policy_Id == installment.Policy_Id && e.Installment_No == installment.Installment_No);
            if (result != null)
            {
                result.Premium = installment.Premium;
                result.Paydate = installment.Paydate;
                await context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Installment> DeleteInstallment(string polis_id, int installmentno)
        {
            var result = await context.InstallmentPolicy.FirstOrDefaultAsync(e => e.Policy_Id == polis_id && e.Installment_No == installmentno);
            if (result != null)
            {
                context.InstallmentPolicy.Remove(result);
                await context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Installment>> GetInstallments()
        {
            return await context.InstallmentPolicy.ToListAsync();
        }

        public async Task<IEnumerable<Installment>> SearchPolicy(string policy)
        {
            IQueryable<Installment> query = context.InstallmentPolicy;
            if (!string.IsNullOrEmpty(policy))
            {
                query = query.Where(e => e.Policy_Id == policy);
            }
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Installment>> SearchInstallmentPolicy(string polis_id, int installmentno)
        {
            IQueryable<Installment> query = context.InstallmentPolicy;
            if (!string.IsNullOrEmpty(polis_id))
            {
                query = query.Where(e => e.Policy_Id == polis_id);
                if (!string.IsNullOrEmpty(Convert.ToString(installmentno)))
                {
                    query = query.Where(e => e.Installment_No == installmentno);
                }
            }
            return await query.ToListAsync();
        }

    }

    public interface IInstallmentPolicyRepository
    {
        Task<Installment> PostInstallment(Installment installment);
        Task<Installment> UpdateInstallment(Installment installment);
        Task<Installment> DeleteInstallment(string polis_id, int installmentno);
        Task<IEnumerable<Installment>> GetInstallments();
        Task<IEnumerable<Installment>> SearchPolicy(string policy);
        Task<IEnumerable<Installment>> SearchInstallmentPolicy(string polis_id, int installmentno);
    }
}
