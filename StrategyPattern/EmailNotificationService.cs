namespace StrategyPattern
{
    internal class EmailNotificationService : IUserNotifier
    {
        public void NotifyUser(string message, User user)
        {
            Console.WriteLine($"Email sent to {user.Email} successfully!");
        }
    }
}
