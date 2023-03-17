<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLot1
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
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.CDVD = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TbBusca = New System.Windows.Forms.TextBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.CLote = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CCheck = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TSelArt1 = New System.Windows.Forms.TextBox()
        Me.lvArticulos = New System.Windows.Forms.ListView()
        Me.CItemCode = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CItemName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.cmbTipo2 = New System.Windows.Forms.ComboBox()
        Me.BBuscar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmbTipo
        '
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.Location = New System.Drawing.Point(-147, -35)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(97, 21)
        Me.cmbTipo.TabIndex = 17
        '
        'CDVD
        '
        Me.CDVD.Text = "DVD"
        Me.CDVD.Width = 168
        '
        'TbBusca
        '
        Me.TbBusca.Location = New System.Drawing.Point(116, 11)
        Me.TbBusca.Name = "TbBusca"
        Me.TbBusca.Size = New System.Drawing.Size(186, 20)
        Me.TbBusca.TabIndex = 16
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(471, 303)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(120, 26)
        Me.btnCancelar.TabIndex = 15
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'CLote
        '
        Me.CLote.Text = "Lote"
        Me.CLote.Width = 101
        '
        'CCheck
        '
        Me.CCheck.Width = 1
        '
        'TSelArt1
        '
        Me.TSelArt1.Location = New System.Drawing.Point(487, 9)
        Me.TSelArt1.Name = "TSelArt1"
        Me.TSelArt1.Size = New System.Drawing.Size(100, 20)
        Me.TSelArt1.TabIndex = 18
        '
        'lvArticulos
        '
        Me.lvArticulos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.CCheck, Me.CLote, Me.CDVD, Me.CItemCode, Me.CItemName})
        Me.lvArticulos.FullRowSelect = True
        Me.lvArticulos.GridLines = True
        Me.lvArticulos.HideSelection = False
        Me.lvArticulos.Location = New System.Drawing.Point(12, 37)
        Me.lvArticulos.MultiSelect = False
        Me.lvArticulos.Name = "lvArticulos"
        Me.lvArticulos.Size = New System.Drawing.Size(579, 260)
        Me.lvArticulos.TabIndex = 13
        Me.lvArticulos.UseCompatibleStateImageBehavior = False
        Me.lvArticulos.View = System.Windows.Forms.View.Details
        '
        'CItemCode
        '
        Me.CItemCode.Text = "Cod. Articulo"
        Me.CItemCode.Width = 82
        '
        'CItemName
        '
        Me.CItemName.Text = "Nom. Articulo"
        Me.CItemName.Width = 197
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(325, 303)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(120, 26)
        Me.btnAceptar.TabIndex = 14
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'cmbTipo2
        '
        Me.cmbTipo2.FormattingEnabled = True
        Me.cmbTipo2.Location = New System.Drawing.Point(12, 9)
        Me.cmbTipo2.Name = "cmbTipo2"
        Me.cmbTipo2.Size = New System.Drawing.Size(98, 21)
        Me.cmbTipo2.TabIndex = 19
        '
        'BBuscar
        '
        Me.BBuscar.Location = New System.Drawing.Point(325, 9)
        Me.BBuscar.Name = "BBuscar"
        Me.BBuscar.Size = New System.Drawing.Size(61, 21)
        Me.BBuscar.TabIndex = 20
        Me.BBuscar.Text = "Buscar"
        Me.BBuscar.UseVisualStyleBackColor = True
        '
        'frmLot1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(599, 335)
        Me.Controls.Add(Me.BBuscar)
        Me.Controls.Add(Me.cmbTipo2)
        Me.Controls.Add(Me.cmbTipo)
        Me.Controls.Add(Me.TbBusca)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.TSelArt1)
        Me.Controls.Add(Me.lvArticulos)
        Me.Controls.Add(Me.btnAceptar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLot1"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Lote Desde"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents CDVD As System.Windows.Forms.ColumnHeader
    Friend WithEvents TbBusca As System.Windows.Forms.TextBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents CLote As System.Windows.Forms.ColumnHeader
    Friend WithEvents CCheck As System.Windows.Forms.ColumnHeader
    Friend WithEvents TSelArt1 As System.Windows.Forms.TextBox
    Friend WithEvents lvArticulos As System.Windows.Forms.ListView
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents cmbTipo2 As System.Windows.Forms.ComboBox
    Friend WithEvents BBuscar As System.Windows.Forms.Button
    Friend WithEvents CItemCode As System.Windows.Forms.ColumnHeader
    Friend WithEvents CItemName As System.Windows.Forms.ColumnHeader
End Class
