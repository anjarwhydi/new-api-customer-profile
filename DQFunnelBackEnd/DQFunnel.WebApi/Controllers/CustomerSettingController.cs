using DQFunnel.BusinessLogic.Interfaces;
using DQFunnel.BusinessLogic;
using DQFunnel.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using DQFunnel.BusinessObject;
using DQFunnel.BusinessObject.ViewModel;
using DQFunnel.DataAccess.Interfaces;

namespace DQFunnel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerSettingController : ControllerBase
    {
        private ICustomerSettingLogic objCustomerSettingLogic;
        private ISalesAssignmentLogic objSalesAssignmentLogic;

        public CustomerSettingController(IOptions<DatabaseConfiguration> appSettings, IOptions<ApiGatewayConfig> apiGateway)
        {
            string apiGatewayURL = string.Format("{0}:{1}", apiGateway.Value.IP, apiGateway.Value.Port);
            objCustomerSettingLogic = new CustomerSettingLogic(appSettings.Value.OMSProd, apiGatewayURL);
            objSalesAssignmentLogic = new SalesAssignmentLogic(appSettings.Value.OMSProd, apiGatewayURL);
        }

        [HttpPost]
        public IActionResult Insert(CpCustomerSetting objEntity)
        {
            try
            {
                var result = objCustomerSettingLogic.Insert(objEntity);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = objCustomerSettingLogic.GetAllCustomerSetting();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{customerID}")]
        public IActionResult GetCustomerSettingBySalesID(long customerID, long SalesID)
        {
            try
            {
                var result = objCustomerSettingLogic.GetCustomerSettingBySalesID(customerID, SalesID);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetCustomerSettingNoNamedAccount")]
        public IActionResult GetCustomerSettingNoNamedAccount(int page, int pageSize, string column, string sorting, string search, bool? pmoCustomer = null, bool? blacklist = null, bool? holdshipment = null)
        {
            try
            {
                var result = objCustomerSettingLogic.GetCustomerSettingNoNamedAccount(page, pageSize, column, sorting, search, pmoCustomer, blacklist, holdshipment);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetCustomerSettingNamedAccount")]
        public IActionResult GetCustomerSettingNamedAccount(int page, int pageSize, string column, string sorting, string search, long? salesID, bool? pmoCustomer = null, bool? blacklist = null, bool? holdshipment = null)
        {
            try
            {
                var result = objCustomerSettingLogic.GetCustomerSettingNamedAccount(page, pageSize, column, sorting, search, salesID, pmoCustomer, blacklist, holdshipment);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetCustomerSettingSharebleAccount")]
        public IActionResult GetCustomerSettingSharebleAccount(int page, int pageSize, string column, string sorting, string search, long? salesID, bool? pmoCustomer = null, bool? blacklist = null, bool? holdshipment = null)
        {
            try
            {
                var result = objCustomerSettingLogic.GetCustomerSettingSharebleAccount(page, pageSize, column, sorting, search, salesID, pmoCustomer, blacklist, holdshipment);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetCustomerSettingAllAccount")]
        public IActionResult GetCustomerSettingAllAccount(int page, int pageSize, string column, string sorting, string search, long? salesID, bool? pmoCustomer = null, bool? blacklist = null, bool? holdshipment = null)
        {
            try
            {
                var result = objCustomerSettingLogic.GetCustomerSettingAllAccount(page, pageSize, column, sorting, search, salesID, pmoCustomer, blacklist, holdshipment);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{customerID}")]
        public IActionResult Update(long customerID, CpCustomerSetting objEntity)
        {
            try
            {
                var result = objCustomerSettingLogic.Update(customerID, objEntity);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{ReleaseAccount}")]
        public IActionResult ReleaseAccount(long customerID, long salesID, int? modifyUserID)
        {
            try
            {
                var result = objCustomerSettingLogic.ReleaseAccount(customerID, salesID, modifyUserID);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{customerID}")]
        public IActionResult Delete(long customerID, long salesID, int ModifyUserID)
        {
            try
            {
                var result = objCustomerSettingLogic.Delete(customerID, salesID, ModifyUserID);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetSalesData")]
        public IActionResult GetSalesData()
        {
            try
            {
                var result = objSalesAssignmentLogic.GetSalesData();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetCustomerPICByCustomerID")]
        public IActionResult GetCustomerPICByCustomerID(long customerID)
        {
            try
            {
                var result = objCustomerSettingLogic.GetCustomerPICByCustomerID(customerID);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetBrandSummary")]
        public IActionResult GetBrandSummary(long customerID)
        {
            try
            {
                var result = objCustomerSettingLogic.GetBrandSummary(customerID);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetServiceSummary")]
        public IActionResult GetServiceSummary(long customerID)
        {
            try
            {
                var result = objCustomerSettingLogic.GetServiceSummary(customerID);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetCustomerData")]
        public IActionResult GetCustomerData(long customerID)
        {
            try
            {
                var result = objCustomerSettingLogic.GetCustomerDataByID(customerID);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetProjectHistory")]
        public IActionResult GetProjectHistory(long customerID)
        {
            try
            {
                var result = objCustomerSettingLogic.GetProjectHistory(customerID);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("SalesAssignment")]
        public IActionResult GetSalesAssignment()
        {
            try
            {
                var result = objSalesAssignmentLogic.GetSalesAssignment();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("SalesAssignment")]
        public IActionResult InsertSalesAssignment(CpSalesAssignment objEntity)
        {
            try
            {
                var result = objSalesAssignmentLogic.InsertSalesAssignment(objEntity);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("SalesAssignment/{SAssignmentID}")]
        public IActionResult UpdateSalesAssignment(long SAssignmentID, CpSalesAssignment objEntity)
        {
            try
            {
                var result = objSalesAssignmentLogic.UpdateSalesAssignment(SAssignmentID, objEntity);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("SalesAssignment/{SAssignmentID}")]
        public IActionResult DeleteSalesAssignment(long SAssignmentID)
        {
            try
            {
                var result = objSalesAssignmentLogic.DeleteSalesAssignment(SAssignmentID);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
