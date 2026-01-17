using RestLesser.OData;
using System;

namespace RestLesser.Examples.ExactOnline.Models
{
    /// <summary>
    /// Represents a document type in Exact Online.
    /// API: GET /api/v1/{division}/documents/DocumentTypes
    /// </summary>
    public class DocumentType : ODataObject
    {
        /// <summary>
        /// Primary key of the document type.
        /// </summary>
        public int? ID { get; set; }

        /// <summary>
        /// Creation date of the document type.
        /// </summary>
        public DateTime? Created { get; set; }

        /// <summary>
        /// Document type description.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Indicates if documents of this type can be created.
        /// </summary>
        public bool? DocumentIsCreatable { get; set; }

        /// <summary>
        /// Indicates if documents of this type can be deleted.
        /// </summary>
        public bool? DocumentIsDeletable { get; set; }

        /// <summary>
        /// Indicates if documents of this type can be updated.
        /// </summary>
        public bool? DocumentIsUpdatable { get; set; }

        /// <summary>
        /// Indicates if documents of this type can be retrieved (viewed).
        /// </summary>
        public bool? DocumentIsViewable { get; set; }

        /// <summary>
        /// Last modified date of the document type.
        /// </summary>
        public DateTime? Modified { get; set; }

        /// <summary>
        /// ID of the document type category.
        /// </summary>
        public int? TypeCategory { get; set; }
    }
}
