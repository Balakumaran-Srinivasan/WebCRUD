using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCRUDCore.cs.Interfaces;
using WebCRUDInfraStructure.cs.DataDbContext;
using WebCRUDInfraStructure.cs.Table;
using WebCRUDModel.cs;

namespace WebCRUDCore.cs.Implementation
{
    public class CustomerCreator : ICustomerCreator
    {
        private readonly WebDbContext _webDbContext;

        public CustomerCreator(WebDbContext webDbContext)
        {
            _webDbContext = webDbContext;
        }

        public  void CreateCustomer(CustomerReqestmodel customerReqestmodel)
        {

            var customer = new Customer()
            {
                Name = customerReqestmodel.Name

            };
            _webDbContext.Add(customer);
            _webDbContext.SaveChanges();

        }
    }
}
