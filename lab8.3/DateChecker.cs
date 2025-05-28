using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8._3
{
    class DateChecker
    {
        public Func<int, bool>
            IsProgrammersDay => day => day == 256;
    }
}
