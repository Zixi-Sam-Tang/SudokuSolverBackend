using System.Data;

namespace SudokuSolver.Extensions
{
    public static class DataRowExtensions
    {
        public static int? TryParseInt(this DataRow dr, string columnName)
        {
            if (dr == null
                || !dr.Table.Columns.Contains(columnName)
                || dr[columnName] == DBNull.Value)
            {
                return null;
            }

            return (int)dr[columnName];
        }
    }
}
