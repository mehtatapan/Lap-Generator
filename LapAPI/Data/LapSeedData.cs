using LapAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LapAPI.Data
{
    public static class LapSeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {

            using (var context = new LapDataContext(
                serviceProvider.GetRequiredService<DbContextOptions<LapDataContext>>()))
            {
                // Look for any Doctors.  Since we can't have patients without Doctors.
                if (!context.Drivers.Any())
                {
                    context.Drivers.AddRange(
                     new Driver
                     {
                         FirstName = "Gregory",
                         MiddleName = "A",
                         LastName = "House",
                         CarNum = 12
                     },

                     new Driver
                     {
                         FirstName = "Doogie",
                         MiddleName = "R",
                         LastName = "Houser",
                         CarNum = 18
                     },
                     new Driver
                     {
                         FirstName = "Charles",
                         MiddleName = "B",
                         LastName = "Xavier",
                         CarNum = 22
                     }
                );
                    context.SaveChanges();
                }
                if (!context.LapTimes.Any())
                {
                    context.LapTimes.AddRange(
                    new LapTime
                    {
                        minute = 1,
                        second = 2,
                        millisecond = 3,
                        DriverID = 1
                    },
                    new LapTime
                    {
                        minute = 2,
                        second = 2,
                        millisecond = 3,
                        DriverID = 1
                    },
                    new LapTime
                    {
                        minute = 3,
                        second = 2,
                        millisecond = 3,
                        DriverID = 2
                    },
                    new LapTime
                    {
                        minute = 4,
                        second = 2,
                        millisecond = 3,
                        DriverID = 3
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
