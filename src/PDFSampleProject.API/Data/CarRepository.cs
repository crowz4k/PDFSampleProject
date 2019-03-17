using System;
using System.Collections.Generic;

namespace PDFSampleProject.API.Data
{
    public static class CarRepository
    {
        public static IList<CarDTO> GetCars()
        {
            return new List<CarDTO>()
            {
                new CarDTO{NameOfCar="Audi Q7",FirstRegistration = DateTime.UtcNow.AddYears(-3),MaxSpeed = 200,NumberOfDoors = 4},
                new CarDTO{NameOfCar="Audi A5",FirstRegistration = DateTime.UtcNow,MaxSpeed = 180,NumberOfDoors = 4},
                new CarDTO{NameOfCar="Audi Q3",FirstRegistration = DateTime.UtcNow,MaxSpeed = 245,NumberOfDoors = 2},
                new CarDTO{NameOfCar="Mercedes SLI",FirstRegistration = DateTime.UtcNow,MaxSpeed = 150,NumberOfDoors = 4},
                new CarDTO{NameOfCar="Chevrolet",FirstRegistration = DateTime.UtcNow,MaxSpeed = 220,NumberOfDoors = 4},
                new CarDTO{NameOfCar="BMW",FirstRegistration = DateTime.UtcNow,MaxSpeed = 200,NumberOfDoors = 4},
        };
        }
    }
}
