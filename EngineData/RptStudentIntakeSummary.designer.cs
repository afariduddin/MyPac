using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Teq;
namespace EngineData {
public partial class RptStudentIntakeSummaryTable : DataTable {
// column indexes
public const int IntakeMonthColumnIndex = 0;
public const int IntakeYearColumnIndex = 1;
public const int TSPColumnIndex = 2;
public const int IntakeColumnIndex = 3;
public const int MaleColumnIndex = 4;
public const int FemaleColumnIndex = 5;
public const int TotalColumnIndex = 6;
public RptStudentIntakeSummaryTable() {
TableName = "[RptStudentIntakeSummary]";
// column IntakeMonth
DataColumn IntakeMonthCol = new DataColumn("IntakeMonth", typeof(System.Int32));
IntakeMonthCol.ReadOnly = true;
IntakeMonthCol.AllowDBNull = false;
Columns.Add(IntakeMonthCol);
// column IntakeYear
DataColumn IntakeYearCol = new DataColumn("IntakeYear", typeof(System.Int32));
IntakeYearCol.ReadOnly = true;
IntakeYearCol.AllowDBNull = false;
Columns.Add(IntakeYearCol);
// column TSP
DataColumn TSPCol = new DataColumn("TSP", typeof(System.String));
TSPCol.ReadOnly = true;
TSPCol.AllowDBNull = false;
Columns.Add(TSPCol);
// column Intake
DataColumn IntakeCol = new DataColumn("Intake", typeof(System.String));
IntakeCol.ReadOnly = true;
IntakeCol.AllowDBNull = false;
Columns.Add(IntakeCol);
// column Male
DataColumn MaleCol = new DataColumn("Male", typeof(System.Int32));
MaleCol.ReadOnly = true;
MaleCol.AllowDBNull = true;
Columns.Add(MaleCol);
// column Female
DataColumn FemaleCol = new DataColumn("Female", typeof(System.Int32));
FemaleCol.ReadOnly = true;
FemaleCol.AllowDBNull = true;
Columns.Add(FemaleCol);
// column Total
DataColumn TotalCol = new DataColumn("Total", typeof(System.Int32));
TotalCol.ReadOnly = true;
TotalCol.AllowDBNull = true;
Columns.Add(TotalCol);
}
protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
return new RptStudentIntakeSummaryRow(builder);
}
public RptStudentIntakeSummaryRow GetRptStudentIntakeSummaryRow(int index) {
return (RptStudentIntakeSummaryRow)Rows[index];
}
}
public partial class RptStudentIntakeSummaryRow : DataRow {
internal RptStudentIntakeSummaryRow(DataRowBuilder builder) : base(builder) {
}
public System.Int32 IntakeMonth {
get {
return (System.Int32)this["IntakeMonth"];
}
}
public System.Int32 IntakeYear {
get {
return (System.Int32)this["IntakeYear"];
}
}
public System.String TSP {
get {
return (System.String)this["TSP"];
}
}
public System.String Intake {
get {
return (System.String)this["Intake"];
}
}
public System.Int32? Male {
get {
if( IsNull("Male") ) return null;
else return (System.Int32)this["Male"];
}
}
public System.Int32? Female {
get {
if( IsNull("Female") ) return null;
else return (System.Int32)this["Female"];
}
}
public System.Int32? Total {
get {
if( IsNull("Total") ) return null;
else return (System.Int32)this["Total"];
}
}
}
public partial class RptStudentIntakeSummaryMinimalizedEntity {
public RptStudentIntakeSummaryMinimalizedEntity() {}
public RptStudentIntakeSummaryMinimalizedEntity(RptStudentIntakeSummaryRow dr) {
this.IntakeMonth = dr.IntakeMonth;
this.IntakeYear = dr.IntakeYear;
this.TSP = dr.TSP;
this.Intake = dr.Intake;
this.Male = dr.Male;
this.Female = dr.Female;
this.Total = dr.Total;
}
public System.Int32 IntakeMonth;
public System.Int32 IntakeYear;
public System.String TSP;
public System.String Intake;
public System.Int32? Male;
public System.Int32? Female;
public System.Int32? Total;
}
public partial class RptStudentIntakeSummaryAdapter:AdapterBase {
SqlDataAdapter adapter;
public SqlDataAdapter Adapter {
get { return adapter; }
}
public RptStudentIntakeSummaryAdapter(DA da):base(da) {
InitializeAdapter();
}
void InitializeAdapter() {
adapter = new SqlDataAdapter();
{
// columns mapping
DataTableMapping tmap = new DataTableMapping();
tmap.SourceTable = "Table";
tmap.DataSetTable = "";
tmap.ColumnMappings.Add("IntakeMonth", "IntakeMonth");
tmap.ColumnMappings.Add("IntakeYear", "IntakeYear");
tmap.ColumnMappings.Add("TSP", "TSP");
tmap.ColumnMappings.Add("Intake", "Intake");
tmap.ColumnMappings.Add("Male", "Male");
tmap.ColumnMappings.Add("Female", "Female");
tmap.ColumnMappings.Add("Total", "Total");
adapter.TableMappings.Add(tmap);
}
}
public RptStudentIntakeSummaryRow GetByPrimaryKeys( ) {
string sql = "SELECT * FROM [RptStudentIntakeSummary] WHERE ";
SqlCommand com = new SqlCommand(sql);

RptStudentIntakeSummaryTable tbl = new RptStudentIntakeSummaryTable();
DA.ExecuteQuery(com, tbl);
if( tbl.Rows.Count == 0 ) return null;
else return tbl.GetRptStudentIntakeSummaryRow(0);
}
public int CountByPrimaryKeys( ) {
string sql = "SELECT COUNT(*) FROM [RptStudentIntakeSummary] WHERE ";
SqlCommand com = new SqlCommand(sql);

return DA.ExecuteInt32(com);
}
}
}
