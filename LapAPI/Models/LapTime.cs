using System.ComponentModel.DataAnnotations;

namespace LapAPI.Models
{
    public class LapTime
    {
        public int ID { get; set; }

        [Display(Name = "Lap Time")]
        public string Time
        {
            get
            {
                return minute.ToString()+":"+second.ToString()+":"+millisecond.ToString();
            }
        }

        [Display(Name = "minutes")]
        [Required(ErrorMessage = "You must enter the minutes for Lap time")]
        [Range(-1, 60, ErrorMessage = "The value for minute ranges from 0 to 60")]
        public int minute { get; set; }

        [Display(Name = "minutes")]
        [Required(ErrorMessage = "You must enter the seconds for Lap time")]
        [Range(-1, 60, ErrorMessage = "The value for seconds ranges from 0 to 60")]
        public int second { get; set; }

        [Display(Name = "minutes")]
        [Required(ErrorMessage = "You must enter the milliseconds for Lap time")]
        [Range(-1, 100, ErrorMessage = "The value for milliseconds ranges from 0 to 100")]
        public int millisecond { get; set; }

        [Display(Name = "Driver")]
        [Required(ErrorMessage = "You must select the Driver.")]
        [Range(1, int.MaxValue, ErrorMessage = "Select which driver does this Lap TIme belong to.")]
        public int DriverID { get; set; }
        public Driver? Driver { get; set; }
    }
}
