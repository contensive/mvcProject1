Namespace Contensive.Addons.mvcProject
    '
    Public Module mvcCommon
        '
        Public errList As New List(Of jsonPackageError)
        '
        Public Function getSerializedJSONWrapper(ByVal CP As Contensive.BaseClasses.CPBaseClass, ByVal success As Boolean, Optional ByVal errorObj As List(Of jsonPackageError) = Nothing, Optional ByVal dataObj As List(Of jsonPackageData) = Nothing, Optional ByVal designObject As List(Of jsonPackageData) = Nothing) As String
            Dim s As String = ""
            '
            Try
                Dim package As New jsonPackage
                '
                package.success = success
                package.dataError = errorObj
                package.data = dataObj
                package.design = designObject
                '
                s = serializeObject(CP, package)
                '
                errorObj.RemoveRange(0, errorObj.Count)
                dataObj.RemoveRange(0, errorObj.Count)
            Catch ex As Exception
                Try
                    CP.Site.ErrorReport(ex, "error in Contensive.Addons.mvcProject.mvcCommon.getSerializedJSONWrapper")
                Catch errObj As Exception
                End Try
            End Try
            '
            Return s
        End Function
        '
        Public Function serializeObject(ByVal CP As Contensive.BaseClasses.CPBaseClass, ByVal dataObject As Object) As String
            Dim s As String = ""
            '
            Try
                s = Newtonsoft.Json.JsonConvert.SerializeObject(dataObject)
            Catch ex As Exception
                Try
                    CP.Site.ErrorReport(ex, "error in Contensive.Addons.mvcProject.mvcCommon.serializeObject")
                Catch errObj As Exception
                End Try
            End Try
            '
            Return s
        End Function
        '
    End Module
    '
    <Serializable()>
    Public Class jsonPackage
        Public success As Boolean = False
        Public dataError As New List(Of jsonPackageError)
        Public data As New List(Of jsonPackageData)
        Public designError As New List(Of jsonPackageError)
        Public design As New List(Of jsonPackageData)
    End Class
    '
    <Serializable()>
    Public Class jsonPackageData
        Public dataFor As String = ""
        Public recordCount As Integer = 0
        Public dataSet As Object
    End Class
    '
    <Serializable()>
    Public Class jsonPackageError
        Public number As Integer = 0
        Public description As String = ""
    End Class
    '
    <Serializable()>
    Public Class people
        Public id As Integer = 0
        Public firstName As String = ""
        Public lastName As String = ""
    End Class
    '
End Namespace