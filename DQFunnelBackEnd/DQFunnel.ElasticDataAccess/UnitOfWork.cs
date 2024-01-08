using DQFunnel.ElasticDataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.ElasticDataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private string _indexName;
        private string _hostElastic;
        public UnitOfWork(string indexName, string hostElastic)
        {
            _indexName = indexName;
            _hostElastic = hostElastic;
        }

        private ISalesFunnelEditFunnelAdditionalElasticRepository salesFunnelEditFunnelAdditionalElasticRepository;
        public ISalesFunnelEditFunnelAdditionalElasticRepository SalesFunnelEditFunnelAdditionalElasticRepository => salesFunnelEditFunnelAdditionalElasticRepository ?? (salesFunnelEditFunnelAdditionalElasticRepository = new SalesFunnelEditFunnelAdditionalElasticRepository(_indexName, _hostElastic));

        private ISalesFunnelEditCustomerElasticRepository salesFunnelEditCustomerElasticRepository;
        public ISalesFunnelEditCustomerElasticRepository SalesFunnelEditCustomerElasticRepository => salesFunnelEditCustomerElasticRepository ?? (salesFunnelEditCustomerElasticRepository = new SalesFunnelEditCustomerElasticRepository(_indexName, _hostElastic));

        private ISalesFunnelEditFunnelSellingElasticRepository salesFunnelEditFunnelSellingElasticRepository;
        public ISalesFunnelEditFunnelSellingElasticRepository SalesFunnelEditFunnelSellingElasticRepository => salesFunnelEditFunnelSellingElasticRepository ?? (salesFunnelEditFunnelSellingElasticRepository = new SalesFunnelEditFunnelSellingElasticRepository(_indexName, _hostElastic));

        private ISalesFunnelEditPOElasticRepository salesFunnelEditPOElasticRepository;
        public ISalesFunnelEditPOElasticRepository SalesFunnelEditPOElasticRepository => salesFunnelEditPOElasticRepository ?? (salesFunnelEditPOElasticRepository = new SalesFunnelEditPOElasticRepository(_indexName, _hostElastic));

        private ISalesFunnelEditProductServiceElasticRepository salesFunnelEditProductServiceElasticRepository;
        public ISalesFunnelEditProductServiceElasticRepository SalesFunnelEditProductServiceElasticRepository => salesFunnelEditProductServiceElasticRepository ?? (salesFunnelEditProductServiceElasticRepository = new SalesFunnelEditProductServiceElasticRepository(_indexName, _hostElastic));
       
        private ISalesFunnelEditStatusElasticRepository salesFunnelEditStatusElasticRepository;
        public ISalesFunnelEditStatusElasticRepository SalesFunnelEditStatusElasticRepository => salesFunnelEditStatusElasticRepository ?? (salesFunnelEditStatusElasticRepository = new SalesFunnelEditStatusElasticRepository(_indexName, _hostElastic));

        private IBankGuaranteeElasticRepository bankGuaranteeElasticRepository;
        public IBankGuaranteeElasticRepository BankGuaranteeElasticRepository => bankGuaranteeElasticRepository ?? (bankGuaranteeElasticRepository = new BankGuaranteeElasticRepository(_indexName, _hostElastic));

        private IFunnelElasticRepository funnelElasticRepository;
        public IFunnelElasticRepository FunnelElasticRepository => funnelElasticRepository ?? (funnelElasticRepository = new FunnelElasticRepository(_indexName, _hostElastic));

        //private IFileFunnelElasticRepository fileFunnelElasticRepository;
        //public IFileFunnelElasticRepository FileFunnelElasticRepository => fileFunnelElasticRepository ?? (fileFunnelElasticRepository = new FileFunnelElasticRepository(_indexName, _hostElastic));

        private IFunnelActivityElasticRepository funnelActivityElasticRepository;
        public IFunnelActivityElasticRepository FunnelActivityElasticRepository => funnelActivityElasticRepository ?? (funnelActivityElasticRepository = new FunnelActivityElasticRepository(_indexName, _hostElastic));

        private IFunnelItemsElasticRepository funnelItemsElasticRepository;
        public IFunnelItemsElasticRepository FunnelItemsElasticRepository => funnelItemsElasticRepository ?? (funnelItemsElasticRepository = new FunnelItemsElasticRepository(_indexName, _hostElastic));

        private IWarrantySupportElasticRepository warrantySupportElasticRepository;
        public IWarrantySupportElasticRepository WarrantySupportElasticRepository => warrantySupportElasticRepository ?? (warrantySupportElasticRepository = new WarrantySupportElasticRepository(_indexName, _hostElastic));

        private IWarrantySLAElasticRepository warrantySLAElasticRepository;
        public IWarrantySLAElasticRepository WarrantySLAElasticRepository => warrantySLAElasticRepository ?? (warrantySLAElasticRepository = new WarrantySLAElasticRepository(_indexName, _hostElastic));
    }
}
