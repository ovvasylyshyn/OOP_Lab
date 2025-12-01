using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9
{
    public class Organization : IComparable<Organization>
    {
        public string Name { get; set; }
        public int EmployeeCount { get; set; }
        public double Rating { get; set; }

        public Organization(string name, int count, double rating)
        {
            Name = name;
            EmployeeCount = count;
            Rating = rating;
        }

        public int CompareTo(Organization other)
        {
            if (other == null) return 1;
            return this.EmployeeCount.CompareTo(other.EmployeeCount);
        }

        public override string ToString()
        {
            return $"Організація: {Name,-15} | Співробітників: {EmployeeCount,-5} | Рейтинг: {Rating:F1}";
        }
    }

    public class SortByEmployees : IComparer<Organization>
    {
        public int Compare(Organization x, Organization y)
        {
            if (x == null || y == null) return 0;
            return x.EmployeeCount.CompareTo(y.EmployeeCount);
        }
    }

    public class SortByRating : IComparer<Organization>
    {
        public int Compare(Organization x, Organization y)
        {
            if (x == null || y == null) return 0;
            return y.Rating.CompareTo(x.Rating);
        }
    }

    public class OrganizationGroup : IEnumerable<Organization>
    {
        private List<Organization> organizations;

        public OrganizationGroup()
        {
            organizations = new List<Organization>();
        }

        public void Add(Organization org)
        {
            organizations.Add(org);
        }

        public void Sort(IComparer<Organization> comparer)
        {
            organizations.Sort(comparer);
        }

        public void SortDefault()
        {
            organizations.Sort();
        }

        public IEnumerator<Organization> GetEnumerator()
        {
            return organizations.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
