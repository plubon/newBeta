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
    
    public partial class Subtasks
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<bool> State { get; set; }
        public int TaskId { get; set; }
    
        public virtual Tasks Tasks { get; set; }
    }
}