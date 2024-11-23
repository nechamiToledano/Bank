using Bank.Core.Entities;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Bank.Data
{
    public class DataContext:IDataContext {
        public List<Account> Accounts { get; set; }
        public List<CreditCard> CreditCards { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Loan> Loans { get; set; }
        public List<Operation> Operations { get; set; }
        public DataContext()
        {
            Accounts = LoadData<Account>();
            CreditCards =LoadData<CreditCard>();
            Customers =  LoadData<Customer>();
            Loans =LoadData<Loan>();
            Operations = LoadData<Operation>();

        }
        private string GetPath<T>()
        {
            return Path.Combine(AppContext.BaseDirectory, "Data", $"{typeof(T).Name}.csv");
        }

        public List<T> LoadData<T>() 
        {
            string path = GetPath<T>();
            List<T> result;

            try
            {
                if (!File.Exists(path))
                {
                    return null;
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
