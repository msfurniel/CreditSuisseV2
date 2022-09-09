using System;
using CreditSuisse.Model;
using System.Globalization;

namespace CreditSuisse
{
    class Program
    {
        static void Main(string[] args)
        {
            TradeModel trade = new TradeModel();

            string[] lines = System.IO.File.ReadAllLines("trades.txt");

            foreach (string line in lines)
            {
                if (line.Length == 10)
                {
                    trade.referenceDate = DateTime.Parse(line);
                }

                if (line.Length == 1)
                {
                    trade.tradesQuantity = int.Parse(line);
                }

                if (line.Length > 10)
                {
                    CultureInfo provider = CultureInfo.InvariantCulture;

                    string[] vs = line.Split(" ");

                    trade.Value = double.Parse(vs[0]);
                    trade.ClientSector = vs[1];
                    trade.NextPaymentDate = DateTime.ParseExact(vs[2], "d", provider);



                    if (trade.NextPaymentDate.AddDays(-30) <= trade.referenceDate)
                    {
                        Console.WriteLine("DEFAULTED");
                    }
                    else
                    {
                        if ((trade.Value > 1000000) && (trade.ClientSector == "Private"))
                        {
                            Console.WriteLine("HIGHRISK");
                        }
                        else
                        {
                            Console.WriteLine("MEDIUMRISK");
                        }
                    }
                }
            }
        }
    }
}
