using InstaSharper.Classes.Models;

namespace InstaManager.MessengerModels
{
    public class MainLoginModel
    {
        public InstaCurrentUser CurrentUser { get; set; }

        public InstaUserShortList Following { get; set; }

        public InstaUserShortList Followers { get; set; }



    }
}
