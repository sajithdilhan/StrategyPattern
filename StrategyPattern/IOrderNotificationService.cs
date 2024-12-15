using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    internal interface IOrderNotificationService
    {
        void SendNotificationToUser(string message, IUserNotifier userNotifier, User user);
    }
}
