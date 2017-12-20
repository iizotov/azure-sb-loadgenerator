using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;


namespace LoadGenerator
{
    class CommandLineOptionsClass
    {
        [Option('t', "threads", Required = true,
            HelpText = "Threads to spawn.", DefaultValue = 5)]
        public int Threads{ get; set; }

        [Option('s', "size", Required = true,
            HelpText = "JSON Payload size, real size in bytes = 35 + size", DefaultValue = 1024)]
        public int MessageSize { get; set; }

        [Option('m', "messagestosend", Required = true,
            HelpText = "Messages to send in each thread before termination, 0 for infinity", DefaultValue = 100)]
        public int MessagesToSend { get; set; }

        [Option('c', "connectionstring", Required = true,
            HelpText = "Event Hub or Service Bus Namespace connection String")]
        public string ConnectionString { get; set; }

        [Option("name", Required = false,
            HelpText = "Event Hub or Queue or Topic Name")]
        public string EHOrQueueOrTopicName { get; set; }

        [Option("checkpoint", Required = false,
            HelpText = "Checkpoint - log to console every N messages", DefaultValue = 100)]
        public int Checkpoint { get; set; }

        [Option('b', "batchmode", Required = false,
            HelpText = "Checkpoint - log to console every N messages", DefaultValue = true)]
        public bool BatchMode { get; set; }

        [Option("batchsize", Required = false,
            HelpText = "Checkpoint - log to console every N messages", DefaultValue = 100)]
        public int BatchSize { get; set; }
    }
}
