Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim pulleddate As Date = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\JipsSoft\Dateticker", "StartDate", Nothing)
        Dim newdate As Date = "01/01/1900"
        DateTimePicker1.Value = pulleddate
        'Make Topmost above other apps
        Top = 0
        'Remove the form border
        FormBorderStyle = 0
        'Place Box in top centre
        Dim x As Integer
        Dim y As Integer
        x = (Screen.PrimaryScreen.WorkingArea.Width / 2) - (Me.Width / 2) ' + 16 ' added 16 pixels due to gap
        y = Screen.PrimaryScreen.WorkingArea.Height / 2 - Me.Height / 2
        Me.Location = New Point(x, y)


        Label1.Text = Me.Height



        Label3.Text = pulleddate
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Pull the date from the date picker and put in registry

        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\JipsSoft\Dateticker", "StartDate", DateTimePicker1.Value)
        Me.Dispose()
    End Sub


End Class