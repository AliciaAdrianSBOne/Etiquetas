<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrinter
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lvPrintTickets = New System.Windows.Forms.ListView()
        Me.gbTickets = New System.Windows.Forms.GroupBox()
        Me.lbTickets = New System.Windows.Forms.Label()
        Me.btTickets = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lbPrinterDefault = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.gbTickets.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvPrintTickets
        '
        Me.lvPrintTickets.Location = New System.Drawing.Point(7, 31)
        Me.lvPrintTickets.Name = "lvPrintTickets"
        Me.lvPrintTickets.Size = New System.Drawing.Size(463, 145)
        Me.lvPrintTickets.TabIndex = 0
        Me.lvPrintTickets.UseCompatibleStateImageBehavior = False
        Me.lvPrintTickets.View = System.Windows.Forms.View.Details
        '
        'gbTickets
        '
        Me.gbTickets.Controls.Add(Me.lbTickets)
        Me.gbTickets.Controls.Add(Me.btTickets)
        Me.gbTickets.Controls.Add(Me.lvPrintTickets)
        Me.gbTickets.Location = New System.Drawing.Point(12, 59)
        Me.gbTickets.Name = "gbTickets"
        Me.gbTickets.Size = New System.Drawing.Size(475, 260)
        Me.gbTickets.TabIndex = 1
        Me.gbTickets.TabStop = False
        Me.gbTickets.Text = "Selecciona impresora Etiquetas"
        '
        'lbTickets
        '
        Me.lbTickets.AutoSize = True
        Me.lbTickets.BackColor = System.Drawing.SystemColors.Control
        Me.lbTickets.Location = New System.Drawing.Point(245, 189)
        Me.lbTickets.Name = "lbTickets"
        Me.lbTickets.Size = New System.Drawing.Size(42, 13)
        Me.lbTickets.TabIndex = 2
        Me.lbTickets.Text = "Tickets"
        '
        'btTickets
        '
        Me.btTickets.Location = New System.Drawing.Point(9, 184)
        Me.btTickets.Name = "btTickets"
        Me.btTickets.Size = New System.Drawing.Size(201, 23)
        Me.btTickets.TabIndex = 1
        Me.btTickets.Text = "Seleccionar impresora"
        Me.btTickets.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lbPrinterDefault)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(475, 41)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Impresora por defecto en el sistema"
        '
        'lbPrinterDefault
        '
        Me.lbPrinterDefault.AutoSize = True
        Me.lbPrinterDefault.BackColor = System.Drawing.Color.DarkGray
        Me.lbPrinterDefault.Location = New System.Drawing.Point(6, 16)
        Me.lbPrinterDefault.Name = "lbPrinterDefault"
        Me.lbPrinterDefault.Size = New System.Drawing.Size(71, 13)
        Me.lbPrinterDefault.TabIndex = 3
        Me.lbPrinterDefault.Text = "DefaultPrinter"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(412, 325)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "Ok"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'frmPrinter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(491, 365)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gbTickets)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPrinter"
        Me.ShowInTaskbar = False
        Me.Text = "Seleción de impresora"
        Me.gbTickets.ResumeLayout(False)
        Me.gbTickets.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lvPrintTickets As System.Windows.Forms.ListView
    Friend WithEvents gbTickets As System.Windows.Forms.GroupBox
    Friend WithEvents lbTickets As System.Windows.Forms.Label
    Friend WithEvents btTickets As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lbPrinterDefault As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
End Class
