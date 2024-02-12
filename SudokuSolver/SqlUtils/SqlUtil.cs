using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using SudokuSolver.Options;
using System.Data;
using System.Data.SqlClient;

namespace SudokuSolver.SqlUtils
{
    public class SqlUtil: ISqlUtil
    {
        private readonly IOptions<DbConfigOption> dbConfig;
        public SqlUtil(IOptions<DbConfigOption> options)
        {
            this.dbConfig = options;
        }

        public DataSet GetDataSet(string sql, List<SqlParameter> sqlParameters = null)
        {
            DataSet dataSet = new DataSet();
            using (var connection = new SqlConnection(dbConfig.Value.PuzzleDbConString)) {
                SqlCommand command = new SqlCommand(sql, connection);
                if(sqlParameters != null && sqlParameters.Count > 0)
                {
                    command.Parameters.Clear();
                    sqlParameters.ForEach(p => { 
                        command.Parameters.Add(new SqlParameter(p.ParameterName, p.Value)); 
                    });                    
                }                

                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    
                    adapter.Fill(dataSet);
                }
                catch (Exception ex) {
                    throw;
                }
            }
            return dataSet;
        }
    }
}
