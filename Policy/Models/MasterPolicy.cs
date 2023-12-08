using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using InstallmentPolicy.Models;

namespace Policy.Models
{
    public class MasterPolicy
    {
        public int PID { get; set; }
        public required string Policy_Id { get; set; }
        public required string Customer_Name { get; set; }
        public DateTime Date_Of_Birth { get; set; }    
        public string? Sex { get; set; }    
        public string? Id_Card { get; set; }
        public string? Phone_Number { get; set; }
        public float Premium { get; set; }
        public string? Plan_Type { get; set; }
        public string? Created_By { get; set; }
        public DateTime Created_Date { get; set; }
        public string? Updated_By { get;set; }
        public DateTime? Update_Date { get; set; }

        public ICollection<Installment>? Installments { get; set; }
    }
}
