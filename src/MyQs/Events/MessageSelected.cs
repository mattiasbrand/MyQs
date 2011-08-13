using System;
using System.Messaging;

namespace MyQs.Wpf.Events
{
    public class MessageSelected
    {
        public MessageQueue Queue { get; set; }
        public string Id { get; set; }

        public MessageSelected(MessageQueue queue, string id)
        {
            Queue = queue;
            Id = id;
        }
    }
}