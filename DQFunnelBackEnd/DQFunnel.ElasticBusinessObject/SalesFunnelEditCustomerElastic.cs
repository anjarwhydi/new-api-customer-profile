using DQFunnel.ElasticBusinessObject.Base;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.ElasticBusinessObject
{
    public class SalesFunnelEditCustomerElastic : BaseEntityES
    {
		[Number(Name = "FunnelGenID")]
		public long FunnelGenID { get; set; }

		[Text(Name = "FunnelID")]
		public string FunnelID { get; set; }

		[Number(Name = "CustomerGenID")]
		public long CustomerGenID { get; set; }

		[Text(Name = "CustomerName")]
		public string CustomerName { get; set; }

		[Number(Name = "EndUserCustomerGenID")]
		public long EndUserCustomerGenID { get; set; }

		[Text(Name = "EndUserCustomerName")]
		public string EndUserCustomerName { get; set; }

		[Text(Name = "ProjectName")]
		public string ProjectName { get; set; }

		[Date(Name = "ActStartProjectDate")]
		public DateTime? ActStartProjectDate { get; set; }

		[Date(Name = "ActEndProjectDate")]
		public DateTime? ActEndProjectDate { get; set; }

		[Date(Name = "EstStartProjectDate")]
		public DateTime? EstStartProjectDate { get; set; }

		[Date(Name = "EstEndProjectDate")]
		public DateTime? EstEndProjectDate { get; set; }

		[Number(Name = "EstDurationProject")]
		public int EstDurationProject { get; set; }

		[Text(Name = "EstDurationType")]
		public string EstDurationType { get; set; }

		[Text(Name = "PresalesDeptID")]
		public string PresalesDeptID { get; set; }

		[Text(Name = "PMODeptID")]
		public string PMODeptID { get; set; }

		[Text(Name = "SMODeptID")]
		public string SMODeptID { get; set; }

		[Number(Name = "ReqDedicatedResource")]
		public int ReqDedicatedResource { get; set; }

		[Text(Name = "CustomerAddress")]
		public string CustomerAddress { get; set; }

		[Text(Name = "PhoneNumber")]
		public string PhoneNumber { get; set; }

		[Text(Name = "NPWPNumber")]
		public string NPWPNumber { get; set; }

		[Number(Name = "CustomerPICID")]
		public long CustomerPICID { get; set; }

		[Text(Name = "PICName")]
		public string PICName { get; set; }

		[Text(Name = "PICMobilePhone")]
		public string PICMobilePhone { get; set; }

		[Text(Name = "PICEmailAddr")]
		public string PICEmailAddr { get; set; }
	}
}
