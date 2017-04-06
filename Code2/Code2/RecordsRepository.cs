using System;
using System.Collections.Generic;
using System.IO;

namespace Code2
{
    public static class RecordsRepository
    {
        public static Dictionary<int, GameRecord> GetRecords()
        {
            var records = new Dictionary<int, GameRecord>();
            if (File.Exists(Path.Combine(Path.GetTempPath(), "CodeRecords.txt")))
            {
                var stringRecords = File.ReadAllLines(Path.Combine(Path.GetTempPath(), "CodeRecords.txt"));

                foreach (var sting in stringRecords)
                {
                    var sides = sting.Split(new string[] { ",=," }, StringSplitOptions.RemoveEmptyEntries);

                    var key = Int32.Parse(sides[0]);
                    var times = sides[1].Split(',');

                    List<double> values = new List<double>();
                    foreach (var time in times)
                    {
                        values.Add(Double.Parse(time));
                    }

                    records[key] = new GameRecord(values);
                }
            }

            return records;
        }

        public static void SaveRecords(Dictionary<int, GameRecord> records)
        {
            string serializedRecords = string.Empty;

            foreach (var rec in records)
            {
                serializedRecords += rec.Key + ",=";
                foreach (var time in rec.Value.Times)
                {
                    serializedRecords += ',' + time.ToString("F2");
                }
                serializedRecords += Environment.NewLine;
            }

            File.WriteAllText(Path.Combine(Path.GetTempPath(), "CodeRecords.txt"), serializedRecords);
        }
    }
}
