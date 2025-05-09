
Public Class PrinterSelection
    Private Sub PrinterSelection_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Remove the form border
        FormBorderStyle = 0


        WorkPrinter.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\JipsSoft\Dateticker", "WorkPrinter", Nothing)
        HomePrinter.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\JipsSoft\Dateticker", "HomePrinter", Nothing)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        'Check TextBoxes are filled in

        Dim emptyTextBoxes =
    From txt In Me.Controls.OfType(Of TextBox)()
    Where txt.Text.Length = 0
    Select txt.Name
        If emptyTextBoxes.Any Then
            MessageBox.Show(String.Format("Please fill following textboxes: {0}",
                    String.Join(",", emptyTextBoxes)))
        End If


        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\JipsSoft\Dateticker", "WorkPrinter", WorkPrinter.Text)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\JipsSoft\Dateticker", "HomePrinter", HomePrinter.Text)
        Application.Restart()




    End Sub
End Class