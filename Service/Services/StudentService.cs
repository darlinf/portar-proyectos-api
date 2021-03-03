using Atiendeme.Data;
using Microsoft.Extensions.Options;
using portar_proyectos_api.Data.Entities;
using portar_proyectos_api.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Helpers;

namespace portar_proyectos_api.Service.Services
{
    public class StudentService : IStudentService
    {

        private readonly AppSettings _appSettings;
        DataContext _context;
        public StudentService(IOptions<AppSettings> appSettings, DataContext context)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }

        public async Task CreateChapterProject(ChapterProject chapterProject)
        {
            _context.Add(chapterProject);
            await _context.SaveChangesAsync();
        }

        public async Task CreateProposedProject(ProposedProject proposedProject)
        {
            _context.Add(proposedProject);
            await _context.SaveChangesAsync();
        }

        public List<ChapterProject> GetAllChapterProject(int StudentId)
        {
            return _context.ChapterProjects.Where(x => x.StudentId == StudentId).ToList();
        }

        public List<ProposedProject> GetAllProposedProject(int UserId, string GroupId)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == UserId);
            var section = _context.Students.Where(x => x.Id == user.StudentId).Select(x => x.StudentSection).ToList();
            var resurt = (from student in _context.Students.Where(x => x.BelongGroup == GroupId)
                       join studentSections in _context.StudentSections.Where(x => x.SectionId == section[0].SectionId)
                       on student.Id equals studentSections.StudentId
                       join proposedProjects in _context.ProposedProjects
                       on student.Id equals proposedProjects.StudentId
                       select proposedProjects).ToList();    
            return resurt;
        }

        public async Task<FinalProject> GetFinalProyect(int StudentId)
        {
            return await _context.FinalProjects.FindAsync(StudentId);
        }

        public async Task<ProposedProject> GetProposedProject(int StudentId)
        {
            return await _context.ProposedProjects.FindAsync(StudentId);
        }

        public async Task UpdateFinalProyect(FinalProject finalProyect)
        {
            _context.Update(finalProyect);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProposedProject(ProposedProject proposedProject)
        {
            _context.Update(proposedProject);
            await _context.SaveChangesAsync();
        }
    }
}
