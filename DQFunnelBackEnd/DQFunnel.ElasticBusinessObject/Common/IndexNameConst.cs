using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.ElasticBusinessObject.Common
{
    public class IndexNameConst
    {
        /// <summary>
        /// Semua nama index di simpan disini
        /// agar memudahkan dalam proses pemanggilan
        /// penamaannya :
        /// 1.Jika schema bukan dbo penulisannya [NAMA_DB]_[SCHEMA]_[NAMA_TABLE]
        /// 2.Jika schema nya menggunakan dbo penulisan nya [NAMA_DB]_[NAMA_TABLE]
        /// </summary>
        public const string SALES_FUNNEL = "omsprod_sales_funnel";

        public const string SALES_PROJECT_TRANSFER = "omsprod_sales_project_transfer";
        public const string SALES_FUNNEL_ATTACHMENT = "omsprod_file_funnel_attachment";
        public const string SERVICE_CATALOG = "omsprod_service_catalog";
        public const string SALES_BANK_GUARANTEE = "omsprod_sales_bank_guarantee";
        public const string SALES_FUNNEL_ACTIVITY = "omsprod_sales_funnel_activity";
        public const string SALES_FUNNEL_ITEMS = "omsprod_sales_funnel_items";
        public const string BRAND_MODEL = "omsprod_brand_model";
        public const string SALES_WARRANTY_SUPPORT = "omsprod_sales_warranty_support";
        public const string SALES_WARRANTY_SLA = "omsprod_sales_warranty_sla";
    }
}
