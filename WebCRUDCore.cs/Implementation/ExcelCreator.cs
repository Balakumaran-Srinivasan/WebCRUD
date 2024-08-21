using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCRUDInfraStructure.cs.DataDbContext;

 
using WebCRUDInfraStructure.cs.Table;
using ExcelDataReader;
using WebCRUDCore.cs.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Reflection.PortableExecutable;

namespace WebCRUDCore.cs.Implementation
{
    public class ExcelCreator : IExcelCreator
    {

        private readonly WebDbContext _webDbContext;

        public ExcelCreator(WebDbContext webDbContext)
        {
            _webDbContext = webDbContext;
        }

        public async Task uploadFile(IFormFile file)
        {
            List<Customer> customers = new List<Customer>();

            // Ensure ExcelDataReader is configured to support system encoding
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                stream.Position = 0;  // Reset stream position to the beginning

                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    // Skip the header row
                    if (reader.Read())
                    {
                        while (reader.Read()) // Each row in the file
                        {
                            var customer = new Customer
                            {
                                Name = reader.GetString(0)?.Trim(), // Column 1: Name
                                Age = Convert.ToInt32(reader.GetValue(1))          // Column 2: Age
                            };

                            customers.Add(customer);
                        }
                    }
                }
            }
            
            // Insert data into the database
            _webDbContext.Customers.AddRange(customers);
            await _webDbContext.SaveChangesAsync();
        }
    }
}

