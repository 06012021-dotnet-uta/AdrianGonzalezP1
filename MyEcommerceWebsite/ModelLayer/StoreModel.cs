﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    /// <summary>
    /// The main <c>Store</c> class. 
    /// Concatinates all of the fields together of the and returns it as a string 
    /// </summary>
    public class StoreModel : AddressModel, IComparable
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string ContactNumber { get; set; }
        public string Description { get; set; }

        public StoreModel() { }

        /// <summary>
        /// This Constructor is responsible for initizaling the store state
        /// </summary>
        /// <param name="StoreName">String name of the store</param>
        /// <param name="Address">String Addresss</param>
        /// <param name="City">String City</param>
        /// <param name="State">String State</param>
        /// <param name="ZipCode">String ZipCode</param>
        /// <param name="ContactNumber">String Contact Number</param>
        /// <param name="Description">String Description</param>
        public StoreModel(string StoreName, string Street, string City, string State, string ZipCode, string ContactNumber, string Description) : base(Street, City, State, ZipCode)
        {
            this.StoreName = StoreName;
            this.Street = Street;
            this.ContactNumber = ContactNumber;
            this.Description = Description;
        }

        /// <summary>
        /// Concatinates all of the fields together of the and returns it as a string 
        /// </summary>
        /// <returns>A string with all if the fields</returns>
        public string StoreInfo()
        {
            string store_info = $"\t\tStore Information\nName: {this.StoreName}\nAddress:{this.Street}\nCity: {this.City}\nState: {this.State}\n{this.ZipCode}\nContact Number: {this.ContactNumber}\nDesciption: {this.Description}";
            return store_info;
        }

        /// <summary>
        /// The CompareTo is used for sorting algorithms.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;


            if (obj is StoreModel otherStore)
                return StoreName.CompareTo(otherStore.StoreName);
            else
                throw new ArgumentException("Object is not a StoreModel");
        }
    }
}
