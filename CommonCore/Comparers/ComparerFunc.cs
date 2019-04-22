using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonCore.Comparers
{
    public class ComparerFunc<T> : IComparer<T>
    {
        private Func<T, T, bool> _func;

        public ComparerFunc(Func<T, T, bool> func)
        {
            _func = func;
        }

        public int Compare(T x, T y)
        {
            return _func(x, y) ? 1 : 0;
        }
    }
}
