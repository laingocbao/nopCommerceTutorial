using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nop.Plugin.Tutorial.DistOfCustByCountry.Models;
using Nop.Services.Common;
using Nop.Services.Customers;
using Nop.Services.Directory;

namespace Nop.Plugin.Tutorial.DistOfCustByCountry.Services
{
    public class CustomersByCountry : ICustomersByCountry
    {
        private readonly IAddressService _addressService;
        private readonly ICountryService _countryService;
        private readonly ICustomerService _customerService;

        public CustomersByCountry(IAddressService addressService, 
            ICountryService countryService,
            ICustomerService customerService)
        {
            _addressService = addressService;
            _countryService = countryService;
            _customerService = customerService;
        }

        public async Task<List<CustomersDistribution>> GetCustomersDistributionByCountryAsync()
        {
            var address = await Task.WhenAll((await _customerService.GetAllCustomersAsync())
                .Where(c => c.ShippingAddressId != null)
                .Select(async c => new
                {
                    (await (_countryService.GetCountryByAddressAsync(
                        await _addressService.GetAddressByIdAsync(c.ShippingAddressId ?? 0)))).Name,
                    c.Username
                }));
            return address.GroupBy(c => c.Name)
                .Select(cbc => new CustomersDistribution { Country = cbc.Key, NoOfCustomers = cbc.Count() }).ToList();

        }
    }
}

