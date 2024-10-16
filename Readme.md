<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128594795/23.1.5%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T237508)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# XAF - How to use the File Attachment Module with a legacy database

The [File Attachments](https://docs.devexpress.com/eXpressAppFramework/112781/document-management/file-attachments-module) module ships with the capability to implement file upload and download functionality in your application. However, the built-in `FileData` class is persistent and therefore requires a separate table in the database to store file contents and names. This means you cannot use this class for XAF applications that work with a legacy database where a file is stored in a BLOB field of the table with other fields of the same object in a plain form - the same object may contain multiple BLOB fields for different files. 


## Implementation Details

To execute this and similar scenarios, you can create a non-persistent class that implements the `IFileData` interface. This example demonstrates a possible `IFileData` implementation in a non-persistent class that passes data to/from the owner persistent object where the BLOB (`byte[]`) property is declared.

Important notes:

- Since the `IFileData` implementor class is not persistent, the object space cannot create its instances, and we create the only instance in the persistent class constructor.
- The `IFileData` property must have a setter to allow uploading files in Blazor.
- In this example, the file name is not stored in the object but is generated from the object key value. It is only used when the file is downloaded.

This example demonstrates only one possible solution. If you need to cover a different scenario, you can extend this solution or create your own.

## Files to Review

* [BusinessObject.cs](CS/EF/CustomFileDataEF/CustomFileDataEF.Module/MyModels/BusinessObject.cs)
* [InplaceFileData.cs](CS/EF/CustomFileDataEF/CustomFileDataEF.Module/MyModels/InplaceFileData.cs)

## Documenation

* [File Attachments Module](https://docs.devexpress.com/eXpressAppFramework/112781/document-management/file-attachments-module)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=xaf-how-to-use-the-file-attachment-module-with-a-legacy-database&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=xaf-how-to-use-the-file-attachment-module-with-a-legacy-database&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
