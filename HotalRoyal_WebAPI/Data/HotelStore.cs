using HotalRoyal_WebAPI.Models.Dto;

namespace HotalRoyal_WebAPI.Data
{
    public static class HotelStore
    {
        public static List<HotelDto> hotelList = new List<HotelDto>
        {
            new HotelDto{Id =  1, Name = "Pool View",Occupancy=4,Sqft=100},
            new HotelDto{Id = 2,Name = "Beach View",Occupancy=3,Sqft=300}
        };
    }
}
