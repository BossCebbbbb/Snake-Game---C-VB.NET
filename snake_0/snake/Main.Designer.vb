<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.tmr = New System.Windows.Forms.Timer(Me.components)
        Me.tss0 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tss1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tss2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssSnakeLength = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tss3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ss = New System.Windows.Forms.StatusStrip()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ss.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'tmr
        '
        Me.tmr.Enabled = True
        Me.tmr.Interval = 50
        '
        'tss0
        '
        Me.tss0.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.tss0.Name = "tss0"
        Me.tss0.Size = New System.Drawing.Size(68, 17)
        Me.tss0.Text = "Screen Size:"
        Me.tss0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tss1
        '
        Me.tss1.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.tss1.Name = "tss1"
        Me.tss1.Size = New System.Drawing.Size(0, 17)
        Me.tss1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tss2
        '
        Me.tss2.BorderStyle = System.Windows.Forms.Border3DStyle.Raised
        Me.tss2.Name = "tss2"
        Me.tss2.Size = New System.Drawing.Size(0, 17)
        Me.tss2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tssSnakeLength
        '
        Me.tssSnakeLength.BorderStyle = System.Windows.Forms.Border3DStyle.Raised
        Me.tssSnakeLength.Name = "tssSnakeLength"
        Me.tssSnakeLength.Size = New System.Drawing.Size(0, 17)
        Me.tssSnakeLength.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tss3
        '
        Me.tss3.BorderStyle = System.Windows.Forms.Border3DStyle.Raised
        Me.tss3.Name = "tss3"
        Me.tss3.Size = New System.Drawing.Size(570, 17)
        Me.tss3.Spring = True
        Me.tss3.Text = "Total Points:"
        Me.tss3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ss
        '
        Me.ss.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tss0, Me.tss1, Me.tss2, Me.tssSnakeLength, Me.tss3})
        Me.ss.Location = New System.Drawing.Point(0, 502)
        Me.ss.Name = "ss"
        Me.ss.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ss.Size = New System.Drawing.Size(653, 22)
        Me.ss.TabIndex = 0
        Me.ss.Text = "StatusStrip1"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Gray
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Location = New System.Drawing.Point(0, 475)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(654, 49)
        Me.Panel2.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "SNAKE"
        '
        'main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.BackgroundImage = Global.snake.My.Resources.Resources.back
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(653, 524)
        Me.Controls.Add(Me.ss)
        Me.Controls.Add(Me.Panel2)
        Me.DoubleBuffered = True
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(669, 600)
        Me.MinimumSize = New System.Drawing.Size(669, 537)
        Me.Name = "main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Snake"
        Me.ss.ResumeLayout(False)
        Me.ss.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tmr As System.Windows.Forms.Timer
    Friend WithEvents tss0 As ToolStripStatusLabel
    Friend WithEvents tss1 As ToolStripStatusLabel
    Friend WithEvents tss2 As ToolStripStatusLabel
    Friend WithEvents tssSnakeLength As ToolStripStatusLabel
    Friend WithEvents tss3 As ToolStripStatusLabel
    Friend WithEvents ss As StatusStrip
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
End Class
