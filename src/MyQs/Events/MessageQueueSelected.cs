using System.Messaging;

namespace MyQs.Wpf.Events
{
    public class MessageQueueSelected
    {
        public MessageQueue MessageQueue { get; set; }

        public MessageQueueSelected(MessageQueue messageQueue)
        {
            MessageQueue = messageQueue;
        }
    }
}