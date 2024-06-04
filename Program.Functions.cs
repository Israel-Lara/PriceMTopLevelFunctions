using System.Globalization;
using System.Linq;
using static System.Console;
//Do not define a namespace to this class goes in the default empty namespace
// just like the auto-generate partial Program  class.

partial class Program
{
    static void WhatsMyNamespace() //Define a static function
    {
        WriteLine("Namespace of Program class: {0}", arg0:  typeof(Program).Namespace ?? "null");
    }

    static decimal CalculateTax(decimal amount, string twoLetterRegionCode)
    {
        decimal rate = twoLetterRegionCode switch
        {            
            "CH" => 0.0M, //Switzerland
            "DK" or "NO" => 0.25M, // Denmark, Norway
            "GB" or "FR" => 0.2M, // UK, France
            "HU" => 0.27M, //Hungary
            "OR" or "AK" or "MT" => 0.0M, //Oregon, Alaska, Montana
            "ND" or "WI" or "ME" or "VA" => 0.05M,
            "CA" => 0.0825M, //California
            _=> 0.06M // Most other states
        };
        return amount*rate;
    }

    static void ConfigureConsole(string culture="en-US", bool useComputerCulture=false)
    {
        //To enable Unicode characters like Euro symbol in the console.
        OutputEncoding = System.Text.Encoding.UTF8;

        if(!useComputerCulture)
        {
            CultureInfo.CurrentCulture=CultureInfo.GetCultureInfo(culture);
        }
        WriteLine($"CurrentCulture: {CultureInfo.CurrentCulture.DisplayName}");
    }

    static string CardinalToOrdinal(uint number)
    {
        uint lastTwoDigits = number % 100;

        switch(lastTwoDigits)
        {
            case 11: // Special cases for 11th to 13th
            case 12:
            case 13:
                return $"{number:N0}th";
            default:
            uint lastDigit=number % 10;

            string suffix = lastDigit switch
            {
                1=>"st",
                2=>"nd",
                3=> "rd",
                _=>"th"
            };
            return $"{number:N0}{suffix}";
        }
    }

    static void RunCardinalToOrdinal()
    {
        for(uint number=1; number<= 150; number++)
        {
            Write($"{CardinalToOrdinal(number)} ");
        }
        WriteLine();
    }

    static void WriteFactorials(uint givenNumber)
    {
        string builtChain="";

        for (int i = 1; i < givenNumber; i++)
        {
            builtChain += "X";
        }

        WriteLine(builtChain);

        // while (givenNumber>1)
        // {
            
        // }
    }

    static void UnderstandingTernaryOperators()
    {

        int x = 5;
        string result = x > 3? "Greater than 3" : "Less than or equal to 3";

        //Equivalent using an if statement
        
        if(x>3){
            result ="Greater than 3";            
        }
        else
        {
            result = "Less than or equal to 3";
        }


    
    }

    static int Factorial(int number)
    {
        if(number<0)
        {
            throw new ArgumentOutOfRangeException(message: 
            $"The factorial function is defined for non-negative integers only. Input: {number}", paramName: nameof(number));
        }
        else if(number==0)
        {
            return 1;
        }
        else
        {
            return number*Factorial(number-1);
        }
    }


    static void RunFactorial()
    {
        for (int i = -2; i < 15; i++)
        {
            try
            {
                WriteLine($"{i}! = {Factorial(i):N0}");
            }
            catch(OverflowException)
            {
                WriteLine($"{i}! is too big for a 32-bit integer.");
            }
            catch (System.Exception ex)
            {
               WriteLine($"{i}! throws {ex.GetType()}: {ex.Message}");
            }
            
        }
    }

    static int FibImperative(uint term)
    {
        if(term==0)
        {
            throw new ArgumentOutOfRangeException();
        }
        else if(term==1)
        {
            return 0;            
        }
        else if(term==2)
        {
            return 1;
        }
        else
        {
            return FibImperative(term -1) + FibImperative(term-2);
        }
    }

    static void RunFibImperative()
    {
        for(uint i=1;i<=30; i++)
        {
            WriteLine("The {0} term of the Fibonnaci sequence is {1:N0}",
                arg0: CardinalToOrdinal(i),
                arg1: FibImperative(term: i));

        }
    }
}