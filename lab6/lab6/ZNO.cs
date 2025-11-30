using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    internal class ZNO
    {
        private string subject;
        private double points;

        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }

        public double Points
        {
            get { return points; }
            set
            {
                if (value < 0) points = 0;
                else if (value > 200) points = 200;
                else points = value;
            }
        }

        public ZNO()
        {
            subject = "Невідомо";
            points = 0;
        }

        public ZNO(string subject, double points)
        {
            this.Subject = subject;
            this.Points = points;
        }

        public ZNO(string subject)
        {
            this.Subject = subject;
            this.points = 0;
        }

        public ZNO(ZNO other)
        {
            this.subject = other.Subject;
            this.points = other.Points;
        }

        public override string ToString()
        {
            return subject + ": " + points + " балів";
        }
    }
}


