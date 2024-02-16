namespace CMS
{
    internal interface IUser
    {
        bool IsUserLogin { get; set; }

        void Login();
    }
}