﻿using portar_proyectos_api.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace portar_proyectos_api.Data.Interfaces
{
    public interface IStudentService
    {
        Task CreateProposedProject(ProposedProject proposedProject);
        Task<ProposedProject> GetProposedProject(int StudentId);
        Task<FinalProject> GetFinalProyect(int StudentId);
        Task UpdateFinalProyect(FinalProject finalProyect);
        Task GetAllProposedProject(int GroupId);
        Task UpdateProposedProject(ProposedProject proposedProject);
        Task CreateChapterProject(ChapterProject chapterProject);
        List<ChapterProject> GetAllChapterProject(int StudentId);
    }
}
