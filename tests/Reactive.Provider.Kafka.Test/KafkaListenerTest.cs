using Reactive.Kafka;
using Reactive.Provider.Kafka.Test.TypeTests;
using Xunit;

namespace Reactive.Provider.Kafka.Test
{
    public class KafkaListenerTest
    {
        [Fact]
        public void Get_Message_Handled_Whitin_ConsumerMessage()
        {
            //Arrange
            var message = "Test message";
            var obj = new ConsumerMessage<string>(null, message);
            var expected = message;
            //Action
            var result = KafkaListener.GetMessageHandled(obj);

            Assert.Equal(expected, result);
            Assert.NotEqual("Test Message", result);
        }

        [Fact]
        public void Get_Message_Handled_Whitout_ConsumerMessage()
        {
            //Arrange
            var date = DateTime.Now;
            var messageString = "Test message";
            var messageInt = 10;
            var messageDecimal = 10.4d;
            var messageDateTime = date;
            //Action

            //Assert
            Assert.Equal(messageString, KafkaListener.GetMessageHandled(messageString));
            Assert.Equal(10.ToString(), KafkaListener.GetMessageHandled(messageInt));
            Assert.Equal(10.4d.ToString(), KafkaListener.GetMessageHandled(messageDecimal));
            Assert.Equal(messageDateTime.ToString(), KafkaListener.GetMessageHandled(messageDateTime));
            Assert.NotEqual("Test Message", KafkaListener.GetMessageHandled(messageString));
        }

        [Fact]
        public void Get_Message_Handled_Whitout_No_Simple_Type()
        {
            //Arrange
            var message = new TestClass1 { Nome = "Robin"};
            var expected = "{\"Nome\":\"Robin\"}";
            //Action
            var result = KafkaListener.GetMessageHandled(message);

            Assert.Equal(expected, result);
            Assert.NotEqual("{\"Nome\": \"Robin\"}", result);
        }
    }
}
