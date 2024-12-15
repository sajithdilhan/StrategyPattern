namespace StrategyPattern
{
    internal class PushNotificationService : IUserNotifier
    {
        public void NotifyUser(string message, User user)
        {
            Console.WriteLine($"Push notification sent to {user.Name} successfully!");
        }
    }
}
