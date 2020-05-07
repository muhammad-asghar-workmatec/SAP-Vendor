using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace SAP_Vendor
{
    /// <summary>
    /// Summary description for WebConfig
    /// </summary>
    public class Settings
    {
        //private Settings(){} 
        string query = "";
        public static string MAXIMOConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["MAXIMOConnectionString"].ConnectionString;
            }
        }
        public static string BPMConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["BPMConnectionString"].ConnectionString;
            }
        }

        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            }
        }

        

        public string GetFilePath(string ID, string path)
        {
            string _path = "";
            try
            {

                string _folderPath = path + @"\Documents\" + ID;

                string _serverpath = GetApplicationPath() + @"/Documents/" + ID + @"/";
                DirectoryInfo dir = new DirectoryInfo(_folderPath);
                // DirectoryInfo _folder = new DirectoryInfo(_folderPath);

                if (dir.Exists)
                {
                    FileInfo[] bmpfiles = dir.GetFiles();
                    foreach (FileInfo f in bmpfiles)
                    {
                        _path = _serverpath + f.Name;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return _path;
        }


        public string GetApplicationPath()
        {
            return "http://" + HttpContext.Current.Request.Url.Host + HttpContext.Current.Request.ApplicationPath + @"/";
        }

        public bool IsExistAttachment(string ID, string path)
        {
            bool _result = false;
            try
            {


                string _folderPath = path + @"\Documents\" + ID;
                DirectoryInfo _folder = new DirectoryInfo(_folderPath);
                if (_folder.Exists)
                    _result = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return _result;
        }

        public SqlDataReader GetGroupUsers(string _Group)
        {
            string query = "";
            SqlConnection dbConn = new SqlConnection(BPMConnectionString);
            SqlCommand comTravel = dbConn.CreateCommand();
            query = "Select T5F0001 From T00005 Where T5F0002 = '" + _Group + "'";
            comTravel.CommandText = query;
            try
            {
                dbConn.Open();
                SqlDataReader drTravel = comTravel.ExecuteReader();
                drTravel.Read();
                int GroupID = (int)drTravel[0];
                drTravel.Close();
                query = "SELECT T00009.T9F0007,T00004.T4F0003 FROM T00004 INNER JOIN T00009 ON T00004.T4F0003 = T00009.T9F0003 Where T00004.T4F0002=" + GroupID + " Order By T00009.T9F0007";
                comTravel.CommandText = query;
                drTravel = comTravel.ExecuteReader(CommandBehavior.CloseConnection);
                return drTravel;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string GetUserBPM_Name(string UserID)
        {
            SqlDataReader drTravel;
            string UserName = "";
            try
            {
                SqlConnection dbConn = new SqlConnection(BPMConnectionString);
                SqlCommand comTravel = dbConn.CreateCommand();
                query = "Select T9F0007 From T00009 Where T9F0003 = '" + UserID + "'";
                comTravel.CommandText = query;
                dbConn.Open();
                drTravel = comTravel.ExecuteReader();
                if (drTravel.Read())
                    UserName = drTravel[0].ToString();
                drTravel.Close();
                dbConn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return UserName;
        }
        public string FormatEmployeeNumber(string EmpNo)
        {
            string _result = "";
            try
            {
                switch (EmpNo.Length)
                {
                    case 1:
                        _result = "0000000" + EmpNo;
                        break;
                    case 2:
                        _result = "000000" + EmpNo;
                        break;
                    case 3:
                        _result = "00000" + EmpNo;
                        break;
                    case 4:
                        _result = "0000" + EmpNo;
                        break;
                    case 5:
                        _result = "000" + EmpNo;
                        break;
                    case 6:
                        _result = "00" + EmpNo;
                        break;
                    case 7:
                        _result = "0" + EmpNo;
                        break;
                    case 8:
                        _result = EmpNo;
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return _result;
        }
        public int GetDays(DateTime StartDate, DateTime EndDate)
        {
            int _days = 0;
            try
            {
                TimeSpan t1 = StartDate - EndDate;
                _days = t1.Days;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return _days;
        }
        public bool IsNumeric(object num)
        {
            double tempResult;
            return IsNumeric(num, out tempResult);
        }

        public bool IsNumeric(object num, out double result)
        {
            return Double.TryParse(num.ToString(), System.Globalization.NumberStyles.Any,
              System.Globalization.NumberFormatInfo.InvariantInfo, out result);
        }
        public string GetRating(string RateNum)
        {
            string result = "";
            try
            {
                switch (RateNum)
                {
                    case "1":
                        result = "Below Average";
                        break;
                    case "2":
                        result = "Average";
                        break;
                    case "3":
                        result = "Good";
                        break;
                    case "4":
                        result = "Very Good";
                        break;
                    case "5":
                        result = "Exceptional";
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
        public static string GetProcessName
        {
            get
            {
                return "Technical Query";
            }
        }
        static public string BPM_URL => ConfigurationManager.AppSettings["BPM_URL"].ToString();

        public static string ApproverGroup => ConfigurationManager.AppSettings["ApproverGroup"].ToString();
    }
    public class WebConfig : Settings
    {
        private WebConfig() { }
    }
    public class AppSettings : Settings
    {
        private AppSettings() { }
    }
    
}