namespace FreddinhoWebApi.Models.Entity
{
    public class PatientModel : AccountModel
    {
        public bool Psychotropic { get; set; }

        public int AccountId { get; set; }
        
        public ICollection<AccountModel>? UserAccount { get; set; }

        public int PsychologistId { get; set; }

        public ICollection<PsychologistModel>? Psychologist { get; set; }

        public int PlainId { get; set; }

        public ICollection<PlainModel>? Plain { get; set; }
    }
}