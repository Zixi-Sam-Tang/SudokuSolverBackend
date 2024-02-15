using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SudokuSolver.Data;
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
        readonly SudokuSolverContext db;

        public SudokuPuzzleController(SudokuSolverContext db)
        {
            this.db = db;
        }

        [HttpGet("/Puzzles")]
        public async Task<ActionResult<List<SudokuModel>>> GetPuzzles([FromQuery] int lowerBound)
        {
            List<SudokuModel> result;
            try
            {
                result = await db.Puzzles
                    .OrderBy(p => p.PuzzleId)
                    .Skip(lowerBound)
                    .Take(10)
                    .ToListAsync()
                    .ConfigureAwait(false);
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500);
            }

            return Ok(result);
        }

        [HttpGet("/Puzzles/Count")]
        public async Task<ActionResult<long>> GetPuzzleTotal()
        {
            int result = 0;

            try
            {
                result = await db.Puzzles.CountAsync().ConfigureAwait(false);
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500);
            }

            return Ok(result);
        }

        [HttpPost("/Puzzles")]
        public async Task<ActionResult> PostPuzzle([FromBody] SudokuDto sudokuDto)
        {
            try
            {
                SudokuModel puzzle = new() { Puzzle = sudokuDto.Puzzle, Solution = sudokuDto.Solution, PostUserId = sudokuDto.PostUserId, PostDate = sudokuDto.DatePosted };
                await db.AddAsync(puzzle).ConfigureAwait(false);
                db.SaveChanges();
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500);
            }

            return Ok();
        }
    }
}
