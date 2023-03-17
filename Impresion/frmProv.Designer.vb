<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProv
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
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.lvProveedores = New System.Windows.Forms.ListView()
        Me.CCheck = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CProveedor = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CDescripcion = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TbBusca = New System.Windows.Forms.TextBox()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.TSelProv = New System.Windows.Forms.TextBox()
        Me.BBuscar2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(471, 318)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(120, 26)
        Me.btnCancelar.TabIndex = 7
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(325, 318)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(120, 26)
        Me.btnAceptar.TabIndex = 6
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'lvProveedores
        '
        Me.lvProveedores.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.CCheck, Me.CProveedor, Me.CDescripcion})
        Me.lvProveedores.FullRowSelect = True
        Me.lvProveedores.GridLines = True
        Me.lvProveedores.HideSelection = False
        Me.lvProveedores.Location = New System.Drawing.Point(12, 43)
        Me.lvProveedores.MultiSelect = False
        Me.lvProveedores.Name = "lvProveedores"
        Me.lvProveedores.Size = New System.Drawing.Size(579, 260)
        Me.lvProveedores.TabIndex = 0
        Me.lvProveedores.UseCompatibleStateImageBehavior = False
        Me.lvProveedores.View = System.Windows.Forms.View.Details
        '
        'CCheck
        '
        Me.CCheck.Width = 1
        '
        'CProveedor
        '
        Me.CProveedor.Text = "Proveedor"
        '
        'CDescripcion
        '
        Me.CDescripcion.Text = "Descripcion"
        Me.CDescripcion.Width = 305
        '
        'TbBusca
        '
        Me.TbBusca.Location = New System.Drawing.Point(115, 12)
        Me.TbBusca.Name = "TbBusca"
        Me.TbBusca.Size = New System.Drawing.Size(177, 20)
        Me.TbBusca.TabIndex = 10
        '
        'cmbTipo
        '
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.Location = New System.Drawing.Point(12, 11)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(97, 21)
        Me.cmbTipo.TabIndex = 11
        '
        'TSelProv
        '
        Me.TSelProv.Location = New System.Drawing.Point(400, 12)
        Me.TSelProv.Name = "TSelProv"
        Me.TSelProv.Size = New System.Drawing.Size(100, 20)
        Me.TSelProv.TabIndex = 12
        '
        'BBuscar2
        '
        Me.BBuscar2.Location = New System.Drawing.Point(308, 13)
        Me.BBuscar2.Name = "BBuscar2"
        Me.BBuscar2.Size = New System.Drawing.Size(65, 19)
        Me.BBuscar2.TabIndex = 13
        Me.BBuscar2.Text = "Buscar"
        Me.BBuscar2.UseVisualStyleBackColor = True
        '
        'frmProv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(604, 356)
        Me.Controls.Add(Me.BBuscar2)
        Me.Controls.Add(Me.TSelProv)
        Me.Controls.Add(Me.cmbTipo)
        Me.Controls.Add(Me.TbBusca)
        Me.Controls.Add(Me.lvProveedores)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmProv"
        Me.ShowInTaskbar = False
        Me.Text = "Proveedor"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents lvProveedores As System.Windows.Forms.ListView
    Friend WithEvents CCheck As System.Windows.Forms.ColumnHeader
    Friend WithEvents CProveedor As System.Windows.Forms.ColumnHeader
    Friend WithEvents CDescripcion As System.Windows.Forms.ColumnHeader
    Friend WithEvents TbBusca As System.Windows.Forms.TextBox
    Friend WithEvents cmbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents TSelProv As System.Windows.Forms.TextBox
    Friend WithEvents BBuscar2 As System.Windows.Forms.Button
End Class
