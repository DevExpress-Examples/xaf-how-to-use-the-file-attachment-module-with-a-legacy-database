<!-- default badges list -->
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T237508)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# XAF - How to use the File Attachment Module with a legacy database

The [File Attachments](https://docs.devexpress.com/eXpressAppFramework/112781/document-management/file-attachments-module) module ships with the capability to easily implement a file upload and download functionality in your application. However, the built-in `FileData` class is persistent and therefore requires a separate table in the database to store file contents and names. These specifics make this class useless for XAF applications that must work with a legacy database where a file is stored in a BLOB field of the table with other fields of the same object and in a plain form. Also, the same object may contain multiple BLOB fields for different files. 


## Implementation Details

To handle this and other various scenarios, you can create a non-persistent class that implements the `IFileData` interface. This example demonstrates a possible `IFileData` implementation in a non-persistent class that actually passes data to and from the owner persistent object, where the BLOB (`byte[]`) property is declared.

Important notes:

- Since the `IFileData` implementor class is not persisent, the object space cannot create its instances. So, we create the only instance in the persistent class constructor.
- The `IFileData` property must have a setter to allow uploading files in Blazor.
- In this example, the file name is not stored in the object, but is generated from the object key value. It is only used when the file is downloaded by a user.

We have created this example only to demonstrate a possible solution. It doesn't cover all possible scenarios. If you need to support an additional scenario, feel free to extend this solution as required (or create your own).

## Files to Review

* [BusinessObject.cs](CS/EF/CustomFileDataEF/CustomFileDataEF.Module/MyModels/BusinessObject.cs)
* [InplaceFileData.cs](CS/EF/CustomFileDataEF/CustomFileDataEF.Module/MyModels/InplaceFileData.cs)

## Documenation

* [File Attachments Module](https://docs.devexpress.com/eXpressAppFramework/112781/document-management/file-attachments-module)
