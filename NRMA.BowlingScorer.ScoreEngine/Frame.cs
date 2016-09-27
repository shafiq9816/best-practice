using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NRMA.BowlingScorer.Core
{
    public class Frame
    {
        public int FirstRoll { get; set; }

        public int SecondRoll { get; set; }

        public bool IsStrike { get{return FirstRoll==10;}  }

        public bool IsSpare { get{ return FirstRoll+SecondRoll==10 && !IsStrike;}  }

        public int Score { get; set; }
    }
}
