﻿using System.ComponentModel.DataAnnotations;

namespace HotalRoyal_WebAPI.Models.Dto
{
    public class HotelDto 
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public string Details { get; set; }
        [Required]
        public double Rate { get; set; }
        public int Occupancy { get; set; }
        public int Sqft{ get; set; }
        public string ImageUrl { get; set; }
        public string Amenity { get; set; }
    }
}

//DTO : DTOs provides the wrapper between the entity or the database Model and what is being exposed from the API