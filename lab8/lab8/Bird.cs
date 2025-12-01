using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{
    public class Bird : Animal
    {
        private bool canFly; 

        public Bird() : base()
        {
            canFly = false;
        }

        public Bird(int age, double weight, string gender, bool canFly)
            : base(age, weight, gender)
        {
            this.canFly = canFly;
        }

        public Bird(int age, double weight, bool canFly)
            : base(age, weight)
        {
            this.canFly = canFly;
        }

        public Bird(Bird other) : base(other)
        {
            this.canFly = other.canFly;
        }

        public void ChangeFlightAbility(bool canFly)
        {
            this.canFly = canFly;
        }

        public override void ShowInfo()
        {
            string fly = canFly ? "Літає" : "Не літає";
            Console.WriteLine($"[Птах] Вік: {age}, Вага: {weight}, Стать: {gender}, Здатність: {fly}");
        }
    }
}
