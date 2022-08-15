using System;
using System.ComponentModel.DataAnnotations;

namespace Test_Vehicle.Models
{
    /// <summary>
    /// Vehicle Characteristics
    /// </summary>
    public class Vehicle
    {
        /// <summary>
        /// Glabally Unique Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Manufactured Year. Must be between 1950 and 2050
        /// </summary>
        [Required]
        [Range(1950, 2050)]
        public int Year { get; set; }


        /// <summary>
        /// Make of the vehicle. Max length: 50
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Make { get; set; }


        /// <summary>
        /// Model of the vehicle. Max length: 50
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Model { get; set; }
    }
}
