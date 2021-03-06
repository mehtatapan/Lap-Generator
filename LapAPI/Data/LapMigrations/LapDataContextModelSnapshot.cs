// <auto-generated />
using LapAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LapAPI.Data.LapMigrations
{
    [DbContext(typeof(LapDataContext))]
    partial class LapDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.4");

            modelBuilder.Entity("LapAPI.Models.Driver", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CarNum")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("CarNum")
                        .IsUnique();

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("LapAPI.Models.LapTime", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DriverID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("millisecond")
                        .HasColumnType("INTEGER");

                    b.Property<int>("minute")
                        .HasColumnType("INTEGER");

                    b.Property<int>("second")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("DriverID");

                    b.ToTable("LapTimes");
                });

            modelBuilder.Entity("LapAPI.Models.LapTime", b =>
                {
                    b.HasOne("LapAPI.Models.Driver", "Driver")
                        .WithMany("LapTime")
                        .HasForeignKey("DriverID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Driver");
                });

            modelBuilder.Entity("LapAPI.Models.Driver", b =>
                {
                    b.Navigation("LapTime");
                });
#pragma warning restore 612, 618
        }
    }
}
