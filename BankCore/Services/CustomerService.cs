using Azure;
using BankCore.Data;
using BankCore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using X.PagedList;
using X.PagedList.Extensions;




namespace BankCore.Services
{
    public class CustomerService
    {
        private readonly VictorBankAppContext _dbContext;

        public CustomerService(VictorBankAppContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IPagedList<Customer>GetAllCustomers(string sortColumn, string sortOrder, int pageNo, string q)
        {
            var allCustomers = _dbContext.Customers.AsQueryable();


            if (!string.IsNullOrEmpty(q))
            {
                allCustomers = allCustomers
                    .Where(p => p.Givenname.Contains(q) ||
                                p.Surname.Contains(q) ||
                                p.Country.Contains(q) ||
                                p.City.Contains(q) || // Stavningsfel på "City" rättat
                                p.Gender.Contains(q) ||
                                p.NationalId.Contains(q) ||
                                p.Streetaddress.Contains(q) ||
                                p.Zipcode.Contains(q) ||
                                p.CountryCode.Contains(q) ||
                                p.Telephonenumber.Contains(q) ||
                                p.Emailaddress.Contains(q));
            }

            if (sortColumn == "Country")
            {
                if (sortOrder == "asc")
                    allCustomers = allCustomers.OrderBy(c => c.Country);
            else if (sortOrder == "desc")
                    allCustomers = allCustomers.OrderByDescending(c => c.Country);
            }
            if (sortColumn == "Givenname")
            {
                if (sortOrder == "asc")
                    allCustomers = allCustomers.OrderBy(c => c.Givenname);
                else if (sortOrder == "desc")
                    allCustomers = allCustomers.OrderByDescending(c => c.Givenname);
            }
            if (sortColumn == "Surname")
            {
                if (sortOrder == "asc")
                    allCustomers = allCustomers.OrderBy(c => c.Surname);
                else if (sortOrder == "desc")
                    allCustomers = allCustomers.OrderByDescending(c => c.Surname);
            }
            if (sortColumn == "City")
            {
                if (sortOrder == "asc")
                    allCustomers = allCustomers.OrderBy(c => c.City);
                else if (sortOrder == "desc")
                    allCustomers = allCustomers.OrderByDescending(c => c.City);
            }
            if (sortColumn == "ID")
            {
                if (sortOrder == "asc")
                    allCustomers = allCustomers.OrderBy(c => c.NationalId);
                else if (sortOrder == "desc")
                    allCustomers = allCustomers.OrderByDescending(c => c.NationalId);
            }
            if (sortColumn == "Gender")
            {
                if (sortOrder == "asc")
                    allCustomers = allCustomers.OrderBy(c => c.Gender);
                else if (sortOrder == "desc")
                    allCustomers = allCustomers.OrderByDescending(c => c.Gender);
            }
            if (sortColumn == "Address")
            {
                if (sortOrder == "asc")
                    allCustomers = allCustomers.OrderBy(c => c.Streetaddress);
                else if (sortOrder == "desc")
                    allCustomers = allCustomers.OrderByDescending(c => c.Streetaddress);
            }
            if (sortColumn == "ZipCode")
            {
                if (sortOrder == "asc")
                    allCustomers = allCustomers.OrderBy(c => c.Zipcode);
                else if (sortOrder == "desc")
                    allCustomers = allCustomers.OrderByDescending(c => c.Zipcode);
            }
            if (sortColumn == "Country")
            {
                if (sortOrder == "asc")
                    allCustomers = allCustomers.OrderBy(c => c.Country);
                else if (sortOrder == "desc")
                    allCustomers = allCustomers.OrderByDescending(c => c.Country);
            }
            if (sortColumn == "CountryCode")
            {
                if (sortOrder == "asc")
                    allCustomers = allCustomers.OrderBy(c => c.CountryCode);
                else if (sortOrder == "desc")
                    allCustomers = allCustomers.OrderByDescending(c => c.CountryCode);
            }
            if (sortColumn == "Prefix")
            {
                if (sortOrder == "asc")
                    allCustomers = allCustomers.OrderBy(c => c.CountryCode);
                else if (sortOrder == "desc")
                    allCustomers = allCustomers.OrderByDescending(c => c.CountryCode);
            }
            if (sortColumn == "Telephone")
            {
                if (sortOrder == "asc")
                    allCustomers = allCustomers.OrderBy(c => c.Telephonenumber);
                else if (sortOrder == "desc")
                    allCustomers = allCustomers.OrderByDescending(c => c.Telephonenumber);
            }
            if (sortColumn == "Email")
            {
                if (sortOrder == "asc")
                    allCustomers = allCustomers.OrderBy(c => c.Emailaddress);
                else if (sortOrder == "desc")
                    allCustomers = allCustomers.OrderByDescending(c => c.Emailaddress);
            }
            //var firstItemIndex = (pageNo - 1) * 50; // 5 är page storlek

            //allCustomers = allCustomers.Skip(firstItemIndex);
            //allCustomers = allCustomers.Take(50); // 5 är page storlek
           // var result = allCustomers.ToPagedList(pageNo, 30);




            return allCustomers.ToPagedList(pageNo, 30);




            // return allCustomers.ToList();



        }
        public Customer GetSpecificCustomer(int id)
        {
            var customer = _dbContext.Customers.FirstOrDefault(c=> c.CustomerId == id);

            return customer;
        }

    }

}
