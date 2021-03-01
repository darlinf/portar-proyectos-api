using portar_proyectos_api.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace portar_proyectos_api.Data.Interfaces
{
    public interface ITeacherService
    {
        object GetAllStudentForCredentials(int TeacherId, string estudentState, string section);
        Task updateStudentForCredentials(Student student);
        object GetAllProjectForEvaluate(int TeacherId, string projectState, string section);
        Task updateProjectForEvaluate(ProposedProject proposedProject);
        object GetAllFinalProjectForEvaluate(int TeacherId, string projectState, string section);
        Task updateFinalProject(FinalProject finalProject);
        object GetAllChapterProject(int TeacherId);
        Task updateChapterProject(ChapterProject chapterProject); 
/*=======
        Task<List<Student>> GetAllStudentForCredentials(int TeacherId, string estudentState = "todo", string section = "todo");
        Task updateStudentForCredentials(Student student);
        Task<List<Student>> GetAllProjectForEvaluate(int TeacherId, string projectState = "todo", string section = "todo");
        Task updateProjectForEvaluate(ProposedProject proposedProject);
        Task<List<Student>> GetAllFinalProjectForEvaluate(int TeacherId, string projectState = "todo", string section = "todo");
        Task updateFinalProject(FinalProject finalProject);
        Task<List<Student>> GetAllChapterProject(int TeacherId);
        Task updateChapterProject(ChapterProject chapterProject);
>>>>>>> bc547d31f37ac6884b03f590ef87d8268e1465eb*/
    }
}
