using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kolokwium.Services;
using Microsoft.AspNetCore.Mvc;

namespace kolokwium.Controllers
{
    [Route("api/[controller]")]
    public class MusicianController : Controller
    {
        private readonly IMusicService _service;

        public MusicianController(IMusicService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMusician(int id) {
            if(_service.IsMusicianExists(id).Result)
                return Ok(await _service.GetMusician(id));
            else
                return NotFound();
        } 
    }
}