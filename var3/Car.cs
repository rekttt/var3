//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace var3
{
    using System;
    using System.Collections.Generic;
   // using static DriversCars;
    
    public partial class Car
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Car()
        {
            this.DriversCars = new HashSet<DriversCars>();
            this.Incident = new HashSet<Incident>();
        }
    
        public string StateNumber { get; set; }
        public int mark { get; set; }
        public string model { get; set; }
        public string color { get; set; }
        public int madeYear { get; set; }
        public System.DateTime dateOfRegistration { get; set; }
       // public string GetFioDriver { get => DriversCars.FioDriver; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DriversCars> DriversCars { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Incident> Incident { get; set; }
    }
}
