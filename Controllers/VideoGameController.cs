using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeDBfirstAPI.Data;
using PracticeDBfirstAPI.Models;

namespace PracticeDBfirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameController(YashContext context) : ControllerBase
    {
        private readonly YashContext _context=context;

        [HttpGet]

        public async Task<ActionResult<List<GameDetailsMst>>> GetGame()
        {
            

            return await _context.GameDetailsMsts.Include(g=>g.GameCharaterMsts).ToListAsync();
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<GameDetailsMst>> getGameByID(int id)
        {
            var game = await _context.GameDetailsMsts.FindAsync(id);
            if(game == null)
            {
                return NotFound();
            }

            return Ok(game);
        }

        [HttpPost]

        public async Task<ActionResult<GameDetailsMst>> AddGame(GameDetailsMst gameDetailsMst)
        {
           if(gameDetailsMst == null)
            {
                return BadRequest();
            }
           _context.GameDetailsMsts.Add(gameDetailsMst);
            await _context.SaveChangesAsync();
            return Ok();    
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<GameDetailsMst>> EditGame(int id,GameDetailsMst gameDetailsMst)
        {
            var game = await _context.GameDetailsMsts.FindAsync(id);
            if(game == null)
            {
                return BadRequest();
            }
            game.GameName = gameDetailsMst.GameName;
            game.Price = gameDetailsMst.Price;
            game.ReleaseYear = gameDetailsMst.ReleaseYear;

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<GameDetailsMst>> deleteGame(int id)
        {
            var game = _context.GameDetailsMsts.Find(id);
            if(game == null)
            {
                return BadRequest();

            }

            _context.GameDetailsMsts.Remove(game);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
