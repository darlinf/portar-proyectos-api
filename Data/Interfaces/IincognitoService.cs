using Atiendeme.Data.Entities;
using portar_proyectos_api.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Dtos;

namespace portar_proyectos_api.Data.Interfaces
{
    public interface IincognitoService
    {
        User Authentication(string Mail, string Password);
        Task Register(UserDto userDto);
        Task<List<ProposedProject>> GetAllProposedProject();
        Task<List<List<ProposedProject>>> GetAllProposedProjectByCareer(string Career);
        Task<List<FinalProject>> GetAllFinalProject();
        Task<List<FinalProject>> GetAllFinalProjectByCareer(string Career);
    }
}
