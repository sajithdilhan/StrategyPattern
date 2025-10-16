using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StrategyPattern;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddScoped<IOrderNotificationService, OrderService>();
        services.AddKeyedScoped<IUserNotifier, EmailNotificationService>("EmailService");
        services.AddKeyedScoped<IUserNotifier, SmsNotificationService>("SmsService");
        services.AddKeyedScoped<IUserNotifier, PushNotificationService>("PushService");
    }).Build();

ProcessUserOrder(host.Services);

static void ProcessUserOrder(IServiceProvider services)
{
    User user = new User
    {
        Email = "test@gmail.com",
        Id = 1,
        Name = "Test",
        Phone = "123123123",
        NotifyPreferences = UserNotifyPreferences.Sms
    };

    using var scope = services.CreateScope();
    IUserNotifier? userNotifier = user.NotifyPreferences switch
    {
        UserNotifyPreferences.Email => services.GetKeyedService<IUserNotifier>("EmailService"),
        UserNotifyPreferences.Sms => services.GetKeyedService<IUserNotifier>("SmsService"),
        UserNotifyPreferences.Push => services.GetKeyedService<IUserNotifier>("PushService"),
        UserNotifyPreferences.None => throw new NotImplementedException(),
        UserNotifyPreferences.Post => throw new NotImplementedException(),
        _ => throw new NotImplementedException(),
    };

    var orderService = services!.GetService<IOrderNotificationService>();
    orderService!.SendNotificationToUser("Order processed", userNotifier!, user);
    Console.ReadLine();
}