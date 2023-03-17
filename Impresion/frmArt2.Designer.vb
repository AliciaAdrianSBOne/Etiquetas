<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmArt2
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
        Me.cmbTipo3 = New System.Windows.Forms.ComboBox()
        Me.TbBusca = New System.Windows.Forms.TextBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.TSelArt2 = New System.Windows.Forms.TextBox()
        Me.lvArticulos = New System.Windows.Forms.ListView()
        Me.CCheck = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CArticulo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CDescripcion = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'BBuscar
        '
        Me.BBuscar.Location = New System.Drawing.Point(323, 9)
        Me.BBuscar.Name = "BBuscar"
        Me.BBuscar.Size = New System.Drawing.Size(61, 21)
        Me.BBuscar.TabIndex = 27
        Me.BBuscar.Text = "Buscar"
        Me.BBuscar.UseVisualStyleBackColor = True
        '
        'cmbTipo3
        '
        Me.cmbTipo3.FormattingEnabled = True
        Me.cmbTipo3.Location = New System.Drawing.Point(10, 9)
        Me.cmbTipo3.Name = "cmbTipo3"
        Me.cmbTipo3.Size = New System.Drawing.Size(98, 21)
        Me.cmbTipo3.TabIndex = 26
        '
        'TbBusca
        '
        Me.TbBusca.Location = New System.Drawing.Point(114, 11)
        Me.TbBusca.Name = "TbBusca"
        Me.TbBusca.Size = New System.Drawing.Size(186, 20)
        Me.TbBusca.TabIndex = 24
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(469, 312)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(120, 26)
        Me.btnCancelar.TabIndex = 23
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'TSelArt2
        '
        Me.TSelArt2.Location = New System.Drawing.Point(485, 9)
        Me.TSelArt2.Name = "TSelArt2"
        Me.TSelArt2.Size = New System.Drawing.Size(100, 20)
        Me.TSelArt2.TabIndex = 25
        '
        'lvArticulos
        '
        Me.lvArticulos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.CCheck, Me.CArticulo, Me.CDescripcion})
        Me.lvArticulos.FullRowSelect = True
        Me.lvArticulos.GridLines = True
        Me.lvArticulos.HideSelection = False
        Me.lvArticulos.Location = New System.Drawing.Point(10, 37)
        Me.lvArticulos.MultiSelect = False
        Me.lvArticulos.Name = "lvArticulos"
        Me.lvArticulos.Size = New System.Drawing.Size(579, 260)
        Me.lvArticulos.TabIndex = 21
        Me.lvArticulos.UseCompatibleStateImageBehavior = False
        Me.lvArticulos.View = System.Windows.Forms.View.Details
        '
        'CCheck
        '
        Me.CCheck.Width = 1
        '
        'CArticulo
        '
        Me.CArticulo.Text = "Artículo"
        '
        'CDescripcion
        '
        Me.CDescripcion.Text = "Descripcion"
        Me.CDescripcion.Width = 305
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(323, 312)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(120, 26)
        Me.btnAceptar.TabIndex = 22
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'frmArt2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(599, 347)
        Me.Controls.Add(Me.BBuscar)
        Me.Controls.Add(Me.cmbTipo3)
        Me.Controls.Add(Me.TbBusca)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.TSelArt2)
        Me.Controls.Add(Me.lvArticulos)
        Me.Controls.Add(Me.btnAceptar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmArt2"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Articulo Hasta"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BBuscar As System.Windows.Forms.Button
    Friend WithEvents cmbTipo3 As System.Windows.Forms.ComboBox
    Friend WithEvents TbBusca As System.Windows.Forms.TextBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents TSelArt2 As System.Windows.Forms.TextBox
    Friend WithEvents lvArticulos As System.Windows.Forms.ListView
    Friend WithEvents CCheck As System.Windows.Forms.ColumnHeader
    Friend WithEvents CArticulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents CDescripcion As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
End Class
