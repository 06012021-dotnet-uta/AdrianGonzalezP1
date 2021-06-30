using System;
using Xunit;
using RepositoryLayer;
using ModelLayer;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;


namespace MyEcommerceWebsite.Test
{
    public class UnitTest1
    {
        // Create the in memeory Db
        DbContextOptions<MyEcommerceDb> options = new DbContextOptionsBuilder<MyEcommerceDb>()
            .UseInMemoryDatabase(databaseName: "TestingDb")
            .Options;


        [Fact]
        public async Task CreateAccountCorrectly()
        {
            // Arrange
            // Create an Account to insert into the inmemory db
            AccountModel account = new()
            {
                Username = "test1@gamil.com",
                Password = "Password"
            };
            bool result = false;
            AccountModel account1;

            using (var context = new MyEcommerceDb(options)) 
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                context.Accounts.Add(account);
                context.SaveChanges();
                account1 = context.Accounts.Where(x => x.Username == "test1@gamil.com").FirstOrDefault();
            }

            // Act
            // Add to the In-Memory Db
            // Instantiate the inmemory db
            using (var context = new MyEcommerceDb(options)) 
            {
                // Verify that  the db was deleted and create a new
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Signup signup = new Signup(context);
                result = await signup.CreateAccount(account);

                context.SaveChanges();


                // Assert
                // Verify the result was as expected
                int accountCount = await context.Accounts.CountAsync();

                var acc = context.Accounts.Where(x => x.Username == "test1@gamil.com").FirstOrDefault();
                Assert.True(result);
                Assert.Equal(1, accountCount);
                Assert.NotNull(acc);
                Assert.Contains(account1, context.Accounts);
                Assert.Equal(account1, acc);
            }
        }

        [Fact]
        public async Task CreateCustomerCorrectly()
        {
            // Arrange
            // Create an Customer to insert into the inmemory db
            CustomerModel customer = new()
            {
                CustomerId = 1,
                Fname = "Adrian",
                Lname = "Gonzalez",
                UsernameRef = "agonzalez108",
                Address1 = "13170 Saker Dr",
                City = "El Paso",
                Zipcode = "79928",
                State = "Texas",
                Country = "US",
                PhoneNumber = "(915) 352-9166",
                Email = "adrian@revature.net"
            };
            bool result = false;
            CustomerModel customer1;

            using (var context = new MyEcommerceDb(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                context.Customers.Add(customer);
                context.SaveChanges();
                customer1 = context.Customers.Where(x => x.CustomerId == 1).FirstOrDefault();
            }

            // Act
            // Add to the In-Memory Db
            // Instantiate the inmemory db
            using (var context = new MyEcommerceDb(options))
            {
                // Verify that  the db was deleted and create a new
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Signup signup = new Signup(context);
                result = await signup.CreateCustomer(customer);

                context.SaveChanges();


                // Assert
                // Verify the result was as expected
                int customerCount = await context.Customers.CountAsync();

                var cus = context.Customers.Where(x => x.CustomerId == 1).FirstOrDefault();
                Assert.True(result);
                Assert.Equal(1, customerCount);
                Assert.NotNull(cus);
                Assert.Contains(customer1, context.Customers);
                Assert.Equal(customer1, cus);
            }
        }
    }
}
