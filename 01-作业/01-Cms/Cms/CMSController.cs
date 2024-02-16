namespace Cms
{
    internal class CMSController
    {
        public void Start(User user, Menu menu)
        {
            // login
            do
            {
                user.Login();
            } while (!user.IsUserLogin);

            // start Menu
            menu.ShowMenu();
        }
    }
}
