using System.ComponentModel.DataAnnotations;

namespace SudokuSolver.Models
{
    public class SudokuModel
    {
        [Key]
        public int PuzzleId { get; set; }
        public string Puzzle { get; set; } = null!;
        public string Solution { get; set; } = null!;
        public int? PostUserId { get; set; }
        public User? PostUser { get; set; }
        public DateTime? PostDate { get; set; }
    }
}
