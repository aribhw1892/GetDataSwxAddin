<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GetData
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.GetDataButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'GetDataButton
        '
        Me.GetDataButton.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GetDataButton.Location = New System.Drawing.Point(3, 3)
        Me.GetDataButton.Name = "GetDataButton"
        Me.GetDataButton.Size = New System.Drawing.Size(193, 42)
        Me.GetDataButton.TabIndex = 0
        Me.GetDataButton.Text = "Get Data"
        Me.GetDataButton.UseVisualStyleBackColor = True
        '
        'GetData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GetDataButton)
        Me.Name = "GetData"
        Me.Size = New System.Drawing.Size(199, 219)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GetDataButton As Windows.Forms.Button
End Class
