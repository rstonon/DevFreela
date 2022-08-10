﻿using Dapper;
using DevFreela.Application.ViewModels;
using DevFreela.Core.DTOs;
using DevFreela.Core.Repositories;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetAllSkills
{
    public class GetAllSkillQueryHandler : IRequestHandler<GetAllSkillsQuery, List<SkillDTO>>
    {
        private readonly ISkillRepository _repository;
        public GetAllSkillQueryHandler(ISkillRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<SkillDTO>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAll();

        }
    }
}
