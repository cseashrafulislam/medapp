using medapp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace medapp.Controllers.API
{

    [ApiController]
    [Route("api/[controller]")]
    public class MedicinesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public MedicinesController(AppDbContext context) { _context = context; }

        [HttpGet]
        public async Task<IActionResult> Get() =>
            Ok(await _context.Medicines.ToListAsync());
    }
}
