using System;
using System.Linq;
using System.Linq.Expressions;
using RestLesser.Authentication;
using RestLesser.Examples.ExactOnline.Models;
using RestLesser.OData;

namespace RestLesser.Examples.ExactOnline
{
    /// <summary>
    /// 
    /// </summary>
    public class ExactApiClient : ExactClient
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="authentication"></param>
        public ExactApiClient(IAuthentication authentication) : base(authentication)
        {
            // Get the AccountingDivision for the current user,
            // we need it in the path of all other api calls
            AccountingDivision = GetCurrentUser(m => m.AccountingDivision)?.AccountingDivision;
        }
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="selectors"></param>
        /// <returns></returns>
        public Me? GetCurrentUser(params Expression<Select<Me>>[] selectors)
        {
            var url = GetUrl("current/Me", true);
            return Query<Me>(url)
                .Select(selectors)
                .GetEntries()
                .FirstOrDefault();
        }

        /// <summary>
        /// Query purchaseentry/PurchaseEntries
        /// </summary>
        public ODataUrlBuilder<PurchaseEntry> PurchaseEntries => Query<PurchaseEntry>(GetUrl("purchaseentry/PurchaseEntries"));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="document"></param>
        /// <param name="selectors"></param>
        /// <returns></returns>
        public PurchaseEntry? GetPurchaseEntryByDocument(Guid? document, params Expression<Select<PurchaseEntry>>[] selectors)
        {
            return PurchaseEntries
                .Select(selectors)
                .Filter(f => f.Document, c => c.Eq(document))
                .GetEntries()
                .FirstOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="selectors"></param>
        /// <returns></returns>
        public PurchaseEntry[] GetPurchaseEntries(params Expression<Select<PurchaseEntry>>[] selectors)
        {
            return PurchaseEntries
                .Select(selectors)
                .GetEntries();
        }

        /// <summary>
        /// Query documents/Documents
        /// </summary>
        public ODataUrlBuilder<Document> Documents => Query<Document>(GetUrl("documents/Documents"));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="selectors"></param>
        /// <returns></returns>
        public Document[] GetDocuments(params Expression<Select<Document>>[] selectors)
        {
            return Documents
                .Select(selectors)
                .GetEntries();
        }      

        /// <summary>
        /// 
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="selectors"></param>
        /// <returns></returns>
        public Document? GetDocument(Guid guid, params Expression<Select<Document>>[] selectors)
        {
            return Documents
                .Select(selectors)
                .Filter(f => f.ID, c => c.Eq(guid))
                .GetEntries()
                .FirstOrDefault();
        }

        /// <summary>
        /// Get all documents after <paramref name="date"/>
        /// </summary>
        /// <param name="date">Date</param>
        /// <param name="selectors">Fields to select</param>
        /// <returns></returns>
        public Document[] GetDocuments(DateTime date, params Expression<Select<Document>>[] selectors)
        {
            return Documents
                .Select(selectors)
                .Filter(f => f.Created, e => e.Gt(date))
                //.OrderBy(f => f.Created)
                .GetEntries();
        }


        /// <summary>
        /// Query documents/DocumentAttachments
        /// </summary>
        public ODataUrlBuilder<DocumentAttachment> DocumentAttachments => Query<DocumentAttachment>(GetUrl("documents/DocumentAttachments"));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="timestamp"></param>
        /// <param name="selectors"></param>
        /// <returns></returns>
        public DocumentAttachment[] GetDocumentAttachments(long? timestamp, params Expression<Select<DocumentAttachment>>[] selectors)
        {
            return DocumentAttachments
                .Select(selectors)
                .Filter(f => f.Timestamp, c => c.Gt(timestamp))
                .GetEntries();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="document"></param>
        /// <param name="selectors"></param>
        /// <returns></returns>
        public DocumentAttachment? GetDocumentAttachmentByDocument(Guid document, params Expression<Select<DocumentAttachment>>[] selectors)
        {
            return DocumentAttachments
                .Select(selectors)
                .Filter(f => f.Document, c => c.Eq(document))
                .GetEntries()
                .FirstOrDefault();
        }

        /// <summary>
        /// Query documents/DocumentTypes
        /// </summary>
        public ODataUrlBuilder<DocumentType> DocumentTypes => Query<DocumentType>(GetUrl("documents/DocumentTypes"));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="selectors"></param>
        /// <returns></returns>
        public DocumentType[] GetDocumentTypes(params Expression<Select<DocumentType>>[] selectors)
        {
            return DocumentTypes
                .Select(selectors)
                .GetEntries();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="selectors"></param>
        /// <returns></returns>
        public DocumentType? GetDocumentTypeById(int? id, params Expression<Select<DocumentType>>[] selectors)
        {
            return DocumentTypes
                .Select(selectors)
                .Filter(f => f.ID, c => c.Eq(id))
                .GetEntries()
                .FirstOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        public ODataUrlBuilder<SyncDocument> SyncDocuments =>
           Query<SyncDocument>(GetUrl("sync/Documents/Documents"));

        /// <summary>
        /// 
        /// </summary>
        public ODataUrlBuilder<PurchaseInvoice> PurchaseInvoices =>
           Query<PurchaseInvoice>(GetUrl("purchase/PurchaseInvoices"));

        /// <summary>
        /// 
        /// </summary>
        public ODataUrlBuilder<Account> Accounts =>
          Query<Account>(GetUrl("crm/Accounts"));
    }
}
