//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASF.Data.DbContext
{
    using System;
    using System.Collections.Generic;
    
    public partial class Language
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Language()
        {
            this.LocaleStringResource = new HashSet<LocaleStringResource>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string LanguageCulture { get; set; }
        public string FlagImageFileName { get; set; }
        public bool RightToLeft { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LocaleStringResource> LocaleStringResource { get; set; }
    }
}