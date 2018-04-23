Imports Microsoft.VisualBasic
Imports DevExpress.ExpressApp.DC
Imports DevExpress.ExpressApp.Utils
Imports DevExpress.Persistent.Base
Imports DevExpress.Xpo
Imports DevExpress.Xpo.Metadata
Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.ComponentModel

Namespace CustomFileDataSolution.Module.BusinessObjects

    <DomainComponent> _
    Public Class InplaceFileData
        Implements IFileData
        Private host As IXPSimpleObject
        Private member As XPMemberInfo
        Private extension As String
        Public Sub New(ByVal host As IXPSimpleObject, ByVal member As XPMemberInfo, ByVal extension As String)
            Me.host = host
            Me.member = member
            Me.extension = extension
        End Sub
        Public Sub Clear() Implements IFileData.Clear
            member.SetValue(host, Nothing)
        End Sub
        Public Property FileName() As String Implements IFileData.FileName
            Get
                If member.GetValue(host) Is Nothing Then
                    Return Nothing
                End If
                Return String.Format("{0}{1}.{2}", member.Name, member.Owner.GetId(host), extension)
            End Get
            Set(ByVal value As String)
            End Set
        End Property
        Public Sub LoadFromStream(ByVal fileName As String, ByVal stream As Stream) Implements IFileData.LoadFromStream
            Guard.ArgumentNotNull(stream, "stream")
            Guard.ArgumentNotNullOrEmpty(fileName, "fileName")
            Dim array(CType(stream.Length, Integer) - 1) As Byte
            stream.Read(array, 0, array.Length)
            member.SetValue(host, array)
        End Sub
        Public Sub SaveToStream(ByVal stream As Stream) Implements IFileData.SaveToStream
            If String.IsNullOrEmpty(Me.FileName) Then
                Throw New InvalidOperationException()
            End If
            Dim array() As Byte = TryCast(member.GetValue(host), Byte())
            If array IsNot Nothing Then
                stream.Write(array, 0, Me.Size)
            End If
            stream.Flush()
        End Sub
        <Browsable(False)> _
        Public ReadOnly Property Size() As Integer Implements IFileData.Size
            Get
                Dim data() As Byte = TryCast(member.GetValue(host), Byte())
                Return If(data Is Nothing, 0, data.Length)
            End Get
        End Property
        Public Overrides Function ToString() As String
            Return FileName
        End Function
    End Class

End Namespace
