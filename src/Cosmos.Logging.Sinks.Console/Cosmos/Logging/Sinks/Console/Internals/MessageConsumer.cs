using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace Cosmos.Logging.Sinks.Console.Internals {
    internal class MessageConsumer : IDisposable {
        /// <summary>
        /// Max count of queue messages
        /// </summary>
        private const int MaxQueuedMessages = 1024;

        /// <summary>
        /// Message wrapper queue
        /// </summary>
        private readonly BlockingCollection<MessageWrapper> _messageQueue = new BlockingCollection<MessageWrapper>(MaxQueuedMessages);

        /// <summary>
        /// Output async
        /// </summary>
        private readonly Task _outputTask;

        /// <summary>
        /// Console implementation
        /// </summary>
        private readonly IConsole _console;

        /// <summary>
        /// Create a new instance of <see cref="MessageConsumer"/>.
        /// </summary>
        /// <param name="console">Console</param>
        public MessageConsumer(IConsole console) {
            _outputTask = Task.Factory.StartNew(ProcessQueue, this, TaskCreationOptions.LongRunning);
            _console = console;
        }

        internal virtual void EnqueueMessage(MessageWrapper wrapper) {
            if (!_messageQueue.IsAddingCompleted) {
                try {
                    _messageQueue.Add(wrapper);
                    return;
                }
                catch (InvalidOperationException) { }
            }

            WriteMessage(wrapper);
        }

        internal virtual void WriteMessage(MessageWrapper wrapper) {
            _console.WriteLine(wrapper.RenderedMessage, wrapper.BackgroundColour, wrapper.ForegroundColour);
            _console.Flush();
        }

        private void ProcessQueue() {
            foreach (var messageWrapper in _messageQueue.GetConsumingEnumerable())
                WriteMessage(messageWrapper);
        }

        private static void ProcessQueue(object state) {
            var consumer = (MessageConsumer) state;
            consumer.ProcessQueue();
        }

        public void Dispose() {
            _messageQueue.CompleteAdding();

            try {
                _outputTask.Wait(1500);
            }
            catch {
                // ignored
            }
        }
    }
}