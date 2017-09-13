using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using OfficeOpenXml;
using System.IO;
using System.Data.SqlClient;
using EngineData;
using System.Configuration;

/// <summary>
/// Generate Excel to client side
/// </summary>
public class ExportExcel
{
    int OFFSET_ROW = 3;
    int STARTING_ROW_POSITION = 1;
    int STARTING_COLUMN_POSITION = 3;


    public ExportExcel()
    {
        //Constructor
    }

    //public DataTable GetDataTable(String sql, int merchantID, String tableName)
    //{
    //    //Cannot use da.GetReportByMerchantID due to column name need to be modified
    //    SqlCommand com = new SqlCommand();
    //    com.CommandText = sql;
    //    com.Parameters.AddWithValue("MerchantID", merchantID);
    //    DataTable tbl = new DataTable();
    //    tbl.TableName = tableName;
    //    DA da = new DA();
    //    da.ExecuteQuery(com, tbl);
    //    return tbl;
    //}
    public void Export(DataTable tbl, string imgURL, string extraString)
    {
        if (tbl != null)
        {
            ExcelPackage p = new ExcelPackage();
            #region Sheet
            if (tbl.TableName.Length <= 0) tbl.TableName = "Report";
            p.Workbook.Worksheets.Add((tbl.TableName.Length > 31 ? tbl.TableName.Substring(0, 31) : tbl.TableName));
            ExcelWorksheet ws = p.Workbook.Worksheets[1];
            string headerFooter = "";//LicenseManager.license.MallName + " (" + LicenseManager.license.OperatorName + ")";
            ws.HeaderFooter.FirstHeader.LeftAlignedText = headerFooter;
            ws.HeaderFooter.FirstFooter.RightAlignedText = headerFooter;
            ws.HeaderFooter.OddHeader.LeftAlignedText = headerFooter;
            ws.HeaderFooter.OddFooter.RightAlignedText = headerFooter;
            ws.HeaderFooter.EvenHeader.LeftAlignedText = headerFooter;
            ws.HeaderFooter.EvenFooter.RightAlignedText = headerFooter;
            #endregion
            #region Heading
            string mergeTitleCol = "A1:" + ExcelColumnFromNumber(tbl.Columns.Count) + "1";
            ws.Cells[mergeTitleCol].Merge = true;
            ws.Cells[mergeTitleCol].Value = tbl.TableName;
            ws.Cells[mergeTitleCol].Style.Font.Size = 22;
            ws.Cells[mergeTitleCol].Style.Font.Bold = true;
            ws.Row(1).Height = 30;
            ws.Cells[mergeTitleCol].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            ws.Cells[mergeTitleCol].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            #endregion
            #region Populate From DataTable
            int rowOccupy = 4;
            if (tbl.Rows.Count > 0)
            {
                ws.Cells[ExcelColumnFromNumber(STARTING_ROW_POSITION) + (rowOccupy).ToString()].LoadFromDataTable(tbl, false);
            }
            #endregion
            #region Header and FormatByColumn
            for (int col = 0; col < tbl.Columns.Count; col++)
            {
                string cell = ExcelColumnFromNumber(col + 1) + STARTING_COLUMN_POSITION;

                ws.Column((col + 1)).AutoFit(5, 75);
                ws.Cells[cell].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                ws.Cells[cell].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                //ws.Cells[cell].Merge = true;
                ws.Cells[cell].Style.Font.Bold = true;

                ws.Cells[cell].Value = tbl.Columns[col].ColumnName;
                ws.Column((col + 1)).Width = tbl.Columns[col].ColumnName.Length + 5;
                if (tbl.Columns[col].DataType == typeof(DateTime))
                {
                    ws.Column(col + 1).Style.Numberformat.Format = "dd-MMM-yyyy, hh:mm AM/PM"; //"DD/MM/YYYY";
                    ws.Column(col + 1).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    ws.Column(col + 1).Width = 22;
                }
                else if (tbl.Columns[col].DataType == typeof(Double))
                {
                    ws.Column(col + 1).Style.Numberformat.Format = "#,0.00";
                    ws.Column(col + 1).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    //ws.Column(col + 1).Width = 22;
                }
            }
            #endregion

            #region ExtraStr
            //"Total Sales":"7185.28";"Total Sqft":"1000";
            //";" to next row, ":" to next column
            if (extraString != null && extraString != "")
            {
                string[] arrSplit = extraString.Split(';');
                int offset = 2;
                int lastrow = ws.Dimension.End.Row + offset;
                int lastcol = 1;

                foreach (string str in arrSplit)
                {
                    ws.Cells[lastrow, lastcol].Value = str.Substring(0, str.IndexOf(':', 0) + 1);
                    ws.Cells[lastrow, lastcol].Style.Font.Bold = true;

                    ws.Cells[lastrow, lastcol + 1].Value = str.Substring(str.IndexOf(':') + 1);
                    lastrow++;
                }
            }
            #endregion
            #region ImageURL
            if (imgURL != null && imgURL != "")
            {
                string path = ConfigurationManager.AppSettings["ChartImageFolder"] + "\\" + imgURL;
                var prodImg = ws.Drawings.AddPicture("chart", new FileInfo(path));
                prodImg.SetPosition(ws.Dimension.End.Row + OFFSET_ROW, 0, 0, 0);
                prodImg.SetSize(60);
            }
            #endregion

            #region Additional cells
            //if (AdditionalCell != null && AdditionalCell.Count > 0)
            //{
            //    int row = tbl.tbl.Rows.Count + rowOccupy + 1;

            //    foreach (AdditionalCells c in tbl.AdditionalCell)
            //    {
            //        string cell = c.ColName + (row + c.RowNum).ToString();

            //        ws.Cells[cell].Value = c.ColValue;
            //        ws.Cells[cell].Style.HorizontalAlignment = c.HorizontalAlignment;

            //        if (ws.Column(ExcelColumnNameToNumber(c.ColName)).Width < c.ColValue.ToString().Length + 5)
            //        {
            //            ws.Column(ExcelColumnNameToNumber(c.ColName)).Width = c.ColValue.ToString().Length + 5;
            //        }
            //    }
            //}
            #endregion

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.AppendHeader("Content-Type", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            //Response.ContentEncoding = System.Text.Encoding.Unicode;
            HttpContext.Current.Response.Charset = "";
            HttpContext.Current.Response.AppendHeader("Content-disposition", "attachment; filename=" + tbl.TableName.Replace(" ", "_") + "_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xlsx");
            //Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
            p.SaveAs(HttpContext.Current.Response.OutputStream);
            p.Dispose();

        }

        HttpContext.Current.Response.End();
    }



    /// <summary>
    /// 1 -> A<br/>
    /// 2 -> B<br/>
    /// 3 -> C<br/>
    /// ...
    /// </summary>
    /// <param name="column"></param>
    /// <returns></returns>
    private string ExcelColumnFromNumber(int column)
    {
        string columnString = "";
        decimal columnNumber = column;
        while (columnNumber > 0)
        {
            decimal currentLetterNumber = (columnNumber - 1) % 26;
            char currentLetter = (char)(currentLetterNumber + 65);
            columnString = currentLetter + columnString;
            columnNumber = (columnNumber - (currentLetterNumber + 1)) / 26;
        }
        return columnString;
    }
    /// <summary>
    /// A -> 1<br/>
    /// B -> 2<br/>
    /// C -> 3<br/>
    /// ...
    /// </summary>
    /// <param name="column"></param>
    /// <returns></returns>
    private int NumberFromExcelColumn(string column)
    {
        int retVal = 0;
        string col = column.ToUpper();
        for (int iChar = col.Length - 1; iChar >= 0; iChar--)
        {
            char colPiece = col[iChar];
            int colNum = colPiece - 64;
            retVal = retVal + colNum * (int)Math.Pow(26, col.Length - (iChar + 1));
        }
        return retVal;
    }

}