using System.Data;
using System.Data.SqlClient;

namespace BTL
{
    public static class Extension
    {
        public static void AddRowFilter(this DataView dataView, string filter)
        {
            dataView.RowFilter = $"bDeleted=0 AND {filter}";
        }

        public static DataView CreateDataView(this DataTable table)
        {
            return new DataView(table) { RowFilter = "bDeleted=0" };
        }

        public static SqlCommand BuildSelectCommand(this SqlConnection conn, string table) 
        {
            return new SqlCommand($"SELECT * FROM {table}", conn);
        }

        public static SqlCommand BuildInsertProc(this SqlConnection conn, string nameProc, params DBParameter[] sqlParameters)
        {
            var cmd = new SqlCommand(nameProc, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            foreach (var param in sqlParameters)
            {
                if (param.IsIdentity) continue;
                cmd.Parameters.Add(param.SqlParameter);
            }

            return cmd;
        }

        public static SqlCommand BuildUpdateCommand(this SqlConnection conn, string table, DBParameter condition, params DBParameter[] sqlParameters)
        {
            string sqlUpdate = $"UPDATE {table} SET ";

            for (int i = 0; i < sqlParameters.Length; i++)
            {
                var param = sqlParameters[i];

                if (param.IsIdentity) continue;

                sqlUpdate += $"{param.SqlParameter.SourceColumn}={param.SqlParameter.ParameterName}";

                if (i < sqlParameters.Length - 1) sqlUpdate += ", ";
            }

            sqlUpdate += $" WHERE {condition.SqlParameter.SourceColumn}={condition.SqlParameter.ParameterName}";

            var cmd = new SqlCommand(sqlUpdate, conn);
            foreach (var param in sqlParameters)
            {
                if (param.IsIdentity) continue;
                cmd.Parameters.AddWithValue(param.SqlParameter.ParameterName, param.Value);
            }
            cmd.Parameters.AddWithValue(condition.SqlParameter.ParameterName, condition.Value);
            return cmd;
        }
    }
}
