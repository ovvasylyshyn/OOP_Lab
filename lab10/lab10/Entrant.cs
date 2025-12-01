using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{
    public class Entrant
    {
        public string FullName { get; set; }
        public string IdNum { get; set; }
        public double AvgPoints { get; set; }

        public List<ZNO> ZnoResults { get; set; }

        public Entrant(string fullName, string idNum, double avgPoints)
        {
            FullName = fullName;
            IdNum = idNum;
            AvgPoints = avgPoints;
            ZnoResults = new List<ZNO>(); // Ініціалізуємо порожній список
        }

        public override string ToString()
        {
            return $"[{IdNum}] {FullName}, Сер. бал: {AvgPoints}";
        }
    }
}
