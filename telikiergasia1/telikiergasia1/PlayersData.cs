using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace telikiergasia1
{
    public class PlayersData
    {
        public String PName { get; set; }
        public String PTries { get; set; }

        public PlayersData AddPName(String PName)
        {
            this.PName = PName;
            return this;
        }
        public PlayersData AddPTries(String PTries)
        {
            this.PTries = PTries;
            return this;
        }
        public void AddTrie(String Trie)
        {
            this.PTries += Trie;
            
        }
    }
}
