using Moq;
using Xunit;

namespace StrategyPattern.Tests
{
    public class SmsNotificationServiceTests
    {
        [Fact]
        public void NotifyUser_ShouldPrintSmsSentMessage()
        {
            // Arrange
            var user = new User
            {
                Id = 1,
                Name = "John Doe",
                Email = "john.doe@example.com",
                Phone = "1234567890",
                NotifyPreferences = UserNotifyPreferences.Sms
            };
            var message = "Test message";
            var smsNotificationService = new SmsNotificationService();

            // Act
            using (var consoleOutput = new ConsoleOutput())
            {
                smsNotificationService.NotifyUser(message, user);

                // Assert
                Assert.Contains($"Sms sent to {user.Phone} successfully!", consoleOutput.GetOuput());
            }
        }
    }

    // Helper class to capture console output
    public class ConsoleOutput : IDisposable
    {
        private readonly StringWriter _stringWriter;
        private readonly TextWriter _originalOutput;

        public ConsoleOutput()
        {
            _stringWriter = new StringWriter();
            _originalOutput = Console.Out;
            Console.SetOut(_stringWriter);
        }

        public string GetOuput()
        {
            return _stringWriter.ToString();
        }

        public void Dispose()
        {
            Console.SetOut(_originalOutput);
            _stringWriter.Dispose();
        }
    }
}