using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SudokuSolver.Models;
using SudokuSolver.Options;

namespace SudokuSolver.Data
{
    public class SudokuSolverContext :  IdentityDbContext<User>
    {
        //public DbSet<User> Users { get; set; } = null!;
        public DbSet<SudokuModel> Puzzles { get; set; } = null!;

        private readonly IOptions<DbConfigOption> dbConfig;

        public SudokuSolverContext(IOptions<DbConfigOption> dbConfig)
        {
            this.dbConfig = dbConfig;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(dbConfig.Value.PuzzleDbConString);
        }
    }
}
