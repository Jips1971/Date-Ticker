Public Class CaffineLocationForm

    Private Sub CaffineLocation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\JipsSoft\Dateticker", "CaffineLocation", Nothing)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\JipsSoft\Dateticker", "CaffineLocation", TextBox1.Text)
        Me.Dispose()
    End Sub
End Class