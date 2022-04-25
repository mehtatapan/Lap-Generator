namespace Lap_Generator_UI.Models
{
    public class Driver
    {
        public Driver()
        {
            this.LapTime = new HashSet<LapTime>();
        }
        public int ID { get; set; }

        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName
                    + (string.IsNullOrEmpty(MiddleName) ? "" :
                        (" " + (char?)MiddleName[0] + ".").ToUpper());
            }
        }

        public string FirstName { get; set; }

        public string? MiddleName { get; set; }

        public string LastName { get; set; }

        public int CarNum { get; set; }

        public string AvgTime { get; set; }

        public ICollection<LapTime>? LapTime { get; set; }
    }
}
