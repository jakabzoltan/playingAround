using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Alchemy;
using Alchemy.Classes;
using System.Collections.Concurrent;

namespace ConsoleApplication1
{
    class Program
    {
        protected static ConcurrentDictionary<User, string> OnlineUsers = new ConcurrentDictionary<User, string>();
        public enum userCommands
        {
            CHAT = 0,
            GENERAL_COMMAND = 1
        }
        /// <summary>
        /// Holds the name and context instance for an online user
        /// </summary>
        public class User
        {
            public string Name = String.Empty;
            public UserContext Context { get; set; }
        }
        /// <summary>
        /// Enumaration for state of the server
        /// </summary>
        public enum ServerState
        {
            STOPPED = 0,
            STARTING = 1,
            RUNNING = 2,
            STOPPING = 3
        }
        /// <summary>
        /// Various Response types from the server
        /// </summary>
        public enum ResponseTypes
        {
            SUCCESS = 1,
            WARN = 2,
            ERROR = 3,
            NOT_FOUND = 404
        }
        static void Main(string[] args)
        {
            var state = ServerState.STARTING;
            var server = new WebSocketServer(81, IPAddress.Any)
            {
                TimeOut=new TimeSpan(0,5,0)
            };
            state = ServerState.RUNNING;
            while (state != ServerState.STOPPING)
            {
                var command = Console.ReadLine();
                if (command == "exit")
                {
                    state = ServerState.STOPPING;
                } else if (command == "cls")
                {
                    Console.Clear();
                }
            }
            server.Stop();
            state = ServerState.STOPPED;
        }
    }
}
