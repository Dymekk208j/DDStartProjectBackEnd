using System;

namespace DDStartProjectBackEnd.Common.Models
{
    public class BaseModel
    {
        public DateTime CreationDate{ get; set; }
        public string CreatedByUserId { get; set; }
        public DateTime? LastModificationDate { get; set; }
        public string ModifiedByUserId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
