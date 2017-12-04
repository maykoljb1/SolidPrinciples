using System;
using SolidPrinciples.SingleResponsability.After.infrastructure;

namespace SolidPrinciples.SingleResponsability.After
{
    /*
     * The issues in this class is the method AddNewCustomer it has too many responsabilities or jobs to do
     * 1. It has to validate the arguments of the new customer object.
     * 2. It has to create the connection to the db and insert the customer in to db
     * 3. It has to create and sent the welcome sms message.
    */
    
    /// <summary>
    /// provides customer operations
    /// </summary>
    public class CustomerService
    {
        /// <summary>
        /// Add new customer and sent the welcome sms
        /// </summary>
        public void AddNewCustomer(string name, string phone)
        {
            //Create new customer
            if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(phone))
            {
                throw new Exception("Invalid arguments");
            }
            var customer = new Customer{ Name = name, Phone = phone};
            
            //Add customer to DB
            var dbCnx = new Connection("MyAppConnectionString");
            //For the sake of the example ignore the sql injection.
            dbCnx.Command = new DbCommand($"INSERT INTO customer (Name, Phone) VALUES ({customer.Name}, {customer.Phone}");
            
            //Sent welcome sms
            var smsMessage = $"Hello new customer {customer.Phone}";
            SentSMS(smsMessage);
        }

        private void SentSMS(string smsMessage)
        {
            throw new System.NotImplementedException();
        }
    }
}