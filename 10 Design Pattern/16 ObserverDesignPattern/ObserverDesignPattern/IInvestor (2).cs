using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverDesignPattern
{
    public interface IInvestor
    {
        void Update(Stock stock);
    }
}
