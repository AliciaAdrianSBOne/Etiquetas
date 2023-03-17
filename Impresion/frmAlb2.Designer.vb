<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAlb2
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
        Me.BBuscar = New System.Windows.Forms.Button()
        Me.cmbTipo2 = New System.Windows.Forms.ComboBox()
        Me.TbBusca = New System.Windows.Forms.TextBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.TSelAlb2 = New System.Windows.Forms.TextBox()
        Me.lvAlbaranes = New System.Windows.Forms.ListView()
        Me.CCheck = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CAlbaran = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CFecha = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CProveedor = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CDescripcion = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CTotal = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'BBuscar
        '
        Me.BBuscar.Location = New System.Drawing.Point(325, 12)
        Me.BBuscar.Name = "BBuscar"
        Me.BBuscar.Size = New System.Drawing.Size(61, 21)
        Me.BBuscar.TabIndex = 34
        Me.BBuscar.Text = "Buscar"
        Me.BBuscar.UseVisualStyleBackColor = True
        '
        'cmbTipo2
        '
        Me.cmbTipo2.FormattingEnabled = True
        Me.cmbTipo2.Location = New System.Drawing.Point(12, 12)
        Me.cmbTipo2.Name = "cmbTipo2"
        Me.cmbTipo2.Size = New System.Drawing.Size(98, 21)
        Me.cmbTipo2.TabIndex = 33
        '
        'TbBusca
        '
        Me.TbBusca.Location = New System.Drawing.Point(116, 14)
        Me.TbBusca.Name = "TbBusca"
        Me.TbBusca.Size = New System.Drawing.Size(186, 20)
        Me.TbBusca.TabIndex = 31
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(471, 315)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(120, 26)
        Me.btnCancelar.TabIndex = 30
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'TSelAlb2
        '
        Me.TSelAlb2.Location = New System.Drawing.Point(487, 12)
        Me.TSelAlb2.Name = "TSelAlb2"
        Me.TSelAlb2.Size = New System.Drawing.Size(100, 20)
        Me.TSelAlb2.TabIndex = 32
        '
        'lvAlbaranes
        '
        Me.lvAlbaranes.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.CCheck, Me.CAlbaran, Me.CFecha, Me.CProveedor, Me.CDescripcion, Me.CTotal})
        Me.lvAlbaranes.FullRowSelect = True
        Me.lvAlbaranes.GridLines = True
        Me.lvAlbaranes.HideSelection = False
        Me.lvAlbaranes.Location = New System.Drawing.Point(12, 40)
        Me.lvAlbaranes.MultiSelect = False
        Me.lvAlbaranes.Name = "lvAlbaranes"
        Me.lvAlbaranes.Size = New System.Drawing.Size(579, 260)
        Me.lvAlbaranes.TabIndex = 28
        Me.lvAlbaranes.UseCompatibleStateImageBehavior = False
        Me.lvAlbaranes.View = System.Windows.Forms.View.Details
        '
        'CCheck
        '
        Me.CCheck.Width = 1
        '
        'CAlbaran
        '
        Me.CAlbaran.Text = "Albarán"
        '
        'CFecha
        '
        Me.CFecha.Text = "Fecha"
        Me.CFecha.Width = 70
        '
        'CProveedor
        '
        Me.CProveedor.Text = "Proveedor"
        Me.CProveedor.Width = 65
        '
        'CDescripcion
        '
        Me.CDescripcion.Text = "Descripcion"
        Me.CDescripcion.Width = 295
        '
        'CTotal
        '
        Me.CTotal.Text = "Total"
        Me.CTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(325, 315)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(120, 26)
        Me.btnAceptar.TabIndex = 29
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'frmAlb2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(601, 349)
        Me.Controls.Add(Me.BBuscar)
        Me.Controls.Add(Me.cmbTipo2)
        Me.Controls.Add(Me.TbBusca)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.TSelAlb2)
        Me.Controls.Add(Me.lvAlbaranes)
        Me.Controls.Add(Me.btnAceptar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAlb2"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Albarán de Compra Hasta"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BBuscar As System.Windows.Forms.Button
    Friend WithEvents cmbTipo2 As System.Windows.Forms.ComboBox
    Friend WithEvents TbBusca As System.Windows.Forms.TextBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents TSelAlb2 As System.Windows.Forms.TextBox
    Friend WithEvents lvAlbaranes As System.Windows.Forms.ListView
    Friend WithEvents CCheck As System.Windows.Forms.ColumnHeader
    Friend WithEvents CAlbaran As System.Windows.Forms.ColumnHeader
    Friend WithEvents CFecha As System.Windows.Forms.ColumnHeader
    Friend WithEvents CProveedor As System.Windows.Forms.ColumnHeader
    Friend WithEvents CDescripcion As System.Windows.Forms.ColumnHeader
    Friend WithEvents CTotal As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
End Class
