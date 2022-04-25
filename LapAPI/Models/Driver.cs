using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LapAPI.Models
{
    public class Driver
    {
        public Driver()
        {

        }
        public int ID { get; set; }

        [Display(Name = "Doctor")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName
                    + (string.IsNullOrEmpty(MiddleName) ? "" :
                        (" " + (char?)MiddleName[0] + ".").ToUpper());
            }
        }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "The Doctor's first name cannot be left blank.")]
        [StringLength(50, ErrorMessage = "First name cannot be more than 50 characters long.")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        [StringLength(50, ErrorMessage = "Middle name cannot be more than 50 characters long.")]
        public string? MiddleName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "The Doctor's last name is required.")]
        [StringLength(100, ErrorMessage = "Last name cannot be more than 100 characters long.")]
        public string LastName { get; set; }

        [Display(Name = "Car Number")]
        [Required(ErrorMessage = "You must enter the Car Number")]
        [Range(-1, 100, ErrorMessage = "The value for Car Number ranges from 0 to 100")]
        public int CarNum { get; set; }

        [Display(Name = "Average Lap Time")]
        public string AvgTime
        {
            get
            {
                if (LapTime == null)
                {
                    return "No Data To Display";
                }
                else
                {
                    int time = 0;
                    int count = 0;
                    foreach (var i in LapTime)
                    {
                        time += i.millisecond;
                        time += (i.second * 100);
                        time += (i.minute * 60 * 100);
                        count++;
                    }
                    string minute = "";
                    string seconds = "";
                    string milliseconds = "";

                    if (time == 0)
                    {
                        return "0";
                    }
                    else
                    {
                        time = time / count;
                        if (time >= 6000)
                        {
                            minute = (time / 6000).ToString();
                            seconds = ((time % 6000) / 100).ToString();
                            milliseconds = ((time % 6000) % 100).ToString();
                        }
                        else if (time < 6000)
                        {
                            minute = "0";
                            seconds = (time / 100).ToString();
                            milliseconds = (time % 100).ToString();
                        }
                        if(minute.Length < 2)
                            minute = "0"+minute;
                        if (seconds.Length < 2)
                            seconds = "0" + seconds;
                        if(milliseconds.Length < 2)
                            milliseconds = "00" + milliseconds;
                        if (milliseconds.Length < 3)
                            milliseconds = "0" + milliseconds;
                    }
                    return minute + ":" + seconds + ":" + milliseconds;
                }
            }
        }

        [JsonIgnore]
        public ICollection<LapTime>? LapTime { get; set; }
    }
}
