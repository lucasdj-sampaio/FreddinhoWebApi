using FreddinhoWebApi.Interfaces;

namespace FreddinhoWebApi.Models.Entity
{
    public class AccountModel : IAccount
    {
        public int? Id { get; set; }

        public string? Name { get; set; }

        public long CelphoneNumber { get; set; }

        public char Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }
    }
}