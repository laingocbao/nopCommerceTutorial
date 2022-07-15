using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Plugin.Tutorial.DistOfCustByCountry.Models;

namespace Nop.Plugin.Tutorial.DistOfCustByCountry.Services
{
    public interface ICustomersByCountry
    {
        Task<List<CustomersDistribution>> GetCustomersDistributionByCountryAsync();
    }
}

