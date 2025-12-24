using RestLesser.OData;

namespace RestLesser.Examples.ExactOnline.Models
{
    /// <summary>
    /// Represents a purchase invoice in Exact Online.
    /// API: /api/v1/{division}/purchase/PurchaseInvoices
    /// </summary>
    public class PurchaseInvoice : ODataObject
    {
        /// <summary>
        /// A guid that is the unique identifier of the purchase invoice.
        /// </summary>
        public Guid? ID { get; set; }

        /// <summary>
        /// The amount including VAT in the foreign currency.
        /// </summary>
        public double? Amount { get; set; }

        /// <summary>
        /// The amount including VAT in the default currency.
        /// </summary>
        public double? AmountDC { get; set; }

        /// <summary>
        /// Discount amount in the default currency of the company.
        /// </summary>
        public double? AmountDiscount { get; set; }

        /// <summary>
        /// Discount amount excluding VAT in the default currency of the company.
        /// </summary>
        public double? AmountDiscountExclVat { get; set; }

        /// <summary>
        /// Amount excluding VAT in the currency of the transaction.
        /// </summary>
        public double? AmountFCExclVat { get; set; }

        /// <summary>
        /// Guid identifying the contact person of the supplier.
        /// </summary>
        public Guid? ContactPerson { get; set; }

        /// <summary>
        /// The code of the currency of the invoiced amount.
        /// </summary>
        public string? Currency { get; set; }

        /// <summary>
        /// The description of the invoice.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Discount percentage.
        /// </summary>
        public double? Discount { get; set; }

        /// <summary>
        /// Guid identifying a document that is attached to the invoice.
        /// </summary>
        public Guid? Document { get; set; }

        /// <summary>
        /// The date before which the invoice has to be paid; by default set according to the payment condition.
        /// </summary>
        public DateTime? DueDate { get; set; }

        /// <summary>
        /// The unique number of the purchase invoice (based on purchase journal setting and incremented per invoice).
        /// </summary>
        public int? EntryNumber { get; set; }

        /// <summary>
        /// The exchange rate between the invoice currency and the default currency of the division.
        /// </summary>
        public double? ExchangeRate { get; set; }

        /// <summary>
        /// The financial period in which the invoice is entered.
        /// </summary>
        public short? FinancialPeriod { get; set; }

        /// <summary>
        /// The financial year in which the invoice is entered.
        /// </summary>
        public short? FinancialYear { get; set; }

        /// <summary>
        /// The date on which the supplier entered the invoice.
        /// </summary>
        public DateTime? InvoiceDate { get; set; }

        /// <summary>
        /// The code of the purchase journal in which the invoice is entered. (Mandatory)
        /// </summary>
        public string? Journal { get; set; }

        /// <summary>
        /// The date and time the invoice was last modified.
        /// </summary>
        public DateTime? Modified { get; set; }

        /// <summary>
        /// The code of the payment condition used to calculate the due date and discount.
        /// </summary>
        public string? PaymentCondition { get; set; }

        /// <summary>
        /// Unique reference to match payments and invoices.
        /// </summary>
        public string? PaymentReference { get; set; }

        /// <summary>
        /// The collection of lines that belong to the purchase invoice. (Mandatory)
        /// </summary>
        public IEnumerable<PurchaseInvoiceLine>? PurchaseInvoiceLines { get; set; }

        /// <summary>
        /// User-entered remarks related to the invoice.
        /// </summary>
        public string? Remarks { get; set; }

        /// <summary>
        /// Indicates the origin of the invoice. 1 = Manual entry, 3 = Purchase invoice, 4 = Purchase order, 5 = Web service.
        /// </summary>
        public short? Source { get; set; }

        /// <summary>
        /// The status of the invoice. 10 = Draft, 20 = Open, 50 = Processed.
        /// </summary>
        public short? Status { get; set; }

        /// <summary>
        /// Guid that identifies the supplier. (Mandatory)
        /// </summary>
        public Guid? Supplier { get; set; }

        /// <summary>
        /// Indicates the type of the purchase invoice.
        /// 8030 = Direct purchase invoice,
        /// 8031 = Direct purchase invoice (Credit),
        /// 8033 = Purchase invoice,
        /// 8034 = Purchase invoice (Credit). (Mandatory)
        /// </summary>
        public short? Type { get; set; }

        /// <summary>
        /// The total VAT amount of the purchase invoice.
        /// </summary>
        public double? VATAmount { get; set; }

        /// <summary>
        /// Guid that identifies the warehouse that will receive the purchased goods.
        /// Mandatory for creating a direct purchase invoice, except for Exact Online Projects.
        /// </summary>
        public Guid? Warehouse { get; set; }

        /// <summary>
        /// The invoice number provided by the supplier.
        /// </summary>
        public string? YourRef { get; set; }
    }

    /// <summary>
    /// Stub for purchase invoice line; fill this based on the PurchaseInvoiceLines resource definition.
    /// </summary>
    public class PurchaseInvoiceLine : ODataObject
    {
        // Define fields according to:
        // https://start.exactonline.nl/docs/HlpRestAPIResourcesDetails.aspx?name=PurchasePurchaseInvoiceLines
    }
}
