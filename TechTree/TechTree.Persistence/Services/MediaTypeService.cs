using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTree.Application.Dtos.MediaTypeDtos;

namespace TechTree.Persistence.Services
{
    public class MediaTypeService : IMediaTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MediaTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<MediaTypesDto>> GetAll()
        {
            var mediaTypes =await _unitOfWork.MediaType.GetAllAsync();
            var model= _mapper.Map<List<MediaTypesDto>>(mediaTypes);
            return model;
        }
    }
}
