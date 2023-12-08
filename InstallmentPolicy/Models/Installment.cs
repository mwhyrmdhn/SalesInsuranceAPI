using System.ComponentModel.DataAnnotations.Schema;
using Policy.Models;

namespace InstallmentPolicy.Models
{
    public class Installment
    {
        public int Id { get; set; }
        [ForeignKey("MasterPolicy")]
        public int PID { get; set; }
        public MasterPolicy? MasterPolicy { get; set; }
        public required string Policy_Id { get; set; }
        public required int Installment_No { get; set; }
        public float? Premium { get; set; }
        public DateTime? Paydate { get; set; }
        public string? Created_By { get; set; }
        public DateTime? Created_On { get; set; }
    }
}
