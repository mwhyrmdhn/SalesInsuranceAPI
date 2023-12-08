namespace Master.Models
{
    public class MasterUser
    {
        public int MID { get; set; }
        public required string User_Id { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string? User_Level { get; set; }
        public string? Created_By { get; set; }
        public DateTime? Created_On { get; set; }
        public string? Updated_By { get; set; }
        public DateTime? Update_Date { get; set; }
        public ICollection<ActivityLog>? ActivityLog { get; set; }
    }
}
