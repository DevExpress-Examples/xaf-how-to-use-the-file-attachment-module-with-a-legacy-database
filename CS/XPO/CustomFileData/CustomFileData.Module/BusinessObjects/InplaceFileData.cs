using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using System.ComponentModel;

namespace CustomFileData.Module.BusinessObjects {
    [DomainComponent]
    public class InplaceFileData : IFileData {
        private BusinessObject owner;
        private PropertyNameEnum propertyName;
        public InplaceFileData(BusinessObject _owner, PropertyNameEnum _propertyName) {
            this.owner = _owner;
            this.propertyName = _propertyName;
        }
        public void Clear() {
            switch (propertyName) {
                case PropertyNameEnum.Document:
                    owner.Document = null;
                    break;
                case PropertyNameEnum.Screenshot:
                    owner.Screenshot = null;
                    break;
            }
        }
        public string FileName {
            get {
                string ext = null;
                switch (propertyName) {
                    case PropertyNameEnum.Document:
                        ext = "txt";
                        break;
                    case PropertyNameEnum.Screenshot:
                        ext = "png";
                        break;
                }
                return string.Format("{0}-{1}.{2}", propertyName, owner.ID,ext);
            }
            set { }
        }
        public void LoadFromStream(string fileName, Stream stream) {
            Guard.ArgumentNotNull(stream, "stream");
            Guard.ArgumentNotNullOrEmpty(fileName, "fileName");
            byte[] array = new byte[stream.Length];
            stream.Read(array, 0, array.Length);
            switch (propertyName) {
                case PropertyNameEnum.Document:
                    owner.Document = array;
                    break;
                case PropertyNameEnum.Screenshot:
                    owner.Screenshot = array;
                    break;
            }
        }
        public void SaveToStream(Stream stream) {
            if (string.IsNullOrEmpty(FileName)) {
                throw new InvalidOperationException();
            }
            byte[] array = null;
            switch (propertyName) {
                case PropertyNameEnum.Document:
                    array = owner.Document;
                    break;
                case PropertyNameEnum.Screenshot:
                    array = owner.Screenshot;
                    break;
            }
            if (array != null) {
                stream.Write(array, 0, Size);
            }
            stream.Flush();
        }
        [Browsable(false)]
        public int Size {
            get {
                byte[] array = null;
                switch (propertyName) {
                    case PropertyNameEnum.Document:
                        array = owner.Document;
                        break;
                    case PropertyNameEnum.Screenshot:
                        array = owner.Screenshot;
                        break;
                }
                return array == null ? 0 : array.Length;
            }
        }
        public override string ToString() {
            return FileName;
        }
    }
}
