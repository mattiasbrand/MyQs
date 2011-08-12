using System.Messaging;

namespace MyQs.Core.Extensions
{
    public static class MessageQueueExtensions
    {
        static readonly MessagePropertyFilter CountFilter;
        static MessageQueueExtensions()
        {
            CountFilter = new MessagePropertyFilter
                              {
                                  AdministrationQueue = false,
                                  ArrivedTime = false,
                                  CorrelationId = false,
                                  Priority = false,
                                  ResponseQueue = false,
                                  SentTime = false,
                                  Body = false,
                                  Label = false,
                                  Id = false
                              };
        }

        public static int CountMessages(this MessageQueue queue)
        {
            queue.MessageReadPropertyFilter = CountFilter;
            return queue.GetAllMessages().Length;
        }
    }
}