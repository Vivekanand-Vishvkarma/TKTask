internal class Program
{
    private static void Main(string[] args)
    {       
        Login();
        int choice = 0;
        do
        {
            try
            {
                Console.Clear();
                Console.WriteLine("========Product List Menu========");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Delete Product");
                Console.WriteLine("3. Show Product");
                Console.WriteLine("0. Exit");

                Console.Write("Enter your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                    case 2:
                    case 3: break;
                    case 0: break;
                    default:
                        ShowMessage("Invalid number.", false);
                        break;

                }

                Pause();
            }
            catch (Exception ex)
            {

                ShowMessage(ex.Message,false);
            }

        } while (choice!=0);
    }


    static void Login()
    {
        int loginAttempts = 0;

        const string _userid= "admin";
        const string _password= "1234";

        string userid = "";
        string password = "";
        do
        {
            try
            {
                Console.Clear();
                Console.Write("\nEnter user id: ");
                userid = Console.ReadLine();
                Console.Write("Enter password: ");
                password = Console.ReadLine();

                if (_userid == userid && _password == password)
                {
                    ShowMessage("Login success.", true);
                    Pause();
                    break;
                }
                else
                {
                    ShowMessage("Invalid user id or password.", false);
                }

                loginAttempts++;
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, false);
            }

        } while(loginAttempts < 3);
    }   

    static void ShowMessage(string message,bool status)
    {
        Console.ForegroundColor=status?ConsoleColor.Green:ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();       
    }

    static void Pause()
    {
        Console.ForegroundColor= ConsoleColor.Yellow;
        Console.WriteLine("\nPress any key to continue...");
        Console.ResetColor();
        Console.ReadKey();
    }
}