using System.Net.Http.Headers;

namespace ConsoleApp1
{
    internal class DataCollections
    {
        public List<Comservis> Comservis { get; set; }
        public List<Payment> Payments { get; set; }

        public DataCollections()
        {
            Comservis = new List<Comservis>();
            Payments = new List<Payment>();
        }
    }
    class Comservis
    {
        public string Surname { get; set; }
        public string Date { get; set; }
        public string TypeOfService { get; set; }
        public decimal AmountAccrued { get; set; }
    }

    class Payment
    {
        public string Surname { get; set; }
        public string TypeOfService { get; set; }
        public decimal PaidAmount { get; set; }
        public string PaymentDate { get; set; }
    }

}
