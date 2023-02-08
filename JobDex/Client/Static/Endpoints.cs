using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobDex.Client.Static
{
    public static class Endpoints
    {
        private static readonly string Prefix = "api";

        public static readonly string UserDetailsEndpoint = $"{Prefix}/userdetails";
        public static readonly string JobEndpoint = $"{Prefix}/jobs";

    }
}
