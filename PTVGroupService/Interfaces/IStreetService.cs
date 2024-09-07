using PTVGroupRepository.Models;
using PTVGroupRepository.Requests;
using PTVGroupsWebApi.Requests;

namespace PTVGroupService.Interfaces
{
    public interface IStreetService
    {
        public List<StreetModel> GetStreetDetails();
        public StreetModel  GetStreetById(int id);
        public string PostStreet(StreetPostRequest streetModel);
        public void UpdateStreetData(StreetPutRequest streetModel, int id);
        public string DeleteStreet(int id);

    }
}