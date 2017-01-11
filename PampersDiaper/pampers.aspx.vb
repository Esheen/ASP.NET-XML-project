Imports System.Data.SqlClient

Public Class pampers
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DiaperXML()
    End Sub

    Sub DiaperXML()
        Dim choice = Request("ProductType")
        Dim SQL1 = "SELECT * FROM Product WHERE ProductName = 'Swaddlers'"
        If choice = "2" Then
            SQL1 = "SELECT * FROM Product WHERE ProductName = 'Cruisers'"
        ElseIf choice = "3" Then
            SQL1 = "SELECT * FROM Product WHERE ProductName = 'BabyDry'"
        ElseIf choice = "4" Then
            SQL1 = "SELECT * FROM Product WHERE ProductName = 'EasyUpGirl'"
        ElseIf choice = "5" Then
            SQL1 = "SELECT * FROM Product WHERE ProductName = 'EasyUpBoy'"
        End If

        Dim XMLOutput = "<?xml version=""1.0""  encoding=""utf-8"" ?>"
        XMLOutput = XMLOutput + "<?xml-stylesheet type=""text/xsl"" href=""pampers.xslt""?>"
        XMLOutput = XMLOutput + "<XOrder"
        XMLOutput = XMLOutput + " xmlns = ""http://www.w3schools.com"""
        XMLOutput = XMLOutput + " xmlns:xsi = ""http://www.w3.org/2001/XMLSchema-instance"""
        XMLOutput = XMLOutput + " xsi:schemaLocation = ""http://www.w3schools.com pampers.xsd"" >"

        Dim conn As New SqlConnection
        Dim cmd = New SqlCommand(SQL1, conn)
        conn.ConnectionString = ConfigurationManager.ConnectionStrings("dbSQL").ConnectionString
        conn.Open()

        Dim dbreader = cmd.ExecuteReader()
        For Each record In dbreader
            XMLOutput = XMLOutput + "<Product"
            XMLOutput = XMLOutput + " ProductName=""" & dbreader.GetString(1) & """"
            XMLOutput = XMLOutput + " Size=""" & dbreader.GetInt32(2) & """"
            XMLOutput = XMLOutput + " >"
            Dim SQL2 = "SELECT Customer.CustomerID, Fname, Lname, City, State FROM Customer INNER JOIN XOrder ON Customer.CustomerID = XOrder.CustomerID WHERE ProductID=" & dbreader.GetInt32(0)
            Dim cmd2 = New SqlCommand(SQL2, conn)
            Dim dbreader2 = cmd2.ExecuteReader()
            For Each record2 In dbreader2
                XMLOutput = XMLOutput + "<Customer"
                XMLOutput = XMLOutput + " CustomerID=""" & dbreader2.GetInt32(0) & """"
                XMLOutput = XMLOutput + " Fname=""" & dbreader2.GetString(1) & """"
                XMLOutput = XMLOutput + " Lname=""" & dbreader2.GetString(2) & """"
                XMLOutput = XMLOutput + " City=""" & dbreader2.GetString(3) & """"
                XMLOutput = XMLOutput + " State=""" & dbreader2.GetString(4) & """"
                XMLOutput = XMLOutput + " />"
            Next
            dbreader2.Close()
            XMLOutput = XMLOutput + "</Product>"
        Next
        dbreader.Close()
        cmd.Dispose()
        conn.Close()
        XMLOutput = XMLOutput + "</XOrder>"
        Response.Write(XMLOutput)

    End Sub

End Class