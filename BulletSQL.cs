using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Reflection;
namespace SAP_Vendor
{
    /// <summary>
    /// MS SQLServer query
    /// </summary>
    public partial class BulletSQL
    {
        #region Declaration
        string connectionString = "";
        SqlConnection connection = null;
        SqlCommand command = null;
        SqlTransaction transaction = null;
        SqlDataAdapter dataAdapter = null;
        #endregion

        #region Properties
        public string ConnectionString
        {
            get { return connectionString; }
            set
            {
                connectionString = connectionString = value;
                //if (Common.GetConnectionStringPart(value, ConnectionStringPart.Provider).Length > 0)
                //    connectionString = Common.GetSqlConnectionString(value);
            }
        }
        public bool IsConnectionOpen
        {
            get
            {
                if (connection != null && ((connection.State & System.Data.ConnectionState.Open) == System.Data.ConnectionState.Open))
                    return true;
                return false;
            }
        }
        public SqlTransaction Transaction
        {
            get { return transaction; }
            set
            {
                transaction = value;
            }
        }
        public bool IsTransaction
        {
            get
            {
                if (transaction == null)
                    return false;
                return true;
            }
        }
        public SqlConnection Connection
        {
            get
            {
                if (connection == null)
                {
                    connection = new SqlConnection(ConnectionString);
                    return connection;
                }
                else if (connection.State == ConnectionState.Closed)
                    connection.ConnectionString = ConnectionString;
                return connection;
            }
            set
            {
                connection = value;
            }
        }
        public SqlCommand Command
        {
            get
            {
                if (command == null)
                {
                    command = Connection.CreateCommand();
                }
                return command;
            }
            set
            {
                command = value;
            }
        }
        public SqlDataAdapter DataAdapter
        {
            get
            {
                if (dataAdapter == null)
                {
                    dataAdapter = new SqlDataAdapter(Command);
                }
                return dataAdapter;
            }
            set
            {
                dataAdapter = value;
            }
        }
        public SqlParameterCollection Parameters
        {
            get
            {
                return Command.Parameters;
            }
        }
        public string CommandText
        {
            get
            {
                return Command.CommandText;
            }
            set
            {
                Command.CommandText = value;
            }
        }
        #endregion

        #region constructors
        public BulletSQL(string SqlConnectionString)
        {
            this.ConnectionString = SqlConnectionString;
            //
            // TODO: Add constructor logic here
            //
        }
        public BulletSQL(SqlCommand _command)
        {
            this.connectionString = _command.Connection.ConnectionString;
            this.connection = _command.Connection;
            this.command = _command;
            this.transaction = _command.Transaction;
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region
        ~BulletSQL()
        {
            Disconnect();
        }
        #endregion

        #region Fuctions
        public bool Connect()
        {
            try
            {
                if (!IsConnectionOpen) Connection.Open();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Close the connection.If Transaction is not committed then rollback the transaction.
        /// </summary>
        public void Disconnect()
        {
            try
            {
                // Disconnect can be called from Dispose and should guarantee no errors

                if (!IsConnectionOpen)
                    return;
                if (IsTransaction)
                    RollbackTransaction();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Connection.Close();
            }


        }
        public void BeginTransaction()
        {
            Connect();
            Transaction = Connection.BeginTransaction();
            Command.Transaction = Transaction;
        }
        /// <summary>
        ///  Save changes on database.
        /// </summary>
        public void CommitTransaction()
        {
            if (IsTransaction)
            {
                Transaction.Commit();
                Transaction = null;
            }
        }
        /// <summary>
        /// do not save changes on database.
        /// </summary>
        public void RollbackTransaction()
        {
            if (IsTransaction)
            {
                Transaction.Rollback();
                Transaction = null;
            }
        }

        public bool FillDataSet(string query, DataSet ds)
        {
            return FillDataSet(query, ds, CommandType.Text);
        }
        public bool FillDataSet(string query, DataSet ds, CommandType commandType)
        {
            try
            {
                CommandText = query;
                Command.CommandType = commandType;
                DataAdapter.Fill(ds);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (!IsTransaction)
                    Disconnect();
            }
        }
        public DataTable GetDataTable(string query)
        {
            return GetDataTable(query, CommandType.Text);
        }
        public DataTable GetDataTable(string query, CommandType commandType)
        {
            try
            {
                CommandText = query;
                Command.CommandType = commandType;
                DataTable dt = new DataTable();
                DataAdapter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (!IsTransaction)
                    Disconnect();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseDataBoundControl"></param>
        /// <param name="query"></param>
        public void Load(BaseDataBoundControl baseDataBoundControl, string query)
        {
            try
            {
                baseDataBoundControl.DataSourceID = "";
                baseDataBoundControl.DataSource = "";
                baseDataBoundControl.DataBind();
                Connect();
                CommandText = query;
                IDataReader rd = Command.ExecuteReader();
                if (rd.FieldCount == 0) return;
                baseDataBoundControl.DataSourceID = "";
                baseDataBoundControl.DataSource = rd;
                if (baseDataBoundControl is ListControl && rd.FieldCount > 0)
                {
                    ListControl lc = (ListControl)baseDataBoundControl;
                    if (lc.DataTextField == "")
                        lc.DataTextField = rd.GetName(0);
                    if (rd.FieldCount > 1 && lc.DataValueField == "")
                        lc.DataValueField = rd.GetName(1);
                }
                baseDataBoundControl.DataBind();
                rd.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (!IsTransaction)
                    Disconnect();
            }
        }
        public void Load(ListControl ddl, string DataTextField, string DataValueField, string query)
        {
            ddl.DataTextField = DataTextField;
            ddl.DataValueField = DataValueField;
            Load(ddl, query);
        }
        public void Load(ListControl ddl, string DataTextField, string DataValueField, string query, ListItem FirstItem)
        {
            ddl.DataTextField = DataTextField;
            ddl.DataValueField = DataValueField;
            Load(ddl, query, FirstItem);
        }
        public void Load(ListControl ddl, string query, ListItem FirstItem)
        {
            Load(ddl, query);
            ddl.Items.Insert(0, FirstItem);
        }
        public void Load(ListControl ddl, string TableName, string DataTextValueField)
        {

            string query = "";
            query = "select distinct  " + DataTextValueField + "  from  " + TableName + " order by " + DataTextValueField;
            Load(ddl, query);
        }
        public void LoadLC(ListControl ddl, string TableName, string DataTextField, string DataValueField)
        {
            string query = "";
            if (DataTextField.Equals(DataValueField, StringComparison.OrdinalIgnoreCase))
            {
                query = "select distinct  " + DataTextField + "  from  " + TableName + " order by " + DataTextField; ;
            }
            else
                query = "select distinct " + DataTextField + "," + DataValueField + "  from  " + TableName + " order by " + DataTextField; ;
            Load(ddl, query);
        }
        public void ExecuteScriptFile(string SriptFilePath)
        {
            FileInfo file = new FileInfo(SriptFilePath);
            string script = file.OpenText().ReadToEnd();
            //Server server = new Server(new ServerConnection(conn));
            //server.ConnectionContext.ExecuteNonQuery(script);
        }



        #endregion

        #region Wraper methods for ADO.NET
        /// <summary>
        /// Open connection before calling this method.Other this method open a connection 
        /// but do not close connection.
        /// </summary>
        /// <param name="sSQL"></param>
        /// <returns></returns>
        public IDataReader ExecuteReader(string sSQL)
        {
            return this.ExecuteReader(sSQL, CommandType.Text);
        }
        /// <summary>
        /// Open connection before calling this method.Other this method open a connection 
        /// but do not close connection.
        /// </summary>
        /// <param name="sSQL"></param>
        /// <param name="oType"></param>
        /// <returns></returns>
        public IDataReader ExecuteReader(string sSQL, CommandType oType)
        {
            try
            {
                Connect();
                CommandText = sSQL;
                Command.CommandType = oType;
                return Command.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {

            }
        }



        public object ExecuteScalar(string sSQL)
        {
            return ExecuteScalar(sSQL, CommandType.Text);
        }
        public object ExecuteScalarDefault(string sSQL, object DefaultValue)
        {
            object value = ExecuteScalar(sSQL);
            if (value == null || value == System.DBNull.Value)
                value = DefaultValue;
            return value;
        }
        public bool IsRecordExist(string sSQL)
        {
            object obj = ExecuteScalar(sSQL, CommandType.Text);
            if (obj != null && obj != System.DBNull.Value) return true;
            return false;
        }
        public bool IsRecordExist(string sSQL, out object value)
        {
            value = null;
            object obj = ExecuteScalar(sSQL, CommandType.Text);
            if (obj != null && obj != System.DBNull.Value)
            {
                value = obj;
                return true;
            }
            return false;
        }
        public object ExecuteScalar(string sSQL, CommandType oType)
        {
            try
            {
                Connect();
                CommandText = sSQL;
                Command.CommandType = oType;
                object obj = Command.ExecuteScalar();
                if (obj != null && obj != System.DBNull.Value)
                {
                    return obj;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (!IsTransaction)
                    Disconnect();
            }
        }
        public int ExecuteNonQuery(string sSQL)
        {
            return ExecuteNonQuery(sSQL, CommandType.Text);
        }

        #region Bullet Methods 
        public int AddObject(object Class)
        {
            string query = "";
            string queryInsert = @"";
            string queryValue = @" Values (";
            try
            {
                ClearParameters();
                Type typClass = Class.GetType();
                queryInsert += @"Insert Into " + typClass.Name + " ( ";
                PropertyInfo[] ptyClass = typClass.GetProperties();
                foreach (PropertyInfo property in ptyClass)
                {
                    AddParameter(property.Name.ToString(), Class.GetType().GetProperty(property.Name).GetValue(Class, null));
                    queryInsert += property.Name + ",";
                    queryValue += "@" + property.Name + ",";
                }
                queryInsert = queryInsert.Remove(queryInsert.Length - 1) + ") ";
                queryValue = queryValue.Remove(queryValue.Length - 1) + ")";
                query = queryInsert + queryValue;
                return ExecuteNonQuery(query, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (!IsTransaction)
                    Disconnect();
            }
        }
        public int AddObject(object Class, string SkipIdentity)
        {
            string query = "";
            string queryInsert = @"";
            string queryValue = @" Values (";
            try
            {
                ClearParameters();
                Type typClass = Class.GetType();
                queryInsert += @"Insert Into " + typClass.Name + " ( ";
                PropertyInfo[] ptyClass = typClass.GetProperties();
                foreach (PropertyInfo property in ptyClass)
                {
                    if (!SkipIdentity.ToLower().Equals(property.Name.ToString().ToLower()))
                    {
                        AddParameter(property.Name.ToString(), Class.GetType().GetProperty(property.Name).GetValue(Class, null));
                        queryInsert += property.Name + ",";
                        queryValue += "@" + property.Name + ",";
                    }
                }
                queryInsert = queryInsert.Remove(queryInsert.Length - 1) + ") ";
                queryValue = queryValue.Remove(queryValue.Length - 1) + ")";
                query = queryInsert + queryValue;
                return ExecuteNonQuery(query, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (!IsTransaction)
                    Disconnect();
            }
        }
        public int AddObjectList(object Class, List<string> SkipIdentitys)
        {
            string query = "";
            string queryInsert = @"";
            string queryValue = @" Values (";
            try
            {
                ClearParameters();
                Type typClass = Class.GetType();
                queryInsert += @"Insert Into " + typClass.Name + " ( ";
                PropertyInfo[] ptyClass = typClass.GetProperties();
                foreach (PropertyInfo property in ptyClass)
                {
                    if (SkipIdentitys.Count > 0)
                    {
                        foreach (string identy in SkipIdentitys)
                        {
                            if (!identy.ToLower().Equals(property.Name.ToString().ToLower()))
                            {
                                AddParameter(property.Name.ToString(), Class.GetType().GetProperty(property.Name).GetValue(Class, null));
                                queryInsert += property.Name + ",";
                                queryValue += "@" + property.Name + ",";
                            }
                        }
                    }
                    else
                    {
                        AddParameter(property.Name.ToString(), Class.GetType().GetProperty(property.Name).GetValue(Class, null));
                        queryInsert += property.Name + ",";
                        queryValue += "@" + property.Name + ",";
                    }
                }
                queryInsert = queryInsert.Remove(queryInsert.Length - 1) + ") ";
                queryValue = queryValue.Remove(queryValue.Length - 1) + ")";
                query = queryInsert + queryValue;
                return ExecuteNonQuery(query, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (!IsTransaction)
                    Disconnect();
            }
        }

        public int UpdateObject(object Class, string WhereID)
        {
            string queryUpdate = @"";
            try
            {
                ClearParameters();
                Type typClass = Class.GetType();
                queryUpdate += @"Update " + typClass.Name + " Set ";
                PropertyInfo[] ptyClass = typClass.GetProperties();
                foreach (PropertyInfo property in ptyClass)
                {
                    AddParameter(property.Name.ToString(), Class.GetType().GetProperty(property.Name).GetValue(Class, null));
                    if (!WhereID.ToLower().Equals(property.Name.ToLower()))
                    {
                        queryUpdate += property.Name + "=@" + property.Name + ",";
                    }
                }
                queryUpdate = queryUpdate.Remove(queryUpdate.Length - 1);
                queryUpdate += " Where " + WhereID + "=@" + WhereID;
                return ExecuteNonQuery(queryUpdate, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (!IsTransaction)
                    Disconnect();
            }
        }
        public int UpdateObjectList(object Class, List<string> WhereID)
        {
            string queryUpdate = @"";
            try
            {
                ClearParameters();
                Type typClass = Class.GetType();
                queryUpdate += @"Update " + typClass.Name + " Set ";
                PropertyInfo[] ptyClass = typClass.GetProperties();

                foreach (PropertyInfo property in ptyClass)
                {
                    AddParameter(property.Name.ToString(), Class.GetType().GetProperty(property.Name).GetValue(Class, null));
                    if (WhereID.Count > 0)
                    {
                        foreach (string ID in WhereID)
                        {
                            if (!ID.ToLower().Equals(property.Name.ToLower()))
                            {
                                queryUpdate += property.Name + "=@" + property.Name + ",";
                            }
                        }
                    }
                    else
                    {
                        queryUpdate += property.Name + "=@" + property.Name + ",";
                    }
                }
                queryUpdate = queryUpdate.Remove(queryUpdate.Length - 1);
                queryUpdate += " Where ";
                for (int i = 0; i < WhereID.Count; i++)
                {
                    queryUpdate += WhereID[i].ToString() + "=@" + WhereID[i].ToString() + " AND ";
                }
                queryUpdate = queryUpdate.Remove(queryUpdate.Length - 4);
                return ExecuteNonQuery(queryUpdate, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (!IsTransaction)
                    Disconnect();
            }
        }

        public bool IsUpdateWhereID(string Property, List<string> WhereID, List<string> UpdateWhereID)
        {
            bool _result = false;
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return _result;
        }
        public int DeleteObject(object Class, string WhereID, string Value)
        {
            string query = @"";
            try
            {
                ClearParameters();
                Type typClass = Class.GetType();
                query = "Delete From " + typClass.Name + " Where " + WhereID + "= @" + WhereID;
                AddParameter(WhereID, Value);
                return ExecuteNonQuery(query, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (!IsTransaction)
                    Disconnect();
            }
        }

        //public object GetTableObject(object Class, string WhereID, string Value)
        //{
        //    string query = "";
        //    object _obj = Class;
        //    try
        //    {
        //        ClearParameters();
        //        Type typClass = Class.GetType();
        //        query = "Select * From " + typClass.Name + " Where " + WhereID + "= @" + WhereID;
        //        AddParameter(WhereID, Value);
        //        DataTable dt = GetDataTable(query);            
        //        if (dt.Rows.Count > 0)
        //        {
        //            PropertyInfo[] ptyClass = _obj.GetType().GetProperties();
        //            foreach (PropertyInfo property in ptyClass)
        //            {
        //                _obj.GetType().GetProperty(property.Name).SetValue(dt, dt.Rows[0][property.Name].ToString(), null);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    finally
        //    {
        //        if (!IsTransaction)
        //            Disconnect();
        //    }
        //    return _obj;
        //}

        public DataTable GetObject(object Class, string WhereID, string Value)
        {
            string query = "";
            DataTable dt = null;
            try
            {
                ClearParameters();
                Type typClass = Class.GetType();
                query = "Select * From " + typClass.Name + " Where " + WhereID + "= @" + WhereID;
                AddParameter(WhereID, Value);
                dt = GetDataTable(query);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (!IsTransaction)
                    Disconnect();
            }
            return dt;
        }



        #endregion

        public int ExecuteNonQuery(string sSQL, CommandType oType)
        {
            try
            {
                Connect();
                CommandText = sSQL;
                Command.CommandType = oType;
                return Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (!IsTransaction)
                    Disconnect();
            }
        }
        public void AddParameter(SqlParameter oParam)
        {
            if (oParam.Value == null)
                oParam.Value = DBNull.Value;
            foreach (SqlParameter par in Command.Parameters)
            {
                if (par.ParameterName.Equals(oParam.ParameterName, StringComparison.OrdinalIgnoreCase))
                {
                    par.Value = oParam.Value;
                    return;
                }
            }
            Command.Parameters.Add(oParam);
        }
        public void AddParameter(string oParam_Name, object value)
        {
            oParam_Name = oParam_Name.Trim();
            if (oParam_Name.Length > 0 && oParam_Name[0] != '@')
            {
                if (char.IsLetterOrDigit(oParam_Name[0]))
                    oParam_Name = "@" + oParam_Name;
                else oParam_Name = "@" + oParam_Name.Remove(0, 1);
            }
            if (value == null || value.ToString() == DateTime.MinValue.ToString())
                value = DBNull.Value;

            foreach (SqlParameter par in Command.Parameters)
            {
                if (par.ParameterName.Equals(oParam_Name, StringComparison.OrdinalIgnoreCase))
                {
                    par.Value = value;
                    return;
                }
            }
            SqlParameter oParam = new SqlParameter(oParam_Name, value);
            Command.Parameters.Add(oParam);
        }
        public void AddParameter(string oParam_Name, object value, bool IsEmptyNull)
        {
            oParam_Name = oParam_Name.Trim();
            if (oParam_Name.Length > 0 && oParam_Name[0] != '@')
            {
                if (char.IsLetterOrDigit(oParam_Name[0]))
                    oParam_Name = "@" + oParam_Name;
                else oParam_Name = "@" + oParam_Name.Remove(0, 1);
            }
            DateTime date = new DateTime();
            if (value == null || value.ToString() == date.ToString())
                value = DBNull.Value;
            else if (IsEmptyNull && value.ToString() == "")
                value = DBNull.Value;


            foreach (SqlParameter par in Command.Parameters)
            {
                if (par.ParameterName.Equals(oParam_Name, StringComparison.OrdinalIgnoreCase))
                {
                    par.Value = value;
                    return;
                }
            }
            SqlParameter oParam = new SqlParameter(oParam_Name, value);
            Command.Parameters.Add(oParam);
        }
        public void AddParameter(string oParam_Name, object value, bool IsEmptyNull, bool IsNullAble)
        {
            oParam_Name = oParam_Name.Trim();
            if (oParam_Name.Length > 0 && oParam_Name[0] != '@')
            {
                if (char.IsLetterOrDigit(oParam_Name[0]))
                    oParam_Name = "@" + oParam_Name;
                else oParam_Name = "@" + oParam_Name.Remove(0, 1);
            }
            DateTime date = new DateTime();
            if (!IsNullAble)// Null Value is not allowed
            {
                if (value == null || value.ToString() == date.ToString())
                {
                    throw new Exception("Invalid " + oParam_Name + "!");
                }
                else if (IsEmptyNull && value.ToString() == "")
                {
                    throw new Exception("Invalid " + oParam_Name + "!");
                }
            }

            if (value == null || value.ToString() == date.ToString())
                value = DBNull.Value;
            else if (IsEmptyNull && value.ToString() == "")
                value = DBNull.Value;

            foreach (SqlParameter par in Command.Parameters)
            {
                if (par.ParameterName.Equals(oParam_Name, StringComparison.OrdinalIgnoreCase))
                {
                    par.Value = value;
                    return;
                }
            }
            SqlParameter oParam = new SqlParameter(oParam_Name, value);
            Command.Parameters.Add(oParam);
        }
        public void ClearParameters()
        {
            Command.Parameters.Clear();
        }
        #endregion

    }
}