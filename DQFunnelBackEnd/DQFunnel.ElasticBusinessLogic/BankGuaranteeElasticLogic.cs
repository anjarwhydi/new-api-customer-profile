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
    public class BankGuaranteeElasticLogic : IBankGuaranteeElasticLogic
    {
        private IBankGuaranteeElasticRepository objRepo;

        public BankGuaranteeElasticLogic(string ES_URI)
        {
            objRepo = new BankGuaranteeElasticRepository(IndexNameConst.SALES_BANK_GUARANTEE, ES_URI);
        }
        public List<SalesBankGuaranteeElastic> GetAll()
        {
            return objRepo.QueryAll();
        }

        public SalesBankGuaranteeElastic GetbyBGID(long bgID)
        {
            return objRepo.GetByBGID(bgID);
        }

        public SalesBankGuaranteeElastic GetbyFunnelGenID(long funnelGenID)
        {
            return objRepo.GetByFunnelGenID(funnelGenID);
        }
    }
}
