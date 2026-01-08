Imports System.Drawing.Printing
Imports System.Net
Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Main
    Dim MOVEPLUS As Boolean = True
    Dim MOVEMINUS As Boolean = False
    Dim WorkPrinter As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\JipsSoft\Dateticker", "WorkPrinter", Nothing)
    Dim HomePrinter As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\JipsSoft\Dateticker", "HomePrinter", Nothing)
    Dim Timer_Counter As Integer = 0



    Private WithEvents RefreshTimer As New Windows.Forms.Timer


    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        'Set up Text Colours to black

        SetLabelColors(Color.Black)

        'Co ordinates position set up

        Label2.Text = Cursor.Position.X
        Label4.Text = Cursor.Position.Y




        'Call Setup Function to find out and set where we are

        Setup()


        'Place Box on screen
        Dim x As Integer = 0
        Dim y As Integer = 0
        Dim CHECK1 As Boolean = False

        'Top Middle
        x = (Screen.PrimaryScreen.WorkingArea.Width / 2) - (Me.Width / 2) ' + 16 ' added 16 pixels due to gap
        y = (Screen.PrimaryScreen.WorkingArea.Height - Me.Height)


        Me.Location = New Point(x, y)

        'Make Topmost above other apps
        Top = 0

        'Remove the form border
        FormBorderStyle = 0




        'Start the timer
        Timer1.Start()
        With RefreshTimer
            .Interval = 100  '1 secs
            .Start()


        End With


    End Sub



    Private Sub Setup()
        Dim Location As String = ""
        Dim host As String = System.Net.Dns.GetHostName()
        'Dim ipaddress As String = Dns.GetHostByName(host).AddressList(0).ToString()
        Dim ipaddress As String = Dns.GetHostEntry(host).AddressList(0).ToString()

        Dim settings As PrinterSettings = New PrinterSettings()
        Dim PrinterName As String = ""


        'Work
        If ipaddress.Substring(0, 3) = "10." Then
            Location = "Work"

            SetLabelColors(Color.White)
            PrinterName = WorkPrinter

            Try
                Shell(String.Format("rundll32 printui.dll,PrintUIEntry /y /n ""{0}""", WorkPrinter))
            Catch ex As Exception
                MsgBox("Printer Incorrect")
            End Try

            'Try
            'If File.Exists("C:\Windows\System32\Drivers\Etc\hostsWork") Then
            'My.Computer.FileSystem.CopyFile("C:\Windows\System32\Drivers\Etc\hostsWork", "C:\Windows\System32\Drivers\Etc\hosts", True)
            'End If
            'Catch ex As Exception
            'End Try

            Try
                If File.Exists("C:\Users\30044908\OneDrive - Yokogawa Electric Corporation\Apps\James\caffine64.exe") Then
                    Process.Start("C:\Users\30044908\OneDrive - Yokogawa Electric Corporation\Apps\James\caffine64.exe", "-replace -useshiftr -appoff")

                End If
            Catch ex As Exception
            End Try


        End If





        'Home
        If ipaddress.Substring(0, 3) = "192" Then
            Location = "Home"


            SetLabelColors(Color.LimeGreen)

            PrinterName = "Canon TS5300 series"

            Try
                Shell(String.Format("rundll32 printui.dll,PrintUIEntry /y /n ""{0}""", HomePrinter))
            Catch ex As Exception
                MsgBox("Printer Incorrect")
            End Try


            'Try
            'If File.Exists("C:\Windows\System32\Drivers\Etc\hostsHome") Then
            'My.Computer.FileSystem.CopyFile("C:\Windows\System32\Drivers\Etc\hostsHome", "C:\Windows\System32\Drivers\Etc\hosts", True)

            'End If
            'Catch ex As Exception
            'End Try



            Try
                If File.Exists("C:\Users\30044908\OneDrive - Yokogawa Electric Corporation\Apps\James\caffine64.exe") Then
                    Process.Start("C:\Users\30044908\OneDrive - Yokogawa Electric Corporation\Apps\James\caffine64.exe", "-replace -useshiftr")
                End If
            Catch ex As Exception
            End Try


        End If












        Label5.Text = "Location - " + Location + "    IP: " + ipaddress
        Label6.Text = "Printer : " + PrinterName
    End Sub





    'If the user clicks the button to alter the start date
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Form1.Show()
    End Sub



    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        PrinterSelection.Show()
    End Sub





    Private Sub CheckReg()
        'Is there a registry key there?

        If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\JipsSoft\Dateticker", "StartDate", Nothing) Is Nothing Then
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\JipsSoft\Dateticker", "StartDate", "01/01/1900")
            Form1.Show()
        Else
            My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\JipsSoft\Dateticker", "StartDate", Nothing)
        End If


        If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\JipsSoft\Dateticker", "WorkPrinter", Nothing) Is Nothing Then
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\JipsSoft\Dateticker", "WorkPrinter", "Not Set")
        Else
            My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\JipsSoft\Dateticker", "WorkPrinter", Nothing)
        End If

        If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\JipsSoft\Dateticker", "HomePrinter", Nothing) Is Nothing Then
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\JipsSoft\Dateticker", "HomePrinter", "Not Set")
        Else
            My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\JipsSoft\Dateticker", "HomePrinter", Nothing)
        End If




    End Sub



    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Dim date2Entered As Date

        Dim ERRORFLAG As Boolean = False

        Label2.Text = "X - " & Cursor.Position.X
        Label4.Text = "Y - " & Cursor.Position.Y







        Static SecondsCount As Integer 'Counts each second
        SecondsCount += 1 'Increment
        'Label5.Text = Decimal.Round(SecondsCount / 10)


        If Decimal.Round(SecondsCount / 10) > 180 And MOVEPLUS = True Then
            Cursor.Position = New Point(Cursor.Position.X + 1, Cursor.Position.Y)
            MOVEPLUS = False
            MOVEMINUS = True
            SecondsCount = 0
            '     Timer1.Enabled = True
        End If

        If Decimal.Round(SecondsCount / 10) > 180 And MOVEMINUS = True Then
            Cursor.Position = New Point(Cursor.Position.X - 1, Cursor.Position.Y)
            MOVEMINUS = False
            MOVEPLUS = True
            SecondsCount = 0
            '   Timer1.Enabled = True
        End If



        'Pull this from the registry
        CheckReg()
        Try
            date2Entered = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\JipsSoft\Dateticker", "StartDate", Nothing)
        Catch ex As Exception
            ERRORFLAG = True
        End Try


        Dim nowtime As Date = Now
        Dim datTim1 As Date = Date.Parse(date2Entered)
        Dim datTim2 As Date = Now
        Dim dateSpan = DateTimeSpan.CompareDates(datTim1, datTim2)
        'If all OK
        If ERRORFLAG = False Then Label9.Text = (dateSpan.Years.ToString() & " Years")
        If ERRORFLAG = False Then Label8.Text = (dateSpan.Months.ToString() & " Months")
        If ERRORFLAG = False Then Label1.Text = (dateSpan.Days.ToString() & " Days     Current Time : " & DateTime.Now.ToString("HH:mm:ss"))
        If ERRORFLAG = False Then Label7.Text = " CET : " & DateAdd("h", 1, DateTime.Now.ToString("HH:mm:ss"))
        If ERRORFLAG = False Then Label10.Text = " China : " & DateAdd("h", 7, DateTime.Now.ToString("HH:mm:ss"))

        'If there is a problem
        If ERRORFLAG = True Then Label9.Text = ("ERROR IN REGISTRY")
        If ERRORFLAG = True Then Label8.Text = ("")
        If ERRORFLAG = True Then Label1.Text = ("")

    End Sub

    Public Structure DateTimeSpan
        Private ReadOnly m_years As Integer
        Private ReadOnly m_months As Integer
        Private ReadOnly m_days As Integer
        Private ReadOnly m_hours As Integer
        Private ReadOnly m_minutes As Integer
        Private ReadOnly m_seconds As Integer
        Private ReadOnly m_milliseconds As Integer
        Public Sub New(years As Integer, months As Integer, days As Integer, hours As Integer, minutes As Integer, seconds As Integer,
        milliseconds As Integer)
            Me.m_years = years
            Me.m_months = months
            Me.m_days = days
            Me.m_hours = hours
            Me.m_minutes = minutes
            Me.m_seconds = seconds
            Me.m_milliseconds = milliseconds
        End Sub
        Public ReadOnly Property Years() As Integer
            Get
                Return m_years
            End Get
        End Property
        Public ReadOnly Property Months() As Integer
            Get
                Return m_months
            End Get
        End Property
        Public ReadOnly Property Days() As Integer
            Get
                Return m_days
            End Get
        End Property
        Public ReadOnly Property Hours() As Integer
            Get
                Return m_hours
            End Get
        End Property
        Public ReadOnly Property Minutes() As Integer
            Get
                Return m_minutes
            End Get
        End Property
        Public ReadOnly Property Seconds() As Integer
            Get
                Return m_seconds
            End Get
        End Property
        Public ReadOnly Property Milliseconds() As Integer
            Get
                Return m_milliseconds
            End Get
        End Property
        Private Enum Phase
            Years
            Months
            Days
            Done
        End Enum
        Public Shared Function CompareDates(date1 As DateTime, date2 As DateTime) As DateTimeSpan
            If date2 < date1 Then
                Dim [sub] = date1
                date1 = date2
                date2 = [sub]
            End If
            Dim current As DateTime = date1
            Dim years As Integer = 0
            Dim months As Integer = 0
            Dim days As Integer = 0
            Dim phase__1 As Phase = Phase.Years
            Dim span As New DateTimeSpan()
            Dim officialDay As Integer = current.Day
            While phase__1 <> Phase.Done
                Select Case phase__1
                    Case Phase.Years
                        If current.AddYears(years + 1) > date2 Then
                            phase__1 = Phase.Months
                            current = current.AddYears(years)
                        Else
                            years += 1
                        End If
                        Exit Select
                    Case Phase.Months
                        If current.AddMonths(months + 1) > date2 Then
                            phase__1 = Phase.Days
                            current = current.AddMonths(months)
                            If current.Day < officialDay AndAlso officialDay <= DateTime.DaysInMonth(current.Year, current.Month) Then
                                current = current.AddDays(officialDay - current.Day)
                            End If
                        Else
                            months += 1
                        End If
                        Exit Select
                    Case Phase.Days
                        If current.AddDays(days + 1) > date2 Then
                            current = current.AddDays(days)
                            Dim timespan = date2 - current
                            span = New DateTimeSpan(years, months, days, timespan.Hours, timespan.Minutes, timespan.Seconds,
                            timespan.Milliseconds)
                            phase__1 = Phase.Done
                        Else
                            days += 1
                        End If
                        Exit Select
                End Select
            End While
            Return span
        End Function
    End Structure

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click
        Timer1.Stop()
        Application.Exit()
        Close()
    End Sub

    Private Sub SetLabelColors(color As Color)
        Label1.ForeColor = color
        Label2.ForeColor = color
        Label4.ForeColor = color
        Label5.ForeColor = color
        Label6.ForeColor = color
        Label8.ForeColor = color
        Label9.ForeColor = color
    End Sub




End Class



