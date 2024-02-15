using Microsoft.AspNetCore.Mvc;

namespace SudokuSolver.Models
{
    public class SudokuDto
    {
        public string Puzzle { get; set; } = null!;
        public string Solution { get; set; } = null!;
        public int? PostUserId { get; set; } = null;
        public DateTime? DatePosted { get; set; }
    }
}
