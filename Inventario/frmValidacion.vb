Public Class frmValidacion

#Region "Declaraciones privadas"
    Private mCnx As SqlClient.SqlConnection
#End Region

    Private Sub frmValidacion_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If Not mCnx Is Nothing Then
            mCnx.Close()
        End If
        mCnx = Nothing
    End Sub

    Private Sub frmValidacion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            mCnx = New SqlClient.SqlConnection
            With mCnx
                .ConnectionString = "Persist Security Info=False;" & _
                                    "Data Source = " & Principal.Servidor & "; " & _
                                    "Initial Catalog = " & Principal.empresa1 & "; " & _
                                    "User ID = " & Principal.SQLUser & "; " & _
                                    "Password = " & Principal.SQLPwd & "; "
                .Open()
            End With

            'carga los articulos
            CargarDatos()

        Catch ex As Exception
            MessageBox.Show("frmInventario_Load: " & ex.Message)
        End Try
    End Sub

    Private Sub CargarDatos()
        Dim lCmd As New SqlClient.SqlCommand
        Dim lDR As SqlClient.SqlDataReader = Nothing
        Dim i As Integer

        Try
            With lCmd
                .Connection = mCnx
                .CommandText = "EXEC OPN_SP_INVENTARIO_DIFERENCIAL_LISTAR "
                lDR = .ExecuteReader
            End With

            'vacia la matriz
            dgvDatos.Rows.Clear() 'vacia las líneas
            i = 0

            While lDR.Read
                With Me.dgvDatos
                    .Rows.Add()
                    .Rows.Item(i).HeaderCell.Value = (i + 1).ToString

                    'Cod. Articulo
                    .CurrentCell = .Rows.Item(i).Cells("cItemCode")
                    .CurrentCell.Value = lDR.Item("Cod. Articulo")

                    'Descripcion
                    .CurrentCell = .Rows.Item(i).Cells("cItemName")
                    .CurrentCell.Value = lDR.Item("Descripcion")

                    'Almacen
                    .CurrentCell = .Rows.Item(i).Cells("cWhsCode")
                    .CurrentCell.Value = lDR.Item("Almacen")

                    'Stock SAP
                    .CurrentCell = .Rows.Item(i).Cells("cOnHand")
                    If Not lDR.Item("Stock SAP") Is System.DBNull.Value Then
                        .CurrentCell.Value = CDbl(lDR.Item("Stock SAP")).ToString("#,0")
                    Else
                        .CurrentCell.Value = lDR.Item("Stock SAP")
                    End If

                    'Contado
                    .CurrentCell = .Rows.Item(i).Cells("cCount")
                    If Not lDR.Item("Contado") Is System.DBNull.Value Then
                        .CurrentCell.Value = CDbl(lDR.Item("Contado")).ToString("#,0")
                    Else
                        .CurrentCell.Value = lDR.Item("Contado")
                    End If

                    'Diferencia
                    .CurrentCell = .Rows.Item(i).Cells("cDif")
                    If Not lDR.Item("Diferencia") Is System.DBNull.Value Then
                        .CurrentCell.Value = CDbl(lDR.Item("Diferencia")).ToString("#,0")
                    Else
                        .CurrentCell.Value = lDR.Item("Diferencia")
                    End If

                    'usuario
                    .CurrentCell = .Rows.Item(i).Cells("cUsuario")
                    .CurrentCell.Value = lDR.Item("Usuario")

                    'fecha
                    .CurrentCell = .Rows.Item(i).Cells("cFecha")
                    .CurrentCell.Value = lDR.Item("Fecha")
                End With
                i = i + 1
            End While

            If i > 0 Then dgvDatos.CurrentCell = dgvDatos.Rows(0).Cells("cItemCode")

            'solo la columna contado y el almacen son editables
            dgvDatos.Columns("cItemCode").ReadOnly = True
            dgvDatos.Columns("cItemName").ReadOnly = True
            dgvDatos.Columns("cOnHand").ReadOnly = True
            dgvDatos.Columns("cDif").ReadOnly = True
            dgvDatos.Columns("cCount").ReadOnly = True

        Catch ex As Exception
            MessageBox.Show("frmInventario.CargarArticulos: " & ex.Message)
        Finally
            If Not lDR Is Nothing Then
                If Not lDR.IsClosed Then
                    lDR.Close()
                End If
                lDR = Nothing
            End If
            lCmd = Nothing
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub dgvDatos_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDatos.CellDoubleClick
        Dim i As Integer

        Try
            If e.ColumnIndex = -1 Then Exit Try

            Dim column As DataGridViewColumn = dgvDatos.Columns(e.ColumnIndex)

            If column.Name = "cCheck" And e.RowIndex = -1 Then
                chkMuestra.Checked = Not chkMuestra.Checked

                For i = 0 To dgvDatos.RowCount - 1
                    dgvDatos.Rows(i).Cells("cCheck").Value = chkMuestra.Checked
                Next
            End If
        Catch ex As Exception
            MessageBox.Show("frmValidacion.dgvDatos_ColumnDividerDoubleClick: " & ex.Message)
        End Try
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Dim i As Integer
        Dim lItemCode As String
        Dim lWhsCode As String
        Dim lCmd As New SqlClient.SqlCommand

        Try
            If MessageBox.Show("¿Está seguro que desea eliminar las líneas seleccionadas?", "Validación inventario", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                With dgvDatos
                    For i = 0 To .Rows.Count - 1
                        If dgvDatos.Rows(i).Cells("cCheck").Value = True Then
                            lItemCode = dgvDatos.Rows(i).Cells("cItemCode").Value
                            lWhsCode = dgvDatos.Rows(i).Cells("cWhsCode").Value

                            lCmd.Connection = mCnx
                            lCmd.CommandText = "EXEC OPN_SP_INVENTARIO_DIFERENCIAL_BORRAR '" & lItemCode & "', '" & lWhsCode & "'"
                            lCmd.ExecuteNonQuery()
                        End If
                    Next
                End With

                MessageBox.Show("Líneas eliminadas con éxito", "Validación inventario")

                'recarga los datos
                CargarDatos()
            End If


        Catch ex As Exception
            MessageBox.Show("frmValidacion.btnEliminar_Click: " & ex.Message)
        Finally
            lCmd = Nothing
        End Try
    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        Dim lFile As System.IO.FileStream = Nothing


        Try
            'comprobamos si existe la "plantilla"
            If Not System.IO.File.Exists(Application.StartupPath & "\Inventario Diferencial.csv") Then
                lFile = System.IO.File.Create(Application.StartupPath & "\Inventario Diferencial.csv")
                lFile.Close()
            End If

            Shell(Application.StartupPath & "\Exportar.bat")

            Dim proceso As New System.Diagnostics.Process

            With proceso
                .StartInfo.FileName = Application.StartupPath & "\Inventario Diferencial.csv"
                .Start()
            End With

        Catch ex As Exception
            MessageBox.Show("frmValidacion.btnExportar_Click: " & ex.Message)
        Finally
            If Not lFile Is Nothing Then
                lFile.Close()
            End If
        End Try
    End Sub
End Class