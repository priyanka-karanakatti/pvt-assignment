using NetTopologySuite.Geometries;
using PTVGroupRepository.Models;

namespace PTVGroupsWebApi.Requests
{
    public class StreetPostRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<StreetCordinates> Geometries { get; set; }
        public int Capacity { get; set; }
    }

    public class StreetCordinates
    {
        public double x { get; set; }
        public double y { get; set; }
    }
}
