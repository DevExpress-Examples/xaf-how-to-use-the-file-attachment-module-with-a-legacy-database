Imports Microsoft.VisualBasic
Imports DevExpress.Persistent.Base
Imports DevExpress.Xpo
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Linq
Imports System.Text

Namespace CustomFileDataSolution.Module.BusinessObjects

	<NavigationItem> _
	Public Class BusinessObject
		Inherits XPLiteObject
		Public Sub New(ByVal s As Session)
			MyBase.New(s)
			Me._DocumentFile = New InplaceFileData(Me, Me.ClassInfo.GetMember("Document"), "pdf")
			Me._ScreenshotFile = New InplaceFileData(Me, Me.ClassInfo.GetMember("Screenshot"), "jpg")
		End Sub

		<Key(True), Persistent("ID")> _
		Private _ID As Integer
		<PersistentAlias("_ID")> _
		Public ReadOnly Property ID() As Integer
			Get
				Return _ID
			End Get
		End Property

		Public Property Description() As String
			Get
				Return GetPropertyValue(Of String)("Description")
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("Description", value)
			End Set
		End Property

		<Browsable(False), Delayed> _
		Public Property Document() As Byte()
			Get
				Return GetDelayedPropertyValue(Of Byte())("Document")
			End Get
			Set(ByVal value As Byte())
				SetDelayedPropertyValue(Of Byte())("Document", value)
			End Set
		End Property
		Private _DocumentFile As InplaceFileData
		Public Property DocumentFile() As InplaceFileData
			Get
				Return _DocumentFile
			End Get
			Set(ByVal value As InplaceFileData)
			End Set
		End Property

		<Browsable(False), Delayed> _
		Public Property Screenshot() As Byte()
			Get
				Return GetDelayedPropertyValue(Of Byte())("Screenshot")
			End Get
			Set(ByVal value As Byte())
				SetDelayedPropertyValue(Of Byte())("Screenshot", value)
			End Set
		End Property
		Private _ScreenshotFile As InplaceFileData
		Public Property ScreenshotFile() As InplaceFileData
			Get
				Return _ScreenshotFile
			End Get
			Set(ByVal value As InplaceFileData)
			End Set
		End Property
	End Class

End Namespace
