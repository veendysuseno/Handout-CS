using System;
using System.Collections.Generic;
using System.Text;

namespace SingletonDesignPattern
{
    public class LoadBalancer
    {
        private static readonly LoadBalancer _instance = new LoadBalancer();
        public List<Server> Servers { get; }

        private LoadBalancer() {
            this.Servers = new List<Server>{
                new Server{ Name = "ServerI", Ip = "120.14.220.18" },
                new Server{ Name = "ServerII", Ip = "120.14.220.19" },
                new Server{ Name = "ServerIII", Ip = "120.14.220.20" },
                new Server{ Name = "ServerIV", Ip = "120.14.220.21" },
                new Server{ Name = "ServerV", Ip = "120.14.220.22" },
            };
        }

        public static LoadBalancer GetLoadBalancer() {
            return _instance;
        }

        public Server NextServer() {
            Random _random = new Random();
            int random = _random.Next(this.Servers.Count);
            return this.Servers[random];
        }
    }
}
