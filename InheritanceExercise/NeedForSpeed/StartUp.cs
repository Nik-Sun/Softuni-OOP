namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Car car = new Car(150,100);
            SportCar sportCar = new SportCar(300,50);
            sportCar.Drive(20);
            System.Console.WriteLine(sportCar.Fuel);
        }
    }
}
