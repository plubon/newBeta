//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace newBeta.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TaskConnections
    {
        public int Id { get; set; }
        public int PreviousTask { get; set; }
        public Nullable<int> NextTask { get; set; }
    
        public virtual Tasks Tasks { get; set; }
        public virtual Tasks Tasks1 { get; set; }
    }
}
