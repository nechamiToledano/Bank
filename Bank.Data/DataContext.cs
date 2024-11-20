using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Bank.Data
{
    public class DataContext {
        private string GetPath<T>()
        {
            return Path.Combine(AppContext.BaseDirectory, "Data", $"{typeof(T).Name}.csv");
        }

        public List<T> LoadData<T>() where T : new()
        {
            string path = GetPath<T>();
            var result = new List<T>();

            try
            {
                if (!File.Exists(path))
                {
                    return result;
                }

                using (var reader = new StreamReader(path))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    result = csv.GetRecords<T>().ToList();
                }
            }
            catch
            {
                return null;
            }

            return result;
        }

        public bool SaveData<T>(List<T> data)
        {
            string path = GetPath<T>();

            try
            {
                using (var writer = new StreamWriter(path))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    // Write the header row and records
                    csv.WriteRecords(data);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
