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
    public class RelatedFileController : ControllerBase
    {
        private IRelatedFileLogic objRelatedFileLogic;
        public RelatedFileController(IOptions<DatabaseConfiguration> appSettings, IOptions<ApiGatewayConfig> apiGateway)
        {
            string apiGatewayURL = string.Format("{0}:{1}", apiGateway.Value.IP, apiGateway.Value.Port);
            objRelatedFileLogic = new RelatedFileLogic(appSettings.Value.OMSProd, apiGatewayURL);
        }
        [HttpGet("RelatedFile")]
        public IActionResult GetRelatedFile()
        {
            try
            {
                var result = objRelatedFileLogic.GetRelatedFile();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("RelatedFile")]
        public IActionResult InsertRelatedFile(CpRelatedFile objEntity)
        {
            try
            {
                var result = objRelatedFileLogic.InsertRelatedFile(objEntity);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("RelatedFile/{RelatedFileID}")]
        public IActionResult UpdateRelatedFile(long RelatedFileID, CpRelatedFile objEntity)
        {
            try
            {
                var result = objRelatedFileLogic.UpdateRelatedFile(RelatedFileID, objEntity);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("RelatedFile/{RelatedFileID}")]
        public IActionResult DeleteRelatedFile(long RelatedFileID)
        {
            try
            {
                var result = objRelatedFileLogic.DeleteRelatedFile(RelatedFileID);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
