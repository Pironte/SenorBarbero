using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SenorBarbero.Data;
using SenorBarbero.Data.Dtos;
using SenorBarbero.IServices;
using SenorBarbero.Model;

namespace SenorBarbero.Services
{
    public class ScheduleService : ICRUDService
    {
        private SenorBarberoDbContext _dbContext;
        private IMapper _mapper;

        public ScheduleService(SenorBarberoDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public Schedule Save(ScheduleDto scheduleDto)
        {
            var schedule = _mapper.Map<Schedule>(scheduleDto);
            _dbContext.Schedules.Add(schedule);
            _dbContext.SaveChanges();

            return schedule;
        }

        public IEnumerable<Schedule> GetAll()
        {
            return _dbContext.Schedules
                .Include(x => x.ScheduleSlot)
                .Include(x => x.Service)
                .Include(x => x.User)
                .Include(x => x.BarberShop)
                .ToList();
        }

        public Schedule GetById(int id)
        {
            var schedule = _dbContext.Schedules
                .Include(x => x.ScheduleSlot)
                .Include(x => x.Service)
                .Include(x => x.User)
                .Include(x => x.BarberShop)
                .FirstOrDefault(x => x.Id == id);

            if (schedule == null)
                throw new NullReferenceException("Serviço não encontrado");

            return schedule;
        }

        public bool Delete(Schedule schedule)
        {
            _dbContext.Remove(schedule);
            return _dbContext.SaveChanges() == 1;
        }

        public bool Update(ScheduleDto scheduleDto, Schedule schedule)
        {
            _mapper.Map(scheduleDto, schedule);
            return _dbContext.SaveChanges() == 1;
        }

        public ScheduleDto GetPatchUpdateObject(Schedule schedule)
        {
            return _mapper.Map<ScheduleDto>(schedule);
        }
    }
}
