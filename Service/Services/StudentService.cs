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

        public Task GetAllProposedProject(int GroupId)
        {
            throw new NotImplementedException();
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
