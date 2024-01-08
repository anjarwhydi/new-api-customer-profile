using DQFunnel.ElasticBusinessObject.Base;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.ElasticBusinessObject
{
    public class SalesFunnelSupportTeamsElastic : BaseEntityES
	{
		[Number(Name = "FunnelSupportID")]
		public long FunnelSupportID { get; set; }

		[Number(Name = "FunnelGenID")]
		public long FunnelGenID { get; set; }

		[Number(Name = "EmployeeID")]
		public int EmployeeID { get; set; }

		[Number(Name = "SupportRoleID")]
		public int SupportRoleID { get; set; }

		[Date(Name = "SupportRequestedBeginDate")]
		public DateTime SupportRequestedBeginDate { get; set; }

		[Date(Name = "SupportRequestedEndDate")]
		public DateTime? SupportRequestedEndDate { get; set; }

		[Boolean(Name = "NeedAssignFlag")]
		public byte NeedAssignFlag { get; set; }

		[Number(Name = "AssignedByID")]
		public int? AssignedByID { get; set; }

		[Date(Name = "AssignDate")]
		public DateTime? AssignDate { get; set; }
	}
}