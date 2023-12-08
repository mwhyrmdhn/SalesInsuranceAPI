using Microsoft.AspNetCore.Mvc;
using Policy.Models;
using Policy.Repository;

namespace Policy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        private readonly IPolicyRepository policyRepository;
        public PolicyController(IPolicyRepository policyRepository)
        {
            this.policyRepository = policyRepository;
        }

        [HttpPost]
        public async Task<ActionResult<MasterPolicy>> PostPolicy(MasterPolicy policy)
        {
            try
            {
                if (policy == null)
                { 
                    return BadRequest();
                }

                var dataPolicy = await policyRepository.SearchPolicy(policy.Policy_Id);

                if (dataPolicy.Count() > 0)
                {
                    return BadRequest("Policy_Id Duplicate!");
                }

                var created = await policyRepository.PostPolicy(policy);

                return CreatedAtAction(nameof(PostPolicy),
                    new { id = created.PID }, created);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new policy record!");
            }
        }

        [HttpPut("{Policy_Id}")]
        public async Task<ActionResult<MasterPolicy>> UpdatePolicy(MasterPolicy policy, string Policy_Id)
        {
            try
            {
                if (Policy_Id.ToUpper() != policy.Policy_Id.ToUpper())
                {
                    return BadRequest("Policy_Id mismatch!");
                }

                var dataPolicy = await policyRepository.SearchPolicy(Policy_Id);

                if (dataPolicy.Count() == 0)
                {
                    return NotFound();
                }
                return await policyRepository.UpdatePolicy(policy);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating policy!");
            }
        }

        [HttpDelete("{Policy_Id}")]
        public async Task<ActionResult<MasterPolicy>> DeletePolicy(string Policy_Id)
        {
            try
            {
                var result = await policyRepository.SearchPolicy(Policy_Id);

                if (result.Count() == 0)
                {
                    return NotFound();
                }

                return await policyRepository.DeletePolicy(Policy_Id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting policy!");
            }
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<MasterPolicy>>> GetPolicies()
        {
            try
            {
                var result = await policyRepository.GetPolicies();
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
        public async Task<ActionResult<IEnumerable<MasterPolicy>>> Search(string Policy_Id)
        {
            try
            {
                var result = await policyRepository.SearchPolicy(Policy_Id);
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
