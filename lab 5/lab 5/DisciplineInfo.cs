using System;

namespace lab5
{
    public struct DisciplineInfo
    {
        public string DisciplineName;
        public string TeacherFullName;
        public string GroupName;
        public int StudentsCount;
        public FinalControlType FinalControl;
        public bool HasCourseWork;
        public string SpecialtyName;
        public int SemesterNumber;

        public override string ToString()
        {
            return
                $"Дисципліна: {DisciplineName}\n" +
                $"Викладач:   {TeacherFullName}\n" +
                $"Група:      {GroupName} (студентів: {StudentsCount})\n" +
                $"Контроль:   {FinalControl}\n" +
                $"Курсова:    {(HasCourseWork ? "так" : "ні")}\n" +
                $"Спеціальність: {SpecialtyName}\n" +
                $"Семестр:    {SemesterNumber}";
        }

        public string TeacherSurname
        {
            get
            {
                if (string.IsNullOrWhiteSpace(TeacherFullName)) return "";
                return TeacherFullName.Split(' ')[0];
            }
        }
    }
}
