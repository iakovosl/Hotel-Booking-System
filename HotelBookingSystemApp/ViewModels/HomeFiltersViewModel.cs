using System.ComponentModel.DataAnnotations;

namespace HotelBookingSystemApp.ViewModels
{
    public class HomeFiltersViewModel
    {

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "Room Type")]
        public int? RoomTypeId { get; set; }

        [Required]
        [Display(Name = "Check In Date")]
        public string CheckInDate { get; set; }

        [Required]
        [Display(Name = "Check Out Date")]
        public string CheckOutDate { get; set; }

        [Display(Name = "Count of Guests")]
        public int? CountOfGuests { get; set; }

        [Display(Name = "Amount min")]
        public int? AmountMin { get; set; }

        [Display(Name = "Amount max")]
        public int? AmountMax { get; set; }
    }
}
