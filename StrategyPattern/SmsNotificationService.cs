﻿namespace StrategyPattern
{
    internal class SmsNotificationService : IUserNotifier
    {
        public void NotifyUser(string message, User user)
        {
            Console.WriteLine($"Sms sent to {user.Phone} successfully!");
        }
    }
}
