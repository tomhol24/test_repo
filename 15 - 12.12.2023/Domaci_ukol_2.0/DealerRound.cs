using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaci_ukol_2._0
{
    internal class DealerRound
    {
        public int dealerHand;
        public string name;
        public DealerRound(string name) 
        { 
            this.name = name;
            dealerHand = 0;
        }
    }
}
