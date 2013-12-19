Namespace Contensive.Addons.mvcProject
    '
    Public Class mvcProject1Class
        Inherits BaseClasses.AddonBaseClass
        '
        Public Overrides Function Execute(ByVal CP As BaseClasses.CPBaseClass) As Object
            Dim s As String = ""
            '
            Try
                s = CP.Html.div(s, , , "mvcContainer")
            Catch ex As Exception
                Try
                    CP.Site.ErrorReport(ex, "error in Contensive.Addons.performanceCloud.effectRemotes.mvcProject1Class.Execute")
                Catch errObj As Exception
                End Try
            End Try
            '
            Return s
        End Function
        '
    End Class
    '
    Public Class mvcProject1HandlerClass
        Inherits BaseClasses.AddonBaseClass
        '
        Public Overrides Function Execute(ByVal CP As BaseClasses.CPBaseClass) As Object
            Dim s As String = ""
            '
            Try
                Dim cs As BaseClasses.CPCSBaseClass = CP.CSNew()
                Dim people As New people
                Dim peopleList As New List(Of people)
                '
                Dim layout As String = ""
                '
                Dim localPackageDesign As New jsonPackageData
                Dim localPackageData As New jsonPackageData
                Dim localPackageError As New jsonPackageError
                Dim success As Boolean = False
                Dim dataObj As New List(Of jsonPackageData)
                Dim designObj As New List(Of jsonPackageData)
                '
                Dim recordCount As Integer = 0
                '
                If cs.Open("Layouts", "name='People List'", , , "layout") Then
                    localPackageDesign.dataSet = cs.GetText("layout")
                    '
                    designObj.Add(localPackageDesign)
                End If
                cs.Close()
                '
                If cs.Open("People", , "lastName", , "id,firstName,lastName") Then
                    recordCount = cs.GetRowCount()
                    '
                    Do While cs.OK()
                        people.id = cs.GetInteger("id")
                        people.firstName = cs.GetText("firstName")
                        people.lastName = cs.GetText("lastName")
                        '
                        peopleList.Add(people)
                        '
                        cs.GoNext()
                        '
                        If cs.OK() Then
                            people = New people
                        End If
                    Loop
                    '
                    localPackageData.dataFor = "People"
                    localPackageData.recordCount = recordCount
                    localPackageData.dataSet = peopleList
                    '
                    dataObj.Add(localPackageData)
                Else
                    localPackageError.number = 999
                    localPackageError.description = "no people found"
                    '
                    errList.Add(localPackageError)
                End If
                cs.Close()
                '
                s = getSerializedJSONWrapper(CP, success, errList, dataObj, designObj)
            Catch ex As Exception
                Try
                    CP.Site.ErrorReport(ex, "error in Contensive.Addons.performanceCloud.effectRemotes.mvcProject1HandlerClass.Execute")
                Catch errObj As Exception
                End Try
            End Try
            '
            Return s
        End Function
        '
    End Class
    '
End Namespace

