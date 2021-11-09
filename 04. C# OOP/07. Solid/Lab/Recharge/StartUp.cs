namespace Recharge
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee("Ivan");
            Robot robot = new Robot("Gosho", 10);

            employee.Work(2);
            employee.Sleep();

            robot.Recharge();
            robot.Work(5);
        }
    }
}
