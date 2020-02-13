using System;
using McMaster.Extensions.CommandLineUtils;
using System.Globalization;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Net;
using System.Text;
using System.Net.Sockets;

namespace CLI_Test
{
    [HelpOption("--hlp")]
    [Subcommand(
        //1
        typeof(UpperCase),typeof(LowerCase),typeof(Capital),
        //2
        typeof(Add),typeof(Substract),typeof(Multiply),typeof(Divide),
        //3
        typeof(Palindrome),
        //4
        typeof(Obfuscator),
        //5
        typeof(Random_),
        //6
        typeof(Ip),
        //7
        typeof(IpEx),
        //10
        typeof(Sum)
    )]
    
    class Program
    {
        static int Main(string[] args)
        {
            return CommandLineApplication.Execute<Program>(args);
        }
    }

    //num1
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

    //num2
    [Command(Description = "Command to add number", Name = "add")]
    class Add
    {
        [Argument(0)]
        public int [] num { get; set; }
        public void OnExecute(CommandLineApplication app)
        {
            long sum = 0;
            for (int i = 0; i < num.Length; i++)
            {
                sum += num[i];
            }
            Console.WriteLine(sum);

        }
    }
    [Command(Description = "Command to substract number", Name = "substract")]
    class Substract
    {
        [Argument(0)]
        public int [] num { get; set; }
        public void OnExecute(CommandLineApplication app)
        {
            long sum = num[0];
            for (int i = 1; i < num.Length; i++)
            {
                sum -= num[i];
            }
            Console.WriteLine(sum);
        }
    }
    [Command(Description = "Command to multiply number", Name = "multiply")]
    class Multiply
    {
        [Argument(0)]
        public int [] num { get; set; }
        public void OnExecute(CommandLineApplication app)
        {

            double sum = num[0];
            for (int i = 1; i < num.Length; i++)
            {
                sum *= num[i];
            }
            Console.WriteLine(sum);

        }
    }
    [Command(Description = "Command to divide number", Name = "divide")]
    class Divide
    {
        [Argument(0)]
        public int [] num { get; set; }
        public void OnExecute(CommandLineApplication app)
        {
            double sum = num[0];
            for (int i = 1; i < num.Length; i++)
            {
                sum /= num[i];
            }
            Console.WriteLine(sum);
        }
    }

    //num3
    [Command(Description = "Command to check if string is palindrome", Name = "palindrome")]
    class Palindrome
    {
        [Argument(0)]
        public string text { get; set; }
        public void OnExecute(CommandLineApplication app)
        {
            Console.WriteLine($"String: \"{text}\" ");
            string Text = (Regex.Replace(text, @"[a-zA-Z]+", "")).ToLower();
            char[] ch = Text.ToCharArray();
            Array.Reverse(ch);
            string TextRev = new string(ch);
            bool check = Text.Equals(TextRev, StringComparison.OrdinalIgnoreCase);
            Console.WriteLine($"is palindrome? {check}");

        }
    }

    //num4
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

    //num5
    [Command(Description = "Command to generate random string", Name = "random")]
    class Random_
    {

        [Option("--letters")]
        public string letters { get; set; }
        [Option("--numbers")]
        public string Number { get; set; }
        [Option("--length")]
        public int charLength { get; set; }
        [Option("--uppercase")]
        public bool upper { get; set; }
        [Option("--lowercase")]
        public bool lower { get; set; }

        public void OnExecute(CommandLineApplication app)
        {
            Random random = new Random();
            var all = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var num = "0123456789";
            var letter = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

            int length = charLength;
            if(length==0)
            {
                length = 32;
            }
            var stringChar = new char[length];

            if (letters == "false")
            {
                
                for (int i = 0; i < length; i++)
                {
                    stringChar[i] = num[random.Next(num.Length)];
                }
            }
            else if (Number == "false")
            {
                for (int i = 0; i < length; i++)
                {
                    stringChar[i] = letter[random.Next(letter.Length)];
                }
            }
            else
            {
                for (int i = 0; i < length; i++)
                {
                    stringChar[i] = all[random.Next(all.Length)];
                }
            }

            if (upper == true)
            {
                var finalStringUp = new String(stringChar).ToUpper();
                Console.WriteLine(finalStringUp);
            }
            else if (lower == true)
            {
                var finalStringLow = new String(stringChar).ToLower();
                Console.WriteLine(finalStringLow);
            }
            else
            {
                var finalString = new String(stringChar);
                Console.WriteLine(finalString);
            }

        }
    }

    //num6
    [Command(Description = "Command to get private ip address", Name = "ip")]
    class Ip
    {
        public void OnExecute(CommandLineApplication app)
        {
            string address ="";
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    address = ip.ToString();
                }
            }
            Console.WriteLine(address);
        }
    }

    //num7
    [Command(Description = "Command to get private ip address", Name = "ip-external")]
    class IpEx
    {
        public void OnExecute(CommandLineApplication app)
        {
            string address = new WebClient().DownloadString("http://icanhazip.com");
            Console.WriteLine(address);
        }
    }

    //num10
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
        }
    }
}
