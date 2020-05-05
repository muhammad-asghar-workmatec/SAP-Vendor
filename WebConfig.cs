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

/// <summary>
/// Summary description for WebConfig
/// </summary>
public class WebConfig
{
    string query = "";
    public WebConfig()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static string OracleConnectionString
    {
        get
        {
            return ConfigurationManager.ConnectionStrings["MAXIMOConnectionString"].ConnectionString;
        }
    }
    public static string SUNConnectionString
    {
        get
        {
            return ConfigurationManager.ConnectionStrings["SUNConnectionString"].ConnectionString;           
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

            string _folderPath = path + @"\Upload Files\" + ID;

            string _serverpath = GetApplicationPath() + @"/Upload Files/" + ID + @"/";
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


            string _folderPath = path + @"\Upload Files\" + ID;
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

    public string GetUserBPM_Email(string UserID)
    {
        SqlDataReader drTravel;
        string _Email = "";
        try
        {
            SqlConnection dbConn = new SqlConnection(BPMConnectionString);
            SqlCommand comTravel = dbConn.CreateCommand();
            query = "Select T12F0009 From T00012 Where T12F0001 = '" + UserID + "'";
            comTravel.CommandText = query;
            dbConn.Open();
            drTravel = comTravel.ExecuteReader();
            if (drTravel.Read())
                _Email = drTravel[0].ToString();
            drTravel.Close();
            dbConn.Close();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        return _Email;
    }

}
