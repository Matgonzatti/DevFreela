namespace DevFreela.Application.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(string userName, string email)
        {
            UserName = userName;
            Email = email;
        }

        public string UserName { get; private set; }
        public string Email { get; private set; }
    }
}