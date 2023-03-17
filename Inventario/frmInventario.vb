Public Class frmInventario

#Region "Declaraciones privadas"
    Private mCnx As SqlClient.SqlConnection
    Private FS_local As frmSeleccion
#End Region

    Public Sub New(ByVal FS As frmSeleccion)

        FS_local = FS

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Function SQL() As String

        Dim lWHERE As String = Space(4)
        Dim lSQL As String = String.Empty

        Try
            Select Case FS_local.TabControl1.SelectedIndex
                Case 0 'VARIOS
                    'ARTICULO DESDE                    
                    If FS_local.TextBox1.Text <> "" Then
                        lWHERE = " T0.ItemCode>= '" + FS_local.TextBox1.Text + "' AND "
                    End If

                    'ARTICULO HASTA                    
                    If FS_local.TextBox2.Text <> "" Then
                        lWHERE = lWHERE & " T0.ItemCode<= '" + FS_local.TextBox2.Text + "' AND "
                    End If

                    'DESCRIPCION                    
                    If FS_local.TextBox3.Text <> "" Then
                        lWHERE = lWHERE & " T0.ItemName LIKE '%" + FS_local.TextBox3.Text + "%' AND "
                    End If

                    'PROVEEDOR                                        
                    If FS_local.TextBox4.Text <> "" Then
                        lWHERE = lWHERE & " T0.CardCode= '" + FS_local.TextBox4.Text + "' AND "
                    End If

                    'monta la cadena sql
                    lSQL = " SELECT T0.Itemcode, T0.Itemname, NULL as WhsCode, NULL as OnHand " & _
                            " FROM OITM T0 " & _
                           IIf(lWHERE.Length > 4, " WHERE " & lWHERE.Substring(0, lWHERE.Length - 4), String.Empty) & _
                            " ORDER BY T0.Itemcode "

                Case 1 'DOCUMENTOS
                    If FS_local.CB1.Checked Then
                        'ALBARAN COMPRA DESDE                        
                        If FS_local.TextBox5.Text <> "" Then
                            lWHERE = lWHERE & " T0.DocNum>= '" + FS_local.TextBox5.Text + "' AND "
                        End If

                        'ALBARAN COMPRA HASTA
                        If FS_local.TextBox6.Text <> "" Then
                            lWHERE = lWHERE & " T0.DocNum<= '" + FS_local.TextBox6.Text + "' AND "
                        End If
                    End If

                    If FS_local.CB2.Checked Then
                        'FECHA ALBARAN COMPRA DESDE                        
                        If FS_local.dtAlbDesde.ToString <> "" Then
                            lWHERE = lWHERE & " T0.DocDate>= '" + FS_local.dtAlbDesde.Value.ToString("yyyyMMdd") + "' AND "
                        End If

                        'FECHA ALBARAN COMPRA HASTA
                        If FS_local.dtAlbHasta.ToString <> "" Then
                            lWHERE = lWHERE & " T0.DocDate<= '" + FS_local.dtAlbHasta.Value.ToString("yyyyMMdd") + "' AND "
                        End If
                    End If

                    If FS_local.CB1.Checked Or FS_local.CB2.Checked Then
                        lSQL = " SELECT T1.Itemcode, T1.Dscription as ItemName, T1.WhsCode, T2.OnHand as OnHand " & _
                               " FROM OPDN T0 INNER JOIN PDN1 T1 ON T0.DocEntry = T1.DocEntry " & _
                               " INNER JOIN OITW T2 ON T1.ItemCode = T2.ItemCode AND T2.WhsCode = T1.WhsCode " & _
                               IIf(lWHERE.Length > 4, " WHERE " & lWHERE.Substring(0, lWHERE.Length - 4), String.Empty) & _
                               " ORDER BY T1.DocEntry,T1.Linenum "
                    End If

                    If FS_local.CB3.Checked Then
                        'TRASLADO DESDE                        
                        If FS_local.TextBox11.Text <> "" Then
                            lWHERE = lWHERE & " T0.DocNum>= '" + FS_local.TextBox11.Text + "' AND "
                        End If

                        'TRASLADO HASTA                        
                        If FS_local.TextBox12.Text <> "" Then
                            lWHERE = lWHERE & " T0.DocNum<= '" + FS_local.TextBox12.Text + "' AND "
                        End If
                    End If

                    If FS_local.CB4.Checked Then
                        'FECHA TRASLADO DESDE                        
                        If FS_local.dtTrasDesde.ToString <> "" Then
                            lWHERE = lWHERE & " T0.DocDate>= '" + FS_local.dtTrasDesde.Value.ToString("yyyyMMdd") + "' AND "
                        End If

                        'FECHA TRASLADO HASTA                        
                        If FS_local.dtTrasHasta.ToString <> "" Then
                            lWHERE = lWHERE & " T0.DocDate<= '" + FS_local.dtTrasHasta.Value.ToString("yyyyMMdd") + "' AND "
                        End If
                    End If

                    If FS_local.CB3.Checked Or FS_local.CB4.Checked Then
                        lSQL = " SELECT T1.Itemcode,T1.Dscription,T1.WhsCode, NULL as OnHand " & _
                               " FROM OWTR T0 INNER JOIN WTR1 T1 ON T0.DocEntry = T1.DocEntry " & _
                               IIf(lWHERE.Length > 4, " WHERE " & lWHERE.Substring(0, lWHERE.Length - 4), String.Empty) & _
                               " ORDER BY T1.DocEntry,T1.Linenum "
                    End If

                Case 2 'CODIGOS

                    Dim dts As DataSet = FS_local.DGCodigos.DataSource
                    Dim t As DataTable = dts.Tables.Item(0)

                    For Each row As DataRow In t.Rows
                        lWHERE = lWHERE & " T0.ItemCode ='" & row.Item("codigo").ToString & "' OR "
                    Next

                    lSQL = " SELECT T0.Itemcode, T0.Itemname, NULL as WhsCode, NULL as OnHand " & _
                            " FROM OITM T0 " & _
                           IIf(lWHERE.Length > 4, " WHERE " & lWHERE.Substring(0, lWHERE.Length - 4), String.Empty) & _
                            " ORDER BY T0.Itemcode "
            End Select

            SQL = lSQL

        Catch ex As Exception
            MessageBox.Show("frmInventario.SQL: " & ex.Message)
            SQL = ""
        End Try

    End Function

    Private Sub CargarArticulos()
        Dim lCmd As New SqlClient.SqlCommand
        Dim lDR As SqlClient.SqlDataReader = Nothing
        Dim i As Integer

        Try
            With lCmd
                .Connection = mCnx
                .CommandText = SQL()
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
                    .CurrentCell.Value = lDR.Item("ItemCode")

                    'Descripcion
                    .CurrentCell = .Rows.Item(i).Cells("cItemName")
                    .CurrentCell.Value = lDR.Item("ItemName")                    

                    'Almacen
                    .CurrentCell = .Rows.Item(i).Cells("cWhsCode")
                    .CurrentCell.Value = lDR.Item("WhsCode")

                    'Stock SAP
                    .CurrentCell = .Rows.Item(i).Cells("cOnHand")
                    If Not lDR.Item("OnHand") Is System.DBNull.Value Then
                        .CurrentCell.Value = CDbl(lDR.Item("OnHand")).ToString("#,0")
                    Else
                        .CurrentCell.Value = lDR.Item("OnHand")
                    End If
                    .EndEdit()

                    'Contado
                    .CurrentCell = .Rows.Item(i).Cells("cCount")
                    .CurrentCell.Value = String.Empty

                    'Diferencia
                    .CurrentCell = .Rows.Item(i).Cells("cDif")
                    .CurrentCell.Value = String.Empty
                End With
                i = i + 1
            End While

            If i > 0 Then dgvDatos.CurrentCell = dgvDatos.Rows(0).Cells("cItemCode")

            'solo la columna contado y el almacen son editables
            dgvDatos.Columns("cItemCode").ReadOnly = True
            dgvDatos.Columns("cItemName").ReadOnly = True
            dgvDatos.Columns("cOnHand").ReadOnly = True
            dgvDatos.Columns("cDif").ReadOnly = True

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

    Private Sub CargarAlmacenes()
        Dim lCmd As New SqlClient.SqlCommand
        Dim lDR As SqlClient.SqlDataReader = Nothing
        Dim lWhsCol As DataGridViewComboBoxColumn

        Try
            lWhsCol = Me.dgvDatos.Columns("cWhsCode")

            With lCmd
                .Connection = mCnx
                .CommandText = "SELECT WhsCode, WhsName FROM OWHS "
                lDR = .ExecuteReader
            End With


            While lDR.Read
                lWhsCol.Items.Add(lDR.Item(0))
            End While

        Catch ex As Exception
            MessageBox.Show("frmInventario.CargarAlmacenes: " & ex.Message)
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


    Private Sub frmInventario_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        If Not mCnx Is Nothing Then
            mCnx.Close()
        End If
        mCnx = Nothing
    End Sub

    Private Sub frmInventario_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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

            'carga los almacenes
            CargarAlmacenes()

            'carga los articulos
            CargarArticulos()

        Catch ex As Exception
            MessageBox.Show("frmInventario_Load: " & ex.Message)
        End Try
    End Sub

    Private Sub dgvDatos_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDatos.CellEndEdit
        Dim lCmd As New SqlClient.SqlCommand
        Dim lDR As SqlClient.SqlDataReader = Nothing
        Dim lItemCode As String
        Dim lWhsCode As String
        Dim lColumn As String = String.Empty

        Try
            lColumn = dgvDatos.Columns(e.ColumnIndex).Name

            Select Case lColumn
                Case "cWhsCode"
                    If Not dgvDatos.Rows(e.RowIndex).Cells("cWhsCode").Value Is Nothing AndAlso Not dgvDatos.Rows(e.RowIndex).Cells("cWhsCode").Value Is System.DBNull.Value AndAlso dgvDatos.Rows(e.RowIndex).Cells("cWhsCode").Value <> String.Empty Then
                        lItemCode = dgvDatos.Rows(e.RowIndex).Cells("cItemCode").Value
                        lWhsCode = dgvDatos.Rows(e.RowIndex).Cells("cWhsCode").Value

                        With lCmd
                            .Connection = mCnx
                            .CommandText = " SELECT OnHand " & _
                                         " FROM OITW " & _
                                         " WHERE ItemCode = '" & lItemCode & "' AND WhsCode ='" & lWhsCode & "'"
                            lDR = .ExecuteReader
                        End With

                        While lDR.Read
                            dgvDatos.Rows(e.RowIndex).Cells("cOnHand").Value = CDbl(lDR.Item(0)).ToString("#,0")
                        End While

                        'tenemos un valor contado
                        If dgvDatos.Rows(e.RowIndex).Cells("cCount").Value <> String.Empty Then
                            dgvDatos.Rows(e.RowIndex).Cells("cDif").Value = CDbl((dgvDatos.Rows(e.RowIndex).Cells("cOnHand").Value - dgvDatos.Rows(e.RowIndex).Cells("cCount").Value)).ToString("#,0")
                        End If
                    End If

                Case "cCount"
                    If dgvDatos.Rows(e.RowIndex).Cells("cCount").Value Is Nothing OrElse dgvDatos.Rows(e.RowIndex).Cells("cCount").Value = String.Empty Then
                        dgvDatos.Rows(e.RowIndex).Cells("cDif").Value = Nothing
                    Else
                        dgvDatos.Rows(e.RowIndex).Cells("cCount").Value = CDbl(dgvDatos.Rows(e.RowIndex).Cells("cCount").Value).ToString("#,0")
                        If Not dgvDatos.Rows(e.RowIndex).Cells("cOnHand").Value Is Nothing Then
                            dgvDatos.Rows(e.RowIndex).Cells("cDif").Value = CDbl((dgvDatos.Rows(e.RowIndex).Cells("cOnHand").Value - dgvDatos.Rows(e.RowIndex).Cells("cCount").Value)).ToString("#,0")
                        End If
                    End If                    
            End Select

        Catch ex As Exception
            MessageBox.Show("dgvDatos_CellEndEdit: " & ex.Message)
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

    'Private Sub dgvDatos_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvDatos.CellFormatting

    '    Try

    '        'comprobamos que tenemos un valor
    '        If e.Value IsNot Nothing Then
    '            Dim column As DataGridViewColumn = dgvDatos.Columns(e.ColumnIndex)

    '            Select Case column.Name
    '                Case "cCount", "cOnHand"
    '                    Try
    '                        e.Value = Double.Parse(e.Value.ToString(), Globalization.NumberStyles.AllowThousands + Globalization.NumberStyles.AllowDecimalPoint).ToString("#,0")
    '                        e.FormattingApplied = True
    '                    Catch ex As FormatException
    '                        '+++
    '                    End Try
    '            End Select
    '        End If

    '    Catch ex As Exception
    '        MessageBox.Show("frmInventario.dgvDatos_CellFormatting: " & ex.Message)
    '    End Try
    'End Sub

    Private Sub dgvDatos_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgvDatos.CellValidating
        Dim column As DataGridViewColumn = dgvDatos.Columns(e.ColumnIndex)


        Try            
            'si es una celda 'ReadOnly' significa que esa factura ya ha sido generada en SAP y por lo tanto no validamos nada
            If dgvDatos.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = True Then Exit Try

            'comprobamos que tenemos un valor
            If e.FormattedValue.ToString IsNot Nothing And e.FormattedValue.ToString <> String.Empty Then
                Select Case column.Name
                    Case "cCount" 'campos de números
                        Try
                            Double.Parse(e.FormattedValue.ToString())
                            'AnnotateCell(String.Empty, e.RowIndex, e.ColumnIndex)
                        Catch ex As FormatException
                            'AnnotateCell("Número no válido.", e.RowIndex, e.ColumnIndex)
                            e.Cancel = True
                        End Try
                End Select
            End If

        Catch ex As Exception
            MessageBox.Show("dgvDatos_CellValidating: " & ex.Message)
        End Try
    End Sub

    'Private Sub AnnotateCell(ByVal errorMessage As String, ByVal RowIndex As Integer, ByVal ColumnIndex As Integer)

    '    Try


    '        Dim cell As DataGridViewCell = dgvDatos.Rows(RowIndex).Cells(ColumnIndex)
    '        cell.ErrorText = errorMessage

    '        'If errorMessage = String.Empty Then
    '        '    dgvDatos.Rows(RowIndex).ErrorText = dgvDatos.Rows(RowIndex).ErrorText.Replace(dgvDatos.Columns(ColumnIndex).Name, "")
    '        'Else
    '        '    dgvDatos.Rows(RowIndex).ErrorText = dgvDatos.Rows(RowIndex).ErrorText & dgvDatos.Columns(ColumnIndex).Name
    '        'End If

    '    Catch ex As Exception
    '        MessageBox.Show("frmInventario.AnnotateCell: " & ex.Message)
    '    End Try
    'End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim lItemCode As String
        Dim lWhsCode As String
        Dim lUsuario As String
        Dim lOnHand As Integer
        Dim lCount As Integer
        Dim i As Integer
        Dim lCmd As New SqlClient.SqlCommand

        Try

            'comprobamos que hayan indicado un nombre de usuario
            If txtUsuario.Text = String.Empty Then
                MessageBox.Show("Debe indicar un nombre de usuario.", "Guardar datos", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                Exit Try
            End If
            lUsuario = txtUsuario.Text

            'validación por parte del usuario
            If MessageBox.Show("Sólo se guardaran aquellos artículos cuyo campo 'Contado' tenga un valor mayor o igual que 0, ¿desea continuar?", "Guardar datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                Exit Try
            End If

            lCmd.Connection = mCnx

            With dgvDatos
                For i = 0 To .Rows.Count - 1
                    'comprobamos que existe un valor para el campo 'contado'
                    If .Rows(i).Cells("cCount").Value <> String.Empty AndAlso .Rows(i).Cells("cCount").Value >= 0 Then
                        lItemCode = .Rows(i).Cells("cItemCode").Value
                        lWhsCode = .Rows(i).Cells("cWhsCode").Value
                        lOnHand = .Rows(i).Cells("cOnHand").Value
                        lCount = .Rows(i).Cells("cCount").Value

                        lCmd.CommandType = CommandType.Text
                        lCmd.CommandText = "EXEC OPN_SP_INVENTARIO_DIFERENCIAL_INSERTAR '" & lItemCode & "', '" & lWhsCode & "', " & lOnHand.ToString & ", " & lCount.ToString & ", '" & lUsuario & "'"
                        lCmd.ExecuteNonQuery()
                    End If
                Next
            End With

            MessageBox.Show("Datos guardados con éxito", "Guardar datos", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("frmInventario.btnGuardar_Click: " & ex.Message)
        End Try
    End Sub




    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class