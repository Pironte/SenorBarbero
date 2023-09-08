using AutoMapper;
using SenorBarbero.Data;
using SenorBarbero.Data.Dtos;
using SenorBarbero.IServices;
using SenorBarbero.Model;

namespace SenorBarbero.Services
{
    public class BarberShopService : ICRUDService
    {
        private SenorBarberoDbContext _dbContext;
        private IMapper _mapper;

        public BarberShopService(SenorBarberoDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public BarberShop Save(BarberShopDto barberShopDto)
        {
            var barberShop = _mapper.Map<BarberShop>(barberShopDto);
            _dbContext.Bars.Add(barberShop);
            _dbContext.SaveChanges();

            return barberShop;
        }

        public IEnumerable<BarberShop> GetAll()
        {
            return _dbContext.Bars.ToList();
        }

        public BarberShop GetById(int id)
        {
            var barberShop = _dbContext.Bars.Find(id);
            if (barberShop == null)
                throw new NullReferenceException("Barbearia não encontrada");

            return barberShop;
        }

        public bool Delete(BarberShop barberShop)
        {
            _dbContext.Remove(barberShop);
            return _dbContext.SaveChanges() == 1;
        }

        public bool Update(BarberShopDto barberShopDto, BarberShop barberShop)
        {
            _mapper.Map(barberShopDto, barberShop);
            return _dbContext.SaveChanges() == 1;
        }

        public BarberShopDto GetPatchUpdateObject(BarberShop barberShop)
        {
            return _mapper.Map<BarberShopDto>(barberShop);
        }
    }
}
