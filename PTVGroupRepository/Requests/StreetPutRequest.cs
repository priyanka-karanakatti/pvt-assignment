using PTVGroupsWebApi.Requests;

namespace PTVGroupRepository.Requests
{
    public class StreetPutRequest
    {
        public List<StreetCordinates> Geometries { get; set; }
    }
}
