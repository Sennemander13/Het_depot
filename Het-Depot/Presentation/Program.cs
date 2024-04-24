public class Program
{
    public static IWorld world = new RealWorld();
    public static void Main()
    {        
        while (true){
            world.Clear();
            world.WriteLine("--------------------");
            world.WriteLine("Welkom scan uw code");
            world.Write("Code: ");
            string code = world.ReadLine()!;
            if (code == "quit") { Environment.Exit(0);}
            BaseLogic.Login(code);
        }
    }

}