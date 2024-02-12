using System.Data.SqlClient;
using System.Data;

namespace SudokuSolver.SqlUtils
{
    public interface ISqlUtil
    {
        DataSet GetDataSet(string sql, List<SqlParameter> sqlParameters = null);
    }
}
