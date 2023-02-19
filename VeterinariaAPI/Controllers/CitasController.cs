using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeterinariaAPI.Models;

namespace VeterinariaAPI.Controllers
{
    [ApiController]
    [Route("veterinaria/api")]
    public class CitasController:ControllerBase
    {
        private readonly VeterinariaContext context;
        private readonly IMapper mapper;

        public CitasController(VeterinariaContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cita>>> GetAllCitas()
        {
            return await context.Citas.ToListAsync();
        }



        [HttpPost]
        public async Task<ActionResult> InsertarNuevaCita(CitaDtoInsert citaNueva)
        {
            var cita = mapper.Map<Cita>(citaNueva);
            Console.WriteLine(cita);
            context.Add(cita);
            await context.SaveChangesAsync();

            return Ok();
        }



    }
}
