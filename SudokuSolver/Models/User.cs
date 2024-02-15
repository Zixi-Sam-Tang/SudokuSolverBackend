using System.ComponentModel.DataAnnotations;

namespace SudokuSolver.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public ICollection<SudokuModel> PuzzlesSolved { get; set; } = null!;
    }
}
