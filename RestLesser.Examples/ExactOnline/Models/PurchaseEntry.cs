using RestLesser.OData;

namespace RestLesser.Examples.ExactOnline.Models
{
    /// <summary>
    /// Represents a Purchase Entry (header) in Exact Online.
    /// </summary>
    public class PurchaseEntry : ODataObject
    {
        /// <summary>
        /// Primary key.
        /// </summary>
        public Guid? EntryID { get; set; }

        /// <summary>
        /// Amount in the default currency of the company.
        /// </summary>
        public double? AmountDC { get; set; }

        /// <summary>
        /// Amount in the currency of the transaction.
        /// </summary>
        public double? AmountFC { get; set; }

        /// <summary>
        /// The number of the batch of entries. Normally a batch consists of multiple entries.
        /// Batchnumbers are filled for invoices created by: Fixed entries; Prolongation (only available with module hosting).
        /// </summary>
        public int? BatchNumber { get; set; }

        /// <summary>
        /// Creation date.
        /// </summary>
        public DateTime? Created { get; set; }

        /// <summary>
        /// User ID of creator.
        /// </summary>
        public Guid? Creator { get; set; }

        /// <summary>
        /// Name of creator.
        /// </summary        >
        public string? CreatorFullName { get; set; }

        /// <summary>
        /// Currency code.
        /// </summary>
        public string? Currency { get; set; }

        /// <summary>
        /// Custom field endpoint.
        /// </summary>
        public string? CustomField { get; set; }

        /// <summary>
        /// Description.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Division code.
        /// </summary>
        public int? Division { get; set; }

        /// <summary>
        /// Reference to document.
        /// </summary>
        public Guid? Document { get; set; }

        /// <summary>
        /// Document number.
        /// </summary>
        public int? DocumentNumber { get; set; }

        /// <summary>
        /// Document subject.
        /// </summary>
        public string? DocumentSubject { get; set; }

        /// <summary>
        /// Date when payment should be done.
        /// </summary>
        public DateTime? DueDate { get; set; }

        /// <summary>
        /// Invoice date.
        /// </summary>
        public DateTime? EntryDate { get; set; }

        /// <summary>
        /// Entry number.
        /// </summary>
        public int? EntryNumber { get; set; }

        /// <summary>
        /// Description of ExternalLink.
        /// </summary>
        public string? ExternalLinkDescription { get; set; }

        /// <summary>
        /// External link.
        /// </summary>
        public string? ExternalLinkReference { get; set; }

        /// <summary>
        /// A positive value of the amount indicates the amount is to be paid to the supplier's G bank account.
        /// In case of a credit invoice the amount should be negative when retrieved or posted to Exact.
        /// </summary>
        public double? GAccountAmountFC { get; set; }

        /// <summary>
        /// Invoice number.
        /// </summary>
        public int? InvoiceNumber { get; set; }

        /// <summary>
        /// Journal. (Mandatory)
        /// </summary>
        public string? Journal { get; set; }

        /// <summary>
        /// Description of Journal.
        /// </summary>
        public string? JournalDescription { get; set; }

        /// <summary>
        /// Last modified date.
        /// </summary>
        public DateTime? Modified { get; set; }

        /// <summary>
        /// User ID of modifier.
        /// </summary>
        public Guid? Modifier { get; set; }

        /// <summary>
        /// Name of modifier.
        /// </summary>
        public string? ModifierFullName { get; set; }

        /// <summary>
        /// Order number.
        /// </summary>
        public int? OrderNumber { get; set; }

        /// <summary>
        /// Payment condition. (e.g., code)
        /// </summary>
        public string? PaymentCondition { get; set; }

        /// <summary>
        /// Description of PaymentCondition.
        /// </summary>
        public string? PaymentConditionDescription { get; set; }

        /// <summary>
        /// Payment method of Payment condition. Values: B = On credit, I = Collection, K = Cash.
        /// </summary>
        public PaymentMethod? PaymentConditionPaymentMethod { get; set; }

        /// <summary>
        /// The payment reference used for bank imports, VAT return and Tax reference.
        /// </summary>
        public string? PaymentReference { get; set; }

        /// <summary>
        /// Internal processing number, only relevant for Germany.
        /// </summary>
        public int? ProcessNumber { get; set; }

        /// <summary>
        /// PurchaseEntryLines. Collection of lines. (Mandatory)
        /// </summary>
        public IEnumerable<PurchaseEntryLine>? PurchaseEntryLines { get; set; }

        /// <summary>
        /// Currency exchange rate.
        /// </summary>
        public double? Rate { get; set; }

        /// <summary>
        /// The period of the transaction lines. The period should exist in the period date table.
        /// </summary>
        public short? ReportingPeriod { get; set; }

        /// <summary>
        /// The financial year to which the entry belongs. The financial year should exist in the period date table.
        /// </summary>
        public short? ReportingYear { get; set; }

        /// <summary>
        /// Indicates that amounts are reversed.
        /// </summary>
        public bool? Reversal { get; set; }

        /// <summary>
        /// Status: 5 = Rejected, 20 = Open, 50 = Processed.
        /// </summary>
        public PurchaseEntryStatus? Status { get; set; }

        /// <summary>
        /// Description of Status.
        /// </summary>
        public string? StatusDescription { get; set; }

        /// <summary>
        /// Reference to supplier (account). (Mandatory)
        /// </summary>
        public Guid Supplier { get; set; }

        /// <summary>
        /// Name of supplier.
        /// </summary>
        public string? SupplierName { get; set; }

        /// <summary>
        /// Type: 30 = Purchase entry, 31 = Purchase credit note.
        /// </summary>
        public PurchaseEntryType Type { get; set; }

        /// <summary>
        /// Description of Type.
        /// </summary>
        public string? TypeDescription { get; set; }

        /// <summary>
        /// VAT Amount in the default currency of the company.
        /// </summary>
        public double? VATAmountDC { get; set; }

        /// <summary>
        /// VAT Amount in the currency of the transaction.
        /// </summary>
        public double? VATAmountFC { get; set; }

        /// <summary>
        /// Your reference.
        /// </summary>
        public string? YourRef { get; set; }
    }
}
