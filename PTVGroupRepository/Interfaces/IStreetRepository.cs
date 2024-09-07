using PTVGroupRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTVGroupRepository.Interfaces
{
    public interface IStreetRepository
    {
        public List<StreetModel> GetStreets();
        public StreetModel GetStreetById(int id);
        public bool PostStreet(StreetModel street);
        public string DeleteStreet(int id);
        public void UpdateStreetData(StreetModel streetModel);

    }
}
