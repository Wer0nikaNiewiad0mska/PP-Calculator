using System.Text.RegularExpressions;

class Calculator
{
    //przedstawia definicję metody DoOperation, która przyjmuje trzy argumenty:
    //dwie liczby zmiennoprzecinkowe (double num1 i double num2) oraz łańcuch znaków (string op),
    //który reprezentuje operację matematyczną do wykonania na tych liczbach.
    //Funkcja zwraca wynik operacji w postaci typu double
    //public – metoda jest dostępna z zewnątrz i może być używana przez inne klasy.
    //static – metoda należy do klasy, a nie do instancji(obiektu) i może być wywoływana
    //bez konieczności tworzenia obiektu tej klasy.
    public static double DoOperation(double num1, double num2, string op)
    {
        //zmienna "result" jest inicjalizowana wartością NaN (Not a Number)
        double result = double.NaN;

        //"switch" - konstrukcja języka; służy do wyboru i wykonania jednego z wielu bloków kodu
        //w zależności od wyrażenia w "Console.ReadLine()
        //"break" - kończy działanie tego konkretnego przypadku, zapobiegając przejściu do kolejnych
        switch (op)
        {
            case "a":
                result = num1 + num2;
                break;
            case "s":
                result = num1 - num2;
                break;
            case "m":
                result = num1 * num2;
                break;
            case "d":
                if (num2 != 0)
                {
                    result = num1 / num2;
                }
                break;
            //W instrukcji switch, default oznacza domyślną gałąź, która zostanie wykonana,
            //jeśli żadna z określonych wartości w case nie pasuje do wartości porównywanej.
            default:
                break;
        }
        return result;
    }
}

class Program
{
    //Jest punktem startowym programu, czyli metodą,
    //od której rozpoczyna się wykonanie aplikacji konsolowej.
    static void Main(string[] args)
    {
        //Tego typu zmienna jest często używana w pętlach, które kontrolują,
        //kiedy aplikacja ma się zakończyć.
        bool endApp = false;
        Console.WriteLine("Console Calculator in C#\r");
        Console.WriteLine("------------------------\n");

        while (!endApp)
        {
            //string? to typ danych reprezentujący łańcuch znaków z obsługą wartości null
            string? numInput1 = "";
            string? numInput2 = "";
            double result = 0;

            Console.Write("Type a number, and then press Enter: ");
            //"Console.ReadKey()" - po tym poleceniu program się wstrzymuje i czeka na wprowadzenie klawisza
            numInput1 = Console.ReadLine();

            double cleanNum1 = 0;
            //double.TryParse to metoda, która próbuje przekonwertować wartość tekstową
            //(łańcuch znaków) na liczbę zmiennoprzecinkową typu double
            //Znak ! przed wyrażeniem double.TryParse oznacza negację. Oznacza to, że pętla while
            //będzie działała dopóki TryParse nie uda się
            while (!double.TryParse(numInput1, out cleanNum1))
            {
                Console.Write("This is not valid input. Please enter a numeric value: ");
                numInput1 = Console.ReadLine();
            }

            Console.Write("Type another number, and then press Enter: ");
            numInput2 = Console.ReadLine();

            double cleanNum2 = 0;
            while (!double.TryParse(numInput2, out cleanNum2))
            {
                Console.Write("This is not valid input. Please enter a numeric value: ");
                numInput2 = Console.ReadLine();
            }

            //"\t" - znak specjalny; oznacza tabulator przed którąś z liter
            Console.WriteLine("Choose an operator from the following list:");
            Console.WriteLine("\ta - Add");
            Console.WriteLine("\ts - Subtract");
            Console.WriteLine("\tm - Multiply");
            Console.WriteLine("\td - Divide");
            Console.Write("Your option? ");

            string? op = Console.ReadLine();

            if (op == null || !Regex.IsMatch(op, "[a|s|m|d]"))
            {
                Console.WriteLine("Error: Unrecognized input.");
            }
            else
            {
                try
                {
                    result = Calculator.DoOperation(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("This operation will result in a mathematical error.\n");
                    }
                    else Console.WriteLine("Your result: {0:0.##}\n", result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
                }
            }
            Console.WriteLine("------------------------\n");

            Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
            if (Console.ReadLine() == "n") endApp = true;

            Console.WriteLine("\n");
        }
        return;
    }
}