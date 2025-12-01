using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{
    public class Fish : Animal
    {
        private bool isOceanic; 

        public Fish() : base()
        {
            isOceanic = false;
        }

        public Fish(int age, double weight, string gender, bool isOceanic)
            : base(age, weight, gender)
        {
            this.isOceanic = isOceanic;
        }

        public Fish(int age, double weight, bool isOceanic)
            : base(age, weight)
        {
            this.isOceanic = isOceanic;
        }

        public Fish(Fish other) : base(other)
        {
            this.isOceanic = other.isOceanic;
        }

        public void ChangeWaterType()
        {
            isOceanic = !isOceanic; 
        }

        public override void ShowInfo()
        {
            string type = isOceanic ? "Океанічна" : "Прісноводна";
            Console.WriteLine($"[Риба] Вік: {age}, Вага: {weight}, Стать: {gender}, Тип: {type}");
        }
    }
}
