using System;
using McMaster.Extensions.CommandLineUtils;
using System.Globalization;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Net;

namespace CLI_Test
{
    [HelpOption("--hlp")]
    [Subcommand(
        typeof(UpperCase),typeof(LowerCase),typeof(Capital),
        typeof(Add),typeof(Substract),typeof(Multiply),typeof(Divide),
        typeof(Palindrome),
        typeof(Obfuscator),
        typeof(Sum)
    )]
    
    class Program
    {
        static int Main(string[] args)
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
            Console.WriteLine(text.ToUpper());
        }
    }
    [Command(Description = "Command to lowercase string", Name = "lowercase")]
    class LowerCase
    {
        [Argument(0)]
        public string text { get; set; }
        public void OnExecute(CommandLineApplication app)
        {
            Console.WriteLine(text.ToLower());
        }
    }
    [Command(Description = "Command to capitalize string", Name = "capitalize")]
    class Capital
    {
        [Argument(0)]
        public string text { get; set; }
        public void OnExecute(CommandLineApplication app)
        {
            Console.WriteLine(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower()));
        }
    }
    [Command(Description = "Command to add number", Name = "add")]
    class Add
    {
        [Argument(0)]
        public string num { get; set; }
        public void OnExecute(CommandLineApplication app)
        {
            long sum = 0;
            String[] Num = num.Split('_');
            for (int i = 0; i < Num.Length; i++)
            {
                int number = Convert.ToInt32(Num[i]);
                sum += number;
            }
            Console.WriteLine(sum);

        }
    }
    [Command(Description = "Command to substract number", Name = "substract")]
    class Substract
    {
        [Argument(0)]
        public string num { get; set; }
        public void OnExecute(CommandLineApplication app)
        {
            String[] Num = num.Split('_');
            long sum = Convert.ToInt32(Num[0]);
            for (int i = 0; i < Num.Length; i++)
            {
                int number = Convert.ToInt32(Num[i]);
                sum -= number;
            }
            Console.WriteLine(sum);

        }
    }
    [Command(Description = "Command to multiply number", Name = "multiply")]
    class Multiply
    {
        [Argument(0)]
        public string num { get; set; }
        public void OnExecute(CommandLineApplication app)
        {
            String[] Num = num.Split('_');
            double sum = Convert.ToDouble(Num[0]);
            for (int i = 0; i < Num.Length; i++)
            {
                double number = Convert.ToDouble(Num[i]);
                sum *= number;
            }
            Console.WriteLine(sum);

        }
    }
    [Command(Description = "Command to divide number", Name = "divide")]
    class Divide
    {
        [Argument(0)]
        public string num { get; set; }
        public void OnExecute(CommandLineApplication app)
        {

            String[] Num = num.Split('_');
            double sum = Convert.ToDouble(Num[0]);
            for (int i = 0; i < Num.Length; i++)
            {
                double number = Convert.ToDouble(Num[i]);
                sum /= number;
            }
            Console.WriteLine(sum);

        }
    }
    [Command(Description = "Command to check if string is palindrome", Name = "palindrome")]
    class Palindrome
    {
        [Argument(0)]
        public string text { get; set; }
        public void OnExecute(CommandLineApplication app)
        {

            string Text = (Regex.Replace(text, @"[a-zA-Z]+", "")).ToLower();
            char[] ch = Text.ToCharArray();
            Array.Reverse(ch);
            string TextRev = new string(ch);

            bool check = Text.Equals(TextRev, StringComparison.OrdinalIgnoreCase);
            Console.WriteLine(check);

        }
    }
    [Command(Description = "Command to obfuscate string", Name = "obfuscate")]
    class Obfuscator
    {
        [Argument(0)]
        public string text { get; set; }
        public void OnExecute(CommandLineApplication app)
        {

            char[] Text = text.ToCharArray();
            List<string> Obfused = new List<string>();
            for (int i = 0; i < Text.Length; i++)
            {
                Obfused.Add($"&#{Convert.ToString(Convert.ToInt32(Text[i]))}");
            }
            Console.WriteLine(String.Join(";", Obfused));

        }
    }
    [Command(Description = "Command to infinitely add numbers", Name = "sum")]
    class Sum
    {
        public void OnExecute(CommandLineApplication app)
        {
            long sum = 0;
            string X = "";
            while (X != null)
            {
                Console.Write("Insert number : ");
                X = Console.ReadLine();
                if (X == "")
                {
                    break;
                }
                else
                {
                    long A = Convert.ToInt32(X);
                    sum += A;
                }
            }
            Console.WriteLine(sum);
            //string hostname = Dns.GetHostName();
            //string host = Dns.GetHostByName(hostname).AddressList[0].ToString();
        }
    }
}
