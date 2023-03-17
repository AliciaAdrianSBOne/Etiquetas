<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAlbB1
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
        Me.TSelAlb1 = New System.Windows.Forms.TextBox()
        Me.lvAlbaranes = New System.Windows.Forms.ListView()
        Me.CCheck = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CBorrador = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
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
        Me.BBuscar.Location = New System.Drawing.Point(325, 10)
        Me.BBuscar.Name = "BBuscar"
        Me.BBuscar.Size = New System.Drawing.Size(61, 21)
        Me.BBuscar.TabIndex = 27
        Me.BBuscar.Text = "Buscar"
        Me.BBuscar.UseVisualStyleBackColor = True
        '
        'cmbTipo2
        '
        Me.cmbTipo2.FormattingEnabled = True
        Me.cmbTipo2.Location = New System.Drawing.Point(12, 10)
        Me.cmbTipo2.Name = "cmbTipo2"
        Me.cmbTipo2.Size = New System.Drawing.Size(98, 21)
        Me.cmbTipo2.TabIndex = 26
        '
        'TbBusca
        '
        Me.TbBusca.Location = New System.Drawing.Point(116, 12)
        Me.TbBusca.Name = "TbBusca"
        Me.TbBusca.Size = New System.Drawing.Size(186, 20)
        Me.TbBusca.TabIndex = 24
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(471, 313)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(120, 26)
        Me.btnCancelar.TabIndex = 23
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'TSelAlb1
        '
        Me.TSelAlb1.Location = New System.Drawing.Point(487, 10)
        Me.TSelAlb1.Name = "TSelAlb1"
        Me.TSelAlb1.Size = New System.Drawing.Size(100, 20)
        Me.TSelAlb1.TabIndex = 25
        '
        'lvAlbaranes
        '
        Me.lvAlbaranes.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.CCheck, Me.CBorrador, Me.CAlbaran, Me.CFecha, Me.CProveedor, Me.CDescripcion, Me.CTotal})
        Me.lvAlbaranes.FullRowSelect = True
        Me.lvAlbaranes.GridLines = True
        Me.lvAlbaranes.HideSelection = False
        Me.lvAlbaranes.Location = New System.Drawing.Point(12, 38)
        Me.lvAlbaranes.MultiSelect = False
        Me.lvAlbaranes.Name = "lvAlbaranes"
        Me.lvAlbaranes.Size = New System.Drawing.Size(579, 260)
        Me.lvAlbaranes.TabIndex = 21
        Me.lvAlbaranes.UseCompatibleStateImageBehavior = False
        Me.lvAlbaranes.View = System.Windows.Forms.View.Details
        '
        'CCheck
        '
        Me.CCheck.Width = 1
        '
        'CBorrador
        '
        Me.CBorrador.Text = "N. Borr."
        Me.CBorrador.Width = 52
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
        Me.CDescripcion.Width = 248
        '
        'CTotal
        '
        Me.CTotal.Text = "Total"
        Me.CTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(325, 313)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(120, 26)
        Me.btnAceptar.TabIndex = 22
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'frmAlbB1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(602, 347)
        Me.Controls.Add(Me.BBuscar)
        Me.Controls.Add(Me.cmbTipo2)
        Me.Controls.Add(Me.TbBusca)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.TSelAlb1)
        Me.Controls.Add(Me.lvAlbaranes)
        Me.Controls.Add(Me.btnAceptar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAlbB1"
        Me.ShowInTaskbar = False
        Me.Text = "Albarán BORRADOR de Compra Desde"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BBuscar As System.Windows.Forms.Button
    Friend WithEvents cmbTipo2 As System.Windows.Forms.ComboBox
    Friend WithEvents TbBusca As System.Windows.Forms.TextBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents TSelAlb1 As System.Windows.Forms.TextBox
    Friend WithEvents lvAlbaranes As System.Windows.Forms.ListView
    Friend WithEvents CCheck As System.Windows.Forms.ColumnHeader
    Friend WithEvents CAlbaran As System.Windows.Forms.ColumnHeader
    Friend WithEvents CProveedor As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents CFecha As System.Windows.Forms.ColumnHeader
    Friend WithEvents CDescripcion As System.Windows.Forms.ColumnHeader
    Friend WithEvents CTotal As System.Windows.Forms.ColumnHeader
    Friend WithEvents CBorrador As System.Windows.Forms.ColumnHeader
End Class
