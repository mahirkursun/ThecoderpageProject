﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThecoderpageProject.Application.Models.DTOs;
using ThecoderpageProject.Application.Models.VMs;

namespace ThecoderpageProject.Application.Services.AbstractServices
{
    public interface ICommentService
    {
        Task Create(CreateCommentDTO model);
        Task Update(UpdateCommentDTO model);
        Task<UpdateCommentDTO> GetCommentById(int id);
        Task Delete(int id);

        Task<IEnumerable<CommentVM>> GetAll();

        Task<IEnumerable<CommentVM>> GetCommentsByProblemId(int problemId); //Problem'e göre Comment getir
    }
}
