using DQFunnel.BusinessLogic.Interfaces;
using DQFunnel.BusinessLogic;
using DQFunnel.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;

namespace DQFunnel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerSettingController : ControllerBase
    {
        private ICustomerSettingLogic objLogic;

        public CustomerSettingController(IOptions<DatabaseConfiguration> appSettings, IOptions<ApiGatewayConfig> apiGateway)
        {
            string apiGatewayURL = string.Format("{0}:{1}", apiGateway.Value.IP, apiGateway.Value.Port);
            objLogic = new CustomerSettingLogic(appSettings.Value.OMSProd, apiGatewayURL);
        }

        [HttpGet("GetCustomerSettingNoNamedAccount")]
        public IActionResult GetCustomerSettingNoNamedAccount(int page, int pageSize, string column, string sorting, string search, bool? pmoCustomer = null, bool? blacklist = null, bool? holdshipment = null)
        {
            try
            {
                var result = objLogic.GetCustomerSettingNoNamedAccount(page, pageSize, column, sorting, search, pmoCustomer, blacklist, holdshipment);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetCustomerSettingNamedAccount")]
        public IActionResult GetCustomerSettingNamedAccount(int page, int pageSize, string column, string sorting, string search, string salesName, bool? pmoCustomer = null, bool? blacklist = null, bool? holdshipment = null)
        {
            try
            {
                var result = objLogic.GetCustomerSettingNamedAccount(page, pageSize, column, sorting, search, salesName, pmoCustomer, blacklist, holdshipment);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
