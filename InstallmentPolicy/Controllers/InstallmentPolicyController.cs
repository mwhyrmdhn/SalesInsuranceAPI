using InstallmentPolicy.Models;
using InstallmentPolicy.Repository;
using Microsoft.AspNetCore.Mvc;

namespace InstallmentPolicy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstallmentPolicyController : ControllerBase
    {
        private readonly IInstallmentPolicyRepository installmentPolicyRepository;
        public InstallmentPolicyController(IInstallmentPolicyRepository installmentPolicyRepository)
        {
            this.installmentPolicyRepository = installmentPolicyRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Installment>> PostInstallment(Installment policy)
        {
            try
            {
                if (policy == null)
                {
                    return BadRequest();
                }

                var dataPolicy = await installmentPolicyRepository.SearchInstallmentPolicy(policy.Policy_Id,policy.Installment_No);

                if (dataPolicy.Count() > 0)
                {
                    return BadRequest("Installment Policy Duplicate!");
                }

                var created = await installmentPolicyRepository.PostInstallment(policy);

                return CreatedAtAction(nameof(PostInstallment),
                    new { id = created.Id }, created);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new installment policy record!");
            }
        }

        [HttpPut("{Policy_Id}/{Installment_No}")]
        public async Task<ActionResult<Installment>> UpdateInstallmentPolicy(Installment policy, string Policy_Id, int Installment_No)
        {
            try
            {
                if (Policy_Id.ToUpper() != policy.Policy_Id.ToUpper())
                {
                    return BadRequest("Policy_Id mismatch!");
                }
                if (Installment_No.ToString() != policy.Installment_No.ToString())
                {
                    return BadRequest("Installment No mismatch!");
                }
                var dataPolicy = await installmentPolicyRepository.SearchInstallmentPolicy(Policy_Id, Installment_No);

                if (dataPolicy.Count() == 0)
                {
                    return NotFound();
                }
                return await installmentPolicyRepository.UpdateInstallment(policy);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating installment policy!");
            }
        }

        [HttpDelete("{Policy_Id}/{Installment_No}")]
        public async Task<ActionResult<Installment>> DeleteInstallment(string Policy_Id, int Installment_No)
        {
            try
            {
                var result = await installmentPolicyRepository.SearchInstallmentPolicy(Policy_Id, Installment_No);

                if (result.Count() == 0)
                {
                    return NotFound();
                }

                return await installmentPolicyRepository.DeleteInstallment(Policy_Id,Installment_No);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting installment policy!");
            }
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Installment>>> GetInstallments()
        {
            try
            {
                var result = await installmentPolicyRepository.GetInstallments();
                if (result.Any())
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database!");
            }
        }

        [HttpGet("{Policy_Id}")]
        public async Task<ActionResult<IEnumerable<Installment>>> Search(string Policy_Id)
        {
            try
            {
                var result = await installmentPolicyRepository.SearchPolicy(Policy_Id);
                if (result.Any())
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database!");
            }
        }

        [HttpGet("{Policy_Id}/{Installment_No}")]
        public async Task<ActionResult<IEnumerable<Installment>>> Search(string Policy_Id, int Installment_No)
        {
            try
            {
                var result = await installmentPolicyRepository.SearchInstallmentPolicy(Policy_Id, Installment_No);
                if (result.Any())
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database!");
            }
        }


    }
}
