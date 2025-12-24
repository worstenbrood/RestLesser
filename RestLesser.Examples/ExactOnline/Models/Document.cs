using RestLesser.OData;

namespace RestLesser.Examples.ExactOnline.Models
{
    /// <summary>
    /// Represents a document in Exact Online.
    /// API: GET/POST /api/v1/{division}/documents/Documents
    /// </summary>
    public class Document : ODataObject
    {
        /// <summary>ID of the related account of this document.</summary>
        public Guid? Account { get; set; }

        /// <summary>Code of account.</summary>
        public string? AccountCode { get; set; }

        /// <summary>Name of account.</summary>
        public string? AccountName { get; set; }

        /// <summary>Amount in the currency of the transaction.</summary>
        public double? AmountFC { get; set; }

        /// <summary>Body/content of the document.</summary>
        public string? Body { get; set; }

        /// <summary>ID of the category of this document.</summary>
        public Guid? Category { get; set; }

        /// <summary>Description of the category.</summary>
        public string? CategoryDescription { get; set; }

        /// <summary>ID of the related contact of this document.</summary>
        public Guid? Contact { get; set; }

        /// <summary>Full name of the contact.</summary>
        public string? ContactFullName { get; set; }

        /// <summary>Contract ID (if linked).</summary>
        public Guid? ContractID { get; set; }

        /// <summary>Contract number (if linked).</summary>
        public string? ContractNumber { get; set; }

        /// <summary>Creation date (local).</summary>
        public DateTime? Created { get; set; }

        /// <summary>Creation date in UTC.</summary>
        public DateTime? CreatedUtc { get; set; }

        /// <summary>User ID of creator.</summary>
        public Guid? Creator { get; set; }

        /// <summary>Name of creator.</summary>
        public string? CreatorFullName { get; set; }

        /// <summary>Currency code.</summary>
        public string? Currency { get; set; }

        /// <summary>Division code.</summary>
        public int Division { get; set; }

        /// <summary>Chamber of Commerce number of the division.</summary>
        public string? DivisionCompanyCoCNumber { get; set; }

        /// <summary>IBAN number of the division.</summary>
        public string? DivisionCompanyIBANNumber { get; set; }

        /// <summary>Company name of the division.</summary>
        public string? DivisionCompanyName { get; set; }

        /// <summary>RSIN number of the division.</summary>
        public string? DivisionCompanyRSINNumber { get; set; }

        /// <summary>VAT number of the division.</summary>
        public string? DivisionCompanyVATNumber { get; set; }

        /// <summary>Wage tax number of the division.</summary>
        public string? DivisionCompanyWageTaxNumber { get; set; }

        /// <summary>Label of the division.</summary>
        public string? DivisionLabel { get; set; }

        /// <summary>Name of the division (administration name).</summary>
        public string? DivisionName { get; set; }

        /// <summary>Name of the subscription owner company.</summary>
        public string? DivisionOwnerCompanyName { get; set; }

        /// <summary>Number of the subscription owner company.</summary>
        public string? DivisionOwnerCompanyNumber { get; set; }

        /// <summary>Short name of the division.</summary>
        public long DivisionShortName { get; set; }

        /// <summary>Entry date of the incoming document.</summary>
        public DateTime? DocumentDate { get; set; }

        /// <summary>ID of the document folder.</summary>
        public Guid? DocumentFolder { get; set; }

        /// <summary>Code of the document folder.</summary>
        public string? DocumentFolderCode { get; set; }

        /// <summary>Description of the document folder.</summary>
        public string? DocumentFolderDescription { get; set; }

        /// <summary>URL to view the document.</summary>
        public string? DocumentViewUrl { get; set; }

        /// <summary>Expiry date of this document.</summary>
        public DateTime? ExpiryDate { get; set; }

        /// <summary>Reference to the financial transaction entry (if any).</summary>
        public Guid? FinancialTransactionEntryID { get; set; }

        /// <summary>Indicates that the document body is empty.</summary>
        public bool? HasEmptyBody { get; set; }

        /// <summary>Human-readable ID (xx.xxx.xxx), unique, nonzero.</summary>
        public int? HID { get; set; }

        /// <summary>Primary key.</summary>
        public Guid ID { get; set; }

        /// <summary>Whether sharing is inherited.</summary>
        public bool? InheritShare { get; set; }

        /// <summary>Linked item ID (if any).</summary>
        public Guid? Item { get; set; }

        /// <summary>Item code.</summary>
        public string? ItemCode { get; set; }

        /// <summary>Item description.</summary>
        public string? ItemDescription { get; set; }

        /// <summary>Language code of the document.</summary>
        public string? Language { get; set; }

        /// <summary>Last modified date (local).</summary>
        public DateTime? Modified { get; set; }

        /// <summary>Last modified date in UTC.</summary>
        public DateTime? ModifiedUtc { get; set; }

        /// <summary>User ID of modifier.</summary>
        public Guid? Modifier { get; set; }

        /// <summary>Name of modifier.</summary>
        public string? ModifierFullName { get; set; }

        /// <summary>Opportunity linked to the document.</summary>
        public Guid? Opportunity { get; set; }

        /// <summary>Project linked to the document.</summary>
        public Guid? Project { get; set; }

        /// <summary>Project code.</summary>
        public string? ProjectCode { get; set; }

        /// <summary>Project description.</summary>
        public string? ProjectDescription { get; set; }

        /// <summary>Proposed entry status.</summary>
        public short? ProposedEntryStatus { get; set; }

        /// <summary>Sales invoice number (‘our reference’) linked to this document.</summary>
        public int? SalesInvoiceNumber { get; set; }

        /// <summary>Sales order number.</summary>
        public int? SalesOrderNumber { get; set; }

        /// <summary>Scan service status.</summary>
        public short? ScanServiceStatus { get; set; }

        /// <summary>Send method.</summary>
        public int? SendMethod { get; set; }

        /// <summary>Shop order number.</summary>
        public int? ShopOrderNumber { get; set; }

        /// <summary>Subject of the document.</summary>
        public string? Subject { get; set; }

        /// <summary>Microsoft Teams meeting ID (if linked).</summary>
        public string? TeamsMeetingId { get; set; }

        /// <summary>ID of the document type.</summary>
        public int? Type { get; set; }

        /// <summary>Description of the document type.</summary>
        public string? TypeDescription { get; set; }
    }

    /// <summary>
    /// Sync documents endpoint return a timstamp fro syncing
    /// https://start.exactonline.nl/docs/HlpRestAPIResourcesDetails.aspx?name=SyncDocumentsDocuments
    /// </summary>
    public class SyncDocument : Document
    {
        public long Timestamp { get; set; }
    }
}
