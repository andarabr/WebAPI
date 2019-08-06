namespace DataAccess.ViewModels
{
    public class LoginVM
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


        public LoginVM() { }

        public LoginVM(int id, string email, string password)
        {
            this.Id = id;
            this.Email = email;
            this.Password = password;
        }

        public void Update(string name, string value)
        {
            this.Email = name;
            this.Password = value;
        }
    }
}