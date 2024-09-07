using PTVGroupRepository.Data;
using PTVGroupRepository.Interfaces;
using PTVGroupRepository.Models;
using System;

namespace PTVGroupRepository
{
    public class StreetRepository : IStreetRepository
    {
        private readonly AppDbContext context;
        public StreetRepository(AppDbContext context)
        {
            this.context = context;
        }
        public List<StreetModel> GetStreets()
        {
            var allStreets = context.Street.ToList();
            return allStreets;
        }

        public StreetModel GetStreetById(int id)
        {
            return context.Street.Where(i => i.Id == id).FirstOrDefault();
        }

        public bool PostStreet(StreetModel street)
        {
            try
            {
                context.Street.Add(street);
                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public void UpdateStreetData(StreetModel streetModel)
        {
            context.Update(streetModel);
            context.SaveChanges();
        }

        public string DeleteStreet(int id)
        {
            var street = context.Street.First(w => w.Id == id);
            if (street != null)
            {
                street.IsActive = false;
                context.SaveChanges();
                return "deleted successfully";
            }
            else
            {
                return "street not found";
            }
        }
    }
}