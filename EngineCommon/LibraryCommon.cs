using System;
using EngineData;
//using EngineModel;
using System.IO;
using System.Data;
using System.Net.Mail;
using System.Configuration;
using System.Globalization;
using Teq;
using EngineVariable;
using System.Collections.Generic;

namespace EngineCommon
{
    public static class LibraryCommon
    {
        //public static string Format_Boolean(LibraryEnumeration.BooleanValueDisplayOption Option, bool BooleanValue)
        //{
        //    string result = "";
        //    switch (Option)
        //    {
        //        case LibraryEnumeration.BooleanValueDisplayOption.Yes_No:
        //            result = (BooleanValue) ? "Yes" : "No";
        //            break;
        //        case LibraryEnumeration.BooleanValueDisplayOption.True_False:
        //            result = (BooleanValue) ? "True" : "False";
        //            break;
        //        default:
        //            result = "";
        //            break;
        //    }
        //    return result;
        //}
        
        public static DateTime ToLocalTime(DateTime UtcDateTime, double TargetTimeZone)
        {
            return UtcDateTime.AddHours(TargetTimeZone);
        }
        public static void SetDateTimeMode(DataTable DataTable, DataSetDateTime DateTimeMode)
        {
            foreach (DataColumn col in DataTable.Columns)
            {
                if (col.DataType == typeof(DateTime))
                {

                    col.DateTimeMode = DateTimeMode;
                }
            }
        }
      
        public static string GetExcelValue(object CellValue)
        {
            if (CellValue == null)
                return "";
            else
            { 
                string Val = CellValue.ToString().Trim();

                if (Val == "0" || Val == "NA")
                    return "";
                else
                    return Val;
            }
        }
        public static DateTime? GetDate(string Dt)
        {
            if (Dt.Trim() == "")
                return null;
            else
            {
                return Convert.ToDateTime(Dt);
            }
        }
        public static DateTime? ConvertDate(string DateValue)
        {

            //, "MM/dd/yyyy", "M/d/yyyy", "MM/d/yyyy", "M/dd/yyyy", "MM/dd/yyyy", "M/d/yyyy", "MM/d/yyyy", "M/dd/yyyy"
            string[] format = { "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy", "dd/MM/yyyy", "d/M/yy", "dd/M/yy", "d/MM/yy", "dd/MM/yy" };

            DateTime dt;

            if (DateTime.TryParseExact(DateValue, format, new CultureInfo("en-GB"), System.Globalization.DateTimeStyles.None, out dt))
                return dt;
            else
                return null;
        }
        public static int GetMonthValue(string MonthString)
        {
            int MonthValue = 1;
            if (MonthString.ToString().ToUpper() == "JAN" || MonthString.ToString().ToUpper() == "JANUARY")
                MonthValue = 1;
            else if (MonthString.ToString().ToUpper() == "FEB" || MonthString.ToString().ToUpper() == "FEBRUARY")
                MonthValue = 2;
            else if (MonthString.ToString().ToUpper() == "MAR" || MonthString.ToString().ToUpper() == "MARCH")
                MonthValue = 3;
            else if (MonthString.ToString().ToUpper() == "APR" || MonthString.ToString().ToUpper() == "APRIL")
                MonthValue = 4;
            else if (MonthString.ToString().ToUpper() == "MAY")
                MonthValue = 5;
            else if (MonthString.ToString().ToUpper() == "JUN" || MonthString.ToString().ToUpper() == "JUNE")
                MonthValue = 6;
            else if (MonthString.ToString().ToUpper() == "JUL" || MonthString.ToString().ToUpper() == "JULY")
                MonthValue = 7;
            else if (MonthString.ToString().ToUpper() == "AUG" || MonthString.ToString().ToUpper() == "AUGUST")
                MonthValue = 8;
            else if (MonthString.ToString().ToUpper() == "SEP" || MonthString.ToString().ToUpper() == "SEPTEMBER")
                MonthValue = 9;
            else if (MonthString.ToString().ToUpper() == "OCT" || MonthString.ToString().ToUpper() == "OCTOBER")
                MonthValue = 10;
            else if (MonthString.ToString().ToUpper() == "NOV" || MonthString.ToString().ToUpper() == "NOVEMBER")
                MonthValue = 11;
            else if (MonthString.ToString().ToUpper() == "DEC" || MonthString.ToString().ToUpper() == "DECEMBER")
                MonthValue = 12;

            return MonthValue;
        }
        public static DateTime? ConvertImportMonthYear_Date(string DateValue)
        {
            string Month = DateValue.Split(new char[] { '\'' })[0].Trim();
            string Year = DateValue.Split(new char[] { '\'' })[1].Trim();

            int MonthValue = 1;
            if (Month.ToString().ToUpper() == "JAN")
                MonthValue = 1;
            else if (Month.ToString().ToUpper() == "FEB")
                MonthValue = 2;
            else if (Month.ToString().ToUpper() == "MAR")
                MonthValue = 3;
            else if (Month.ToString().ToUpper() == "APR")
                MonthValue = 4;
            else if (Month.ToString().ToUpper() == "MAY")
                MonthValue = 5;
            else if (Month.ToString().ToUpper() == "JUN")
                MonthValue = 6;
            else if (Month.ToString().ToUpper() == "JUL")
                MonthValue = 7;
            else if (Month.ToString().ToUpper() == "AUG")
                MonthValue = 8;
            else if (Month.ToString().ToUpper() == "SEP")
                MonthValue = 9;
            else if (Month.ToString().ToUpper() == "OCT")
                MonthValue = 10;
            else if (Month.ToString().ToUpper() == "NOV")
                MonthValue = 11;
            else if (Month.ToString().ToUpper() == "DEC")
                MonthValue = 12;
            else return null;

            int YearValue = int.Parse(Year) + 2000;

            DateTime dt = new DateTime(YearValue, MonthValue, 1);

            return dt;
        }

        public static DateTime? ConvertMonthYear(string MonthYearValue)
        {
            string[] vals = MonthYearValue.Split(new char[] {'-'}, StringSplitOptions.RemoveEmptyEntries);

            if (vals.Length != 2)
                return null;

            string Month = vals[0].Trim().ToUpper();
            string Year = vals[1].Trim();

            int MonthValue = 0;
            int YearValue = 0;

            if (Month == "JAN")
                MonthValue = 1;
            else if (Month == "FEB")
                MonthValue = 2;
            else if (Month == "MAR")
                MonthValue = 3;
            else if (Month == "APR")
                MonthValue = 4;
            else if (Month == "MAY")
                MonthValue = 5;
            else if (Month == "JUN")
                MonthValue = 6;
            else if (Month == "JUL")
                MonthValue = 7;
            else if (Month == "AUG")
                MonthValue = 8;
            else if (Month == "SEP")
                MonthValue = 9;
            else if (Month == "OCT")
                MonthValue = 10;
            else if (Month == "NOV")
                MonthValue = 11;
            else if (Month == "DEC")
                MonthValue = 12;
            else
                return null;

            if (!int.TryParse(Year, out YearValue))
                return null;

            if (YearValue < 2000 && YearValue > 2100)
                return null;

            DateTime dt = new DateTime(YearValue, MonthValue, 1);
            return dt;
        }

        public static EngineVariable.GenderType ConvertGender(string GenderValue)
        {
            if (GenderValue.ToUpper() == "M")
                return EngineVariable.GenderType.Male;
            else if (GenderValue.ToUpper() == "F")
                return EngineVariable.GenderType.Female;
            else return null;
        }
        public static EngineVariable.NationalityType ConvertNationality(string NationalityValue)
        {
            if (NationalityValue.ToUpper() == "1")
                return EngineVariable.NationalityType.Malaysian;
            else if (NationalityValue.ToUpper() == "2")
                return EngineVariable.NationalityType.Other;
            else return null;
        }
        public static bool? ConvertBoolean(string BoolValue)
        {
            if (BoolValue.ToUpper() == "Y")
                return true;
            else if (BoolValue.ToUpper() == "N")
                return false;
            else return null;
        }
        public static float ConvertFloat(string FloatValue)
        {
            float val = 0;
            if (float.TryParse(FloatValue, out val))
            {
                return val;
            }
            return 0;
        }
        public static decimal ConvertDecimal(string DecimalValue)
        {
            decimal val = 0;
            if (decimal.TryParse(DecimalValue, out val))
            {
                return val;
            }
            return 0;
        }
        public static int ConvertInteger(string IntegerValue)
        {
            int val = 0;
            if (int.TryParse(IntegerValue, out val))
            {
                return val;
            }
            return 0;
        }

        public static string TruncateText(string OriginalText, int MaxLength)
        {
            if (OriginalText.Length <= MaxLength)
                return OriginalText;
            else
            {
                return OriginalText.Remove(MaxLength - 1) + "...";
            }

        }
        
        public static string Convert_MoneyToWord(decimal Amount)
        {

            string sAmount = Amount.ToString(EngineVariable.LibraryVariable.Format_2Decimal);

            int Cent = 0;
            int Dollar = 0;
            int decimalPlace = sAmount.IndexOf(".");

            Dollar = int.Parse(sAmount.Substring(0, decimalPlace));
            Cent = int.Parse(sAmount.Substring(decimalPlace + 1));

            string Word = "";
            if (Dollar > 0)
            {
                Word = NumberToWords(Dollar);
            }
            if (Cent > 0)
            {
                Word += (Word != "" ? " & " : "") + NumberToWords(Cent) + " Cent";
            }

            return "RINGGIT MALAYSIA " + Word.ToUpper();
        }
        public static string NumberToWords(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }

        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();

            // If the source directory does not exist, throw an exception.
            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            // If the destination directory does not exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }


            // Get the file contents of the directory to copy.
            FileInfo[] files = dir.GetFiles();

            foreach (FileInfo file in files)
            {
                // Create the path to the new copy of the file.
                string temppath = Path.Combine(destDirName, file.Name);

                // Copy the file.
                if (!File.Exists(temppath)) file.CopyTo(temppath, false);

            }

            // If copySubDirs is true, copy the subdirectories.
            if (copySubDirs)
            {

                foreach (DirectoryInfo subdir in dirs)
                {
                    // Create the subdirectory.
                    string temppath = Path.Combine(destDirName, subdir.Name);

                    // Copy the subdirectories.
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }

        public static string DisplayCurrentUser(string CurrentUserName)
        {
            if(CurrentUserName.Trim().Length > 20)
            {
                return CurrentUserName.Substring(0, 20) + "...";
            }
            else

            {
                return CurrentUserName;
            }
        }

        public static string SendEmail(string sendTo, string bccTo, string body, string subject)
        {
            return SendEmail(sendTo, bccTo, body, subject, ConfigurationManager.AppSettings["Email_SenderEmail"].ToString(), ConfigurationManager.AppSettings["Email_SenderName"].ToString());
        }
        public static string SendEmail(string sendTo, string bccTo, string body, string subject, string senderEmail, string senderName)
        {
            MailMessage myEmail = new MailMessage();
            SmtpClient mySMTPClient = new SmtpClient();
            try
            {
                myEmail.BodyEncoding = System.Text.Encoding.UTF8;
                myEmail.SubjectEncoding = System.Text.Encoding.UTF8;
                myEmail.From = new MailAddress(senderEmail, senderName); //Specify Sender Email and Name
                myEmail.To.Add(sendTo); //Specify Recipient Email
                if (bccTo != "")
                    myEmail.Bcc.Add(bccTo);
                myEmail.Subject = subject; //Specify Email Subject
                myEmail.IsBodyHtml = true;
                myEmail.Body = body; //Specify Email Body

                mySMTPClient.Host = ConfigurationManager.AppSettings["Email_Server"]; //Specify SMTP Host Name
                mySMTPClient.Port = int.Parse(ConfigurationManager.AppSettings["Email_Port"]);
                System.Net.NetworkCredential basicAuthentication = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["Email_Sender"].ToString(), ConfigurationManager.AppSettings["Email_SenderPassword"].ToString()); //Specify Username and Password 
                mySMTPClient.UseDefaultCredentials = false;
                mySMTPClient.EnableSsl = bool.Parse(ConfigurationManager.AppSettings["Email_SSL"]);
                //mySMTPClient.Credentials = basicAuthentication;
                mySMTPClient.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["Email_Sender"].ToString(), ConfigurationManager.AppSettings["Email_SenderPassword"].ToString());
                mySMTPClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                mySMTPClient.Send(myEmail);
                return "";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public static string GetEmailContent_InterviewAssessmentInvitation(ApplicationRow drApplication, AssessmentSessionRow drAssessmentSession)
        {
            string emailcontentpath = ConfigurationManager.AppSettings["EmailContent"].ToString();

            string content = File.ReadAllText(Path.Combine(emailcontentpath, "InterviewAssessmentInvitation.html"));

            content = content.Replace("@FullName", drApplication.Application_FullName);
            content = content.Replace("@Location", drAssessmentSession.AssessmentSession_Location);
            content = content.Replace("@Date", drAssessmentSession.AssessmentSession_DateTime.ToString(EngineVariable.LibraryVariable.Format_Date));
            content = content.Replace("@Time", drAssessmentSession.AssessmentSession_DateTime.ToString(EngineVariable.LibraryVariable.Format_Time));
            content = content.Replace("@AcceptURL", ConfigurationManager.AppSettings["EmailResponseServerURL"].ToString()+"?ApplicationID="+drApplication.Application_ID.ToString()+"&ResponseType="+ EmailResponseType.InterviewInvitation.Code.ToString()+ "&Accept=true");
            content = content.Replace("@RejectURL", ConfigurationManager.AppSettings["EmailResponseServerURL"].ToString() + "?ApplicationID=" + drApplication.Application_ID.ToString() + "&ResponseType=" + EmailResponseType.InterviewInvitation.Code.ToString() + "&Accept=false");
            content = content.Replace("@LogoURL", ConfigurationManager.AppSettings["LogoURL"].ToString());
            return content;
        }
        public static string GetEmailContent_AssessmentInvitation(ApplicationRow drApplication, AssessmentSessionRow drAssessmentSession)
        {
            string emailcontentpath = ConfigurationManager.AppSettings["EmailContent"].ToString();

            string content = File.ReadAllText(Path.Combine(emailcontentpath, "AssessmentInvitation.html"));

            content = content.Replace("@FullName", drApplication.Application_FullName);
            content = content.Replace("@Location", drAssessmentSession.AssessmentSession_Location);
            content = content.Replace("@Date", drAssessmentSession.AssessmentSession_DateTime.ToString(EngineVariable.LibraryVariable.Format_Date));
            content = content.Replace("@Time", drAssessmentSession.AssessmentSession_DateTime.ToString(EngineVariable.LibraryVariable.Format_Time));
            content = content.Replace("@AcceptURL", ConfigurationManager.AppSettings["EmailResponseServerURL"].ToString() + "?ApplicationID=" + drApplication.Application_ID.ToString() + "&ResponseType=" + EmailResponseType.AssessmentInvitation.Code.ToString() + "&Accept=true");
            content = content.Replace("@RejectURL", ConfigurationManager.AppSettings["EmailResponseServerURL"].ToString() + "?ApplicationID=" + drApplication.Application_ID.ToString() + "&ResponseType=" + EmailResponseType.AssessmentInvitation.Code.ToString() + "&Accept=false");
            content = content.Replace("@LogoURL", ConfigurationManager.AppSettings["LogoURL"].ToString());
            return content;
        }
        public static string GetEmailContent_RegistrationImport(CandidateRow drCandidate)
        {
            string emailcontentpath = ConfigurationManager.AppSettings["EmailContent"].ToString();
            
            string content = File.ReadAllText(Path.Combine(emailcontentpath, "RegistrationImport.html"));

            content = content.Replace("@FullName", drCandidate.Candidate_FullName);
            content = content.Replace("@Username", drCandidate.Candidate_UserID);
            content = content.Replace("@Password", drCandidate.Candidate_Password);
            content = content.Replace("@CandidateLoginURL", ConfigurationManager.AppSettings["CandidateLoginURL"].ToString());
            content = content.Replace("@LogoURL", ConfigurationManager.AppSettings["LogoURL"].ToString());

            return content;
        }
        public static string GetEmailContent_ConditionalLetterOfOffer(ApplicationRow drApplication)
        {
            string emailcontentpath = ConfigurationManager.AppSettings["EmailContent"].ToString();

           
            //return HTML;
            string content = File.ReadAllText(Path.Combine(emailcontentpath, "ConditionalLetterOfOffer.html"));
            content = content.Replace("@AcceptURL", ConfigurationManager.AppSettings["EmailResponseServerURL"].ToString() + "?ApplicationID=" + drApplication.Application_ID.ToString() + "&ResponseType=" + EmailResponseType.CLO.Code.ToString() + "&Accept=true");
            content = content.Replace("@RejectURL", ConfigurationManager.AppSettings["EmailResponseServerURL"].ToString() + "?ApplicationID=" + drApplication.Application_ID.ToString() + "&ResponseType=" + EmailResponseType.CLO.Code.ToString() + "&Accept=false");
            content = content.Replace("@FullName", drApplication.Application_FullName);
            content = content.Replace("@CLOURL", ConfigurationManager.AppSettings["EmailCLOURL"].ToString() + "?ApplicationID=" + drApplication.Application_ID.ToString());
            content = content.Replace("@LogoURL", ConfigurationManager.AppSettings["LogoURL"].ToString());
            return content;
        }
        public static string GetEmailContent_LetterOfOffer(ApplicationRow drApplication)
        {
            string emailcontentpath = ConfigurationManager.AppSettings["EmailContent"].ToString();

            string content = File.ReadAllText(Path.Combine(emailcontentpath, "LetterOfOffer.html"));

            content = content.Replace("@FullName", drApplication.Application_FullName);
            content = content.Replace("@AcceptURL", ConfigurationManager.AppSettings["EmailResponseServerURL"].ToString() + "?ApplicationID=" + drApplication.Application_ID.ToString() + "&ResponseType=" + EmailResponseType.LO.Code.ToString() + "&Accept=true");
            content = content.Replace("@RejectURL", ConfigurationManager.AppSettings["EmailResponseServerURL"].ToString() + "?ApplicationID=" + drApplication.Application_ID.ToString() + "&ResponseType=" + EmailResponseType.LO.Code.ToString() + "&Accept=false");
            content = content.Replace("@LOURL", ConfigurationManager.AppSettings["EmailLOURL"].ToString() + "?ApplicationID=" + drApplication.Application_ID.ToString());
            content = content.Replace("@LogoURL", ConfigurationManager.AppSettings["LogoURL"].ToString());
            return content;
          

            //return HTML;
        }
        public static string GetEmailContent_Registration(CandidateRow drCandidate)
        {
            string emailcontentpath = ConfigurationManager.AppSettings["EmailContent"].ToString();

            string content = File.ReadAllText(Path.Combine(emailcontentpath, "Registration.html"));

            content = content.Replace("@FullName", drCandidate.Candidate_FullName);
            content = content.Replace("@Username", drCandidate.Candidate_UserID);
            content = content.Replace("@CandidateLoginURL", ConfigurationManager.AppSettings["CandidateLoginURL"].ToString());
            content = content.Replace("@LogoURL", ConfigurationManager.AppSettings["LogoURL"].ToString());
            return content;
        }
        public static string GetEmailContent_PartTimerAssessment(ApplicationRow drApplication, PartTimerAssessmentSessionRow drPartTimerAssessmentSession)
        {
            string emailcontentpath = ConfigurationManager.AppSettings["EmailContent"].ToString();

            string content = File.ReadAllText(Path.Combine(emailcontentpath, "PartTimerAssessment.html"));

            content = content.Replace("@FullName", drApplication.Application_FullName);
            content = content.Replace("@Location", drPartTimerAssessmentSession.PartTimerAssessmentSession_Location);
            content = content.Replace("@Date", drPartTimerAssessmentSession.PartTimerAssessmentSession_DateTime.ToString(EngineVariable.LibraryVariable.Format_Date));
            content = content.Replace("@Time", drPartTimerAssessmentSession.PartTimerAssessmentSession_DateTime.ToString(EngineVariable.LibraryVariable.Format_Time));
            content = content.Replace("@AcceptURL", ConfigurationManager.AppSettings["EmailResponseServerURL"].ToString() + "?ApplicationID=" + drApplication.Application_ID.ToString() + "&ResponseType=" + EmailResponseType.PartTimerAssessment.Code.ToString() + "&Accept=true");
            content = content.Replace("@RejectURL", ConfigurationManager.AppSettings["EmailResponseServerURL"].ToString() + "?ApplicationID=" + drApplication.Application_ID.ToString() + "&ResponseType=" + EmailResponseType.PartTimerAssessment.Code.ToString() + "&Accept=false");
            content = content.Replace("@LogoURL", ConfigurationManager.AppSettings["LogoURL"].ToString());

            return content;
        }
        public static string GetEmailContent_PartTimerCDP(ApplicationRow drApplication, PartTimerAssessmentSessionRow drPartTimerAssessmentSession)
        {
            string emailcontentpath = ConfigurationManager.AppSettings["EmailContent"].ToString();

            string content = File.ReadAllText(Path.Combine(emailcontentpath, "PartTimerCDP.html"));

            content = content.Replace("@FullName", drApplication.Application_FullName);
            content = content.Replace("@Location", drPartTimerAssessmentSession.PartTimerAssessmentSession_Location);
            content = content.Replace("@Date", drPartTimerAssessmentSession.PartTimerAssessmentSession_DateTime.ToString(EngineVariable.LibraryVariable.Format_Date));
            content = content.Replace("@Time", drPartTimerAssessmentSession.PartTimerAssessmentSession_DateTime.ToString(EngineVariable.LibraryVariable.Format_Time));
            content = content.Replace("@AcceptURL", ConfigurationManager.AppSettings["EmailResponseServerURL"].ToString() + "?ApplicationID=" + drApplication.Application_ID.ToString() + "&ResponseType=" + EmailResponseType.PartTimerCDP.Code.ToString() + "&Accept=true");
            content = content.Replace("@RejectURL", ConfigurationManager.AppSettings["EmailResponseServerURL"].ToString() + "?ApplicationID=" + drApplication.Application_ID.ToString() + "&ResponseType=" + EmailResponseType.PartTimerCDP.Code.ToString() + "&Accept=false");
            content = content.Replace("@LogoURL", ConfigurationManager.AppSettings["LogoURL"].ToString());

            return content;
        }
        public static string GetEmailContent_PartTimerInterview(ApplicationRow drApplication, PartTimerAssessmentSessionRow drPartTimerAssessmentSession)
        {
            string emailcontentpath = ConfigurationManager.AppSettings["EmailContent"].ToString();

            string content = File.ReadAllText(Path.Combine(emailcontentpath, "PartTimerInterview.html"));

            content = content.Replace("@FullName", drApplication.Application_FullName);
            content = content.Replace("@Location", drPartTimerAssessmentSession.PartTimerAssessmentSession_Location);
            content = content.Replace("@Date", drPartTimerAssessmentSession.PartTimerAssessmentSession_DateTime.ToString(EngineVariable.LibraryVariable.Format_Date));
            content = content.Replace("@Time", drPartTimerAssessmentSession.PartTimerAssessmentSession_DateTime.ToString(EngineVariable.LibraryVariable.Format_Time));
            content = content.Replace("@AcceptURL", ConfigurationManager.AppSettings["EmailResponseServerURL"].ToString() + "?ApplicationID=" + drApplication.Application_ID.ToString() + "&ResponseType=" + EmailResponseType.PartTimerInterview.Code.ToString() + "&Accept=true");
            content = content.Replace("@RejectURL", ConfigurationManager.AppSettings["EmailResponseServerURL"].ToString() + "?ApplicationID=" + drApplication.Application_ID.ToString() + "&ResponseType=" + EmailResponseType.PartTimerInterview.Code.ToString() + "&Accept=false");
            content = content.Replace("@LogoURL", ConfigurationManager.AppSettings["LogoURL"].ToString());

            return content;
        }
        public static string GetEmailContent_CandidatePasswordRetrieve(CandidateRow drCandidate)
        {
            string emailcontentpath = ConfigurationManager.AppSettings["EmailContent"].ToString();

            string content = File.ReadAllText(Path.Combine(emailcontentpath, "CandidatePasswordRetrieve.html"));

            content = content.Replace("@FullName", drCandidate.Candidate_FullName);
            content = content.Replace("@Username", drCandidate.Candidate_UserID);
            content = content.Replace("@Password", drCandidate.Candidate_Password);
            content = content.Replace("@CandidateLoginURL", ConfigurationManager.AppSettings["CandidateLoginURL"].ToString());
            content = content.Replace("@LogoURL", ConfigurationManager.AppSettings["LogoURL"].ToString());
            return content;
        }
        public static bool Validate_AccessRight(string Permissions, EngineVariable.PermissionType PageType)
        {
            string[] PermissionCollection = Permissions.Split(new char[] { ';' });
            
            List<string> list = new List<string>(PermissionCollection);
            return list.Contains(((int)PageType).ToString());
        }
    }
}