using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DevExpress.Persistent.Base;

using Microsoft.EntityFrameworkCore;

namespace CustomFileDataEF.Module.BusinessObjects;

[Table("BusinessObject")]
[DefaultClassOptions]
public partial class BusinessObject {
    public BusinessObject() {
        _DocumentFile = new InplaceFileData(this, PropertyNameEnum.Document);
        _ScreenshotFile = new InplaceFileData(this, PropertyNameEnum.Screenshot);
    }
    [Key]
    [Column("ID")]
    public virtual int Id { get; set; }

    [StringLength(100)]
    public virtual string Description { get; set; }

    [Browsable(false)]
    public virtual byte[] Document { get; set; }

    [Browsable(false)]
    public virtual byte[] Screenshot { get; set; }


    private InplaceFileData _DocumentFile;
    [NotMapped]
    public InplaceFileData DocumentFile { get { return _DocumentFile; } set { } }
    private InplaceFileData _ScreenshotFile;
    [NotMapped]
    public InplaceFileData ScreenshotFile { get { return _ScreenshotFile; } set { } }
}
