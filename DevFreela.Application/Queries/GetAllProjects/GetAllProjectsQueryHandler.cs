﻿using DevFreela.Application.ViewModels;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetAllProjects
{
    public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, List<ProjectViewModel>>
    {
        private readonly IProjectRepository _repository;
        public GetAllProjectsQueryHandler(IProjectRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<ProjectViewModel>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            var projects = await _repository.GetAllAsync();

            var projectsViewModel = projects.Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt)).ToList();

            return projectsViewModel;
        }
    }
}
