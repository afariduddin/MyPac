using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Teq;
namespace EngineData {
public partial class CoachingTable : DataTable {
// column indexes
public const int Coaching_IDColumnIndex = 0;
public const int Coaching_DescriptionColumnIndex = 1;
public const int StudentCourse_IDColumnIndex = 2;
public const int Coaching_RemarkColumnIndex = 3;
public const int Coaching_DateColumnIndex = 4;
public const int Coaching_IsDeletedColumnIndex = 5;
public const int Coaching_StatusColumnIndex = 6;
public const int Coaching_CreatedDateColumnIndex = 7;
public const int Coaching_CreatedByColumnIndex = 8;
public const int Coaching_UpdatedDateColumnIndex = 9;
public const int Coaching_UpdatedByColumnIndex = 10;
public const int UserAccount_IDColumnIndex = 11;
public CoachingTable() {
TableName = "[Coaching]";
// column Coaching_ID
DataColumn Coaching_IDCol = new DataColumn("Coaching_ID", typeof(System.Guid));
Coaching_IDCol.ReadOnly = false;
Coaching_IDCol.AllowDBNull = false;
Columns.Add(Coaching_IDCol);
// column Coaching_Description
DataColumn Coaching_DescriptionCol = new DataColumn("Coaching_Description", typeof(System.String));
Coaching_DescriptionCol.ReadOnly = false;
Coaching_DescriptionCol.AllowDBNull = false;
Columns.Add(Coaching_DescriptionCol);
// column StudentCourse_ID
DataColumn StudentCourse_IDCol = new DataColumn("StudentCourse_ID", typeof(System.Guid));
StudentCourse_IDCol.ReadOnly = false;
StudentCourse_IDCol.AllowDBNull = false;
Columns.Add(StudentCourse_IDCol);
// column Coaching_Remark
DataColumn Coaching_RemarkCol = new DataColumn("Coaching_Remark", typeof(System.String));
Coaching_RemarkCol.ReadOnly = false;
Coaching_RemarkCol.AllowDBNull = false;
Columns.Add(Coaching_RemarkCol);
// column Coaching_Date
DataColumn Coaching_DateCol = new DataColumn("Coaching_Date", typeof(System.DateTime));
Coaching_DateCol.DateTimeMode = DataSetDateTime.Local;
Coaching_DateCol.ReadOnly = false;
Coaching_DateCol.AllowDBNull = false;
Columns.Add(Coaching_DateCol);
// column Coaching_IsDeleted
DataColumn Coaching_IsDeletedCol = new DataColumn("Coaching_IsDeleted", typeof(System.Boolean));
Coaching_IsDeletedCol.ReadOnly = false;
Coaching_IsDeletedCol.AllowDBNull = false;
Columns.Add(Coaching_IsDeletedCol);
// column Coaching_Status
DataColumn Coaching_StatusCol = new DataColumn("Coaching_Status", typeof(System.Int16));
Coaching_StatusCol.ReadOnly = false;
Coaching_StatusCol.AllowDBNull = false;
Columns.Add(Coaching_StatusCol);
// column Coaching_CreatedDate
DataColumn Coaching_CreatedDateCol = new DataColumn("Coaching_CreatedDate", typeof(System.DateTime));
Coaching_CreatedDateCol.DateTimeMode = DataSetDateTime.Local;
Coaching_CreatedDateCol.ReadOnly = false;
Coaching_CreatedDateCol.AllowDBNull = false;
Columns.Add(Coaching_CreatedDateCol);
// column Coaching_CreatedBy
DataColumn Coaching_CreatedByCol = new DataColumn("Coaching_CreatedBy", typeof(System.String));
Coaching_CreatedByCol.ReadOnly = false;
Coaching_CreatedByCol.AllowDBNull = false;
Columns.Add(Coaching_CreatedByCol);
// column Coaching_UpdatedDate
DataColumn Coaching_UpdatedDateCol = new DataColumn("Coaching_UpdatedDate", typeof(System.DateTime));
Coaching_UpdatedDateCol.DateTimeMode = DataSetDateTime.Local;
Coaching_UpdatedDateCol.ReadOnly = false;
Coaching_UpdatedDateCol.AllowDBNull = false;
Columns.Add(Coaching_UpdatedDateCol);
// column Coaching_UpdatedBy
DataColumn Coaching_UpdatedByCol = new DataColumn("Coaching_UpdatedBy", typeof(System.String));
Coaching_UpdatedByCol.ReadOnly = false;
Coaching_UpdatedByCol.AllowDBNull = false;
Columns.Add(Coaching_UpdatedByCol);
// column UserAccount_ID
DataColumn UserAccount_IDCol = new DataColumn("UserAccount_ID", typeof(System.Guid));
UserAccount_IDCol.ReadOnly = false;
UserAccount_IDCol.AllowDBNull = false;
Columns.Add(UserAccount_IDCol);
}
public CoachingRow NewCoachingRow() {
CoachingRow row = (CoachingRow)NewRow();
SetDefaultValues(row);
row.OverrideDefaultValues();
Rows.Add(row);
return row;
}
void SetDefaultValues(CoachingRow row) {
row.Coaching_ID = Guid.Empty;
row.Coaching_Description = "";
row.StudentCourse_ID = Guid.Empty;
row.Coaching_Remark = "";
row.Coaching_Date = DateTime.Now;
row.Coaching_IsDeleted = false;
row.Coaching_Status = 0;
row.Coaching_CreatedDate = DateTime.Now;
row.Coaching_CreatedBy = "";
row.Coaching_UpdatedDate = DateTime.Now;
row.Coaching_UpdatedBy = "";
row.UserAccount_ID = Guid.Empty;
}
protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
return new CoachingRow(builder);
}
public CoachingRow GetCoachingRow(int index) {
return (CoachingRow)Rows[index];
}
}
public partial class CoachingRow : DataRow {
internal CoachingRow(DataRowBuilder builder) : base(builder) {
}
public System.Guid Coaching_ID {
get {
return (System.Guid)this["Coaching_ID"];
}
set {
this["Coaching_ID"] = value;
}
}
public System.String Coaching_Description {
get {
return (System.String)this["Coaching_Description"];
}
set {
if( value.Length > 500 ) this["Coaching_Description"] = value.Substring(0, 500);
else this["Coaching_Description"] = value;
}
}
public System.Guid StudentCourse_ID {
get {
return (System.Guid)this["StudentCourse_ID"];
}
set {
this["StudentCourse_ID"] = value;
}
}
public System.String Coaching_Remark {
get {
return (System.String)this["Coaching_Remark"];
}
set {
if( value.Length > 250 ) this["Coaching_Remark"] = value.Substring(0, 250);
else this["Coaching_Remark"] = value;
}
}
public System.DateTime Coaching_Date {
get {
return (System.DateTime)this["Coaching_Date"];
}
set {
this["Coaching_Date"] = value;
}
}
public System.Boolean Coaching_IsDeleted {
get {
return (System.Boolean)this["Coaching_IsDeleted"];
}
set {
this["Coaching_IsDeleted"] = value;
}
}
public System.Int16 Coaching_Status {
get {
return (System.Int16)this["Coaching_Status"];
}
set {
this["Coaching_Status"] = value;
}
}
public System.DateTime Coaching_CreatedDate {
get {
return (System.DateTime)this["Coaching_CreatedDate"];
}
set {
this["Coaching_CreatedDate"] = value;
}
}
public System.String Coaching_CreatedBy {
get {
return (System.String)this["Coaching_CreatedBy"];
}
set {
if( value.Length > 50 ) this["Coaching_CreatedBy"] = value.Substring(0, 50);
else this["Coaching_CreatedBy"] = value;
}
}
public System.DateTime Coaching_UpdatedDate {
get {
return (System.DateTime)this["Coaching_UpdatedDate"];
}
set {
this["Coaching_UpdatedDate"] = value;
}
}
public System.String Coaching_UpdatedBy {
get {
return (System.String)this["Coaching_UpdatedBy"];
}
set {
if( value.Length > 50 ) this["Coaching_UpdatedBy"] = value.Substring(0, 50);
else this["Coaching_UpdatedBy"] = value;
}
}
public System.Guid UserAccount_ID {
get {
return (System.Guid)this["UserAccount_ID"];
}
set {
this["UserAccount_ID"] = value;
}
}
}
public partial class CoachingMinimalizedEntity {
public CoachingMinimalizedEntity() {}
public CoachingMinimalizedEntity(CoachingRow dr) {
this.Coaching_ID = dr.Coaching_ID;
this.Coaching_Description = dr.Coaching_Description;
this.StudentCourse_ID = dr.StudentCourse_ID;
this.Coaching_Remark = dr.Coaching_Remark;
this.Coaching_Date = dr.Coaching_Date;
this.Coaching_IsDeleted = dr.Coaching_IsDeleted;
this.Coaching_Status = dr.Coaching_Status;
this.Coaching_CreatedDate = dr.Coaching_CreatedDate;
this.Coaching_CreatedBy = dr.Coaching_CreatedBy;
this.Coaching_UpdatedDate = dr.Coaching_UpdatedDate;
this.Coaching_UpdatedBy = dr.Coaching_UpdatedBy;
this.UserAccount_ID = dr.UserAccount_ID;
}
public void CopyTo(CoachingRow dr) {
dr.Coaching_ID = this.Coaching_ID;
dr.Coaching_Description = this.Coaching_Description;
dr.StudentCourse_ID = this.StudentCourse_ID;
dr.Coaching_Remark = this.Coaching_Remark;
dr.Coaching_Date = this.Coaching_Date;
dr.Coaching_IsDeleted = this.Coaching_IsDeleted;
dr.Coaching_Status = this.Coaching_Status;
dr.Coaching_CreatedDate = this.Coaching_CreatedDate;
dr.Coaching_CreatedBy = this.Coaching_CreatedBy;
dr.Coaching_UpdatedDate = this.Coaching_UpdatedDate;
dr.Coaching_UpdatedBy = this.Coaching_UpdatedBy;
dr.UserAccount_ID = this.UserAccount_ID;
}
public System.Guid Coaching_ID;
public System.String Coaching_Description;
public System.Guid StudentCourse_ID;
public System.String Coaching_Remark;
public System.DateTime Coaching_Date;
public System.Boolean Coaching_IsDeleted;
public System.Int16 Coaching_Status;
public System.DateTime Coaching_CreatedDate;
public System.String Coaching_CreatedBy;
public System.DateTime Coaching_UpdatedDate;
public System.String Coaching_UpdatedBy;
public System.Guid UserAccount_ID;
}
public partial class CoachingAdapter:AdapterBase {
SqlDataAdapter adapter;
public SqlDataAdapter Adapter {
get { return adapter; }
}
public CoachingAdapter(DA da):base(da) {
InitializeAdapter();
}
void InitializeAdapter() {
adapter = new SqlDataAdapter();
{
// columns mapping
DataTableMapping tmap = new DataTableMapping();
tmap.SourceTable = "Table";
tmap.DataSetTable = "";
tmap.ColumnMappings.Add("Coaching_ID", "Coaching_ID");
tmap.ColumnMappings.Add("Coaching_Description", "Coaching_Description");
tmap.ColumnMappings.Add("StudentCourse_ID", "StudentCourse_ID");
tmap.ColumnMappings.Add("Coaching_Remark", "Coaching_Remark");
tmap.ColumnMappings.Add("Coaching_Date", "Coaching_Date");
tmap.ColumnMappings.Add("Coaching_IsDeleted", "Coaching_IsDeleted");
tmap.ColumnMappings.Add("Coaching_Status", "Coaching_Status");
tmap.ColumnMappings.Add("Coaching_CreatedDate", "Coaching_CreatedDate");
tmap.ColumnMappings.Add("Coaching_CreatedBy", "Coaching_CreatedBy");
tmap.ColumnMappings.Add("Coaching_UpdatedDate", "Coaching_UpdatedDate");
tmap.ColumnMappings.Add("Coaching_UpdatedBy", "Coaching_UpdatedBy");
tmap.ColumnMappings.Add("UserAccount_ID", "UserAccount_ID");
adapter.TableMappings.Add(tmap);
}
// insert command
adapter.InsertCommand = new SqlCommand("INSERT INTO [Coaching] ([Coaching_ID], [Coaching_Description], [StudentCourse_ID], [Coaching_Remark], [Coaching_Date], [Coaching_IsDeleted], [Coaching_Status], [Coaching_CreatedDate], [Coaching_CreatedBy], [Coaching_UpdatedDate], [Coaching_UpdatedBy], [UserAccount_ID]) VALUES (@Coaching_ID, @Coaching_Description, @StudentCourse_ID, @Coaching_Remark, @Coaching_Date, @Coaching_IsDeleted, @Coaching_Status, @Coaching_CreatedDate, @Coaching_CreatedBy, @Coaching_UpdatedDate, @Coaching_UpdatedBy, @UserAccount_ID)");
adapter.InsertCommand.Parameters.Add("@Coaching_ID", SqlDbType.UniqueIdentifier, 0, "Coaching_ID");
adapter.InsertCommand.Parameters.Add("@Coaching_Description", SqlDbType.NVarChar, 0, "Coaching_Description");
adapter.InsertCommand.Parameters.Add("@StudentCourse_ID", SqlDbType.UniqueIdentifier, 0, "StudentCourse_ID");
adapter.InsertCommand.Parameters.Add("@Coaching_Remark", SqlDbType.NVarChar, 0, "Coaching_Remark");
adapter.InsertCommand.Parameters.Add("@Coaching_Date", SqlDbType.DateTime, 0, "Coaching_Date");
adapter.InsertCommand.Parameters.Add("@Coaching_IsDeleted", SqlDbType.Bit, 0, "Coaching_IsDeleted");
adapter.InsertCommand.Parameters.Add("@Coaching_Status", SqlDbType.SmallInt, 0, "Coaching_Status");
adapter.InsertCommand.Parameters.Add("@Coaching_CreatedDate", SqlDbType.DateTime, 0, "Coaching_CreatedDate");
adapter.InsertCommand.Parameters.Add("@Coaching_CreatedBy", SqlDbType.NVarChar, 0, "Coaching_CreatedBy");
adapter.InsertCommand.Parameters.Add("@Coaching_UpdatedDate", SqlDbType.DateTime, 0, "Coaching_UpdatedDate");
adapter.InsertCommand.Parameters.Add("@Coaching_UpdatedBy", SqlDbType.NVarChar, 0, "Coaching_UpdatedBy");
adapter.InsertCommand.Parameters.Add("@UserAccount_ID", SqlDbType.UniqueIdentifier, 0, "UserAccount_ID");
// update command
adapter.UpdateCommand = new SqlCommand("UPDATE [Coaching] SET [Coaching_ID] = @Coaching_ID, [Coaching_Description] = @Coaching_Description, [StudentCourse_ID] = @StudentCourse_ID, [Coaching_Remark] = @Coaching_Remark, [Coaching_Date] = @Coaching_Date, [Coaching_IsDeleted] = @Coaching_IsDeleted, [Coaching_Status] = @Coaching_Status, [Coaching_CreatedDate] = @Coaching_CreatedDate, [Coaching_CreatedBy] = @Coaching_CreatedBy, [Coaching_UpdatedDate] = @Coaching_UpdatedDate, [Coaching_UpdatedBy] = @Coaching_UpdatedBy, [UserAccount_ID] = @UserAccount_ID WHERE [Coaching_ID] = @o_Coaching_ID");
adapter.UpdateCommand.Parameters.Add("@Coaching_ID", SqlDbType.UniqueIdentifier, 0, "Coaching_ID");
adapter.UpdateCommand.Parameters.Add(new SqlParameter("@o_Coaching_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "Coaching_ID", DataRowVersion.Original, null));
adapter.UpdateCommand.Parameters.Add("@Coaching_Description", SqlDbType.NVarChar, 0, "Coaching_Description");
adapter.UpdateCommand.Parameters.Add("@StudentCourse_ID", SqlDbType.UniqueIdentifier, 0, "StudentCourse_ID");
adapter.UpdateCommand.Parameters.Add("@Coaching_Remark", SqlDbType.NVarChar, 0, "Coaching_Remark");
adapter.UpdateCommand.Parameters.Add("@Coaching_Date", SqlDbType.DateTime, 0, "Coaching_Date");
adapter.UpdateCommand.Parameters.Add("@Coaching_IsDeleted", SqlDbType.Bit, 0, "Coaching_IsDeleted");
adapter.UpdateCommand.Parameters.Add("@Coaching_Status", SqlDbType.SmallInt, 0, "Coaching_Status");
adapter.UpdateCommand.Parameters.Add("@Coaching_CreatedDate", SqlDbType.DateTime, 0, "Coaching_CreatedDate");
adapter.UpdateCommand.Parameters.Add("@Coaching_CreatedBy", SqlDbType.NVarChar, 0, "Coaching_CreatedBy");
adapter.UpdateCommand.Parameters.Add("@Coaching_UpdatedDate", SqlDbType.DateTime, 0, "Coaching_UpdatedDate");
adapter.UpdateCommand.Parameters.Add("@Coaching_UpdatedBy", SqlDbType.NVarChar, 0, "Coaching_UpdatedBy");
adapter.UpdateCommand.Parameters.Add("@UserAccount_ID", SqlDbType.UniqueIdentifier, 0, "UserAccount_ID");
// delete command
adapter.DeleteCommand = new SqlCommand("DELETE FROM [Coaching] WHERE [Coaching_ID] = @o_Coaching_ID");
adapter.DeleteCommand.Parameters.Add(new SqlParameter("@o_Coaching_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "Coaching_ID", DataRowVersion.Original, null));
}
public void Update(CoachingTable tbl, IActivityLog log) {
Log(tbl, log);
DA.ExecuteAdapter(Adapter, tbl);
}
public void Update(CoachingRow dr, IActivityLog log) {
Log(dr, log);
DA.ExecuteAdapter(Adapter, dr);
}
public CoachingRow GetByCoaching_ID(System.Guid Coaching_ID ) {
string sql = "SELECT * FROM [Coaching] WHERE [Coaching_ID] = @Coaching_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("Coaching_ID", Coaching_ID);

CoachingTable tbl = new CoachingTable();
DA.ExecuteQuery(com, tbl);
if( tbl.Rows.Count == 0 ) return null;
else return tbl.GetCoachingRow(0);
}
public int CountByCoaching_ID(System.Guid Coaching_ID ) {
string sql = "SELECT COUNT(*) FROM [Coaching] WHERE [Coaching_ID] = @Coaching_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("Coaching_ID", Coaching_ID);

return DA.ExecuteInt32(com);
}
public int DeleteByCoaching_ID(System.Guid Coaching_ID, IActivityLog log ) {
string sql = "DELETE FROM [Coaching] WHERE [Coaching_ID] = @Coaching_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("Coaching_ID", Coaching_ID);

if(log!=null) log.AddTransaction(com);
return DA.ExecuteNonQuery(com);
}
public CoachingTable GetByStudentCourse_ID(System.Guid StudentCourse_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT * FROM [Coaching] WHERE [StudentCourse_ID] = @StudentCourse_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("StudentCourse_ID", StudentCourse_ID);
CoachingTable tbl = new CoachingTable();
DA.ExecuteQuery(fcom, tbl);
return tbl;
}
public int CountByStudentCourse_ID(System.Guid StudentCourse_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT COUNT(*) FROM [Coaching] WHERE [StudentCourse_ID] = @StudentCourse_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("StudentCourse_ID", StudentCourse_ID);
return DA.ExecuteInt32(fcom);
}
public int DeleteByStudentCourse_ID(System.Guid StudentCourse_ID, IActivityLog log ) {
SqlCommand fcom = new SqlCommand();
string sql = "DELETE FROM [Coaching] WHERE [StudentCourse_ID] = @StudentCourse_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("StudentCourse_ID", StudentCourse_ID);
if(log!=null) log.AddTransaction(fcom);
return DA.ExecuteNonQuery(fcom);
}
public CoachingTable GetByUserAccount_ID(System.Guid UserAccount_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT * FROM [Coaching] WHERE [UserAccount_ID] = @UserAccount_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("UserAccount_ID", UserAccount_ID);
CoachingTable tbl = new CoachingTable();
DA.ExecuteQuery(fcom, tbl);
return tbl;
}
public int CountByUserAccount_ID(System.Guid UserAccount_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT COUNT(*) FROM [Coaching] WHERE [UserAccount_ID] = @UserAccount_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("UserAccount_ID", UserAccount_ID);
return DA.ExecuteInt32(fcom);
}
public int DeleteByUserAccount_ID(System.Guid UserAccount_ID, IActivityLog log ) {
SqlCommand fcom = new SqlCommand();
string sql = "DELETE FROM [Coaching] WHERE [UserAccount_ID] = @UserAccount_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("UserAccount_ID", UserAccount_ID);
if(log!=null) log.AddTransaction(fcom);
return DA.ExecuteNonQuery(fcom);
}
}
}
