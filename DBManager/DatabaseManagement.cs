using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SimpleCart.DBManager
{
    public class DatabaseManagement
    {
        private string strConnectionString = "";
        public SqlConnection sqlConnection;
        private SqlDataAdapter sqlDataAdapter;
        private SqlCommand sqlCommand;
        private SqlTransaction sqlTransaction;

        /// <summary>
        /// Get or Set the ConnectionString property.
        /// </summary>
        public string ConnectionString
        {
            get { return strConnectionString; }
            set { strConnectionString = value; }
        }
        /// <summary>
        /// Get or Set the CommandText property.
        /// </summary>
        public string SQLCommandText
        {
            get { return sqlCommand.CommandText; }
            set
            {
                if (sqlCommand == null)

                    sqlCommand = new SqlCommand();
                sqlCommand.CommandText = value;
            }
        }
        public DatabaseManagement()
        {
            strConnectionString = ConfigurationManager.ConnectionStrings["_myCartConnection"].ConnectionString;
            if (strConnectionString == null)
            {
                throw new ArgumentException("Connection string has not been initialized.");
            }
            else
            {
                sqlConnection = new SqlConnection(strConnectionString);
            }

        }

        public DatabaseManagement(string ConnectionString)
        {
            if (ConnectionString == null)
            {
                throw new ArgumentException("Connection string has not been initialized.");
            }
            else
            {
                sqlConnection = new SqlConnection(ConnectionString);

            }

        }
        /// <summary>
        /// Query the database and returns a DataSet. Accept SQLCommand text and TableName as parameter.
        /// Use this function for short SQL queries.
        /// </summary>
        /// <param name="SQLCommand">SQL Query in the Text form.</param>
        /// <param name="TableName">TableName for the DataSet</param>
        /// <returns>DataSet</returns>
        public DataSet GetRecords(string SQLCommand, string TableName)
        {
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }

                DataSet ds = new DataSet();
                sqlCommand = new SqlCommand();
                sqlCommand.CommandText = SQLCommand;
                sqlDataAdapter = new SqlDataAdapter(SQLCommand, sqlConnection);
                sqlDataAdapter.Fill(ds, TableName);

                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }

        }
        public DataSet GetRecords(SqlCommand command, string TableName)
        {
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }

                DataSet ds = new DataSet();
                sqlCommand = command;
                sqlCommand.Connection = sqlConnection;
                sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(ds, TableName);

                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }

        }

        public DataSet GetRecords(SqlCommand command)
        {
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }

                DataSet ds = new DataSet();
                sqlCommand = command;
                sqlCommand.Connection = sqlConnection;
                sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(ds);

                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }

        }
        /// <summary>
        /// Query the database and returns a DataSet. Set the DatabaseManagement.SQLCommandText property before
        /// calling this method. Use this method for long SQL queries.
        /// </summary>
        /// <param name="TableName">TableName for the DataSet</param>
        /// <returns>DataSet</returns>
        public DataSet GetRecords(string TableName)
        {
            try
            {

                if (this.sqlCommand.CommandText == "")
                {
                    throw new ArgumentNullException("SQLCommandText property of DatabaseManagement class cannot be an empty string.");
                }
                else
                {
                    if (sqlConnection.State == ConnectionState.Closed)
                    {
                        sqlConnection.Open();
                    }

                    DataSet ds = new DataSet();
                    sqlDataAdapter = new SqlDataAdapter(this.sqlCommand.CommandText, sqlConnection);
                    sqlDataAdapter.Fill(ds, TableName);

                    return ds;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }

        }

        public DataTable GetDataTable(string sqlQuery)
        {
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }

                DataTable dt = new DataTable();
                sqlCommand = new SqlCommand();
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = sqlQuery;
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandTimeout = 0;
                sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dt);

                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
                //return ex.Message;
            }
            finally
            {
                sqlConnection.Close();
            }

        }

        public DataTable GetDataTable(SqlCommand command)
        {
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }

                DataTable dt = new DataTable();
                sqlCommand = command;
                sqlCommand.CommandTimeout = 0;
                sqlCommand.Connection = sqlConnection;
                sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dt);

                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }

        }

        /// <summary>
        /// Runs a StoredProcedure of SQLServer and returns a dataset
        /// </summary>
        /// <param name="TableName">string</param>
        /// <param name="commandType">CommandType</param>
        /// <param name="commandText">string</param>
        /// <returns></returns>
        public DataSet GetRecords(string TableName, CommandType commandType, string commandText)
        {
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }

                DataSet ds = new DataSet();
                if (this.sqlCommand == null)
                    this.sqlCommand = new SqlCommand();
                this.sqlCommand.Connection = this.sqlConnection;
                this.sqlCommand.CommandType = commandType;
                this.sqlCommand.CommandText = commandText;
                this.sqlCommand.CommandTimeout = 0;
                sqlDataAdapter = new SqlDataAdapter(this.sqlCommand);
                sqlDataAdapter.Fill(ds, TableName);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();

            }

        }
        /// <summary>
        /// Query the database and return bool if SQLCommand has rows for the specified SQL query.
        /// Use this method for short SQL queries.
        /// </summary>
        /// <param name="SQLString">SQL query in the text form.</param>
        /// <returns>true if SQLCommand has rows and false if no rows are returned.</returns>
        public bool RecordExist(string SQLString)
        {
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }

                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = SQLString;
                return sqlCommand.ExecuteReader().HasRows;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
                sqlCommand = null;
            }
        }

        public SqlDataReader ExecuteReader(String SQLString)
        {
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }

                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = SQLString;
                return sqlCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                sqlCommand = null;
                throw ex;
            }
        }

        /// <summary>
        /// Get DataTabl using Store Procedure
        /// </summary>
        /// <param name="Command"></param>
        /// <returns></returns>

        public DataTable GetRecords(string StoreProcedureName, SqlParameter[] sqlparms)
        {
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }
                sqlDataAdapter = new SqlDataAdapter(StoreProcedureName, sqlConnection);
                sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter sqlparm in sqlparms)
                {
                    sqlDataAdapter.SelectCommand.Parameters.Add(sqlparm);
                }
                DataSet _ds = new DataSet();
                DataTable dt = new DataTable();
                sqlDataAdapter.Fill(_ds);
                sqlDataAdapter.Dispose();
                if (_ds.Tables.Count > 0)
                {
                    dt = _ds.Tables[0];
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public string GetRecord(string StoreProcedureName, SqlParameter[] sqlparms)
        {
            try
            {
                string strValue = string.Empty;
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }
                sqlDataAdapter = new SqlDataAdapter(StoreProcedureName, sqlConnection);
                sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter sqlparm in sqlparms)
                {
                    sqlDataAdapter.SelectCommand.Parameters.Add(sqlparm);
                }
                DataSet _ds = new DataSet();
                DataTable dt = new DataTable();
                sqlDataAdapter.Fill(_ds);
                sqlDataAdapter.Dispose();
                if (_ds.Tables.Count > 0)
                {
                    dt = _ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        strValue = dt.Rows[0][0].ToString();
                    }
                }
                return strValue;
            }
            catch (Exception ex)
            {
                throw ex;
                // return string.Empty;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public SqlDataReader ExecuteSPReader(SqlCommand Command)
        {
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }


                //Note: sqlCommand can be set either in here or in AddSqlParameterToCommandObject method 
                this.sqlCommand = Command;
                this.sqlCommand.Connection = this.sqlConnection;
                return this.sqlCommand.ExecuteReader();

            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                sqlCommand = null;
                throw ex;
            }
        }
        /// <summary>
        /// Query the database and return bool if SQLCommand has rows for the specified SQL query.
        /// Set the DatabaseManagement.SQLCommandText property before calling this method. 
        /// Use this method for long SQL queries.
        /// </summary>
        /// <returns>true if SQLCommand has rows and false if no rows are returned.</returns>
        public bool RecordExist()
        {
            try
            {
                if (this.sqlCommand.CommandText == "")
                {
                    throw new ArgumentNullException("SQLCommandText property of DatabaseManagement class cannot be an empty string.");
                }
                else
                {
                    if (sqlConnection.State == ConnectionState.Closed)
                    {
                        sqlConnection.Open();
                    }

                    sqlCommand = new SqlCommand();
                    sqlCommand.Connection = sqlConnection;
                    return sqlCommand.ExecuteReader().HasRows;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
                sqlCommand = null;
            }
        }

        //

        public void ExecuteStoredProcedureWithParameters(string SPName, Dictionary<string, object> parameters)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["_onlineExam"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SPName, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (parameters != null)
                    {
                        foreach (KeyValuePair<string, object> kvp in parameters)
                            cmd.Parameters.Add(new SqlParameter(kvp.Key, kvp.Value));
                    }
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        //
        /// <summary>
        /// Execute a StoredProcedure and returns number of rows affected.
        /// </summary>
        /// <param name="commandType">SqlCommandType</param>
        /// <param name="commandText">Stored Procedure Name</param>
        /// <returns></returns>
        /// 
        public int ExecuteSQL(CommandType commandType, string commandText)
        {
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }


                //Note: sqlCommand can be set either in here or in AddSqlParameterToCommandObject method 
                if (this.sqlCommand == null)
                    this.sqlCommand = new SqlCommand();
                this.sqlCommand.Connection = this.sqlConnection;
                this.sqlCommand.CommandType = commandType;
                this.sqlCommand.CommandText = commandText;
                return this.sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public int ExecuteSQL(SqlCommand Command)
        {
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }
                //Note: sqlCommand can be set either in here or in AddSqlParameterToCommandObject method 
                this.sqlCommand = Command;
                this.sqlCommand.Connection = this.sqlConnection;
                return this.sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        /// <summary>
        /// Execute the specified SQL and returns the number of rows affected.
        /// Use this method for short SQL queries.
        /// </summary>
        /// <param name="SQLString">SQL query in text format.</param>
        /// <returns>integer specifying number of rows affected as the result of SQL query.</returns>
        public int ExecuteSQL(string SQLString)
        {
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }

                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = SQLString;
                return sqlCommand.ExecuteNonQuery();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
                sqlCommand = null;
            }
        }
        /// <summary>
        /// Execute the specified SQL and returns the number of rows affected. 
        /// Set the DatabaseManagement.SQLCommandText property before calling this method.
        /// Use this method for long SQL queries.
        /// </summary>
        /// <returns>integer specifying number of rows affected as the result of SQLCommand</returns>
        public int ExecuteSQL()
        {
            try
            {
                if (this.sqlCommand.CommandText == "")
                {
                    throw new ArgumentNullException("SQLCommandText property of DatabaseManagement class cannot be an empty string.");

                }
                else
                {
                    if (sqlConnection.State == ConnectionState.Closed)
                    {
                        sqlConnection.Open();
                    }
                    this.sqlCommand.Connection = sqlConnection;
                    return this.sqlCommand.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
                sqlCommand = null;
            }
        }
        /// <summary>
        /// Query the database and return string if SQLCommand has rows for the specified SQL query.
        /// Set the DatabaseManagement.SQLCommandText property before calling this method. 
        /// Use this method for long SQL queries.
        /// </summary>
        ///  <param name="strSQL">Table Name.</param>
        /// <returns>return string.</returns>
        public string GetExecuteScalar(string strSQL)
        {
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }

                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = strSQL;
                object strResult = sqlCommand.ExecuteScalar();
                if (strResult != null && strResult != System.DBNull.Value)
                {
                    return strResult.ToString();
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
                sqlCommand = null;
            }
        }
        public string CheckSQLServerStatus()
        {
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }
                return this.sqlConnection.State.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ResetCommandObjectSqlParameters()
        {
            if (this.sqlCommand != null)
                this.sqlCommand.Parameters.Clear();
        }
        public void AddSqlParameterToCommandObject(string parameterName, SqlDbType dbType, int size, object Value)
        {
            if (this.sqlCommand == null)
                this.sqlCommand = new SqlCommand();
            SqlParameter sqlParameter = new SqlParameter(parameterName, dbType, size);
            sqlParameter.Value = Value;
            this.sqlCommand.Parameters.Add(sqlParameter);

        }

        /// <summary>
        /// Execute an array of specified SQL under a trasaction and return true if process complete successsfuly.
        /// Use this method for Array of SQL queries.
        /// </summary>
        /// <param name="SQLString">Array of SQL query in text format.</param>
        /// <returns>Boolean specifying success or failure of execution of Array of SQL queries.</returns>
        public bool ExecuteSQL(string[] SQLString)
        {
            try
            {
                int i = 0;
                int TotalQueries;
                string sqlString = "";
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }

                sqlTransaction = sqlConnection.BeginTransaction();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;

                sqlCommand.Transaction = sqlTransaction;
                TotalQueries = SQLString.Length;
                for (i = 0; i < TotalQueries; i++)
                {
                    if (SQLString[i] != null)
                    {
                        sqlString = SQLString[i].ToString();
                        if (sqlString.Trim().Length > 0)
                        {
                            sqlCommand.CommandText = sqlString;
                            sqlCommand.ExecuteNonQuery();
                        }
                    }
                }
                sqlTransaction.Commit();
                return true;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                if (sqlTransaction != null)
                    sqlTransaction.Rollback();

                throw ex;

            }
            catch (Exception ex)
            {
                if (sqlTransaction != null)
                    sqlTransaction.Rollback();
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
                sqlCommand = null;
            }

        }

        public int SaveImage(String Table, String Column, String KeyColumn, String KeyValue, byte[] image)
        {
            int rowsAffected;

            SqlCommand command = sqlConnection.CreateCommand();
            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }


            command.CommandText = "UPDATE " + Table + " SET " + Column + "=@" + Column + "123 WHERE " + KeyColumn + "=" + KeyValue;
            SqlParameter param = new SqlParameter("@" + Column + "123", SqlDbType.Image);
            if (image == null)
            {
                param.Value = DBNull.Value;
            }
            else
            {
                param.Value = image;
            }
            command.Parameters.Add(param);
            rowsAffected = command.ExecuteNonQuery();
            sqlConnection.Close();
            return rowsAffected;
        }
        public String GetFieldValue(String Table, String ColumnName, String ColumnidName, Decimal ColumnID)
        {
            try
            {
                String SQL = "Select " + ColumnName + " From " + Table + " Where " + ColumnidName + "=" + ColumnID;
                sqlCommand = sqlConnection.CreateCommand();
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }

                sqlCommand.CommandText = SQL;
                SqlDataReader sqlReader = sqlCommand.ExecuteReader();
                if (sqlReader.Read())
                {
                    return sqlReader[ColumnName].ToString();
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }
        public String GetFieldID(String Table, String ColumnID, String ColumnName, String ColumnValue)
        {
            String result = "";
            try
            {
                String SQL = "Select " + ColumnID + " From " + Table + " Where " + ColumnName + "='" + ColumnValue + "'";

                sqlCommand = sqlConnection.CreateCommand();
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }

                sqlCommand.CommandText = SQL;
                SqlDataReader sqlReader = sqlCommand.ExecuteReader();
                if (sqlReader.Read())
                {
                    result = sqlReader[ColumnID].ToString();
                }
                sqlReader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
            return result;
        }
        public int GetRecordID(string strQuery)
        {
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = strQuery.ToString();
                object RecordID = sqlCommand.ExecuteScalar();
                if (RecordID != null && RecordID != System.DBNull.Value)
                {
                    return (int)RecordID;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }
        public DataTable GetSurveyDate(SqlCommand cmd, DataTable dt)
        {
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }
                SqlDataAdapter da = new SqlDataAdapter();
                cmd.Connection = sqlConnection;
                cmd.ExecuteScalar();
                da.SelectCommand = cmd;
                da.Fill(dt);
                return dt;


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }

        }

        public SqlCommand Command
        {
            get
            {
                return sqlCommand;
            }
        }

        ///////////////////////////////////Database Management of Distress Graph///////////////////////////////////////////
        ////////////////////////////////////////Executing Stored Procedure/////////////////////////////////////////////////

        public DataTable GetDistressGraph(SqlCommand cmd, DataTable dt)
        {
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }
                SqlDataAdapter da = new SqlDataAdapter();
                cmd.Connection = sqlConnection;
                da.SelectCommand = cmd;
                da.Fill(dt);
                sqlConnection.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }

        public DataTable GetGraphRecords(string query, string TableName, DataTable dt)
        {
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                cmd.Connection = sqlConnection;
                cmd.CommandText = query;
                da.SelectCommand = cmd;
                da.Fill(dt);
                sqlConnection.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }

        ////////////////////////////////////////Database Management of Performance Trend/////////////////////////////////////////
        public DataTable GetPerformanceData(DatabaseManagement db, DataTable dt, string Query)
        {
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                cmd.Connection = sqlConnection;
                cmd.CommandText = Query;
                da.SelectCommand = cmd;
                da.Fill(dt);
                sqlConnection.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }

        public DataTable GetDDlDeflectionData(SqlCommand cmd, DataTable dt)
        {
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }
                SqlDataAdapter da = new SqlDataAdapter();
                cmd.Connection = sqlConnection;
                da.SelectCommand = cmd;
                da.Fill(dt);
                sqlConnection.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }

        public DataTable GetDeflectionData(DatabaseManagement db, DataTable dt, string Query)
        {
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                cmd.Connection = sqlConnection;
                cmd.CommandText = Query;
                da.SelectCommand = cmd;
                da.Fill(dt);
                sqlConnection.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }

        public DataTable GetPredictorGraphData(DatabaseManagement db, DataTable dt, SqlCommand cmd)
        {
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }
                SqlDataAdapter da = new SqlDataAdapter();
                cmd.Connection = sqlConnection;
                da.SelectCommand = cmd;
                da.Fill(dt);
                sqlConnection.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }
    }
}