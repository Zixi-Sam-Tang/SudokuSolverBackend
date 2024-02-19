using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SudokuSolver.Models
{
    public class User : IdentityUser
    {
        public ICollection<SudokuModel> PuzzlesSolved { get; set; } = null!;
    }
}
