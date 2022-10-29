namespace Sat.Recruitment.Domain.Dtos
{
    public class UserCreationDto
    {
        public string name { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string userType { get; set; }
        public decimal money { get; set; }
    }
}
