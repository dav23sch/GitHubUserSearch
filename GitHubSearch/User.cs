using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHubSearch
{
    public class User
    {
        public string Login { get; set; }
        public int Id { get; set; }
        public long Score { get; set; }
        public string Url { get; set; }
        public string Type { get; set; }
        public string Html_Url { get; set; }
        public string Avatar_Url { get; set; }
        public bool Site_Admin { get; set; }
    }
}
