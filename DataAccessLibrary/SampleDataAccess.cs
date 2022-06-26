using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class SampleDataAccess
    {
        private readonly IMemoryCache _memoryCache;

        public SampleDataAccess(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        public List<EmployeeModel> GetEmployees()
        {
            List<EmployeeModel> output = new();

            output.Add(new() { FirstName  = "Nonanik", LastName = "Toor"});
            output.Add(new() { FirstName  = "Root", LastName = "Toor"});
            output.Add(new() { FirstName  = "Muro", LastName = "Suro"});

            Thread.Sleep(3000);

            return output;
        }
        public async Task<List<EmployeeModel>> GetEmployeesAsync() 
        {
            List<EmployeeModel> output = new();

            output.Add(new() { FirstName = "Nonanik", LastName = "Toor" });
            output.Add(new() { FirstName = "Root", LastName = "Toor" });
            output.Add(new() { FirstName = "Muro", LastName = "Suro" });

            await Task.Delay(3000);

            return output;
        }

        public async Task<List<EmployeeModel>> GetEmployeeCache()
        {
            List<EmployeeModel> output;

            output = _memoryCache.Get<List<EmployeeModel>>("employees");

            if (output is null)
            {
                output = new();

                output.Add(new() { FirstName = "Nonanik", LastName = "Toor" });
                output.Add(new() { FirstName = "Root", LastName = "Toor" });
                output.Add(new() { FirstName = "Muro", LastName = "Suro" });

                await Task.Delay(3000);

                _memoryCache.Set("emloyees", output, TimeSpan.FromMinutes(1));
            }

            return output;
        }
    }
}
