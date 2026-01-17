using RestLesser.OData;
using System;

namespace RestLesser.Examples.ExactOnline.Models
{
    /// <summary>
    /// Represents an account (customer/supplier / contact-base) in Exact Online CRM Accounts.
    /// API: /api/v1/{division}/crm/Accounts
    /// </summary>
    public class Account : ODataObject
    {
        /// <summary>
        /// Unique identifier of the account (GUID).</summary>
        public Guid ID { get; set; }

        /// <summary>
        /// Code of the account (often the customer/supplier code).</summary>
        public string? Code { get; set; }

        /// <summary>
        /// Name of the account (company or contact name).</summary>
        public string? Name { get; set; }

        /// <summary>
        /// Indicates whether the account is active.</summary>
        public bool? IsActive { get; set; }

        /// <summary>
        /// VAT number of the account (if applicable).</summary>
        public string? VATNumber { get; set; }

        /// <summary>
        /// Chamber of Commerce / company registration number (if applicable).</summary>
        public string? ChamberOfCommerce { get; set; }

        /// <summary>
        /// Address line 1 (street / main address).</summary>
        public string? AddressLine1 { get; set; }

        /// <summary>
        /// Address line 2 (additional address info).</summary>
        public string? AddressLine2 { get; set; }

        /// <summary>
        /// Address line 3 (additional address info).</summary>
        public string? AddressLine3 { get; set; }

        /// <summary>
        /// Postal code / ZIP of the account address.</summary>
        public string? PostCode { get; set; }

        /// <summary>
        /// City of the account address.</summary>
        public string? City { get; set; }

        /// <summary>
        /// Country of the account address.</summary>
        public string? Country { get; set; }

        /// <summary>
        /// Phone number of the account.</summary>
        public string? Phone { get; set; }

        /// <summary>
        /// Email address of the account.</summary>
        public string? Email { get; set; }

        /// <summary>
        /// Website / URL of the account (if any).</summary>
        public string? Website { get; set; }

        /// <summary>
        /// Date when the account was created.</summary>
        public DateTime? Created { get; set; }

        /// <summary>
        /// Date when the account was last modified.</summary>
        public DateTime? Modified { get; set; }

        /// <summary>
        /// Optional reference to classification (e.g. account type) GUID.</summary>
        public Guid? Classification { get; set; }
    }
}
