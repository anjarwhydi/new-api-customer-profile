using System;
using System.Collections.Generic;
using System.Text;
using DQFunnel.BusinessLogic.Interfaces;
using DQFunnel.BusinessLogic.Services;
using DQFunnel.BusinessObject;
using DQFunnel.DataAccess;
using DQFunnel.DataAccess.Interfaces;

namespace DQFunnel.BusinessLogic
{
    public class SalesAssignmentLogic : ISalesAssignmentLogic
    {
        private DapperContext _context;
        private IGenericAPI genericAPI;
        public SalesAssignmentLogic(string connectionstring, string apiGateway)
        {
            this._context = new DapperContext(connectionstring);
            genericAPI = new GenericAPI(apiGateway);
        }

        private ResultAction MessageResult(bool bSuccess, string message)
        {
            return MessageResult(bSuccess, message, null);
        }

        private ResultAction MessageResult(bool bSuccess, string message, object objResult)
        {
            ResultAction result = new ResultAction()
            {
                bSuccess = bSuccess,
                ErrorNumber = (bSuccess ? "0" : "666"),
                Message = message,
                ResultObj = objResult
            };

            return result;

        }
        public ResultAction GetSalesData()
        {
            ResultAction result = new ResultAction();
            try
            {
                using (_context)
                {
                    IUnitOfWork uow = new UnitOfWork(_context);
                    var existing = uow.SalesAssignmentRepository.GetListSales();
                    result = MessageResult(true, "Success", existing);
                }
            }
            catch (Exception ex)
            {
                result = MessageResult(false, ex.Message);
            }
            return result;
        }

        public ResultAction Insert(CpSalesAssignment objEntity)
        {
            ResultAction result = new ResultAction();
            try
            {
                using (_context)
                {
                    IUnitOfWork uow = new UnitOfWork(_context);
                    objEntity.RequstedDate = DateTime.Now;
                    uow.SalesAssignmentRepository.Add(objEntity);
                    result = MessageResult(true, "Success");
                }
            }
            catch (Exception ex)
            {
                result = MessageResult(false, ex.Message);
            }
            return result;
        }

        public ResultAction Update(long id, CpSalesAssignment objEntity)
        {
            ResultAction result = new ResultAction();
            try
            {
                using (_context)
                {
                    IUnitOfWork uow = new UnitOfWork(_context);
                    var existing = uow.SalesAssignmentRepository.GetSalesAssignmentById(id);
                    if (existing == null)
                    {
                        return result = MessageResult(false, "Data not found");
                    }
                    existing.CustomerID = objEntity.CustomerID;
                    existing.SalesID = objEntity.SalesID;
                    existing.RequstedBy = objEntity.RequstedBy;
                    existing.ModifyUserID = objEntity.ModifyUserID;
                    existing.ModifyDate = DateTime.Now;
                    uow.SalesAssignmentRepository.Update(existing);
                    result = MessageResult(true, "Success");
                }
            }
            catch (Exception ex)
            {
                result = MessageResult(false, ex.Message);
            }
            return result;
        }

        public ResultAction Delete(long id)
        {
            ResultAction result = new ResultAction();
            try
            {
                IUnitOfWork uow = new UnitOfWork(_context);
                var existing = uow.SalesAssignmentRepository.GetSalesAssignmentById(id);
                if (existing == null)
                {
                    return result = MessageResult(false, "Data not found");
                }
                uow.SalesAssignmentRepository.Delete(existing);
            }
            catch (Exception ex)
            {
                result = MessageResult(false, ex.Message);
            }
            return result;
        }
    }
}
