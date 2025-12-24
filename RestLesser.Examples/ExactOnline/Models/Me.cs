using RestLesser.OData;

namespace RestLesser.Examples.ExactOnline.Models
{
    /// <summary>
    /// Represents the current user information returned by the Exact Online "Me" endpoint.
    /// API: GET /api/v1/current/Me
    /// </summary>
    public class Me : ODataObject
    {
        /// <summary>Unique identifier of the user.</summary>
        public Guid? UserID { get; set; }

        /// <summary>Division code for the accountant (only applicable for accountants).</summary>
        public int? AccountingDivision { get; set; }

        /// <summary>Current administrative division number.</summary>
        public int? CurrentDivision { get; set; }

        /// <summary>Customer code of the Exact Online customer.</summary>
        public string? CustomerCode { get; set; }

        /// <summary>Reference to the customer record of the division.</summary>
        public Guid? DivisionCustomer { get; set; }

        /// <summary>Code of the customer record of the division.</summary>
        public string? DivisionCustomerCode { get; set; }

        /// <summary>Name of the customer record of the division.</summary>
        public string? DivisionCustomerName { get; set; }

        /// <summary>SIRET number of the customer (France only).</summary>
        public string? DivisionCustomerSiretNumber { get; set; }

        /// <summary>VAT number of the customer.</summary>
        public string? DivisionCustomerVatNumber { get; set; }

        /// <summary>Dossier division number.</summary>
        public int? DossierDivision { get; set; }

        /// <summary>Email address of the user.</summary>
        public string? Email { get; set; }

        /// <summary>Identifier of the employee linked to this user.</summary>
        public Guid? EmployeeID { get; set; }

        /// <summary>First name of the user.</summary>
        public string? FirstName { get; set; }

        /// <summary>Full display name of the user.</summary>
        public string? FullName { get; set; }

        /// <summary>Gender of the user. M = Male, V = Female, O = Unknown.</summary>
        public string? Gender { get; set; }

        /// <summary>Initials of the user.</summary>
        public string? Initials { get; set; }

        /// <summary>Indicates whether the user is a client user.</summary>
        public bool? IsClientUser { get; set; }

        /// <summary>Indicates whether the user is an employee self-service user.</summary>
        public bool? IsEmployeeSelfServiceUser { get; set; }

        /// <summary>Indicates whether the user is a MyFirm Lite user.</summary>
        public bool? IsMyFirmLiteUser { get; set; }

        /// <summary>Indicates whether the user is a MyFirm Portal user.</summary>
        public bool? IsMyFirmPortalUser { get; set; }

        /// <summary>Indicates whether migration to Online Expense Integration is mandatory.</summary>
        public bool? IsOEIMigrationMandatory { get; set; }

        /// <summary>Indicates whether the user is a starter (trial) user.</summary>
        public bool? IsStarterUser { get; set; }

        /// <summary>Language of the user (localized name).</summary>
        public string? Language { get; set; }

        /// <summary>Language code (e.g., "EN", "NL", "FR").</summary>
        public string? LanguageCode { get; set; }

        /// <summary>Last name of the user.</summary>
        public string? LastName { get; set; }

        /// <summary>Legislation code of the division (country-specific identifier).</summary>
        public long? Legislation { get; set; }

        /// <summary>Middle name of the user.</summary>
        public string? MiddleName { get; set; }

        /// <summary>Mobile phone number of the user.</summary>
        public string? Mobile { get; set; }

        /// <summary>Nationality of the user.</summary>
        public string? Nationality { get; set; }

        /// <summary>Code of the Exact Online package the user is using.</summary>
        public string? PackageCode { get; set; }

        /// <summary>Phone number of the user.</summary>
        public string? Phone { get; set; }

        /// <summary>Phone extension of the user.</summary>
        public string? PhoneExtension { get; set; }

        /// <summary>URL to the user’s profile picture.</summary>
        public string? PictureUrl { get; set; }

        /// <summary>Server time in string format (UTC or local).</summary>
        public string? ServerTime { get; set; }

        /// <summary>Offset (in hours) between server time and UTC.</summary>
        public double? ServerUtcOffset { get; set; }

        /// <summary>Thumbnail picture of the user (deprecated, will be removed).</summary>
        public byte[]? ThumbnailPicture { get; set; }

        /// <summary>Format of the thumbnail picture (e.g., "jpg", "png").</summary>
        public string? ThumbnailPictureFormat { get; set; }

        /// <summary>Title or salutation (e.g., "Mr", "Mrs").</summary>
        public string? Title { get; set; }

        /// <summary>Login name of the user (Exact Online username).</summary>
        public string? UserName { get; set; }
    }
}
