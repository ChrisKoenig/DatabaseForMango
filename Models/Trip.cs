using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace DatabaseForMango.Models
{
    public class Trip
    {
        // Fields...
        private Airport _ToAirportCode;
        private Airport _FromAirportCode;

        public Airport FromAirportCode
        {
            get { return _FromAirportCode; }
            set
            {
                _FromAirportCode = value;
            }
        }

        public Airport ToAirportCode
        {
            get { return _ToAirportCode; }
            set
            {
                _ToAirportCode = value;
            }
        }

        public DateTime FlightDate { get; set; }
    }
}