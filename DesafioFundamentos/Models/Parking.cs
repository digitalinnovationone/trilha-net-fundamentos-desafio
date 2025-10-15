namespace DesafioFundamentos.Models
{
    public class Parking
    {
        private decimal initialPrice = 0;
        private decimal pricePerHour = 0;
        private List<string> vehicles = new List<string>();

        public Parking(decimal initialPrice, decimal pricePerHour)
        {
            this.initialPrice = initialPrice;
            this.pricePerHour = pricePerHour;
        }

        public void AddVahicle()
        {
            Console.WriteLine("Enter the vehicle plate for park:");
            string plate = Console.ReadLine();
            vehicles.Add(plate);
        }

        public void RemoveVehicle()
        {
            Console.WriteLine("Enter the vehicle plate for park:");

            string plate = Console.ReadLine();


            // Verifica se o veículo existe
            if (vehicles.Any(x => x.ToUpper() == plate.ToUpper()))
            {
                Console.WriteLine("Enter how many hours the vehicle was parked:");

                int hours = Convert.ToInt32(Console.ReadLine());

                decimal totalValue = initialPrice + pricePerHour * hours;

                vehicles.Remove(plate);

                Console.WriteLine($"Vehicle {plate} was removed and the total value was: R$ {totalValue}");
            }
            else
            {
                Console.WriteLine("Sorry, this vehicle is not parked here. Check if you entered the vehicle plate number correctly.");
            }
        }

        public void ListVehicles()
        {
            // Verifica se há veículos no estacionamento
            if (vehicles.Any())
            {
                Console.WriteLine("The parked vehicles are::");

                foreach(string item in vehicles)
                {
                    Console.WriteLine(item);
                }      
            }
            else
            {
                Console.WriteLine("There are no parked vehicles.");
            }
        }
    }
}
