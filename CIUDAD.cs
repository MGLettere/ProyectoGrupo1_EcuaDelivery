//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EcuaDeliveryV3
{
    using System;
    using System.Collections.Generic;
    
    public partial class CIUDAD
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CIUDAD()
        {
            this.DIRECCIONs = new HashSet<DIRECCION>();
        }
    
        public int CIU_ID { get; set; }
        public string CIU_NOMBRE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DIRECCION> DIRECCIONs { get; set; }
    }
}