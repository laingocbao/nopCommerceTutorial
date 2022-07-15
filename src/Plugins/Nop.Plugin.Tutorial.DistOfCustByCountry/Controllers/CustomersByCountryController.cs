using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.Tutorial.DistOfCustByCountry.Models;
using Nop.Plugin.Tutorial.DistOfCustByCountry.Services;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Models.DataTables;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugin.Tutorial.DistOfCustByCountry.Controllers;

[AutoValidateAntiforgeryToken]
[AuthorizeAdmin] //confirms access to the admin panel
[Area(AreaNames.Admin)] //specifies the area containing a controller or action
public class DistOfCustByCountryPluginController : BasePluginController
{
    private readonly ICustomersByCountry _service;
    public DistOfCustByCountryPluginController(ICustomersByCountry service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Configure()
    {
        CustomersByCountrySearchModel customerSearchModel = new CustomersByCountrySearchModel
        {
            AvailablePageSizes = "10"
        };
        return View("~/Plugins/Tutorial.DistOfCustByCountry/Views/Configure.cshtml", customerSearchModel);
    }

    [HttpPost]
    public async Task<IActionResult> GetCustomersCountByCountry()
    {
        try
        {
            return Ok(new DataTablesModel { Data = await _service.GetCustomersDistributionByCountryAsync() });
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }
}