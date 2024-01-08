using DQFunnel.BusinessObject;
using DQFunnel.ElasticBusinessLogic.Interfaces;
using DQFunnel.ElasticBusinessObject;
using DQFunnel.ElasticBusinessObject.Common;
using DQFunnel.ElasticDataAccess;
using DQFunnel.ElasticDataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.ElasticBusinessLogic
{
    public class FunnelViewEditElasticLogic : IFunnelViewEditElasticLogic
    {
        private IUnitOfWork uow;
        private string uri;

        public FunnelViewEditElasticLogic(string ES_URI)
        {
            uri = ES_URI;
        }

        public IEnumerable<SalesFunnelEditFunnelAdditionalElastic> GetViewFunnelAdditionalByFunnelGenID(long funnelGenId)
        {
            uow = new UnitOfWork(IndexNameConst.SALES_FUNNEL, uri);
            return uow.SalesFunnelEditFunnelAdditionalElasticRepository.GetViewFunnelAdditional(funnelGenId);
        }

        public IEnumerable<SalesFunnelEditCustomerElastic> GetViewFunnelCustomerByFunnelGenID(long funnelGenId)
        {
            uow = new UnitOfWork(IndexNameConst.SALES_FUNNEL, uri);
            return uow.SalesFunnelEditCustomerElasticRepository.GetViewFunnelCustomerByFunnelGenID(funnelGenId);
        }

        public IEnumerable<SalesFunnelEditPOElastic> GetViewFunnelPOByFunnelGenID(long funnelGenId)
        {
            uow = new UnitOfWork(IndexNameConst.SALES_FUNNEL, uri);
            return uow.SalesFunnelEditPOElasticRepository.GetViewFunnelPOByFunnelGenID(funnelGenId);
        }

        public IEnumerable<SalesFunnelEditSellingElastic> GetViewFunnelSellingByFunnelGenID(long funnelGenId)
        {
            uow = new UnitOfWork(IndexNameConst.SALES_FUNNEL, uri);
            return uow.SalesFunnelEditFunnelSellingElasticRepository.GetViewFunnelSelling(funnelGenId);
        }

        public IEnumerable<SalesFunnelEditStatusElastic> GetViewFunnelStatusByFunnelGenID(long funnelGenId)
        {
            uow = new UnitOfWork(IndexNameConst.SALES_FUNNEL, uri);
            return uow.SalesFunnelEditStatusElasticRepository.GetViewFunnelStatusByFunnelGenID(funnelGenId);
        }

        public ResultAction UpdateCustomer(SalesFunnelEditCustomerElastic objEntity)
        {
            ResultAction result = new ResultAction();
            try
            {
                uow = new UnitOfWork(IndexNameConst.SALES_FUNNEL, uri);
                uow.SalesFunnelEditCustomerElasticRepository.UpdateCustomer(objEntity);

                result = MessageResult(true, "Update Success!");
            }
            catch (Exception ex)
            {
                result = MessageResult(false, ex.Message);
            }

            return result;
        }

        public ResultAction UpdateFunnelAdditional(SalesFunnelEditFunnelAdditionalElastic objEntity)
        {
            ResultAction result = new ResultAction();
            try
            {
                uow = new UnitOfWork(IndexNameConst.SALES_FUNNEL, uri);
                uow.SalesFunnelEditFunnelAdditionalElasticRepository.UpdateFunnelAdditional(objEntity);

                result = MessageResult(true, "Update Success!");
            }
            catch(Exception ex)
            {
                result = MessageResult(false, ex.Message);
            }

            return result;
        }

        public ResultAction UpdateFunnelPO(SalesFunnelEditPOElastic objEntity)
        {
            ResultAction result = new ResultAction();
            try
            {
                uow = new UnitOfWork(IndexNameConst.SALES_FUNNEL, uri);
                uow.SalesFunnelEditPOElasticRepository.UpdateFunnelPO(objEntity);

                result = MessageResult(true, "Update Success!");
            }
            catch (Exception ex)
            {
                result = MessageResult(false, ex.Message);
            }

            return result;
        }

        public ResultAction UpdateFunnelSelling(SalesFunnelEditSellingElastic objEntity)
        {
            ResultAction result = new ResultAction();
            try
            {
                uow = new UnitOfWork(IndexNameConst.SALES_FUNNEL, uri);
                uow.SalesFunnelEditFunnelSellingElasticRepository.UpdateFunnelSelling(objEntity);

                result = MessageResult(true, "Update Success!");
            }
            catch (Exception ex)
            {
                result = MessageResult(false, ex.Message);
            }

            return result;
        }

        public ResultAction UpdateProductService(SalesFunnelEditProductServiceElastic objEntity)
        {
            ResultAction result = new ResultAction();
            try
            {
                uow = new UnitOfWork(IndexNameConst.SALES_FUNNEL, uri);
                uow.SalesFunnelEditProductServiceElasticRepository.UpdateProductService(objEntity);

                uow = new UnitOfWork(IndexNameConst.SALES_FUNNEL_ITEMS, uri);
                SalesFunnelItemsElastic salesFunnelItems = MappingUpdateFunnelItem(objEntity);
                //uow.FunnelItemsElasticRepository.UpdateFunnelItems(salesFunnelItems);

                result = MessageResult(true, "Update Success!");
            }
            catch(Exception ex)
            {
                result = MessageResult(false, ex.Message);
            }
            return result;
        }

        private SalesFunnelItemsElastic MappingUpdateFunnelItem(SalesFunnelEditProductServiceElastic objEntity)
        {
            SalesFunnelItemsElastic result = new SalesFunnelItemsElastic()
            {
                FunnelGenID = objEntity.FunnelGenID,
                FunnelItemsID = objEntity.FunnelItemsID,
                ItemDescription = objEntity.ItemDescription,
                ItemID = objEntity.ItemID,
                ItemName = objEntity.ItemName,
                ItemSubName = objEntity.ItemSubName,
                ItemType = objEntity.ItemType,
                OrderingPrice = objEntity.OrderingPrice,
                SellingPrice = objEntity.SellingPrice,
                ModifyDate = objEntity.ModifyDate,
                ModifyUserID = objEntity.ModifyUserID
            };
            return result;
        }

        public ResultAction UpdateStatus(SalesFunnelEditStatusElastic objEntity)
        {
            ResultAction result = new ResultAction();
            try
            {
                uow = new UnitOfWork(IndexNameConst.SALES_FUNNEL, uri);
                uow.SalesFunnelEditStatusElasticRepository.UpdateStatus(objEntity);

                result = MessageResult(true, "Update Success!");
            }
            catch (Exception ex)
            {
                result = MessageResult(false, ex.Message);
            }

            return result;
        }

        private ResultAction MessageResult(bool bSuccess, string message)
        {
            ResultAction result = new ResultAction()
            {
                bSuccess = bSuccess,
                ErrorNumber = (bSuccess ? "0" : "666"),
                Message = message
            };

            return result;
        }
    }
}
