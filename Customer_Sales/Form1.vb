
Imports System.Data.SqlClient

Public Class Form1

    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim rd As SqlDataReader
    Dim lst As ListViewItem


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        con.ConnectionString = "Persist Security Info=False;Integrated Security=true;Initial Catalog=sql4657;server=DESKTOP-9SA4VPE\MSSQLSERVER01"
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        con.Open()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ListView1.Items.Clear()
        cmd = New SqlCommand("select pr.product_name, pr.price,d.discount_percent,d.new_price from deals d left join product pr on d.product_id =pr.product_id", con)
        rd = cmd.ExecuteReader()
        While rd.Read
            lst = ListView1.Items.Add(rd.Item(0))
            lst.SubItems.Add(rd.Item(1))
            lst.SubItems.Add(rd.Item(2))
            lst.SubItems.Add(rd.Item(3))
        End While
        rd.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ListView1.Items.Clear()
        cmd = New SqlCommand("select pr.product_name, pr.price,d.discount_percent,d.new_price from deals d left join product pr on d.product_id = pr.product_id where pr.product_id = '" & TextBox1.Text & "' ", con)
        rd = cmd.ExecuteReader()
        While rd.Read
            lst = ListView1.Items.Add(rd.Item(0))
            lst.SubItems.Add(rd.Item(1))
            lst.SubItems.Add(rd.Item(2))
            lst.SubItems.Add(rd.Item(3))
        End While
        rd.Close()

    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Close()
    End Sub
End Class
