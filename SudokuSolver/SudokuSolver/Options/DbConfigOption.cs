using System.ComponentModel.DataAnnotations;

namespace SudokuSolver.Options
{
    public class DbConfigOption
    {
        public static string Section { get; set; } = "DbConfig";

        [Required]
        public string PuzzleDbConString { get; set; } = string.Empty;
    }
}
