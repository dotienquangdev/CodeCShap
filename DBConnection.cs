using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BTL
{
    public class DBParameter
    {
        public SqlParameter SqlParameter { get; set; }

        public object Value { get; set; }

        public bool IsIdentity { get; set; }
    }

    public class DBConnection
    {
        public DataSet DataSet => _dataSet;
        public static DBConnection Instance => _instance;

        private static DBConnection _instance = new DBConnection();

        private DataSet _dataSet = new DataSet();

        public SqlConnection CreateConnection()
        {
            string constr = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
            return new SqlConnection(constr);
        }

        public DataTable SelectDB(string table)
        {
            string sqlSelect = $"SELECT * FROM {table}";
            using (SqlConnection cnn = CreateConnection())
            {
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    try
                    {
                        da.SelectCommand = cnn.BuildSelectCommand(table);
                        _dataSet.Tables[table]?.Clear();
                        cnn.Open();
                        da.Fill(_dataSet, table);
                        cnn.Close();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Lỗi select DataBase : " + ex.Message);
                    }

                }
            }
            return _dataSet.Tables[table];
        }

        public bool InsertDB(string table, string nameProc,params DBParameter[] sqlParameters)
        {
            DataTable dt = _dataSet.Tables[table];
            if (_dataSet.Tables[table] == null)
            {
                dt = SelectDB(table);
            }

            using (SqlConnection cnn = CreateConnection())
            {
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    using (SqlCommand cmd = cnn.BuildInsertProc(nameProc, sqlParameters))
                    {
                        try
                        {
                            da.InsertCommand = cmd;
                            DataRow newRow = dt.NewRow();
                            for (int j = 0; j < sqlParameters.Length; j++)
                            {
                                DBParameter p = sqlParameters[j];
                                if (p.IsIdentity)
                                {
                                    newRow[j] = dt.Rows.Count + 1;
                                    continue;
                                }
                                newRow[p.SqlParameter.SourceColumn] = p.Value;
                            }
                            newRow["bDeleted"] = false;
                            dt.Rows.Add(newRow);
                            cnn.Open();
                            int i = da.Update(_dataSet, table);
                            cnn.Close();
                            _dataSet.Tables[table].AcceptChanges();
                            return i > 0;
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Lỗi insert DataBase : " + ex.Message);
                        }
                    }

                }
            }
        }

        public bool UpdateDB(string table, DBParameter condition, params DBParameter[] sqlParameters)
        {
            DataTable dt = _dataSet.Tables[table];
            if (_dataSet.Tables[table] == null)
            {
                dt = SelectDB(table);
            }

            using (SqlConnection cnn = CreateConnection())
            {
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    using (SqlCommand cmd = cnn.BuildUpdateCommand(table, condition, sqlParameters))
                    {
                        try
                        {
                            da.UpdateCommand = cmd;
                            cnn.Open(); 
                            for (int j = 0; j < sqlParameters.Length; j++)
                            {
                                DBParameter p = sqlParameters[j];
                                if (p.IsIdentity)
                                {
                                    continue;
                                }
                                dt.Rows[(int)condition.Value - 1][p.SqlParameter.SourceColumn] = p.Value;
                            }
                            int i = da.Update(_dataSet, table);
                            cnn.Close();
                            _dataSet.Tables[table].AcceptChanges();
                            return i > 0;
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Lỗi update DataBase : " + ex.Message);
                        }
                    }

                }
            }
        }
    }
}
