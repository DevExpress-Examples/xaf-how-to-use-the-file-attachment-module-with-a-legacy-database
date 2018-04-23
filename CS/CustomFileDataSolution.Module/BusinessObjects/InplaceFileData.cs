using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;

namespace CustomFileDataSolution.Module.BusinessObjects {

    [DomainComponent]
    public class InplaceFileData : IFileData {
        private IXPSimpleObject host;
        private XPMemberInfo member;
        private string extension;
        public InplaceFileData(IXPSimpleObject host, XPMemberInfo member, string extension) {
            this.host = host;
            this.member = member;
            this.extension = extension;
        }
        public void Clear() {
            member.SetValue(host, null);
        }
        public string FileName {
            get {
                if (member.GetValue(host) == null) return null;
                return string.Format("{0}{1}.{2}", member.Name, member.Owner.GetId(host), extension);
            }
            set { }
        }
        public void LoadFromStream(string fileName, Stream stream) {
            Guard.ArgumentNotNull(stream, "stream");
            Guard.ArgumentNotNullOrEmpty(fileName, "fileName");
            byte[] array = new byte[stream.Length];
            stream.Read(array, 0, array.Length);
            member.SetValue(host, array);
        }
        public void SaveToStream(Stream stream) {
            if (string.IsNullOrEmpty(FileName)) {
                throw new InvalidOperationException();
            }
            byte[] array = member.GetValue(host) as byte[];
            if (array != null) {
                stream.Write(array, 0, Size);
            }
            stream.Flush();
        }
        [Browsable(false)]
        public int Size {
            get {
                byte[] data = member.GetValue(host) as byte[];
                return data == null ? 0 : data.Length;
            }
        }
        public override string ToString() {
            return FileName;
        }
    }

}
