//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyRecipies.DBContext
{
    using System;
    using System.Collections.Generic;
    
    public partial class Dish
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dish()
        {
            this.CookingStage = new HashSet<CookingStage>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int ServingQuantity { get; set; }
        public int CategoryId { get; set; }
        public string RecipeLink { get; set; }
        public byte[] Photo { get; set; }
        public string PhotoPath { get; set; }
    
        public virtual Category Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CookingStage> CookingStage { get; set; }
    }
}
