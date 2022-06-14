namespace FreddinhoWebApi.Models.Entity
{
    public class PsychologistModel : AccountModel
    {
        public int Workload { get; set; }

        public string? Location { get; set; }

        public float Price { get; set; }

        
        public int AccountId { get; set; }
        
        public ICollection<AccountModel>? UserAccount { get; set; }

        public int AvailabilityId { get; set; }

        public ICollection<AvailabilityModel>? Availability { get; set; }
    }
}