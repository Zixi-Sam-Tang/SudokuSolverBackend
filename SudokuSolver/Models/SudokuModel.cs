namespace SudokuSolver.Models
{
    public class SudokuModel
    {
        public int PuzzleId { get; set; }
        public string Puzzle { get; set; } = string.Empty;
        public string Solution { get; set; } = string.Empty;
    }
}
