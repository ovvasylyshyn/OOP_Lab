using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{
    public class ZNO
    {
        public string Subject { get; set; }
        public double Points { get; set; }

        public ZNO(string subject, double points)
        {
            Subject = subject;
            Points = points;
        }

        public override string ToString()
        {
            return $"{Subject}: {Points}";
        }
    }
}
