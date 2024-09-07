using NetTopologySuite.Geometries;
using PTVGroupRepository.Interfaces;
using PTVGroupRepository.Models;
using PTVGroupRepository.Requests;
using PTVGroupService.Interfaces;
using PTVGroupsWebApi.Requests;

namespace PTVGroupService
{
    public class StreetService : IStreetService
    {
        public readonly IStreetRepository _streetRepository;
        public StreetService(IStreetRepository streetRepository)
        {
            this._streetRepository = streetRepository;
        }
        public List<StreetModel> GetStreetDetails()
        {
            return _streetRepository.GetStreets();
        }
        public StreetModel GetStreetById(int id)
        {
            return _streetRepository.GetStreetById(id);
        }
        public string PostStreet(StreetPostRequest streetModel)
        {
            if (streetModel != null)
            {
                var street = new StreetModel();
                street.Name = streetModel.Name;
                street.Geometries = new MultiPoint(ToPoints(streetModel.Geometries));
                street.Capacity = streetModel.Capacity;
                street.IsActive = true;
                street.CreatedDate = DateTime.UtcNow;
                _streetRepository.PostStreet(street);
            }
            return "";
        }
        public void UpdateStreetData(StreetPutRequest streetModel, int id)
        {
            var existingStreet =_streetRepository.GetStreetById(id);
            if(existingStreet != null)
            {
               existingStreet.Geometries = new MultiPoint(
                   ToPoints(existingStreet.Geometries.Coordinates.ToList())
                   .Concat(ToPoints(streetModel.Geometries)).ToArray()
                   );
                existingStreet.LastModifiedDateTime = DateTime.UtcNow;
                _streetRepository.UpdateStreetData(existingStreet);
            }
            
        }
        public string DeleteStreet(int id)
        {
            return _streetRepository.DeleteStreet(id);
        }

        #region Helper Methods
        private Point[] ToPoints(List<StreetCordinates> cordinates)
        {
            var points = new List<Point>();
            foreach (var point in cordinates)
            {
                points.Add(new Point(point.x, point.y));
            }
            return points.ToArray();
        }

        private Point[] ToPoints(List<Coordinate> coordinates)
        {
            var points = new List<Point>();
            foreach (var point in coordinates)
            {
                points.Add(new Point(point.X, point.Y));
            }
            return points.ToArray();
        }
        #endregion


    }
}