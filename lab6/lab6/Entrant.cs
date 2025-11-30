using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    internal class Entrant
    {
        private string fullName;
        private string idNum;
        private double avgPoints;
        private bool isAwarded;
        private ZNO[] znoResults;

        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        public string IdNum
        {
            get { return idNum; }
            set { idNum = value; }
        }

        public double AvgPoints
        {
            get { return avgPoints; }
            set { avgPoints = value; }
        }

        public bool IsAwarded
        {
            get { return isAwarded; }
            set { isAwarded = value; }
        }

        public ZNO[] ZNOResults
        {
            get { return znoResults; }
            set { znoResults = value; }
        }

        public Entrant()
        {
            fullName = "Немає даних";
            idNum = "000000";
            avgPoints = 0;
            isAwarded = false;
            znoResults = new ZNO[0];
        }

        public Entrant(string fullName, string idNum, double avgPoints, bool isAwarded, ZNO[] znoResults)
        {
            this.fullName = fullName;
            this.idNum = idNum;
            this.avgPoints = avgPoints;
            this.isAwarded = isAwarded;
            this.znoResults = znoResults;
        }

        public Entrant(string fullName, string idNum)
        {
            this.fullName = fullName;
            this.idNum = idNum;
            this.avgPoints = 0;
            this.isAwarded = false;
            this.znoResults = new ZNO[0];
        }

        public Entrant(Entrant other)
        {
            this.fullName = other.FullName;
            this.idNum = other.IdNum;
            this.avgPoints = other.AvgPoints;
            this.isAwarded = other.IsAwarded;

            if (other.ZNOResults != null)
            {
                this.znoResults = new ZNO[other.ZNOResults.Length];
                for (int i = 0; i < other.ZNOResults.Length; i++)
                {
                    this.znoResults[i] = new ZNO(other.ZNOResults[i]);
                }
            }
        }

        public string GetBestSubject()
        {
            if (znoResults == null || znoResults.Length == 0)
                return "Немає предметів";

            ZNO best = znoResults[0];
            for (int i = 1; i < znoResults.Length; i++)
            {
                if (znoResults[i].Points > best.Points)
                {
                    best = znoResults[i];
                }
            }
            return best.Subject;
        }

        public bool IsOnTopOfTheRating()
        {
            if (isAwarded == true && avgPoints >= 4.9)
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            string medal = isAwarded ? "Так" : "Ні";
            string info = "ПІБ: " + fullName + "\n" +
                          "Код: " + idNum + "\n" +
                          "Сер. бал: " + avgPoints + "\n" +
                          "Медаль: " + medal + "\n" +
                          "Предмети ЗНО:";

            if (znoResults != null)
            {
                foreach (var z in znoResults)
                {
                    info += "\n - " + z.ToString();
                }
            }
            return info;
        }
    }
}
