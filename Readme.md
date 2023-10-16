<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128594795/23.1.5%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T237508)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [BusinessObject.cs](CS/EF/CustomFileDataEF/CustomFileDataEF.Module/MyModels/BusinessObject.cs)
* **[InplaceFileData.cs](CS/EF/CustomFileDataEF/CustomFileDataEF.Module/MyModels/InplaceFileData.cs)**
<!-- default file list end -->
# How to use the File Attachment Module with a legacy database


The <a href="https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112781.aspx">File Attachments Module</a> provides the capability to easily implement a file upload and download functionality in your application. However, the built-in <strong>FileData</strong> class is persistent, and thus requires a separate table in the database to store file contents and names. Moreover, with XPO model, the built-in FileData class stores file contents in compressed form. These specifics make this class useless for XAF applications that must work with a legacy database. It is quite typical for a legacy database that a file is stored in a BLOB field of the table with other fields of the same object and in a plain form. Also, the same reecord may contain multiple BLOB fields for different files. To handle this and other various scenarios, a non-persistent class that implements the <strong>IFileData</strong> interface can be created.<br /><br />This example demonstrates a possible IFileData implementation in a non-persistent class that actually passes data to and from the owner persistent XPO object, where the BLOB (byte[]) property is declared.<br /><br />Important notes:<br />- Since the IFileData implementor class is non-persisent, the object space cannot create its instances. So, we create the only instance in the persistent class constructor.<br />- The IFileData property must have a setter to allow uploading files in ASP.NET.<br />- In this example, the file name is not stored in the object, but generated from the object key value. It is only used when the file is downloaded by the client.<br /><br />

<br/>


