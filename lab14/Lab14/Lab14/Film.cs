//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lab14
{
    using System;
    using System.Collections.Generic;
    
    public partial class Film
    {
        public int id { get; set; }
        public Nullable<int> producer { get; set; }
        public byte[] cover { get; set; }
        public Nullable<int> year { get; set; }
        public string Title { get; set; }
    
        public virtual Producer Producer1 { get; set; }
    }
}
