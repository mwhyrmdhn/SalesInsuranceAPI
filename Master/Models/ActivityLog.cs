using System.ComponentModel.DataAnnotations.Schema;

namespace Master.Models
{
    public class ActivityLog
    {
        public int Id { get; set; }
        [ForeignKey("MasterUser")]
        public required int MID { get; set; }
        public MasterUser? MasterUser { get; set; }
        public DateTime? DateTime { get; set; }
        public string? Details {  get; set; }
        public int ResponseCode { get; set; }
        public string? ResponseDesc { get; set; }
    }
}
