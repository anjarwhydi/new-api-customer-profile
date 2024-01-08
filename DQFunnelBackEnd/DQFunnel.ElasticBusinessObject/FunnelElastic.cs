using DQFunnel.ElasticBusinessObject.Base;
using Nest;
using System;
using System.Collections.Generic;

namespace DQFunnel.ElasticBusinessObject
{
	[ElasticsearchType(IdProperty = nameof(Id))]
	public class FunnelElastic : BaseEntityES
	{
		public string id { get; set; }

		[Text(Name = "FunnelID")]
		public string FunnelID { get; set; }

		[Number(Name = "FunnelStatusID")]
		public int FunnelStatusID { get; set; }

		[Number(Name = "FunnelStatusText")]
		public string FunnelStatusText { get; set; }

		[Date(Name = "DealCloseDate")]
		public DateTime DealCloseDate { get; set; }

		[Number(Name = "SalesID")]
		public int SalesID { get; set; }

		[Number(Name = "CustomerGenID")]
		public long CustomerGenID { get; set; }

		[Number(Name = "EndUserCustomerGenID")]
		public long EndUserCustomerGenID { get; set; }

		[Number(Name = "CustomerPICID")]
		public long CustomerPICID { get; set; }

		[Text(Name = "ProjectName")]
		public string ProjectName { get; set; }

		[Number(Name = "GPMPctg")]
		public float? GPMPctg { get; set; }

		[Number(Name = "GPMAmount")]
		public decimal? GPMAmount { get; set; }

		[Number(Name = "TotalOrderingPriceProduct")]
		public decimal? TotalOrderingPriceProduct { get; set; }

		[Number(Name = "TotalSellingPriceProduct")]
		public decimal? TotalSellingPriceProduct { get; set; }

		[Number(Name = "TotalOrderingPriceService")]
		public decimal? TotalOrderingPriceService { get; set; }

		[Number(Name = "TotalSellingPriceService")]
		public decimal? TotalSellingPriceService { get; set; }

		[Number(Name = "TotalOrderingPrice")]
		public decimal? TotalOrderingPrice { get; set; }

		[Number(Name = "TotalSellingPrice")]
		public decimal? TotalSellingPrice { get; set; }

		[Text(Name = "CompellingEvent")]
		public string CompellingEvent { get; set; }

		[Number(Name = "CustomerBudget")]
		public decimal? CustomerBudget { get; set; }

		[Text(Name = "SupportiveCoach")]
		public string SupportiveCoach { get; set; }

		[Text(Name = "CustomerNeeds")]
		public string CustomerNeeds { get; set; }

		[Text(Name = "Competitor")]
		public string Competitor { get; set; }

		[Text(Name = "PresalesDeptID")]
		public string PresalesDeptID { get; set; }

		[Text(Name = "PMODeptID")]
		public string PMODeptID { get; set; }

		[Number(Name = "NeedSMO")]
		public byte? NeedSMO { get; set; }

		[Text(Name = "SMODeptID")]
		public string SMODeptID { get; set; }

		[Date(Name = "POCustomerDate")]
		public DateTime? POCustomerDate { get; set; }

		[Date(Name = "EstStartProjectDate")]
		public DateTime? EstStartProjectDate { get; set; }

		[Date(Name = "EstEndProjectDate")]
		public DateTime? EstEndProjectDate { get; set; }

		[Date(Name = "ActStartProjectDate")]
		public DateTime? ActStartProjectDate { get; set; }

		[Date(Name = "ActEndProjectDate")]
		public DateTime? ActEndProjectDate { get; set; }

		[Text(Name = "LastDataChangeType")]
		public string LastDataChangeType { get; set; }

		[Text(Name = "LastDataChangeRemarks")]
		public string LastDataChangeRemarks { get; set; }

		[Number(Name = "cocode")]
		public int cocode { get; set; }

		[Date(Name = "StartTime")]
		public DateTime? StartTime { get; set; }

		[Date(Name = "EndTime")]
		public DateTime? EndTime { get; set; }

		[Number(Name = "EstDurationProject")]
		public int EstDurationProject { get; set; }

		[Text(Name = "EstDurationType")]
		public string EstDurationType { get; set; }

		[Number(Name = "NumOfMaxResource")]
		public int NumOfMaxResource { get; set; }

		[Number(Name = "NumOfBufferResource")]
		public int NumOfBufferResource { get; set; }

		[Number(Name = "HaveWarranty")]
		public int HaveWarranty { get; set; }

		[Text(Name = "POCustomerNo")]
		public string POCustomerNo { get; set; }

		[Date(Name = "ContractStartDate")]
		public DateTime? ContractStartDate { get; set; }

		[Date(Name = "ContractEndDate")]
		public DateTime? ContractEndDate { get; set; }

		[Text(Name = "ContractNo")]
		public string ContractNo { get; set; }

		[Number(Name = "ReqDedicatedResource")]
		public int ReqDedicatedResource { get; set; }


		[Number(Name = "EmployeeKey")]
		public int EmployeeKey { get; set; }

		[Text(Name = "EmployeeEmail")]
		public string EmployeeEmail { get; set; }

		[Text(Name = "SalesName")]
		public string SalesName { get; set; }

		[Text(Name = "CustomerName")]
		public string CustomerName { get; set; }

		[Text(Name = "EndUserCustomerName")]
		public string EndUserCustomerName { get; set; }

		[Text(Name = "CustomerPICName")]
		public string CustomerPICName { get; set; }

		[Text(Name = "FunnelStatus")]
		public string FunnelStatus { get; set; }


		[Nested]
		[PropertyName("SalesFunnelActivity")]
		public List<SalesFunnelActivityElastic> SalesFunnelActivity { get; set; }

		[Nested]
		[PropertyName("SalesFunnelItems")]
		public List<SalesFunnelItemsElastic> SalesFunnelItems { get; set; }

		[Nested]
		[PropertyName("SalesFunnelSupportTeam")]
		public List<SalesFunnelSupportTeamsElastic> SalesFunnelSupportTeam { get; set; }

		[Nested]
		[PropertyName("SalesBankGuarantee")]
		public SalesBankGuaranteeElastic SalesBankGuarantee { get; set; }
		//public List<SalesFunnelNotes> SalesFunnelNotes { get; set; }

		[Nested]
		[PropertyName("FileFunnelAttachment")]
		public List<FileFunnelAttachmentElastic> FileFunnelAttachment { get; set; }
	}
}
