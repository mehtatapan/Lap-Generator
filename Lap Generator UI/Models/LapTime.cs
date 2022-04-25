namespace Lap_Generator_UI.Models
{
    public class LapTime
    {
        public int ID { get; set; }

        public string Time
        {
            get
            {
                return minute.ToString() + ":" + second.ToString() + ":" + millisecond.ToString();
            }
        }

        public int minute { get; set; }

        public int second { get; set; }

        public int millisecond { get; set; }

        public int DriverID { get; set; }
        public Driver? Driver { get; set; }
    }
}
