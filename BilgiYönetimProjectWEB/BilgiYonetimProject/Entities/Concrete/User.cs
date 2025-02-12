

using Core.Entities;

namespace Entities.Concrete
{
    public class User:IEntity
    {
        public int UserId { get; set; }
        public  string? UserName { get; set; }
        public  string? UserSurname { get; set; }
        public  string? UserCode { get; set; }
        public  string? UserMail { get; set; }
        public  string? UserPassword { get; set; }
        public DateTime? CreateDate { get; set; }
        public  string? CreateUser { get; set; }
    }
}
 