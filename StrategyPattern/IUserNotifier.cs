using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    internal interface IUserNotifier
    {
        void NotifyUser(string message, User user);
    }
}
