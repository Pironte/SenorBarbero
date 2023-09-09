using AutoMapper;
using SenorBarbero.Data;
using SenorBarbero.Data.Dtos;
using SenorBarbero.IServices;
using SenorBarbero.Model;

namespace SenorBarbero.Services
{
    public class ServiceService : ICRUDService
    {
        private SenorBarberoDbContext _dbContext;
        private IMapper _mapper;

        public ServiceService(SenorBarberoDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public Service Save(ServiceDto serviceDto)
        {
            var service = _mapper.Map<Service>(serviceDto);
            _dbContext.Services.Add(service);
            _dbContext.SaveChanges();

            return service;
        }

        public IEnumerable<Service> GetAll()
        {
            return _dbContext.Services.ToList();
        }

        public Service GetById(int id)
        {
            var service = _dbContext.Services.Find(id);
            if (service == null)
                throw new NullReferenceException("Serviço não encontrado");

            return service;
        }

        public bool Delete(Service service)
        {
            _dbContext.Remove(service);
            return _dbContext.SaveChanges() == 1;
        }

        public bool Update(ServiceDto serviceDto, Service service)
        {
            _mapper.Map(serviceDto, service);
            return _dbContext.SaveChanges() == 1;
        }

        public ServiceDto GetPatchUpdateObject(Service service)
        {
            return _mapper.Map<ServiceDto>(service);
        }
    }
}