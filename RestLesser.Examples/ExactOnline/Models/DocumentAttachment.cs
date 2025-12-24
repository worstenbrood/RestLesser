using RestLesser.OData;

namespace RestLesser.Examples.ExactOnline.Models
{
    /// <summary>
    /// Exact Online Sync endpoint model for Document Attachments.
    /// API: GET /api/v1/{division}/sync/Documents/DocumentAttachments
    /// </summary>
    public class DocumentAttachment : ODataObject
    {
        /// <summary>
        /// Row version used for incremental sync.
        /// Store the highest value you receive and use it as the next filter.
        /// </summary>
        public long? Timestamp { get; set; }

        /// <summary>
        /// The attachment content (Base64-encoded binary).
        /// NOTE: For the Sync endpoint, this will always be null.
        /// </summary>
        public byte[]? Attachment { get; set; }

        /// <summary>
        /// Reference to the parent Document (mandatory).
        /// </summary>
        public Guid Document { get; set; }

        /// <summary>
        /// Filename of the attachment (mandatory).
        /// </summary>
        public string? FileName { get; set; }

        /// <summary>
        /// File size of the attachment.
        /// </summary>
        public double? FileSize { get; set; }

        /// <summary>
        /// Primary key of the attachment record.
        /// </summary>
        public Guid? ID { get; set; }

        /// <summary>
        /// URL of the attachment. Append &amp;Download=1 to get the file in its original format.
        /// </summary>
        public string? Url { get; set; }
    }
}
