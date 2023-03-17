<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTra2
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
        Me.TSelTra1 = New System.Windows.Forms.TextBox()
        Me.lvTraslados = New System.Windows.Forms.ListView()
        Me.CCheck = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CTraslado = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CFecha = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CAlmD = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CCliente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CDescripcion = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'BBuscar
        '
        Me.BBuscar.Location = New System.Drawing.Point(325, 8)
        Me.BBuscar.Name = "BBuscar"
        Me.BBuscar.Size = New System.Drawing.Size(61, 21)
        Me.BBuscar.TabIndex = 41
        Me.BBuscar.Text = "Buscar"
        Me.BBuscar.UseVisualStyleBackColor = True
        '
        'cmbTipo2
        '
        Me.cmbTipo2.FormattingEnabled = True
        Me.cmbTipo2.Location = New System.Drawing.Point(12, 8)
        Me.cmbTipo2.Name = "cmbTipo2"
        Me.cmbTipo2.Size = New System.Drawing.Size(98, 21)
        Me.cmbTipo2.TabIndex = 40
        '
        'TbBusca
        '
        Me.TbBusca.Location = New System.Drawing.Point(116, 10)
        Me.TbBusca.Name = "TbBusca"
        Me.TbBusca.Size = New System.Drawing.Size(186, 20)
        Me.TbBusca.TabIndex = 38
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(471, 311)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(120, 26)
        Me.btnCancelar.TabIndex = 37
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'TSelTra1
        '
        Me.TSelTra1.Location = New System.Drawing.Point(487, 8)
        Me.TSelTra1.Name = "TSelTra1"
        Me.TSelTra1.Size = New System.Drawing.Size(100, 20)
        Me.TSelTra1.TabIndex = 39
        '
        'lvTraslados
        '
        Me.lvTraslados.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.CCheck, Me.CTraslado, Me.CFecha, Me.CAlmD, Me.CCliente, Me.CDescripcion})
        Me.lvTraslados.FullRowSelect = True
        Me.lvTraslados.GridLines = True
        Me.lvTraslados.HideSelection = False
        Me.lvTraslados.Location = New System.Drawing.Point(12, 36)
        Me.lvTraslados.MultiSelect = False
        Me.lvTraslados.Name = "lvTraslados"
        Me.lvTraslados.Size = New System.Drawing.Size(579, 260)
        Me.lvTraslados.TabIndex = 35
        Me.lvTraslados.UseCompatibleStateImageBehavior = False
        Me.lvTraslados.View = System.Windows.Forms.View.Details
        '
        'CCheck
        '
        Me.CCheck.Width = 1
        '
        'CTraslado
        '
        Me.CTraslado.Text = "Traslado"
        '
        'CFecha
        '
        Me.CFecha.Text = "Fecha"
        Me.CFecha.Width = 70
        '
        'CAlmD
        '
        Me.CAlmD.Text = "Alm.Desde"
        '
        'CCliente
        '
        Me.CCliente.Text = "Cliente"
        '
        'CDescripcion
        '
        Me.CDescripcion.Text = "Descripcion"
        Me.CDescripcion.Width = 295
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(325, 311)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(120, 26)
        Me.btnAceptar.TabIndex = 36
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'frmTra2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(598, 347)
        Me.Controls.Add(Me.BBuscar)
        Me.Controls.Add(Me.cmbTipo2)
        Me.Controls.Add(Me.TbBusca)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.TSelTra1)
        Me.Controls.Add(Me.lvTraslados)
        Me.Controls.Add(Me.btnAceptar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmTra2"
        Me.ShowInTaskbar = False
        Me.Text = "Traslados Hasta"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BBuscar As System.Windows.Forms.Button
    Friend WithEvents cmbTipo2 As System.Windows.Forms.ComboBox
    Friend WithEvents TbBusca As System.Windows.Forms.TextBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents TSelTra1 As System.Windows.Forms.TextBox
    Friend WithEvents lvTraslados As System.Windows.Forms.ListView
    Friend WithEvents CCheck As System.Windows.Forms.ColumnHeader
    Friend WithEvents CTraslado As System.Windows.Forms.ColumnHeader
    Friend WithEvents CFecha As System.Windows.Forms.ColumnHeader
    Friend WithEvents CAlmD As System.Windows.Forms.ColumnHeader
    Friend WithEvents CCliente As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents CDescripcion As System.Windows.Forms.ColumnHeader
End Class
