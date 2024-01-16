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
    public class InvoicingScheduleController : ControllerBase
    {
        private IInvoicingScheduleLogic objInvoicingScheduleLogic;
        public InvoicingScheduleController(IOptions<DatabaseConfiguration> appSettings, IOptions<ApiGatewayConfig> apiGateway)
        {
            string apiGatewayURL = string.Format("{0}:{1}", apiGateway.Value.IP, apiGateway.Value.Port);
            objInvoicingScheduleLogic = new InvoicingScheduleLogic(appSettings.Value.OMSProd, apiGatewayURL);
        }
        [HttpGet("InvoicingSchedule")]
        public IActionResult GetInvoicingSchedule()
        {
            try
            {
                var result = objInvoicingScheduleLogic.GetInvoicingSchedule();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("InvoicingSchedule")]
        public IActionResult InsertInvoicingSchedule(CpInvoicingSchedule objEntity)
        {
            try
            {
                var result = objInvoicingScheduleLogic.InsertInvoicingSchedule(objEntity);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("InvoicingSchedule/{InvoicingScheduleID}")]
        public IActionResult UpdateInvoicingSchedule(long InvoicingScheduleID, CpInvoicingSchedule objEntity)
        {
            try
            {
                var result = objInvoicingScheduleLogic.UpdateInvoicingSchedule(InvoicingScheduleID, objEntity);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("InvoicingSchedule/{InvoicingScheduleID}")]
        public IActionResult DeleteInvoicingSchedule(long InvoicingScheduleID)
        {
            try
            {
                var result = objInvoicingScheduleLogic.DeleteInvoicingSchedule(InvoicingScheduleID);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
