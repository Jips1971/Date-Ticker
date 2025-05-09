<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrinterSelection
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.HomePrinter = New System.Windows.Forms.TextBox()
        Me.WorkPrinter = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Home Printer"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 82)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Work printer"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(16, 130)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(261, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Apply"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'HomePrinter
        '
        Me.HomePrinter.Location = New System.Drawing.Point(113, 41)
        Me.HomePrinter.Name = "HomePrinter"
        Me.HomePrinter.Size = New System.Drawing.Size(164, 20)
        Me.HomePrinter.TabIndex = 3
        '
        'WorkPrinter
        '
        Me.WorkPrinter.Location = New System.Drawing.Point(113, 82)
        Me.WorkPrinter.Name = "WorkPrinter"
        Me.WorkPrinter.Size = New System.Drawing.Size(164, 20)
        Me.WorkPrinter.TabIndex = 4
        '
        'PrinterSelection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(308, 192)
        Me.Controls.Add(Me.WorkPrinter)
        Me.Controls.Add(Me.HomePrinter)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "PrinterSelection"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PrinterSelection"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents HomePrinter As TextBox
    Friend WithEvents WorkPrinter As TextBox
End Class
