using AutoMapper;
using SenorBarbero.Data.Dtos;
using SenorBarbero.Data;
using SenorBarbero.Model;
using SenorBarbero.IServices;

namespace SenorBarbero.Services
{
    public class ScheduleSlotService : ICRUDService
    {
        private SenorBarberoDbContext _dbContext;
        private IMapper _mapper;

        public ScheduleSlotService(SenorBarberoDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public ScheduleSlot Save(ScheduleSlotDto scheduleSlotDto)
        {
            var scheduleSlot = _mapper.Map<ScheduleSlot>(scheduleSlotDto);
            _dbContext.ScheduleSlots.Add(scheduleSlot);
            _dbContext.SaveChanges();

            return scheduleSlot;
        }

        public IEnumerable<ScheduleSlot> GetAll()
        {
            return _dbContext.ScheduleSlots.ToList();
        }

        public ScheduleSlot GetById(int id)
        {
            var scheduleSlot = _dbContext.ScheduleSlots.Find(id);
            if (scheduleSlot == null)
                throw new NullReferenceException("Serviço não encontrado");

            return scheduleSlot;
        }

        public bool Delete(ScheduleSlot scheduleSlot)
        {
            _dbContext.Remove(scheduleSlot);
            return _dbContext.SaveChanges() == 1;
        }

        public bool Update(ScheduleSlotDto scheduleSlotDto, ScheduleSlot scheduleSlot)
        {
            _mapper.Map(scheduleSlotDto, scheduleSlot);
            return _dbContext.SaveChanges() == 1;
        }

        public ScheduleSlotDto GetPatchUpdateObject(ScheduleSlot scheduleSlot)
        {
            return _mapper.Map<ScheduleSlotDto>(scheduleSlot);
        }
    }
}
