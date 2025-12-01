using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{
    public class Animal
    {
        protected int age;
        protected double weight;
        protected string gender; 

        public Animal()
        {
            age = 0;
            weight = 0.0;
            gender = "Unknown";
        }

        public Animal(int age, double weight, string gender)
        {
            this.age = age;
            this.weight = weight;
            this.gender = gender;
        }

        public Animal(int age, double weight)
        {
            this.age = age;
            this.weight = weight;
            this.gender = "Unknown";
        }

        public Animal(Animal other)
        {
            this.age = other.age;
            this.weight = other.weight;
            this.gender = other.gender;
        }

        public void SetAge(int newAge)
        {
            if (newAge >= 0) age = newAge;
        }

        public void SetWeight(double newWeight)
        {
            if (newWeight > 0) weight = newWeight;
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"[Тварина] Вік: {age}, Вага: {weight}, Стать: {gender}");
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Animal other = (Animal)obj;
            return this.age == other.age &&
                   this.weight == other.weight &&
                   this.gender == other.gender;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(age, weight, gender);
        }
    }
}