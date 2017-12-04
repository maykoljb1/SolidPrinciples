using System;
using SolidPrinciples.SingleResponsability.Before.infrastructure;

namespace SolidPrinciples
{
    
    /* Single Responsibility Principle (SRP)
     *  -  A class should have only single responsibility. A single reason to change.
     *  -  Based on separation of concerns.
     *  -  Vary each concern independently of other concern.
     *  -  Each class should be designed to do one thing and it should do it well.
     *  -  The size of the classes become shorter. This makes code easily understandable.
     *
     * With the refactor AddNewCustomer only have 1 job and is to add the new customer
     * the responsability or job to add the custsomer to add it to the db is managed by the DbContext Class
     * the responsability or job to sent the sms notification is now managed by the SmsService Class
     */
    
    /// <summary>
    /// provides customer operations
    /// </summary>
    public class CustomerService
    {
        private readonly CustomerDbContext _customerDbContext;
        private readonly CustomerSmsService _customerSmsService;
        public CustomerService(CustomerDbContext customerDbContext, CustomerSmsService customerSmsService)
        {
            _customerDbContext = customerDbContext;
            _customerSmsService = customerSmsService;
        }
        
        /// <summary>
        /// Add new customer and sent the welcome sms
        /// </summary>
        public void AddNewCustomer(string name, string phone)
        {
            if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(phone))
            {
                throw new Exception("Invalid arguments");
            }
            var customer = new Customer{ Name = name, Phone = phone};
            
            
            _customerDbContext.Add(customer);

            //Sent welcome sms
            _customerSmsService.SentWelcomeCustomerSms(customer);
        }
    }
}