<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmValidacion
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvDatos = New System.Windows.Forms.DataGridView()
        Me.cCheck = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cFecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cItemCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cWhsCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cOnHand = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDif = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cUsuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.chkMuestra = New System.Windows.Forms.CheckBox()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnExportar = New System.Windows.Forms.Button()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvDatos
        '
        Me.dgvDatos.AllowUserToAddRows = False
        Me.dgvDatos.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray
        Me.dgvDatos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDatos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDatos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cCheck, Me.cFecha, Me.cItemCode, Me.cItemName, Me.cWhsCode, Me.cOnHand, Me.cCount, Me.cDif, Me.cUsuario})
        Me.dgvDatos.Location = New System.Drawing.Point(12, 12)
        Me.dgvDatos.Name = "dgvDatos"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDatos.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvDatos.RowHeadersWidth = 51
        Me.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDatos.Size = New System.Drawing.Size(1116, 495)
        Me.dgvDatos.TabIndex = 1
        '
        'cCheck
        '
        Me.cCheck.Frozen = True
        Me.cCheck.HeaderText = ""
        Me.cCheck.Name = "cCheck"
        Me.cCheck.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.cCheck.Width = 25
        '
        'cFecha
        '
        Me.cFecha.Frozen = True
        Me.cFecha.HeaderText = "Fecha"
        Me.cFecha.Name = "cFecha"
        Me.cFecha.ReadOnly = True
        '
        'cItemCode
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.cItemCode.DefaultCellStyle = DataGridViewCellStyle3
        Me.cItemCode.Frozen = True
        Me.cItemCode.HeaderText = "Cod. Articulo"
        Me.cItemCode.Name = "cItemCode"
        Me.cItemCode.ReadOnly = True
        Me.cItemCode.Width = 150
        '
        'cItemName
        '
        Me.cItemName.Frozen = True
        Me.cItemName.HeaderText = "Descripción"
        Me.cItemName.Name = "cItemName"
        Me.cItemName.ReadOnly = True
        Me.cItemName.Width = 300
        '
        'cWhsCode
        '
        Me.cWhsCode.Frozen = True
        Me.cWhsCode.HeaderText = "Almacén"
        Me.cWhsCode.Name = "cWhsCode"
        Me.cWhsCode.ReadOnly = True
        Me.cWhsCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.cWhsCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'cOnHand
        '
        Me.cOnHand.Frozen = True
        Me.cOnHand.HeaderText = "Stock SAP"
        Me.cOnHand.Name = "cOnHand"
        Me.cOnHand.ReadOnly = True
        '
        'cCount
        '
        Me.cCount.Frozen = True
        Me.cCount.HeaderText = "Contado"
        Me.cCount.Name = "cCount"
        Me.cCount.ReadOnly = True
        Me.cCount.Width = 80
        '
        'cDif
        '
        Me.cDif.Frozen = True
        Me.cDif.HeaderText = "Diferencia"
        Me.cDif.Name = "cDif"
        Me.cDif.ReadOnly = True
        Me.cDif.Width = 80
        '
        'cUsuario
        '
        Me.cUsuario.Frozen = True
        Me.cUsuario.HeaderText = "Usuario"
        Me.cUsuario.Name = "cUsuario"
        Me.cUsuario.ReadOnly = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(1053, 526)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 5
        Me.btnCancelar.Text = "Cerrar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'chkMuestra
        '
        Me.chkMuestra.AutoSize = True
        Me.chkMuestra.Location = New System.Drawing.Point(305, 526)
        Me.chkMuestra.Name = "chkMuestra"
        Me.chkMuestra.Size = New System.Drawing.Size(81, 17)
        Me.chkMuestra.TabIndex = 6
        Me.chkMuestra.Text = "CheckBox1"
        Me.chkMuestra.UseVisualStyleBackColor = True
        Me.chkMuestra.Visible = False
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(972, 526)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(75, 23)
        Me.btnEliminar.TabIndex = 7
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnExportar
        '
        Me.btnExportar.Location = New System.Drawing.Point(12, 526)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(104, 23)
        Me.btnExportar.TabIndex = 8
        Me.btnExportar.Text = "Exportar"
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'frmValidacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1141, 561)
        Me.Controls.Add(Me.btnExportar)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.chkMuestra)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.dgvDatos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmValidacion"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Validación de inventario diferencial"
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvDatos As System.Windows.Forms.DataGridView
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents chkMuestra As System.Windows.Forms.CheckBox
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents cCheck As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents cFecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cItemCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cWhsCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cOnHand As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cCount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDif As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cUsuario As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
