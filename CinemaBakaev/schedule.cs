//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CinemaBakaev
{
    using System;
    using System.Collections.Generic;
    
    public partial class schedule
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public schedule()
        {
            this.tickets = new HashSet<tickets>();
        }
    
        public int id { get; set; }
        public Nullable<int> idFilm { get; set; }
        public Nullable<int> idHall { get; set; }
        public Nullable<System.DateTime> dateSchedule { get; set; }
        public Nullable<int> priceTicket { get; set; }
    
        public virtual film film { get; set; }
        public virtual hall hall { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tickets> tickets { get; set; }
    }
}
