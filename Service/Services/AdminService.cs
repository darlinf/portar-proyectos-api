using Atiendeme.Data;
using Atiendeme.Data.Entities;
using Microsoft.Extensions.Options;
using portar_proyectos_api.Data.Entities;
using portar_proyectos_api.Data.Interfaces;
using portar_proyectos_api.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Helpers;

namespace portar_proyectos_api.Service.Services
{
    public class AdminService : IAdminService
    {
        private readonly AppSettings _appSettings;
        DataContext _context;
        public AdminService(IOptions<AppSettings> appSettings, DataContext context)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }

        public async Task DeleteTeacher(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            var user = _context.Users.FirstOrDefault(x => x.TeacherId == teacher.Id);
            _context.Remove(user);
            _context.Remove(teacher);
            await _context.SaveChangesAsync();
        }

        public async Task EditTeacher(Teacher teacher)
        {
            _context.Update(teacher);
            await _context.SaveChangesAsync();
        }

        public object GetAllTeacher()
        {

            var innerJoin = (from teacher in _context.Teachers // outer sequence
                            join user in _context.Users //inner sequence 
                            on teacher.Id equals user.TeacherId // key selector 
                            select new 
                            {
                                Id = teacher.Id,
                                Mail = user.Mail,
                                Name = user.Name
                            }).ToList();

            return innerJoin;
        }

        public Task RegisterTeacher(TeacherDto teacher)
        {
            throw new NotImplementedException();
        }
    }
}
