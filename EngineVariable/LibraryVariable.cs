    using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.IO;

namespace EngineVariable
{
    public static class LibraryVariable
    {
        public static string System_Version
        {
            get
            {
                return "In Development";
            }
        }
        public static int System_Year
        {
            get
            {
                return 2015;
            }
        }
        public static string System_Company
        {
            get
            {
                return "Infinitas Technologies (M) Sdn. Bhd.";
            }
        }
        public static string System_Name
        {
            get
            {
                return "eCase";
            }
        }

        public static string Format_Money
        {
            get
            {
                return "###,###,###,###,##0.00";
            }
        }
        public static string Format_2Decimal
        {
            get
            {
                return "0.00";
            }
        }
        public static string Format_Number
        {
            get
            {
                return "###,###,###,###,##0";
            }
        }
        public static string Format_Date
        {
            get
            {
                return "dd-MMM-yyyy";
            }
        }
        public static string Format_DateTime
        {
            get
            {
                return "dd-MMM-yyyy HH:mm";
            }
        }
        public static string Format_GSTFormDate
        {
            get
            {
                return "dd-MM-yyyy";
            }
        }
        public static string Format_Time
        {
            get
            {
                return "HH:mm";
            }
        }
        public static string Format_Time_Picker
        {
            get
            {
                return "hh\\:mm";
            }
        }
        public static string Format_Date_Picker
        {
            get
            {
                return "dd-M-yyyy";
            }
        }

        public static int Setting_MaxLogoWidth
        {
            get
            {
                return 300;
            }
        }
        public static int Setting_MaxLogoHeight
        {
            get
            {
                return 250;
            }
        }

        public static string Default_SelectOneText
        {
            get
            {
                return "-- Select One --";
            }
        }
        public static string Default_SelectAllText
        {
            get
            {
                return "-- Select All --";
            }
        }
        public static string Default_SelectValue
        {
            get
            {
                return "-1";
            }
        }
        public static int Default_SubscriptionExpiryDay
        {
            get
            {
                return 14;
            }
        }

        public static string Default_InvoicePrefix
        {
            get
            {
                return "INV";
            }
        }
        public static string Default_PaymentVoucherPrefix
        {
            get
            {
                return "PV";
            }
        }
        public static string Default_PaymentReceiptPrefix
        {
            get
            {
                return "PR";
            }
        }
        public static string Default_DocumentNumberLengthPrefix
        {
            get
            {
                return "000000";
            }
        }

        public static int Page_Size
        {
            get
            {
                return 15;
            }
        }
        public static double User_TimeZone
        {
            get
            {
                return 8;
            }
        }
        public static string Message_SavedSuccessfully
        {
            get
            {
                return "Saved Successfully.";
            }
        }
        public static string Message_RecordDeletedSuccessfully
        {
            get
            {
                return "Record Deleted Successfully.";
            }
        }
        public static string Message_ProcessRequestError
        {
            get
            {
                return "Error occured while processing your request.";
            }
        }

        public static string Folder_FileStorage
        {
            get
            {
                return "FileStorage";
            }
        }
        public static string Folder_TaskFileStorage
        {
            get
            {
                return Folder_FileStorage + "/Task";
            }
        }
        public static string Folder_CaseTaskFileStorage
        {
            get
            {
                return Folder_FileStorage + "/CaseTask";
            }
        }
        public static string Folder_DocumentFileStorage
        {
            get
            {
                return Folder_FileStorage + "/Document";
            }
        }
        public static string Folder_DocumentCenterFileStorage
        {
            get
            {
                return Folder_FileStorage + "/DocumentCenter";
            }
        }
        public static string Folder_LogoStorage
        {
            get
            {
                return Folder_FileStorage + "/Logo";
            }
        }
        public static string Folder_PaymentReceiptStorage
        {
            get
            {
                return Folder_FileStorage + "/PaymentReceipt";
            }
        }
        public static int Upload_FileSize
        {
            get
            {
                int maxRequestLength = 0;
                HttpRuntimeSection section =
                ConfigurationManager.GetSection("system.web/httpRuntime") as HttpRuntimeSection;
                if (section != null)
                    maxRequestLength = section.MaxRequestLength;

                return maxRequestLength;
            }
        }

        public static string Folder_Temporary
        {
            get
            {
                return "Temporary";
            }
        }

        public static string Report_Bill
        {
            get
            {
                return "Bill.rdlc";
            }
        }
        public static string Report_Invoice
        {
            get
            {
                return "Invoice.rdlc";
            }
        }
        public static string Report_PaymentReceipt
        {
            get
            {
                return"PaymentReceipt.rdlc";
            }
        }
        public static string Report_PaymentVoucher
        {
            get
            {
                return "PaymentVoucher.rdlc";
            }
        }

        public static DateTime Empty_DateTime
        {
            get
            {
                return new DateTime(1900, 1, 1);
            }
        }

        /// <summary>
        /// interval in days
        /// </summary>
        public static int MinimumApplicationSubmittedInterval
        {
            get
            {
                return 365;
            }
        }
        public static int MinimumExamPassingMark
        {
            get
            {
                return 50;
            }
        }
    }
}
