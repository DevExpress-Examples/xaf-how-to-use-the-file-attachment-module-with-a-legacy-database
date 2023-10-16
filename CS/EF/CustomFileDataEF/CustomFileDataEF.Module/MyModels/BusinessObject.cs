using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DevExpress.Persistent.Base;
using Microsoft.EntityFrameworkCore;

namespace CustomFileDataEF.Module.BusinessObjects;

[Table("BusinessObject")]
[DefaultClassOptions]
public partial class BusinessObject
{
    [Key]
    [Column("ID")]
    public virtual int Id { get; set; }

    [StringLength(100)]
    public virtual string Description { get; set; }

    public virtual byte[] Document { get; set; }

    public virtual byte[] Screenshot { get; set; }
}
