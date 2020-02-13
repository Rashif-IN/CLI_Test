using System;
using McMaster.Extensions.CommandLineUtils;

namespace hello_async
{
    [HelpOption("--hlp")]
    [Subcommand(
        typeof(UpperCase),
        typeof(LowerCase)
    )]
    class Program
    {
        public static int Main(string[] args)
        {
            return CommandLineApplication.Execute<Program>(args);
        }
    }
    [Command(Description = "Command to uppercase string", Name = "uppercase")]
    class UpperCase
    {
        [Argument(0)]
        public string text { get; set; }
        public void OnExecute(CommandLineApplication app)
        {
            Console.WriteLine($"{text.ToUpper()}");
        }
    }
    [Command(Description = "Command to lowercase string", Name = "lowercase")]
    class LowerCase
    {
        [Argument(0)]
        public string text { get; set; }
        public void OnExecute(CommandLineApplication app)
        {
            Console.WriteLine($"{text.ToLower()}");
        }
    }
}
//private void OnExecute()
//{
//    var subject = Subject ?? "kaliMAT alAyz BetCh";

//    //algo num1 - low up cap
//    Console.WriteLine(subject.ToLower());
//    Console.WriteLine(subject.ToUpper());
//    Console.WriteLine(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(subject.ToLower()));

//    ////algo num2 - kabataku
//    long sumPlus = 0;
//    Console.Write("Insert number to plus: ");
//    String pilus = Console.ReadLine();
//    String[] Pilus = pilus.Split(' ');
//    for (int i = 0; i < Pilus.Length; i++)
//    {
//        int plus = Convert.ToInt32(Pilus[i]);
//        sumPlus += plus;
//    }
//    Console.WriteLine(sumPlus);

//Console.Write("Insert number to Min: ");
//String minus = Console.ReadLine();
//String[] Minus = minus.Split(' ');
//long sumMin = Convert.ToInt32(Minus[0]);

//for (int i = 1; i < Minus.Length; i++)
//{
//    int min = Convert.ToInt32(Minus[i]);
//    sumMin -= min;
//}
//Console.WriteLine(sumMin);

//Console.Write("Insert number to Mul: ");
//String multi = Console.ReadLine();
//String[] Multi = multi.Split(' ');
//double sumMul = Convert.ToDouble(Multi[0]);
//for (int i = 1; i < Multi.Length; i++)
//{
//    double mul = Convert.ToDouble(Multi[i]);
//    sumMul *= mul;
//}
//Console.WriteLine(sumMul);

//Console.Write("Insert number to Div: ");
//String divid = Console.ReadLine();
//String[] Divid = divid.Split(' ');
//double sumDiv = Convert.ToDouble(Divid[0]);
//for (int i = 1; i < Divid.Length; i++)
//{
//    double div = Convert.ToDouble(Divid[i]);
//    sumDiv /= div;
//}
//Console.WriteLine(sumDiv);

//algo num3 - palindrome

//algo num4 - obfuscator
//String email = "email@example.com";
//char[] Email = email.ToCharArray();
//List<string> Obfused = new List<string>();
//for (int i = 0; i < Email.Length; i++)
//{
//    Obfused.Add($"&#{Convert.ToString(Convert.ToInt32(Email[i]))}");
//}
//Console.WriteLine(String.Join(";", Obfused));

//algo num5 - random string

//algo num6 - ip address private network
//String Host = Dns.GetHostName();

//algo num7 - ip address external

//algo num8 - screenshot from url

//algo num9 - screenshot from list of file


//aldo num10 - infinite inputs
//    long sum = 0;
//    string X = "";
//    while (X != null)
//    {
//        Console.Write("Insert number :");
//        X = Console.ReadLine();
//        if(X=="")
//        {
//            break;
//        }
//        else
//        {
//            long A = Convert.ToInt32(X);
//            sum += A;
//        }
//    }
//    Console.WriteLine(sum);
//}



