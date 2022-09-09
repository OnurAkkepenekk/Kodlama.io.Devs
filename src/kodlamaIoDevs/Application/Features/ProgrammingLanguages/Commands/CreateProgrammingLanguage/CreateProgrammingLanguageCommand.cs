using Application.Features.ProgrammingLanguages.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage
{
    public class CreateProgrammingLanguageCommand : IRequest<CreatedProgrammingLanguageDto>
    {
        public string Name { get; set; }

        public class CreateProgrammingLanguageCommandHandler : IRequestHandler<CreateProgrammingLanguageCommand, CreatedProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;

            public CreateProgrammingLanguageCommandHandler(IMapper mapper, IProgrammingLanguageRepository programmingLanguageRepository)
            {
                _mapper = mapper;
                _programmingLanguageRepository = programmingLanguageRepository;
            }

            public async Task<CreatedProgrammingLanguageDto> Handle(CreateProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                ProgrammingLanguage _mappedProgrammingLanguage = _mapper.Map<ProgrammingLanguage>(request);
                ProgrammingLanguage _createdProgrammingLanguage = await _programmingLanguageRepository.AddAsync(_mappedProgrammingLanguage);
                CreatedProgrammingLanguageDto createdProgrammingLanguageDto =
                    _mapper.Map<CreatedProgrammingLanguageDto>(_createdProgrammingLanguage);
                return createdProgrammingLanguageDto;

            }
        }
    }
}