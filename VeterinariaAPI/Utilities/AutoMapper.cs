using AutoMapper;
using VeterinariaAPI.Models;

namespace VeterinariaAPI.Utilities
{
    public class AutoMapper:Profile
    {

        public AutoMapper()
        {
            CreateMap<CitaDtoInsert, Cita>();
        }


    }
}
