using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RestLesser.OData;
using System;

namespace RestLesser.Examples.ExactOnline.Models
{
    /// <summary>
    /// Type of purchase entry.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PurchaseEntryType
    {
        /// <summary>Purchase entry (30)</summary>
        PurchaseEntry = 30,

        /// <summary>Purchase credit note (31)</summary>
        PurchaseCreditNote = 31
    }

    /// <summary>
    /// Status of a purchase entry.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PurchaseEntryStatus : short
    {
        /// <summary>Rejected (5)</summary>
        Rejected = 5,

        /// <summary>Open (20)</summary>
        Open = 20,

        /// <summary>Processed (50)</summary>
        Processed = 50
    }

    /// <summary>
    /// Payment method related to payment condition.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PaymentMethod
    {
        /// <summary>On Credit (B)</summary>
        OnCredit = 'B',

        /// <summary>Collection (I)</summary>
        Collection = 'I',

        /// <summary>Cash (K)</summary>
        Cash = 'K'
    }

    /// <summary>
    /// Represents a Purchase Entry line in Exact Online.
    /// </summary>
    public class PurchaseEntryLine : ODataObject
    {
        /// <summary>
        /// Amount in the company's default currency. (Required)
        /// </summary>
        public double AmountDC { get; set; }

        /// <summary>
        /// Amount in the transaction currency. (Required)
        /// </summary>
        public double AmountFC { get; set; }

        /// <summary>
        /// Reference to asset.
        /// </summary>
        public Guid? Asset { get; set; }

        /// <summary>
        /// Asset description.
        /// </summary>
        public string? AssetDescription { get; set; }

        /// <summary>
        /// Reference to cost center (code).
        /// </summary>
        public string? CostCenter { get; set; }

        /// <summary>
        /// Description of the cost center.
        /// </summary>
        public string? CostCenterDescription { get; set; }

        /// <summary>
        /// Reference to cost unit (code).
        /// </summary>
        public string? CostUnit { get; set; }

        /// <summary>
        /// Description of the cost unit.
        /// </summary>
        public string? CostUnitDescription { get; set; }

        /// <summary>
        /// Custom field.
        /// </summary>
        public string? CustomField { get; set; }

        /// <summary>
        /// Line description.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Division code. (Required)
        /// </summary>
        public int Division { get; set; }

        /// <summary>
        /// Chamber of commerce number of the division.
        /// </summary>
        public string? DivisionCompanyCoCNumber { get; set; }

        /// <summary>
        /// IBAN number of the division.
        /// </summary>
        public string? DivisionCompanyIBANNumber { get; set; }

        /// <summary>
        /// Company name of the division. (Required)
        /// </summary>
        public string? DivisionCompanyName { get; set; }

        /// <summary>
        /// RSIN number of the division.
        /// </summary>
        public string? DivisionCompanyRSINNumber { get; set; }

        /// <summary>
        /// VAT number of the division.
        /// </summary>
        public string? DivisionCompanyVATNumber { get; set; }

        /// <summary>
        /// Wage tax number of the division.
        /// </summary>
        public string? DivisionCompanyWageTaxNumber { get; set; }

        /// <summary>
        /// Label of the division. (Required)
        /// </summary>
        public string? DivisionLabel { get; set; }

        /// <summary>
        /// Name of the division. (Required)
        /// </summary>
        public string? DivisionName { get; set; }

        /// <summary>
        /// Name of the subscription owner (division 1). (Required)
        /// </summary>
        public string? DivisionOwnerCompanyName { get; set; }

        /// <summary>
        /// Number of the subscription owner (division 1). (Required)
        /// </summary>
        public string? DivisionOwnerCompanyNumber { get; set; }

        /// <summary>
        /// Short name of the division. (Required)
        /// </summary>
        public long DivisionShortName { get; set; }

        /// <summary>
        /// Reference to the purchase entry header.
        /// </summary>
        public Guid? EntryID { get; set; }

        /// <summary>
        /// Reference to expense.
        /// </summary>
        public Guid? Expense { get; set; }

        /// <summary>
        /// Expense description.
        /// </summary>
        public string? ExpenseDescription { get; set; }

        /// <summary>
        /// From date for deferred revenue.
        /// </summary>
        public DateTime? From { get; set; }

        /// <summary>
        /// General ledger account (ID).
        /// </summary>
        public Guid? GLAccount { get; set; }

        /// <summary>
        /// General ledger account code.
        /// </summary>
        public string? GLAccountCode { get; set; }

        /// <summary>
        /// General ledger account description.
        /// </summary>
        public string? GLAccountDescription { get; set; }

        /// <summary>
        /// Primary key. (Required)
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// IntraStat area.
        /// </summary>
        public string? IntraStatArea { get; set; }

        /// <summary>
        /// IntraStat country.
        /// </summary>
        public string? IntraStatCountry { get; set; }

        /// <summary>
        /// IntraStat delivery term.
        /// </summary>
        public string? IntraStatDeliveryTerm { get; set; }

        /// <summary>
        /// IntraStat transaction A (1 char).
        /// </summary>
        public string? IntraStatTransactionA { get; set; }

        /// <summary>
        /// IntraStat transaction B.
        /// </summary>
        public string? IntraStatTransactionB { get; set; }

        /// <summary>
        /// IntraStat transport method (1 char).
        /// </summary>
        public string? IntraStatTransportMethod { get; set; }

        /// <summary>
        /// Line number.
        /// </summary>
        public int? LineNumber { get; set; }

        /// <summary>
        /// Net amount in division currency.
        /// </summary>
        public double? NetAmountDC { get; set; }

        /// <summary>
        /// Net amount in foreign currency.
        /// </summary>
        public double? NetAmountFC { get; set; }

        /// <summary>
        /// Extra remarks.
        /// </summary>
        public string? Notes { get; set; }

        /// <summary>
        /// Percentage of non-deductible/private use.
        /// </summary>
        public double? PrivateUsePercentage { get; set; }

        /// <summary>
        /// Reference to project.
        /// </summary>
        public Guid? Project { get; set; }

        /// <summary>
        /// Project description.
        /// </summary>
        public string? ProjectDescription { get; set; }

        /// <summary>
        /// Quantity.
        /// </summary>
        public double? Quantity { get; set; }

        /// <summary>
        /// Serial number.
        /// </summary>
        public string? SerialNumber { get; set; }

        /// <summary>
        /// Statistical net weight.
        /// </summary>
        public double? StatisticalNetWeight { get; set; }

        /// <summary>
        /// Statistical number (goods code).
        /// </summary>
        public string? StatisticalNumber { get; set; }

        /// <summary>
        /// Statistical quantity.
        /// </summary>
        public double? StatisticalQuantity { get; set; }

        /// <summary>
        /// Statistical value.
        /// </summary>
        public double? StatisticalValue { get; set; }

        /// <summary>
        /// Reference to subscription.
        /// </summary>
        public Guid? Subscription { get; set; }

        /// <summary>
        /// Subscription description.
        /// </summary>
        public string? SubscriptionDescription { get; set; }

        /// <summary>
        /// To date for deferred revenue.
        /// </summary>
        public DateTime? To { get; set; }

        /// <summary>
        /// Tracking number (ID).
        /// </summary>
        public Guid? TrackingNumber { get; set; }

        /// <summary>
        /// Tracking number description.
        /// </summary>
        public string? TrackingNumberDescription { get; set; }

        /// <summary>
        /// Line type: 30 = Purchase entry, 31 = Purchase credit note.
        /// </summary>
        public int? Type { get; set; }

        /// <summary>
        /// VAT amount in the company's default currency.
        /// </summary>
        public double? VATAmountDC { get; set; }

        /// <summary>
        /// VAT amount in the transaction currency.
        /// Use this when the VAT differs from the automatically calculated amount.
        /// </summary>
        public double? VATAmountFC { get; set; }

        /// <summary>
        /// VAT base amount in the company's default currency.
        /// </summary>
        public double? VATBaseAmountDC { get; set; }

        /// <summary>
        /// VAT base amount in the transaction currency.
        /// </summary>
        public double? VATBaseAmountFC { get; set; }

        /// <summary>
        /// VAT code.
        /// </summary>
        public string? VATCode { get; set; }

        /// <summary>
        /// VAT code description.
        /// </summary>
        public string? VATCodeDescription { get; set; }

        /// <summary>
        /// Percentage of non-deductible VAT.
        /// </summary>
        public double? VATNonDeductiblePercentage { get; set; }

        /// <summary>
        /// VAT percentage.
        /// </summary>
        public double? VATPercentage { get; set; }

        /// <summary>
        /// Withholding tax amount for Spanish legislation (company currency).
        /// </summary>
        public double? WithholdingAmountDC { get; set; }

        /// <summary>
        /// Withholding tax key for Spanish legislation.
        /// </summary>
        public string? WithholdingTax { get; set; }
    }
}
