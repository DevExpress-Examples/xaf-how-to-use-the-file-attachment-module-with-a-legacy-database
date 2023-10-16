using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomFileData.Module.BusinessObjects {

    [DefaultClassOptions]
    public partial class BusinessObject : XPLiteObject {
        public BusinessObject(Session session) : base(session) {
            _DocumentFile = new InplaceFileData(this, PropertyNameEnum.Document);
            _ScreenshotFile = new InplaceFileData(this, PropertyNameEnum.Screenshot);
        }

        int fID;
        [Key(true)]
        public int ID {
            get { return fID; }
            set { SetPropertyValue<int>(nameof(ID), ref fID, value); }
        }
        string fDescription;
        public string Description {
            get { return fDescription; }
            set { SetPropertyValue<string>(nameof(Description), ref fDescription, value); }
        }
        byte[] fDocument;
        [Size(SizeAttribute.Unlimited)]
        [MemberDesignTimeVisibility(true)]
        [Browsable(false)]
        public byte[] Document {
            get { return fDocument; }
            set { SetPropertyValue<byte[]>(nameof(Document), ref fDocument, value); }
        }
        byte[] fScreenshot;
        [Size(SizeAttribute.Unlimited)]
        [MemberDesignTimeVisibility(true)]
        [Browsable(false)]
        public byte[] Screenshot {
            get { return fScreenshot; }
            set { SetPropertyValue<byte[]>(nameof(Screenshot), ref fScreenshot, value); }
        }

        private InplaceFileData _DocumentFile;
        public InplaceFileData DocumentFile { get { return _DocumentFile; }set { } }
        private InplaceFileData _ScreenshotFile;
        public InplaceFileData ScreenshotFile { get { return _ScreenshotFile; } set { } }
    }
    public enum PropertyNameEnum { Document, Screenshot }
}
