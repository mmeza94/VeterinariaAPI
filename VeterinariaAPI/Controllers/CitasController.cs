using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeterinariaAPI.Models;

namespace VeterinariaAPI.Controllers
{
    [ApiController]
    [Route("veterinaria/api")]
    public class CitasController : ControllerBase
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

            return await context.Citas.Where(cita => cita.Active == 1)
                                      .OrderByDescending(cita => cita.CitaId)
                                      .ToListAsync();

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



        [HttpPut("{id:int}")]
        public async Task<ActionResult> DeleteCita([FromRoute] int id)
        {
            Cita cita = await context.Citas.FirstOrDefaultAsync(cita => cita.CitaId == id);

            cita.Active = 0;

            context.Update(cita);
            await context.SaveChangesAsync();

            return Ok();


        }

        [HttpPut("Update/{id:int}")]
        public async Task<ActionResult> UpdateCita(CitaDtoInsert citaNueva,[FromRoute] int id)
        {

            var cita = mapper.Map<Cita>(citaNueva);
            cita.CitaId= id;
            cita.Active = 1;

            context.Update(cita);
            await context.SaveChangesAsync();

            return Ok();


        }



    }
}
