using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SudokuSolver.Models;
using SudokuSolver.Options;
using SudokuSolver.SqlUtils;
using System.Data;
using System.Data.SqlClient;

namespace SudokuSolver.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SudokuPuzzleController : ControllerBase
    {
        private readonly IOptions<DbConfigOption> dbConfig;

        public SudokuPuzzleController(IOptions<DbConfigOption> dbConfig)
        {
            this.dbConfig = dbConfig;
        }

        // GET: SudokuPuzzleController
        [HttpGet("/Puzzles")]
        public List<SudokuModel> GetPuzzles(ISqlUtil sqlUtil, [FromQuery] int lowerBound)
        {
            var result = new List<SudokuModel>();

            string queryString =
                "SELECT PuzzleId, Puzzle, Solution from SudokuPuzzles where PuzzleId between @LowerBound and @UpperBound";

            var sqlParameters = new List<SqlParameter> {
                new SqlParameter("@LowerBound", lowerBound),
                new SqlParameter("@UpperBound", lowerBound + 9)
            };
            try {
                DataSet dataSet = sqlUtil.GetDataSet(queryString, sqlParameters);
                foreach (DataRow _row in dataSet.Tables[0].Rows)
                {
                    result.Add(new SudokuModel
                    {
                        PuzzleId = Convert.ToInt32(_row["PuzzleId"]),
                        Puzzle = _row["Puzzle"].ToString() ?? string.Empty,
                        Solution = _row["Solution"].ToString() ?? string.Empty
                    });
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        [HttpGet("/PuzzleCount")]
        public long GetPuzzleTotal()
        {
            string connectionString = dbConfig.Value.PuzzleDbConString;

            long result = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new ("SELECT COUNT(1) cnt FROM SudokuPuzzles (NOLOCK)", connection);
                cmd.CommandTimeout = 2000;
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        result = reader.GetInt32(0);
                    }
                }
                reader.Close();

            }

            return result;
        }
    }
}
