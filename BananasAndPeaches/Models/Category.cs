//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BananasAndPeaches.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    
    public partial class Category
    {
        public Category()
        {
            this.TaskToDoes = new HashSet<TaskToDo>();
        }
        //[DisplayName("Category")]
        public int id { get; set; }
        [DisplayName("Category")]
        public string name { get; set; }
    
        public virtual ICollection<TaskToDo> TaskToDoes { get; set; }
    }
}