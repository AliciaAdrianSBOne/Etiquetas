Imports System.IO
Imports System
Imports System.Drawing
Imports System.Drawing.Printing

Public Class frmImpEtiquetas


#Region "Declaraciones privadas"
    Private mCnx As SqlClient.SqlConnection
    Private FS_local As frmSeleccion
    Private primera As Boolean = True
    Private forzado As Boolean
    Private vLote As String
    Private vDVD As String
    Private vItemCode As String
    Private vItemName As String


#End Region

    Private Sub frmImpEtiquetas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            'Cargar los combos de Tarifas a seleccionar
            'CargaTarifas()

            CheckBox1.Checked = False
            tbCopias.Text = "1"
            If FS_local.TabControl1.SelectedIndex.ToString = "1" Or FS_local.TabControl1.SelectedIndex.ToString = "0" Then
                EtiquetasCargar()
            Else
                EtiquetasCargar2()
            End If
            primera = False
        Catch ex As Exception
            MessageBox.Show("frmEtiquetas_Load: " & ex.Message)
        End Try
    End Sub

    Private Sub CargaTarifas()
        Dim lCmd As New SqlClient.SqlCommand
        Dim lDR2 As SqlClient.SqlDataReader

        lDR2 = Nothing

        cbTarifa1.Items.Clear()
        cbTarifa1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList

        cbTarifa2.Items.Clear()
        cbTarifa2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList

        'Recuperar las tarifas de la empresa.
        Try

            With lCmd
                .Connection = mCnx
                .CommandType = CommandType.Text
                .CommandText = " SELECT T0.ListName as z" & _
                               " FROM OPLN T0 "

                lDR2 = .ExecuteReader
            End With

            If Not lDR2.HasRows Then
                MsgBox("No existen tarifas en la empresa.", MsgBoxStyle.Critical)
                Close()
            Else
                While lDR2.Read
                    cbTarifa1.Items.Add(lDR2.Item("z").ToString)
                    cbTarifa2.Items.Add(lDR2.Item("z").ToString)
                End While
            End If

        Catch ex As Exception
            MessageBox.Show("frmImpEtiquetas.CargarTarifas: " & ex.Message)
        Finally
            If Not lDR2 Is Nothing Then
                lDR2.Close()
            End If
            lDR2 = Nothing
        End Try

    End Sub

    Private Sub EtiquetasCargar()
        Dim Table1 As DataTable
        Table1 = New DataTable("Etiquetas")
        Dim row1 As DataRow
        Dim lCmd As New SqlClient.SqlCommand
        Dim lDR As SqlClient.SqlDataReader = Nothing
        Dim lDR2 As SqlClient.SqlDataReader = Nothing
        Dim condicion As String = String.Empty
        Dim primera As Boolean = True

        Try
            Dim Imp As DataColumn = New DataColumn("Imp")
            Imp.DataType = System.Type.GetType("System.Boolean")
            Table1.Columns.Add(Imp)

            Dim Lote As DataColumn = New DataColumn("Lote")
            Lote.DataType = System.Type.GetType("System.String")
            Table1.Columns.Add(Lote)

            Dim DVD As DataColumn = New DataColumn("DVD")
            DVD.DataType = System.Type.GetType("System.String")
            Table1.Columns.Add(DVD)

            Dim codigo As DataColumn = New DataColumn("Codigo")
            codigo.DataType = System.Type.GetType("System.String")
            Table1.Columns.Add(codigo)

            Dim descripcion As DataColumn = New DataColumn("Descripcion")
            descripcion.DataType = System.Type.GetType("System.String")
            Table1.Columns.Add(descripcion)

            Dim copias As DataColumn = New DataColumn("Copias")
            copias.DataType = System.Type.GetType("System.String")
            Table1.Columns.Add(copias)

            '**********************************************
            '*** Condiciones de búsqueda Pestaña VARIOS ***
            '**********************************************

            If FS_local.TabControl1.SelectedIndex.ToString = "0" Then

                'ARTICULO DESDE
                If FS_local.TextBox1.Text <> "" Then
                    condicion = " T0.ItemCode>= '" + FS_local.TextBox1.Text + "'"
                    primera = False
                End If

                'ARTICULO HASTA
                If FS_local.TextBox2.Text <> "" Then
                    If primera = True Then
                        condicion = " T0.ItemCode<= '" + FS_local.TextBox2.Text + "'"
                        primera = False
                    Else
                        condicion = condicion + " AND T0.ItemCode<= '" + FS_local.TextBox2.Text + "'"
                    End If
                End If

                'LOTE DESDE
                If FS_local.TextBox9.Text <> "" Then
                    If primera = True Then
                        condicion = " T3.DistNumber>= '" + FS_local.TextBox9.Text + "'"
                        primera = False
                    Else
                        condicion = condicion + " AND T3.DistNumber>= '" + FS_local.TextBox9.Text + "'"
                    End If
                End If

                'LOTE HASTA
                If FS_local.TextBox10.Text <> "" Then
                    If primera = True Then
                        condicion = condicion + " T3.DistNumber<= '" + FS_local.TextBox10.Text + "'"
                        primera = False
                    Else
                        condicion = condicion + " AND T3.DistNumber<= '" + FS_local.TextBox10.Text + "'"
                    End If
                End If

                'DESCRIPCION
                If FS_local.TextBox3.Text <> "" Then
                    If primera = True Then
                        condicion = " T0.ItemName LIKE '%" + FS_local.TextBox3.Text + "%'"
                        primera = False
                    Else
                        condicion = condicion + " AND T0.ItemName LIKE '%" + FS_local.TextBox3.Text + "%'"
                    End If
                End If

                'PROVEEDOR
                If FS_local.TextBox4.Text <> "" Then
                    If primera = True Then
                        condicion = " T0.CardCode= '" + FS_local.TextBox4.Text + "'"
                        primera = False
                    Else
                        condicion = condicion + " AND T0.CardCode= '" + FS_local.TextBox4.Text + "'"
                    End If

                End If
            End If

            '**************************************************
            '*** Condiciones de búsqueda Pestaña DOCUMENTOS ***
            '**************************************************
            '+++++++ALBARAN COMPRA++++++++++++++++++++++++++++++++++++++++++++++++
            If FS_local.TabControl1.SelectedIndex.ToString = "1" Then
                If FS_local.CB1.Checked Then
                    'ALBARAN COMPRA DESDE
                    If FS_local.TextBox5.Text <> "" Then
                        condicion = " T0.DocNum>= '" + FS_local.TextBox5.Text + "'"
                        primera = False
                    End If
                    'ALBARAN COMPRA HASTA
                    If FS_local.TextBox6.Text <> "" Then
                        If primera = True Then
                            condicion = " T0.DocNum<= '" + FS_local.TextBox6.Text + "'"
                            primera = False
                        Else
                            condicion = condicion + " AND T0.DocNum<= '" + FS_local.TextBox6.Text + "'"
                        End If
                    End If
                End If
                If FS_local.CB2.Checked Then
                    'FECHA ALBARAN COMPRA DESDE
                    If FS_local.dtAlbDesde.ToString <> "" Then
                        If primera = True Then
                            condicion = " T0.DocDate>= '" + FS_local.dtAlbDesde.Value.ToString("yyyyMMdd") + "'"
                            primera = False
                        Else
                            condicion = condicion + " AND T0.DocDate>= '" + FS_local.dtAlbDesde.Value.ToString("yyyyMMdd") + "'"
                        End If
                    End If
                    'FECHA ALBARAN COMPRA HASTA
                    If FS_local.dtAlbHasta.ToString <> "" Then
                        If primera = True Then
                            condicion = " T0.DocDate<= '" + FS_local.dtAlbHasta.Value.ToString("yyyyMMdd") + "'"
                            primera = False
                        Else
                            condicion = condicion + " AND T0.DocDate<= '" + FS_local.dtAlbHasta.Value.ToString("yyyyMMdd") + "'"
                        End If
                    End If
                End If

                '+++++ALBARAN BORRADOR+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                If FS_local.CB5.Checked Then
                    'ALBARAN BORRADOR COMPRA DESDE
                    If FS_local.TextBox7.Text <> "" Then
                        If primera Then
                            condicion = " T0.DocEntry>= '" + FS_local.TextBox7.Text + "'"
                            primera = False
                        Else
                            condicion = " AND T0.DocEntry>= '" + FS_local.TextBox7.Text + "'"
                        End If
                    End If
                    'ALBARAN BORRADOR COMPRA HASTA
                    If FS_local.TextBox8.Text <> "" Then
                        If primera = True Then
                            condicion = " T0.DocEntry<= '" + FS_local.TextBox8.Text + "'"
                            primera = False
                        Else
                            condicion = condicion + " AND T0.DocEntry<= '" + FS_local.TextBox8.Text + "'"
                        End If
                    End If
                End If
                If FS_local.CB6.Checked Then
                    'FECHA ALBARAN BORRADOR COMPRA DESDE
                    If FS_local.dtAlbBDesde.ToString <> "" Then
                        If primera = True Then
                            condicion = " T0.DocDate>= '" + FS_local.dtAlbBDesde.Value.ToString("yyyyMMdd") + "'"
                            primera = False
                        Else
                            condicion = condicion + " AND T0.DocDate>= '" + FS_local.dtAlbBDesde.Value.ToString("yyyyMMdd") + "'"
                        End If
                    End If
                    'FECHA ALBARAN BORRADOR COMPRA HASTA
                    If FS_local.dtAlbBHasta.ToString <> "" Then
                        If primera = True Then
                            condicion = " T0.DocDate<= '" + FS_local.dtAlbBHasta.Value.ToString("yyyyMMdd") + "'"
                            primera = False
                        Else
                            condicion = condicion + " AND T0.DocDate<= '" + FS_local.dtAlbBHasta.Value.ToString("yyyyMMdd") + "'"
                        End If
                    End If
                End If
                '+++++++TRASLADOS DE ALMACEN++++++++++++++++++++++++++++++++++++++++++++++++
                If FS_local.CB3.Checked Then
                    'TRASLADO DESDE
                    If FS_local.TextBox11.Text <> "" Then
                        If primera = True Then
                            condicion = " T0.DocNum>= '" + FS_local.TextBox11.Text + "'"
                            primera = False
                        Else
                            condicion = condicion + " AND T0.DocNum>= '" + FS_local.TextBox11.Text + "'"
                        End If
                    End If
                    'TRASLADO HASTA
                    If FS_local.TextBox12.Text <> "" Then
                        If primera = True Then
                            condicion = " T0.DocNum<= '" + FS_local.TextBox12.Text + "'"
                            primera = False
                        Else
                            condicion = condicion + " AND T0.DocNum<= '" + FS_local.TextBox12.Text + "'"
                        End If
                    End If
                End If
                If FS_local.CB4.Checked Then
                    'FECHA TRASLADO DESDE
                    If FS_local.dtTrasDesde.ToString <> "" Then
                        If primera = True Then
                            condicion = " T0.DocDate>= '" + FS_local.dtTrasDesde.Value.ToString("yyyyMMdd") + "'"
                            primera = False
                        Else
                            condicion = condicion + " AND T0.DocDate>= '" + FS_local.dtTrasDesde.Value.ToString("yyyyMMdd") + "'"
                        End If
                    End If
                    'FECHA TRASLADO HASTA
                    If FS_local.dtTrasHasta.ToString <> "" Then
                        If primera = True Then
                            condicion = " T0.DocDate<= '" + FS_local.dtTrasHasta.Value.ToString("yyyyMMdd") + "'"
                            primera = False
                        Else
                            condicion = condicion + " AND T0.DocDate<= '" + FS_local.dtTrasHasta.Value.ToString("yyyyMMdd") + "'"
                        End If
                    End If
                End If
            End If

            Try

                With lCmd
                    .Connection = mCnx
                    .CommandType = CommandType.Text

                    '*** Condiciones de búsqueda Pestaña VARIOS ***
                    If FS_local.TabControl1.SelectedIndex.ToString = "0" Then
                        .CommandText = " SELECT T0.Itemcode,T0.Itemname, T3.DistNumber, T3.MnfSerial " & _
                                       " from OITM T0 right join OBTN T3 on T0.Itemcode = T3.Itemcode " & _
                                       " WHERE " & _
                                       " " + condicion + " " & _
                                       " ORDER BY T0.Itemcode "
                    End If

                    '*** Condiciones de búsqueda Pestaña DOCUMENTOS ***
                    If FS_local.TabControl1.SelectedIndex.ToString = "1" Then
                        If FS_local.CB1.Checked Or FS_local.CB2.Checked Then 'ALBARANES
                            .CommandText = "select distinct T3.Itemcode, T3.Itemname as Dscription, abs(t2.Quantity) as Quantity, T3.DistNumber, T3.MnfSerial from " & _
                                            "OPDN T0 left join oitl T1 on t0.DocEntry = t1.DocEntry and t1.doctype = 20 " & _
                                            "inner join itl1 t2 on t1.LogEntry = t2.LogEntry " & _
                                            "right join obtn t3 on t2.SysNumber = t3.SysNumber and t2.ItemCode = t3.ItemCode where " & _
                                            " " + condicion + " " & _
                                            " ORDER BY T3.DistNumber "
                        End If
                        If FS_local.CB3.Checked Or FS_local.CB4.Checked Then 'TRASLADO ALMACENES
                            .CommandText = " SELECT T1.Itemcode,T1.Dscription,T1.Quantity as Quantity, T3.DistNumber, T3.MnfSerial " & _
                                           " from OWTR T0 INNER JOIN WTR1 T1 ON T0.DocEntry = T1.DocEntry right join OBTN T3 on T1.Itemcode = T3.Itemcode " & _
                                           " WHERE " & _
                                           " " + condicion + " " & _
                                           " ORDER BY T1.DocEntry,T1.Linenum "
                        End If
                        If FS_local.CB5.Checked Or FS_local.CB6.Checked Then 'ALBARANES BORRADOR
                            .CommandText = "select distinct isnull(T3.Itemcode,t4.ItemCode) as ItemCode, isnull(T3.Itemname,t4.itemName) as Dscription, abs(t2.Quantity) as Quantity, isnull(T3.DistNumber,t4.DistNumber) as DistNumber, isnull(T3.MnfSerial,t4.MnfSerial) as MnfSerial from " & _
                                           "ODRF T0 left join DRF1 T1 on t0.DocEntry = t1.DocEntry and t0.objtype = 20 " & _
                                           "inner join DRF16 T2 on t1.DocEntry = t2.absentry and t1.ItemCode = t2.ItemCode " & _
                                           "left join ODBN T3 on t2.ObjAbs = t3.AbsEntry left join OBTN t4 on t2.objabs = t4.absentry where " & _
                                           " " + condicion + " " & _
                                           " ORDER BY DistNumber "
                        End If
                    End If

                    lDR = .ExecuteReader
                End With

                If Not lDR.HasRows Then
                    MsgBox("No existen datos con las condiciones de selección.", MsgBoxStyle.Critical)
                    Close()
                Else

                    '***********************************************************************************************************************
                    '************************* OBTENEMOS LOS DATOS DE TODOS LOS LOTES QUE TENGAN ESOS ARTICULOS ****************************
                    '***********************************************************************************************************************

                    While lDR.Read
                        row1 = Table1.NewRow()
                        row1.Item("Imp") = CheckBox1.Checked
                        row1.Item("Lote") = lDR.Item("DistNumber").ToString
                        row1.Item("DVD") = lDR.Item("MnfSerial").ToString
                        row1.Item("codigo") = lDR.Item("Itemcode").ToString
                        If FS_local.TabControl1.SelectedIndex.ToString = "0" Then
                            row1.Item("descripcion") = lDR.Item("Itemname").ToString
                            row1.Item("copias") = tbCopias.Text
                        End If
                        If FS_local.TabControl1.SelectedIndex.ToString = "1" Then
                            row1.Item("descripcion") = lDR.Item("Dscription").ToString
                            row1.Item("copias") = Format(lDR.Item("Quantity"), "#").ToString
                        End If
                        If forzado Then
                            row1.Item("copias") = tbCopias.Text
                        End If
                        Table1.Rows.Add(row1)
                    End While
                End If
            Catch ex As Exception
                MessageBox.Show("frmImpEtiquetas.EtiquetasCargar: " & ex.Message)
            Finally
                If Not lDR Is Nothing Then
                    lDR.Close()
                End If
                lDR = Nothing
                lCmd = Nothing
                GC.Collect()
            End Try

        Catch
        End Try

        Dim ds As New DataSet()
        ds = New DataSet()
        'creating a dataset
        ds.Tables.Add(Table1)

        'Instanciamos y creamos nuestro manejador para bloquear nuevos registros si error..
        Dim cm As CurrencyManager
        cm = CType(BindingContext(ds, ds.Tables(0).TableName), CurrencyManager)
        'Instanciamos y creamos un DataView asosiado a nuestro manejador CurrencyManager
        Dim Dv As DataView = CType(cm.List, DataView)
        Dv.AllowNew = False

        'adding the table to dataset 
        dgEtiquetas.SetDataBinding(ds, "Etiquetas")
        'binding the table to datagrid


        'Borramos la tabla de estilos en el DataGrid si es que existe
        Me.dgEtiquetas.TableStyles.Clear()

        'Instanciamos y creamos una nueva tabla de estilos
        Dim TableStyle1 As New DataGridTableStyle
        'Le indicamos el nombre de la tabla de nuestro DataSet
        TableStyle1.MappingName = ds.Tables(0).TableName
        'TableStyle1.AlternatingBackColor = Color.LightGray

        Dim TextCol1 As New DataGridBoolColumn
        'Dim TextCol1 As New DataGridTextBoxColumn
        TextCol1.MappingName = "Imp"
        TextCol1.HeaderText = "Imp"
        TextCol1.Width = 30
        TextCol1.AllowNull = False
        TableStyle1.GridColumnStyles.Add(TextCol1)

        Dim TextCol0 As New DataGridTextBoxColumn
        TextCol0.MappingName = "Lote"
        TextCol0.HeaderText = "Lote"
        TextCol0.Width = 60
        TextCol0.ReadOnly = True
        TableStyle1.GridColumnStyles.Add(TextCol0)

        Dim TextCol5 As New DataGridTextBoxColumn
        TextCol5.MappingName = "DVD"
        TextCol5.HeaderText = "DVD"
        TextCol5.Width = 60
        TextCol5.ReadOnly = True
        TableStyle1.GridColumnStyles.Add(TextCol5)

        Dim TextCol2 As New DataGridTextBoxColumn
        TextCol2.MappingName = "Codigo"
        TextCol2.HeaderText = "Código"
        TextCol2.Width = 60
        TextCol2.ReadOnly = True
        TableStyle1.GridColumnStyles.Add(TextCol2)

        Dim TextCol3 As New DataGridTextBoxColumn
        TextCol3.MappingName = "descripcion"
        TextCol3.HeaderText = "Descripcion"
        TextCol3.Width = 355
        TextCol3.ReadOnly = True
        TableStyle1.GridColumnStyles.Add(TextCol3)

        Dim TextCol4 As New DataGridTextBoxColumn
        TextCol4.MappingName = "copias"
        TextCol4.HeaderText = "Copias"
        TextCol4.Width = 60
        TextCol4.Format = "g"
        TextCol4.ReadOnly = False
        TableStyle1.GridColumnStyles.Add(TextCol4)

        Me.dgEtiquetas.TableStyles.Add(TableStyle1)

    End Sub

    Private Sub EtiquetasCargar2()
        Dim Table1 As DataTable
        Table1 = New DataTable("Etiquetas")
        Dim row1 As DataRow
        Dim lCmd As New SqlClient.SqlCommand
        Dim lDR2 As SqlClient.SqlDataReader = Nothing
        Dim condicion As String = String.Empty
        Dim primera As Boolean = True

        Dim Imp As DataColumn = New DataColumn("Imp")
        Imp.DataType = System.Type.GetType("System.Boolean")
        Table1.Columns.Add(Imp)

        Dim Lote As DataColumn = New DataColumn("Lote")
        Lote.DataType = System.Type.GetType("System.String")
        Table1.Columns.Add(Lote)

        Dim DVD As DataColumn = New DataColumn("DVD")
        DVD.DataType = System.Type.GetType("System.String")
        Table1.Columns.Add(DVD)

        Dim codigo As DataColumn = New DataColumn("Codigo")
        codigo.DataType = System.Type.GetType("System.String")
        Table1.Columns.Add(codigo)

        Dim descripcion As DataColumn = New DataColumn("Descripcion")
        descripcion.DataType = System.Type.GetType("System.String")
        Table1.Columns.Add(descripcion)

        Dim copias As DataColumn = New DataColumn("Copias")
        copias.DataType = System.Type.GetType("System.String")
        Table1.Columns.Add(copias)

        Try
            Dim dts As DataSet = FS_local.DGCodigos.DataSource
            Dim t As DataTable = dts.Tables.Item(0)

            For Each row As DataRow In t.Rows

                row1 = Table1.NewRow()
                row1.Item("Imp") = CheckBox1.Checked
                row1.Item("lote") = row.Item("codigo").ToString

                'Recuperar la descripción del artículo.
                Try

                    With lCmd
                        .Connection = mCnx
                        .CommandType = CommandType.Text
                        .CommandText = " SELECT Itemcode, DistNumber, MnfSerial, ItemName" & _
                                       " from OBTN T0 " & _
                                       " WHERE DistNumber=" & _
                                       " '" + row.Item("codigo").ToString + "' "

                        lDR2 = .ExecuteReader
                    End With

                    If lDR2.Read() Then
                        row1.Item("Codigo") = lDR2.Item("ItemCode").ToString
                        row1.Item("DVD") = lDR2.Item("MnfSerial").ToString
                        row1.Item("Descripcion") = lDR2.Item("ItemName").ToString
                    Else
                        row1.Item("descripcion") = ""
                    End If
                Catch ex As Exception
                    MessageBox.Show("frmImpEtiquetas.CargarDescripcionLot: " & ex.Message)
                Finally
                    If Not lDR2 Is Nothing Then
                        lDR2.Close()
                    End If
                    lDR2 = Nothing
                End Try

                row1.Item("copias") = row.Item("copias").ToString
                If forzado Then
                    row1.Item("copias") = tbCopias.Text
                End If
                Table1.Rows.Add(row1)
            Next

        Catch ex As Exception
            MessageBox.Show("frmImpEtiquetas.EtiquetasCargar2: " & ex.Message)
        End Try

        Dim ds As New DataSet()
        ds = New DataSet()
        'creating a dataset
        ds.Tables.Add(Table1)

        'Instanciamos y creamos nuestro manejador para bloquear nuevos registros si error..
        Dim cm As CurrencyManager
        cm = CType(BindingContext(ds, ds.Tables(0).TableName), CurrencyManager)
        'Instanciamos y creamos un DataView asosiado a nuestro manejador CurrencyManager
        Dim Dv As DataView = CType(cm.List, DataView)
        Dv.AllowNew = False

        'adding the table to dataset 
        dgEtiquetas.SetDataBinding(ds, "Etiquetas")
        'binding the table to datagrid


        'Borramos la tabla de estilos en el DataGrid si es que existe
        Me.dgEtiquetas.TableStyles.Clear()

        'Instanciamos y creamos una nueva tabla de estilos
        Dim TableStyle1 As New DataGridTableStyle
        'Le indicamos el nombre de la tabla de nuestro DataSet
        TableStyle1.MappingName = ds.Tables(0).TableName
        'TableStyle1.AlternatingBackColor = Color.LightGray

        Dim TextCol1 As New DataGridBoolColumn
        'Dim TextCol1 As New DataGridTextBoxColumn
        TextCol1.MappingName = "Imp"
        TextCol1.HeaderText = "Imp"
        TextCol1.Width = 30
        TextCol1.AllowNull = False
        TableStyle1.GridColumnStyles.Add(TextCol1)

        Dim TextCol5 As New DataGridTextBoxColumn
        TextCol5.MappingName = "Lote"
        TextCol5.HeaderText = "Lote"
        TextCol5.Width = 60
        TextCol5.ReadOnly = True
        TableStyle1.GridColumnStyles.Add(TextCol5)

        Dim TextCol6 As New DataGridTextBoxColumn
        TextCol6.MappingName = "DVD"
        TextCol6.HeaderText = "DVD"
        TextCol6.Width = 60
        TextCol6.ReadOnly = True
        TableStyle1.GridColumnStyles.Add(TextCol6)

        Dim TextCol2 As New DataGridTextBoxColumn
        TextCol2.MappingName = "Codigo"
        TextCol2.HeaderText = "Código"
        TextCol2.Width = 60
        TextCol2.ReadOnly = True
        TableStyle1.GridColumnStyles.Add(TextCol2)

        Dim TextCol3 As New DataGridTextBoxColumn
        TextCol3.MappingName = "Descripcion"
        TextCol3.HeaderText = "Descripcion"
        TextCol3.Width = 355
        TextCol3.ReadOnly = True
        TableStyle1.GridColumnStyles.Add(TextCol3)

        Dim TextCol4 As New DataGridTextBoxColumn
        TextCol4.MappingName = "copias"
        TextCol4.HeaderText = "Copias"
        TextCol4.Width = 60
        TextCol4.Format = "g"
        TextCol4.ReadOnly = False
        TableStyle1.GridColumnStyles.Add(TextCol4)

        Me.dgEtiquetas.TableStyles.Add(TableStyle1)


    End Sub

    Private Sub frmImpEtiquetas_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        If Not mCnx Is Nothing Then
            mCnx.Close()
        End If
        mCnx = Nothing

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Sub New(ByVal FS As frmSeleccion)

        FS_local = FS

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub


    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If Not primera Then
            forzado = True
            If FS_local.TabControl1.SelectedIndex.ToString = "1" Or FS_local.TabControl1.SelectedIndex.ToString = "0" Then
                EtiquetasCargar()
            Else
                EtiquetasCargar2()
            End If
            forzado = False
        End If
    End Sub

    Private Sub tbCopias_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbCopias.LostFocus
        If Not primera Then
            forzado = True
            If FS_local.TabControl1.SelectedIndex.ToString = "1" Or FS_local.TabControl1.SelectedIndex.ToString = "0" Then
                EtiquetasCargar()
            Else
                EtiquetasCargar2()
            End If
            forzado = False
        End If
    End Sub



    Private Sub btnimprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnimprimir.Click
       
        Dim dts As DataSet = dgEtiquetas.DataSource
        Dim t As DataTable = dts.Tables.Item(0)
        Dim a As Integer = 1
        Dim lCmd As New SqlClient.SqlCommand
        Dim lDR2 As SqlClient.SqlDataReader = Nothing
        Dim condicion As String = String.Empty

        For Each row As DataRow In t.Rows
            If row.Item("imp") Then
                vItemName = row.Item("Descripcion").ToString
                vItemCode = row.Item("Codigo").ToString
                vLote = row.Item("Lote").ToString
                vDVD = row.Item("DVD").ToString

                If row.Item("copias") = "" Then row.Item("copias") = 1

                If row.Item("copias") > 0 Then
                    'a = 1
                    'Do While a <= row.Item("copias")
                    Imprimir(row.Item("copias"))
                    'Imprimir(1)
                    'a = a + 1
                    'Loop
                End If
            End If
        Next

    End Sub


    Private Sub Imprimir(NumCopias As Integer)

        Dim printDoc As New PrintDocument
        ' asignamos el método de evento para cada página a imprimir
        AddHandler printDoc.PrintPage, AddressOf print_PrintPage
        ' indicamos que queremos imprimir y por qué impresora
        printDoc.PrinterSettings.PrinterName = PrinterTickets
        printDoc.DocumentName = "Etiquetas"
        printDoc.PrinterSettings.Copies = NumCopias
        printDoc.PrinterSettings.DefaultPageSettings.PrinterResolution.Kind = PrinterResolutionKind.Draft
        printDoc.PrinterSettings.DefaultPageSettings.PrinterResolution.X = 96
        printDoc.PrinterSettings.DefaultPageSettings.PrinterResolution.X = 96
        'printDoc.DefaultPageSettings.PaperSize.Width = 236
        'printDoc.DefaultPageSettings.PaperSize.Height = 400
        'Dim i As Integer
        'For i = 1 To NumCopias
        printDoc.Print()
        'Next

    End Sub


    Private Sub print_PrintPage(ByVal sender As Object, _
                            ByVal e As PrintPageEventArgs)

        'Dim xPos As Single = e.MarginBounds.Left
        Dim prFontItemName As New Font("Arial", 13, FontStyle.Regular)
        Dim prFontItemCode As New Font("Arial", 15, FontStyle.Bold)
        Dim prFontLote As New Font("Arial", 13, FontStyle.Bold)
        'Dim prFontDVD As New Font("Arial", 14, FontStyle.Regular)
        Dim prFontBarras As New Font("Code39AzaleaRegular2", 28, FontStyle.Regular) 'original 25 Code39AzaleaRegular2
        'Dim prFontBarrasDVD As New Font("Code39AzaleaRegular2", 8, FontStyle.Regular) 'original 25
        'Dim prFontBarras2 As New Font("Code39AzaleaRegular2", 18, FontStyle.Regular)
        'Dim yPos As Single = prFontItemCode.GetHeight(e.Graphics)
        Dim vdes1, vdes2 As String 'vdes3 vdes4

        Dim width As Single = 340.0F
        Dim height As Single = 40.0F
        Dim lDrawRectF As New RectangleF(5.0F, 5.0F, width, height)
        Dim lDrawFormat As New StringFormat

        e.PageSettings.PrinterResolution.Kind = PrinterResolutionKind.Custom
        e.PageSettings.PrinterResolution.X = 5
        e.PageSettings.PrinterResolution.Y = 5

        lDrawFormat.Alignment = StringAlignment.Center

        vdes1 = Mid(vItemName, 1, 20)
        vdes2 = Mid(vItemName, 21, 20)

        'vItemName = "FROZEN PINEAPPLE JUICE CONCENTRATE 60 BX"
        'vItemCode = "DAFPINA53R2025-240"
        'vLote = "310336PRF-270"
        'vDVD = "DUA16ES00461130484372"

        '************************************************************
        ' imprimimos las cadenas
        'lDrawRectF.Y = 5 '0 '10
        'e.Graphics.DrawString(vItemName, prFontItemName, Brushes.Black, lDrawRectF, lDrawFormat)

        'lDrawRectF.Y = 5 + 50 ' 10 + 50
        'e.Graphics.DrawString("Código: ", prFontItemName, Brushes.Black, lDrawRectF, lDrawFormat)

        'lDrawRectF.Y = 75 '50 '130
        'e.Graphics.DrawString(vItemCode, prFontItemCode, Brushes.Black, lDrawRectF, lDrawFormat)
        'lDrawRectF.Y = 65 + 30 + 30 '50 + 30 ' 130 + 50
        'e.Graphics.DrawString("*" + vItemCode + "*", prFontBarras, Brushes.Black, lDrawRectF, lDrawFormat)

        'lDrawRectF.Y = 130 + 40 '100 '290
        ''lDrawFormat.Alignment = StringAlignment.Near
        'e.Graphics.DrawString("Lote: ", prFontItemName, Brushes.Black, lDrawRectF, lDrawFormat)
        'lDrawRectF.Y = 130 + 60
        ''lDrawFormat.Alignment = StringAlignment.Center
        'e.Graphics.DrawString(vLote, prFontLote, Brushes.Black, lDrawRectF, lDrawFormat)

        'lDrawRectF.Y = 130 + 30 + 80 '100 + 30 '290 + 50
        'e.Graphics.DrawString("*" + vLote + "*", prFontBarras, Brushes.Black, lDrawRectF, lDrawFormat)

        'If vDVD <> "" Then
        '    lDrawRectF.Y = 295 '170 '440
        '    e.Graphics.DrawString(vDVD, prFontDVD, Brushes.Black, lDrawRectF, lDrawFormat)
        '    lDrawRectF.Y = 295 + 20 '170 + 30 '440 + 35
        '    e.Graphics.DrawString("*" + vDVD + "*", prFontBarrasDVD, Brushes.Black, lDrawRectF, lDrawFormat)
        'End If
        '********************************************

        lDrawRectF.Y = 5
        lDrawRectF.Height = 320
        e.Graphics.DrawString(vItemName, prFontItemName, Brushes.Black, lDrawRectF, lDrawFormat)

        lDrawRectF.Y = 5 + 20 '5 + 40
        e.Graphics.DrawString("Código: " & vItemCode, prFontItemName, Brushes.Black, lDrawRectF, lDrawFormat)

        'lDrawRectF.X = lDrawRectF.X + 40
        'e.Graphics.DrawString(vItemCode, prFontItemCode, Brushes.Black, lDrawRectF, lDrawFormat)

        lDrawRectF.Y = 35 + 20
        lDrawRectF.Height = 40
        e.Graphics.DrawString("*" + vItemCode + "*", prFontBarras, Brushes.Black, lDrawRectF, lDrawFormat)

        lDrawRectF.Y = 85 + 20 '85 + 40
        e.Graphics.DrawString("Lote: " & vLote, prFontLote, Brushes.Black, lDrawRectF, lDrawFormat)

        'lDrawRectF.X = lDrawRectF.X + 40
        'e.Graphics.DrawString(vLote, prFontLote, Brushes.Black, lDrawRectF, lDrawFormat)

        lDrawRectF.Y = 115 + 20
        lDrawRectF.Height = 40
        e.Graphics.DrawString("*" + vLote + "*", prFontBarras, Brushes.Black, lDrawRectF, lDrawFormat)

        ' INICIO Tarea Nº26036 - Ajuste etiquetas (aplicación externa Seidor)
        'If vDVD <> "" Then
        '    lDrawRectF.Y = 295 '170 '440
        '    e.Graphics.DrawString(vDVD, prFontItemName, Brushes.Black, lDrawRectF, lDrawFormat)
        '    lDrawRectF.Y = 295 + 20 '170 + 30 '440 + 35
        '    e.Graphics.DrawString("*" + vDVD + "*", prFontBarras, Brushes.Black, lDrawRectF, lDrawFormat)
        'End If
        ' FIN Tarea Nº26036 - Ajuste etiquetas (aplicación externa Seidor)

        'Dibujar un grid para ayudar a ubicar los campos
        'Dim i As Single
        'Dim p As New Pen(Color.Black, 3)
        'For i = 0 To 500 Step 50
        '    'linea horizontal
        '    e.Graphics.DrawLine(p, i, 50.0F, i, 50.0F)
        '    'linea vertical
        '    e.Graphics.DrawLine(p, 50.0F, i, 50.0F, i)
        'Next

        ' indicamos que ya no hay nada más que imprimir
        ' (el valor predeterminado de esta propiedad es False)
        e.HasMorePages = False


    End Sub


End Class