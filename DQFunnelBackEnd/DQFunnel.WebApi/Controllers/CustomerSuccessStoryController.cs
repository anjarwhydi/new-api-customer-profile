using System;
using DQFunnel.BusinessLogic;
using DQFunnel.BusinessLogic.Interfaces;
using DQFunnel.BusinessObject;
using DQFunnel.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DQFunnel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerSuccessStoryController : ControllerBase
    {
        private ICustomerSuccessStoryLogic objCustomerSuccessStoryLogic;

        public CustomerSuccessStoryController(IOptions<DatabaseConfiguration> appSettings, IOptions<ApiGatewayConfig> apiGateway)
        {
            string apiGatewayURL = string.Format("{0}:{1}", apiGateway.Value.IP, apiGateway.Value.Port);
            objCustomerSuccessStoryLogic = new CustomerSuccessStoryLogic(appSettings.Value.OMSProd, apiGatewayURL);
        }

        [HttpPost]
        public IActionResult Insert(CpCustomerSuccessStory objEntity)
        {
            try
            {
                var result = objCustomerSuccessStoryLogic.Insert(objEntity);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
