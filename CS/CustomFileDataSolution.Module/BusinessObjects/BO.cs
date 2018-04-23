using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CustomFileDataSolution.Module.BusinessObjects {

    [NavigationItem]
    public class BusinessObject : XPLiteObject {
        public BusinessObject(Session s)
            : base(s) {
            _DocumentFile = new InplaceFileData(this, this.ClassInfo.GetMember("Document"), "pdf");
            _ScreenshotFile = new InplaceFileData(this, this.ClassInfo.GetMember("Screenshot"), "jpg");
        }

        [Key(true)]
        [Persistent("ID")]
        private int _ID = 0;
        [PersistentAlias("_ID")]
        public int ID { get { return _ID; } }

        public string Description {
            get { return GetPropertyValue<string>("Description"); }
            set { SetPropertyValue<string>("Description", value); }
        }

        [Browsable(false)]
        [Delayed]
        public byte[] Document {
            get { return GetDelayedPropertyValue<byte[]>("Document"); }
            set { SetDelayedPropertyValue<byte[]>("Document", value); }
        }
        private InplaceFileData _DocumentFile;
        public InplaceFileData DocumentFile { get { return _DocumentFile; } set { } }

        [Browsable(false)]
        [Delayed]
        public byte[] Screenshot {
            get { return GetDelayedPropertyValue<byte[]>("Screenshot"); }
            set { SetDelayedPropertyValue<byte[]>("Screenshot", value); }
        }
        private InplaceFileData _ScreenshotFile;
        public InplaceFileData ScreenshotFile { get { return _ScreenshotFile; } set { } }
    }

}
