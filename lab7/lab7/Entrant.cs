using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7
{
    public class Entrant
    {
        private string fullName;
        private string idNum;
        private double avgPoints;
        private bool isAwarded;
        private ZNO[] znoResults;
        private double tuitionPerMonth;

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

        public double TuitionPerMonth
        {
            get { return tuitionPerMonth; }
            set
            {
                if (value < 0) tuitionPerMonth = 0;
                else tuitionPerMonth = value;
            }
        }

        public double TuitionPerYear
        {
            get { return tuitionPerMonth * 10; }
        }

        public double TuitionTotal
        {
            get { return tuitionPerMonth * 40; }
        }

        public Entrant()
        {
            fullName = "Немає даних";
            idNum = "000000";
            avgPoints = 0;
            isAwarded = false;
            znoResults = new ZNO[0];
            tuitionPerMonth = 0;
        }

        public Entrant(string fullName, string idNum, double avgPoints, bool isAwarded, ZNO[] znoResults, double tuitionPerMonth)
        {
            this.fullName = fullName;
            this.idNum = idNum;
            this.avgPoints = avgPoints;
            this.isAwarded = isAwarded;
            this.znoResults = znoResults;
            this.TuitionPerMonth = tuitionPerMonth;
        }

        public Entrant(Entrant other)
        {
            this.fullName = other.FullName;
            this.idNum = other.IdNum;
            this.avgPoints = other.AvgPoints;
            this.isAwarded = other.IsAwarded;
            this.tuitionPerMonth = other.TuitionPerMonth;

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
            if (znoResults == null || znoResults.Length == 0) return "Немає предметів";
            ZNO best = znoResults[0];
            for (int i = 1; i < znoResults.Length; i++)
            {
                if (znoResults[i].Points > best.Points) best = znoResults[i];
            }
            return best.Subject;
        }

        public bool IsOnTopOfTheRating()
        {
            return isAwarded && avgPoints >= 4.9;
        }

        public override string ToString()
        {
            string medal = isAwarded ? "Так" : "Ні";
            string info = $"ПІБ: {fullName}\n" +
                          $"Код: {idNum}\n" +
                          $"Сер. бал: {avgPoints}\n" +
                          $"Медаль: {medal}\n" +
                          $"Вартість навчання:\n" +
                          $" - За місяць: {TuitionPerMonth} грн\n" +
                          $" - За рік (10 міс): {TuitionPerYear} грн\n" +
                          $" - Весь період (40 міс): {TuitionTotal} грн\n" +
                          $"Предмети ЗНО:";

            if (znoResults != null)
            {
                foreach (var z in znoResults) info += "\n - " + z.ToString();
            }
            return info;
        }
    }
}
