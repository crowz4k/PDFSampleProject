using System;

namespace PDFSampleProject.API.Data
{
    public class CarDTO
    {
        public string NameOfCar { get; set; }
        public int NumberOfDoors { get; set; }
        public DateTime FirstRegistration { get; set; }
        public double MaxSpeed { get; set; }
    }
}
