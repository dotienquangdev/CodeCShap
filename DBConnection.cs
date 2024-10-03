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
                        da.SelectCommand = new SqlCommand(sqlSelect, cnn);
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

        public bool InsertDB(string table,string nameProc,params DBParameter[] sqlParameters)
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
                    using (SqlCommand cmd = cnn.CreateCommand())
                    {
                        try
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = nameProc;
                            foreach (DBParameter p in sqlParameters)
                            {
                                if (p.IsIdentity) continue;
                                cmd.Parameters.Add(p.SqlParameter);
                            }
                            da.InsertCommand = cmd;
                            DataRow newRow = dt.NewRow();
                            for (int j =  0; j < sqlParameters.Length; j++)
                            {
                                DBParameter p = sqlParameters[j];
                                if (p.IsIdentity)
                                {
                                    newRow[j] = dt.Rows.Count + 1;
                                    continue;
                                }
                                newRow[p.SqlParameter.SourceColumn] = p.Value;
                            }
                            foreach (DBParameter p in sqlParameters)
                            {
                            }
                            dt.Rows.Add(newRow);
                            cnn.Open();
                            int i = da.Update(_dataSet, table);
                            cnn.Close();
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
    }
}
