using System.Collections.Generic;
using System.Linq;
using System.Messaging;

namespace MyQs.Core.Extensions
{
    public static class MessageQueueExtensions
    {
        static readonly MessagePropertyFilter CountFilter = new MessagePropertyFilter
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

        static readonly MessagePropertyFilter NameFilter = new MessagePropertyFilter
        {
            AdministrationQueue = false,
            ArrivedTime = false,
            CorrelationId = false,
            Priority = false,
            ResponseQueue = false,
            SentTime = false,
            Body = false,
            Label = true,
            Id = true
        };

        public static int CountMessages(this MessageQueue queue)
        {
            queue.MessageReadPropertyFilter = CountFilter;
            return queue.GetAllMessages().Length;
        }

        public static IEnumerable<string> ListMessageNames(this MessageQueue queue)
        {
            if (queue == null) return new List<string>();
            queue.MessageReadPropertyFilter = NameFilter;
            return queue.GetAllMessages().Select(x => string.Format("{0}: {1}", x.Id, x.Label));
        }
    }
}