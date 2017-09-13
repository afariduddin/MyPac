using System;
using System.Data.SqlClient;

namespace EngineData
{
    partial class GlobalSettingTable
    {
    }
    partial class GlobalSettingRow
    {
        public void OverrideDefaultValues()
        {
        }
    }
    public partial class GlobalSettingMinimalizedEntity { }
    partial class GlobalSettingAdapter
    {

        public GlobalSettingRow Get(int SettingType)
        {
            string sql = "SELECT * FROM GlobalSetting WHERE GlobalSetting_Type = @SettingType";
            SqlCommand com = new SqlCommand(sql);
            com.Parameters.AddWithValue("@SettingType", SettingType);
            GlobalSettingTable tbl = new GlobalSettingTable();
            DA.ExecuteQuery(com, tbl);
            if (tbl.Rows.Count > 0)
            {
                return tbl.GetGlobalSettingRow(0);
            }
            else
            {
                return null;
            }
        }
    }
}
