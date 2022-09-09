using System;
using System.Collections.Generic;

namespace CreditSuisse.Model
{
    interface ITrade
    {
        double Value { get; }
        string ClientSector { get; }
        DateTime NextPaymentDate { get; }
    }

    public class TradeModel : ITrade
    {
        public DateTime referenceDate { get; set; }
        public Int32 tradesQuantity { get; set; }
        public double Value { get; set; }
        public string ClientSector { get; set; }
        public DateTime NextPaymentDate { get; set; }
    }
}
