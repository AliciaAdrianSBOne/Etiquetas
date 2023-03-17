<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImpEtiquetas
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
        Me.dgEtiquetas = New System.Windows.Forms.DataGrid()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnimprimir = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbCopias = New System.Windows.Forms.TextBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.cbTarifa1 = New System.Windows.Forms.ComboBox()
        Me.cbTarifa2 = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.dgEtiquetas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgEtiquetas
        '
        Me.dgEtiquetas.CaptionVisible = False
        Me.dgEtiquetas.DataMember = ""
        Me.dgEtiquetas.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgEtiquetas.Location = New System.Drawing.Point(12, 42)
        Me.dgEtiquetas.Name = "dgEtiquetas"
        Me.dgEtiquetas.Size = New System.Drawing.Size(745, 392)
        Me.dgEtiquetas.TabIndex = 0
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(637, 449)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(120, 26)
        Me.btnCancelar.TabIndex = 11
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnimprimir
        '
        Me.btnimprimir.Location = New System.Drawing.Point(491, 449)
        Me.btnimprimir.Name = "btnimprimir"
        Me.btnimprimir.Size = New System.Drawing.Size(120, 26)
        Me.btnimprimir.TabIndex = 10
        Me.btnimprimir.Text = "Imprimir"
        Me.btnimprimir.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(657, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Nº Copias"
        '
        'tbCopias
        '
        Me.tbCopias.Location = New System.Drawing.Point(717, 12)
        Me.tbCopias.Name = "tbCopias"
        Me.tbCopias.Size = New System.Drawing.Size(40, 20)
        Me.tbCopias.TabIndex = 12
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(504, 14)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(148, 17)
        Me.CheckBox1.TabIndex = 14
        Me.CheckBox1.Text = "Marcar/Desmarcar Todos"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'cbTarifa1
        '
        Me.cbTarifa1.FormattingEnabled = True
        Me.cbTarifa1.Location = New System.Drawing.Point(12, 453)
        Me.cbTarifa1.Name = "cbTarifa1"
        Me.cbTarifa1.Size = New System.Drawing.Size(117, 21)
        Me.cbTarifa1.TabIndex = 15
        Me.cbTarifa1.Visible = False
        '
        'cbTarifa2
        '
        Me.cbTarifa2.FormattingEnabled = True
        Me.cbTarifa2.Location = New System.Drawing.Point(135, 453)
        Me.cbTarifa2.Name = "cbTarifa2"
        Me.cbTarifa2.Size = New System.Drawing.Size(115, 21)
        Me.cbTarifa2.TabIndex = 16
        Me.cbTarifa2.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 437)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Tarifa IZQ"
        Me.Label2.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(132, 437)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Tarifa DER"
        Me.Label3.Visible = False
        '
        'frmImpEtiquetas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(769, 495)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbTarifa2)
        Me.Controls.Add(Me.cbTarifa1)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbCopias)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnimprimir)
        Me.Controls.Add(Me.dgEtiquetas)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmImpEtiquetas"
        Me.ShowInTaskbar = False
        Me.Text = "Impresión de Etiquetas"
        CType(Me.dgEtiquetas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgEtiquetas As System.Windows.Forms.DataGrid
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnimprimir As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbCopias As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents cbTarifa1 As System.Windows.Forms.ComboBox
    Friend WithEvents cbTarifa2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
