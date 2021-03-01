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
    public class TeacherService : ITeacherService
    {
        private readonly AppSettings _appSettings;
        DataContext _context;
        public TeacherService(IOptions<AppSettings> appSettings, DataContext context)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }

        public object GetAllChapterProject(int TeacherId)
        {
            return (from sections in _context.Sections.Where(x => x.TeacherId == TeacherId)
                    join studentSection in _context.StudentSections
                    on sections.Id equals studentSection.SectionId
                    join chapterProjects in _context.ChapterProjects
                    on studentSection.StudentId equals chapterProjects.StudentId
                    join student in _context.Students
                    on chapterProjects.StudentId equals student.Id
                    join user in _context.Users
                    on student.Id equals user.StudentId
                    select new
                    {
                        chapterProjectsId = chapterProjects.Id,
                        chapterProjects.StudentId,
                        chapterProjects.Name,
                        chapterProjects.ChapterNumber,
                        chapterProjects.Grade,
                        chapterProjects.ChapterDocumentationSRC,

                        studenName = user.Name,
                        student.Enrollment
                    }).ToList();
        }

        public object GetAllFinalProjectForEvaluate(int TeacherId, string section, string projectState)
        {
            if (projectState == "all" && section != "all")
            {
                return (from sections in _context.Sections.Where(x => x.TeacherId == TeacherId && x.SectionNumber == section)
                        join studentSection in _context.StudentSections
                        on sections.Id equals studentSection.SectionId
                        join finalProject in _context.FinalProjects
                        on studentSection.StudentId equals finalProject.StudentId
                        join student in _context.Students
                        on finalProject.StudentId equals student.Id
                        join user in _context.Users
                        on student.Id equals user.StudentId
                        select new
                        {
                            finalProjectId = finalProject.Id,
                            finalProject.StudentId,
                            finalProject.ExamGrade,
                            finalProject.State,
                            finalProject.FinalDocumentationSRC,
                            finalProject.ImageSRC,
                            finalProject.Description,

                            studenName = user.Name,
                            student.Enrollment
                        }).ToList();
            }
            if (section == "all" && projectState != "all")
            {
                

                return (from sections in _context.Sections.Where(x => x.TeacherId == TeacherId)
                        join studentSection in _context.StudentSections
                        on sections.Id equals studentSection.SectionId
                        join finalProject in _context.FinalProjects.Where(x => x.State == projectState)
                        on studentSection.StudentId equals finalProject.StudentId
                        join student in _context.Students
                        on finalProject.StudentId equals student.Id
                        join user in _context.Users
                        on student.Id equals user.StudentId
                        select new
                        {
                            finalProjectId = finalProject.Id,
                            finalProject.StudentId,
                            finalProject.ExamGrade,
                            finalProject.State,
                            finalProject.FinalDocumentationSRC,
                            finalProject.ImageSRC,
                            finalProject.Description,

                            studenName = user.Name,
                            student.Enrollment
                        }).ToList();
            }
            if (section == "all" && projectState == "all")
            {
                return (from sections in _context.Sections.Where(x => x.TeacherId == TeacherId)
                        join studentSection in _context.StudentSections
                        on sections.Id equals studentSection.SectionId
                        join finalProject in _context.FinalProjects
                        on studentSection.StudentId equals finalProject.StudentId
                        join student in _context.Students
                        on finalProject.StudentId equals student.Id
                        join user in _context.Users
                        on student.Id equals user.StudentId
                        select new
                        {
                            finalProjectId = finalProject.Id,
                            finalProject.StudentId,
                            finalProject.ExamGrade,
                            finalProject.State,
                            finalProject.FinalDocumentationSRC,
                            finalProject.ImageSRC,
                            finalProject.Description,

                            studenName = user.Name,
                            student.Enrollment
                        }).ToList();

            }

            return (from sections in _context.Sections.Where(x => x.TeacherId == TeacherId && x.SectionNumber == section)
                    join studentSection in _context.StudentSections
                    on sections.Id equals studentSection.SectionId
                    join finalProject in _context.FinalProjects.Where(x => x.State == projectState)
                    on studentSection.StudentId equals finalProject.StudentId
                    join student in _context.Students
                    on finalProject.StudentId equals student.Id
                    join user in _context.Users
                    on student.Id equals user.StudentId
                    select new
                    {
                        finalProjectId = finalProject.Id,
                        finalProject.StudentId,
                        finalProject.ExamGrade,
                        finalProject.State,
                        finalProject.FinalDocumentationSRC,
                        finalProject.ImageSRC,
                        finalProject.Description,

                        studenName = user.Name,
                        student.Enrollment
                    }).ToList();
        }

        public object GetAllProjectForEvaluate(int TeacherId, string section, string projectState)
        {
            if (projectState == "all" && section != "all") { 
                return (from sections in _context.Sections.Where(x => x.TeacherId == TeacherId && x.SectionNumber == section)
                            join studentSection in _context.StudentSections 
                            on sections.Id equals studentSection.SectionId
                            join proposedProjects in _context.ProposedProjects
                            on studentSection.StudentId equals proposedProjects.StudentId
                            join student in _context.Students
                            on proposedProjects.StudentId equals student.Id
                            join user in _context.Users
                            on student.Id equals user.StudentId
                        select new {
                                proposedProjectsId = proposedProjects.Id,
                                proposedProjects.StudentId,
                                proposedProjects.Name,
                                proposedProjects.State,
                                proposedProjects.Justification,
                                proposedProjects.Description,
                                
                                studenName = user.Name,
                                student.Enrollment
                            }).ToList();
            }
            if(section == "all" && projectState != "all")
            {
                return (from sections in _context.Sections.Where(x => x.TeacherId == TeacherId)
                        join studentSection in _context.StudentSections
                        on sections.Id equals studentSection.SectionId
                        join proposedProjects in _context.ProposedProjects.Where(x => x.State == projectState)
                        on studentSection.StudentId equals proposedProjects.StudentId
                        join student in _context.Students
                        on proposedProjects.StudentId equals student.Id
                        join user in _context.Users
                        on student.Id equals user.StudentId
                        select new
                        {
                            proposedProjectsId = proposedProjects.Id,
                            proposedProjects.StudentId,
                            proposedProjects.Name,
                            proposedProjects.State,
                            proposedProjects.Justification,
                            proposedProjects.Description,

                            studenName = user.Name,
                            student.Enrollment
                        }).ToList();
            }
            if (section == "all" && projectState == "all")
            {
                return (from sections in _context.Sections.Where(x => x.TeacherId == TeacherId)
                        join studentSection in _context.StudentSections
                        on sections.Id equals studentSection.SectionId
                        join proposedProjects in _context.ProposedProjects
                        on studentSection.StudentId equals proposedProjects.StudentId
                        join student in _context.Students
                        on proposedProjects.StudentId equals student.Id
                        join user in _context.Users
                        on student.Id equals user.StudentId
                        select new
                        {
                            proposedProjectsId = proposedProjects.Id,
                            proposedProjects.StudentId,
                            proposedProjects.Name,
                            proposedProjects.State,
                            proposedProjects.Justification,
                            proposedProjects.Description,

                            studenName = user.Name,
                            student.Enrollment
                        }).ToList();

            }
            return (from sections in _context.Sections.Where(x => x.TeacherId == TeacherId && x.SectionNumber == section)
                    join studentSection in _context.StudentSections
                    on sections.Id equals studentSection.SectionId
                    join proposedProjects in _context.ProposedProjects.Where(x => x.State == projectState)
                    on studentSection.StudentId equals proposedProjects.StudentId
                    join student in _context.Students
                    on proposedProjects.StudentId equals student.Id
                    join user in _context.Users
                    on student.Id equals user.StudentId
                    select new
                    {
                        proposedProjectsId = proposedProjects.Id,
                        proposedProjects.StudentId,
                        proposedProjects.Name,
                        proposedProjects.State,
                        proposedProjects.Justification,
                        proposedProjects.Description,

                        studenName = user.Name,
                        student.Enrollment
                    }).ToList();
        }

        public object GetAllStudentForCredentials(int TeacherId, string estudentState, string section)
        {
            return null;
        }

       /* public Task<List<Student>> GetAllChapterProject(int TeacherId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Student>> GetAllFinalProjectForEvaluate(int TeacherId, string section, string projectState)
        {
            throw new NotImplementedException();
        }

        public Task<List<Student>> GetAllProjectForEvaluate(int TeacherId, string section, string projectState)
        {
            /* var innerJoin = (from teacher in _context.Sections.Where(x => x.TeacherId == TeacherId) 
                              join user in _context.Users
                              on teacher.Id equals user.TeacherId // key selector 
                              select new
                              {
                                  Id = teacher.Id,
                                  Mail = user.Mail,
                                  Name = user.Name
                              }).ToList();

           var sectionGet = _context.Sections.Where(x => x.TeacherId == TeacherId && x.SectionNumber == section).Select(x => x.StudentSections).ToList();



            var innerJoi2 = from studentSections in _context.Sections.Where(x => x.TeacherId == TeacherId && x.SectionNumber == section)
                            join proposedProjects in _context.ProposedProjects 
                            on studentSections.TeacherId equals proposedProjects.StudentId
                            select new 
                            {
                                ss = proposedProjects
                            };
            return null;
        }
        
        public Task<List<Student>> GetAllStudentForCredentials(int TeacherId, string estudentState = "todo", string section = "todo")
        {
            throw new NotImplementedException();
        }*/

        public async Task updateChapterProject(ChapterProject chapterProject)
        {
            _context.Update(chapterProject);
            await _context.SaveChangesAsync();
        }

        public async Task updateFinalProject(FinalProject finalProject)
        {
            _context.Update(finalProject);
            await _context.SaveChangesAsync();
        }

        public async Task updateProjectForEvaluate(ProposedProject proposedProject)
        {
            _context.Update(proposedProject);
            await _context.SaveChangesAsync();
        }

        public async Task updateStudentForCredentials(Student student)
        {
            _context.Update(student);
            await _context.SaveChangesAsync();
        }
    }
}
