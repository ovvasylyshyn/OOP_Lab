using System;
using System.Collections.Generic;
using System.IO;

namespace lab5
{
    public static class FileStore
    {
        public static void Append(string path, DisciplineInfo info)
        {
            string line = $"{info.DisciplineName}|{info.TeacherFullName}|" +
                $"{info.GroupName}|{info.StudentsCount}|{(int)info.FinalControl}" +
                $"|{info.HasCourseWork}|{info.SpecialtyName}|{info.SemesterNumber}";
            File.AppendAllText(path, line + Environment.NewLine);
        }

        public static List<DisciplineInfo> ReadAll(string path)
        {
            var list = new List<DisciplineInfo>();
            if (!File.Exists(path)) return list;

            foreach (var line in File.ReadAllLines(path))
            {
                var parts = line.Split('|');
                if (parts.Length < 8) continue;

                DisciplineInfo d = new DisciplineInfo
                {
                    DisciplineName = parts[0],
                    TeacherFullName = parts[1],
                    GroupName = parts[2],
                    StudentsCount = int.Parse(parts[3]),
                    FinalControl = (FinalControlType)int.Parse(parts[4]),
                    HasCourseWork = bool.Parse(parts[5]),
                    SpecialtyName = parts[6],
                    SemesterNumber = int.Parse(parts[7])
                };
                list.Add(d);
            }
            return list;
        }
    }
}
