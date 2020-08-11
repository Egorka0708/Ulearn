using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Tickets
{
    public static class TicketsTask
    {
        public static BigInteger Solve(int totalLen, int totalSum)
        {
            if (totalSum % 2 == 1)
                return new BigInteger(0);
            var halfSum = totalSum / 2;
            var opt = new BigInteger[totalLen + 1, halfSum + 1];
            for (var i = 0; i <= halfSum; i++)
                opt[0, i] = 0;
            for (var i = 1; i <= totalLen; i++)
                opt[i, 0] = 1;
            for (var i = 1; i <= totalLen; i++)
                for (var j = 1; j <= halfSum; j++)
                    if (j > i * 9) opt[i, j] = 0;
                    else
                    {
                        opt[i, j] = opt[i - 1, j] + opt[i, j - 1];
                        if (j > 9)
                            opt[i, j] -= opt[i - 1, j - 10];
                    }
            return opt[totalLen, halfSum] * opt[totalLen, halfSum];
        }
    }
}
