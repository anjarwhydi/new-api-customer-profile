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
    public class RelatedCustomerController : ControllerBase
    {
        private IRelatedCustomerLogic objRelatedCustomerLogic;
        public RelatedCustomerController(IOptions<DatabaseConfiguration> appSettings, IOptions<ApiGatewayConfig> apiGateway)
        {
            string apiGatewayURL = string.Format("{0}:{1}", apiGateway.Value.IP, apiGateway.Value.Port);
            objRelatedCustomerLogic = new RelatedCustomerLogic(appSettings.Value.OMSProd, apiGatewayURL);
        }
        [HttpGet("RelatedCustomer")]
        public IActionResult GetRelatedCustomer()
        {
            try
            {
                var result = objRelatedCustomerLogic.GetRelatedCustomer();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("RelatedCustomer")]
        public IActionResult InsertRelatedCustomer(CpRelatedCustomer objEntity)
        {
            try
            {
                var result = objRelatedCustomerLogic.InsertRelatedCustomer(objEntity);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("RelatedCustomer/{RelatedCustomerID}")]
        public IActionResult UpdateRelatedCustomer(long RelatedCustomerID, CpRelatedCustomer objEntity)
        {
            try
            {
                var result = objRelatedCustomerLogic.UpdateRelatedCustomer(RelatedCustomerID, objEntity);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("RelatedCustomer/{RelatedCustomerID}")]
        public IActionResult DeleteRelatedCustomer(long RelatedCustomerID)
        {
            try
            {
                var result = objRelatedCustomerLogic.DeleteRelatedCustomer(RelatedCustomerID);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
