using System;
using static System.Net.WebRequestMethods;
using System.Net;
using System.Globalization;

namespace ElectricBill
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = new CultureInfo("da-DK");

            byte counter = 0;
            ElectricBillWebContent electricBillWebContent = new();
            foreach (var item in electricBillWebContent.lsClockHour)
            {
                Console.WriteLine($"Den {electricBillWebContent.dtTomorrow.ToLongDateString()} klokken {item.ToShortTimeString()} koster strøm {electricBillWebContent.lsPriceDK1PerMWh[counter]:C2}");
                counter++;
            }
        }
    }

    public class ElectricBillWebContent
    {
        /*
           OPTIMERINGS FORSLAG: Auto indhente indholdet fra hjemmesiden, i stedet for manuelt at lægge data ind.
           string url = "https://www.random.org/integers/?num=1&min=1&max=100&col=1&base=10&format=plain&rnd=new";
           WebClient webClient = new();
           string tekstFraUrl = webClient.DownloadString(url);
        */

        public ElectricBillWebContent()
        {
            GenerateTimeOnlyClock();
        }


        public DateTime dtToday = DateTime.Today;
        public DateTime dtTomorrow = DateTime.Today.AddDays(1);
        public List<TimeOnly> lsClockHour = new List<TimeOnly>();
        public List<double> lsPriceDK1PerMWh = new List<double>
        {
            310.30, //h: 00-01
            299.58,
            299.54,
            299.58,
            297.28,
            340.94,
            427.01,
            534.75,
            527.71,
            429.07,
            358.15,
            321.62,
            298.37,
            302.26,
            311.38,
            331.88,
            364.32,
            406.74,
            470.00,
            574.51,
            490.53,
            403.66,
            370.00,
            349.39, //h: 23-00
        };

        private void GenerateTimeOnlyClock()
        {
            for (int i = 0; i < 24; i++)
            {
                this.lsClockHour.Add(new TimeOnly(i,0)); //i = hour, 0 = min
            }
        }

    }
}