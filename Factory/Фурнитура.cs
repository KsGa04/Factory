//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Factory
{
    using System;
    using System.Collections.Generic;
    
    public partial class Фурнитура
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Фурнитура()
        {
            this.Типы = new HashSet<Типы>();
        }
    
        public string Артикул { get; set; }
        public string Наименование { get; set; }
        public Nullable<double> Ширина { get; set; }
        public Nullable<double> Длина { get; set; }
        public decimal Цена { get; set; }
        public double Вес { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Типы> Типы { get; set; }
    }
}
