using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WheelsMarket.Services.Data
{
    public interface IAdService
    {
         Task<string> CreateAd();

    }
}
