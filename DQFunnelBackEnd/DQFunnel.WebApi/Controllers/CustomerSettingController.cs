﻿using DQFunnel.BusinessLogic.Interfaces;
using DQFunnel.BusinessLogic;
using DQFunnel.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using DQFunnel.BusinessObject;

namespace DQFunnel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerSettingController : ControllerBase
    {
        private ICustomerSettingLogic objCustomerSettingLogic;

        public CustomerSettingController(IOptions<DatabaseConfiguration> appSettings, IOptions<ApiGatewayConfig> apiGateway)
        {
            string apiGatewayURL = string.Format("{0}:{1}", apiGateway.Value.IP, apiGateway.Value.Port);
            objCustomerSettingLogic = new CustomerSettingLogic(appSettings.Value.OMSProd, apiGatewayURL);
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
        public IActionResult GetCustomerSettingNamedAccount(int page, int pageSize, string column, string sorting, string search, string salesName, bool? pmoCustomer = null, bool? blacklist = null, bool? holdshipment = null)
        {
            try
            {
                var result = objCustomerSettingLogic.GetCustomerSettingNamedAccount(page, pageSize, column, sorting, search, salesName, pmoCustomer, blacklist, holdshipment);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetCustomerSettingSharebleAccount")]
        public IActionResult GetCustomerSettingSharebleAccount(int page, int pageSize, string column, string sorting, string search, string salesName, bool? pmoCustomer = null, bool? blacklist = null, bool? holdshipment = null)
        {
            try
            {
                var result = objCustomerSettingLogic.GetCustomerSettingSharebleAccount(page, pageSize, column, sorting, search, salesName, pmoCustomer, blacklist, holdshipment);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
        [HttpPut("{customerSettingID}")]
        public IActionResult Update(long customerSettingID, CpCustomerSetting objEntity)
        {
            try
            {
                var result = objCustomerSettingLogic.Update(customerSettingID, objEntity);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{customerSettingID}")]
        public IActionResult Delete(long customerSettingID)
        {
            try
            {
                var result = objCustomerSettingLogic.Delete(customerSettingID);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
