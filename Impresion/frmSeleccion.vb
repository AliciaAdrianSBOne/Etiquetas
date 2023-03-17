Imports System.IO
Public Class frmSeleccion


#Region "Declaraciones privadas"
    Private mCnx As SqlClient.SqlConnection
    Dim lCmd As New SqlClient.SqlCommand
    Dim lDR As SqlClient.SqlDataReader
    Dim ds As New DataSet()

    Dim mModoEjecución As Integer
    Dim mTitulo As String
#End Region



    Private Sub frmSeleccion_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If Not mCnx Is Nothing Then
            mCnx.Close()
        End If
        mCnx = Nothing

        GC.Collect()
    End Sub


    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim lFrm As New frmProv(Me)
        lFrm.ShowDialog()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim lFrm As New frmArt1(Me)
        lFrm.ShowDialog()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim lFrm As New frmArt2(Me)
        lFrm.ShowDialog()
    End Sub

    Private Sub btnPasaArticulos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPasaArticulos.Click
        If TextBox1.Text = "" And TextBox2.Text = "" And TextBox3.Text = "" And TextBox4.Text = "" And TextBox9.Text = "" And TextBox10.Text = "" Then
            MsgBox("Debe seleccionar al menos un valor.", MsgBoxStyle.Critical, mTitulo)
        Else
            Select Case mModoEjecución
                Case MODO_IMPRESION
                    Dim lFrm As New frmImpEtiquetas(Me)
                    lFrm.ShowDialog()

                Case MODO_INVENTARIO
                    Dim lFrm As New frmInventario(Me)
                    lFrm.ShowDialog()
            End Select
        End If
    End Sub

    Private Sub CB1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB1.CheckedChanged
        If CB1.Checked Then
            CB3.Checked = False
            CB4.Checked = False
            CB5.Checked = False
            CB6.Checked = False
        End If
    End Sub

    Private Sub CB2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB2.CheckedChanged
        If CB2.Checked Then
            CB3.Checked = False
            CB4.Checked = False
            CB5.Checked = False
            CB6.Checked = False
        End If
    End Sub

    Private Sub CB3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB3.CheckedChanged
        If CB3.Checked Then
            CB1.Checked = False
            CB2.Checked = False
            CB5.Checked = False
            CB6.Checked = False
        End If
    End Sub

    Private Sub CB4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB4.CheckedChanged
        If CB4.Checked Then
            CB1.Checked = False
            CB2.Checked = False
            CB5.Checked = False
            CB6.Checked = False
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim lFrm As New frmAlb1(Me)
        lFrm.ShowDialog()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim lFrm As New frmAlb2(Me)
        lFrm.ShowDialog()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim lFrm As New frmTra1(Me)
        lFrm.ShowDialog()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim lFrm As New frmTra2(Me)
        lFrm.ShowDialog()
    End Sub


    Private Sub btnPasaArticulosD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPasaArticulosD.Click
        If Not CB1.Checked And Not CB2.Checked And Not CB3.Checked And Not CB4.Checked And Not CB5.Checked And Not CB6.Checked Then
            MsgBox("Debe seleccionar al menos un valor.", MsgBoxStyle.Critical, mTitulo)
        Else
            Select Case mModoEjecución
                Case MODO_IMPRESION
                    Dim lFrm As New frmImpEtiquetas(Me)
                    lFrm.ShowDialog()

                Case MODO_INVENTARIO
                    Dim lFrm As New frmInventario(Me)
                    lFrm.ShowDialog()
            End Select
        End If
    End Sub


    Private Sub tpCodigos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tpCodigos.Click


    End Sub

    Private Sub Customers_ColumnChanging(ByVal sender As Object, _
ByVal e As System.Data.DataColumnChangeEventArgs)

        ' Validar columna CODIGO
        If (e.Column.ColumnName.Equals("Codigo")) Then
            Try
                With lCmd
                    .Connection = mCnx
                    .CommandType = CommandType.Text
                    .CommandText = " SELECT T0.Itemcode " & _
                                       " from OBTN T0 " & _
                                       " WHERE T0.DistNumber=" & _
                                       " '" + CType(e.ProposedValue, String) + "' " & _
                                       " ORDER BY T0.DistNumber "

                    lDR = .ExecuteReader
                End With

                'Instanciamos y creamos nuestro manejador para bloquear nuevos registros si error..
                Dim cm As CurrencyManager
                cm = CType(BindingContext(ds, Me.ds.Tables(0).TableName), CurrencyManager)
                'Instanciamos y creamos un DataView asosiado a nuestro manejador CurrencyManager
                Dim Dv As DataView = CType(cm.List, DataView)
                If Not lDR.HasRows Then
                    Dim badValue As Object = e.ProposedValue
                    e.ProposedValue = "ERROR"
                    e.Row.RowError = "La columna Código contiene un error."
                    e.Row.SetColumnError(e.Column, "El lote " + CType(badValue, String) & _
                    " no existe.")

                    Dv.AllowNew = False
                Else
                    e.Row.ClearErrors()
                    Dv.AllowNew = True
                End If
            Catch ex As Exception
                MessageBox.Show("frmSeleccion.ValidarLotes: " & ex.Message)
            Finally
                If Not lDR Is Nothing Then
                    lDR.Close()
                End If
                lDR = Nothing
            End Try
        End If

    End Sub

    Private Sub frmSeleccion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim TablaCodigos As DataTable
        TablaCodigos = New DataTable("Codigos")

        mCnx = New SqlClient.SqlConnection
        With mCnx
            .ConnectionString = "Persist Security Info=False;" & _
                                "Data Source = " & Principal.Servidor & "; " & _
                                "Initial Catalog = " & Principal.empresa1 & "; " & _
                                "User ID = " & Principal.SQLUser & "; " & _
                                "Password = " & Principal.SQLPwd & "; "
            .Open()
        End With


        Dim codigo As DataColumn = New DataColumn("Codigo")
        codigo.DataType = System.Type.GetType("System.String")
        TablaCodigos.Columns.Add(codigo)

        Dim descripcion As DataColumn = New DataColumn("Descripcion")
        descripcion.DataType = System.Type.GetType("System.String")
        TablaCodigos.Columns.Add(descripcion)

        Dim copias As DataColumn = New DataColumn("Copias")
        copias.DataType = System.Type.GetType("System.String")
        TablaCodigos.Columns.Add(copias)


        ds = New DataSet()
        'creating a dataset
        ds.Tables.Add(TablaCodigos)
        AddHandler ds.Tables("Codigos").ColumnChanging, AddressOf Customers_ColumnChanging
        'adding the table to dataset 
        DGCodigos.SetDataBinding(ds, "Codigos")
        'binding the table to datagrid

        'Borramos la tabla de estilos en el DataGrid si es que existe
        Me.DGCodigos.TableStyles.Clear()

        'Instanciamos y creamos una nueva tabla de estilos
        Dim TableStyle1 As New DataGridTableStyle
        'Le indicamos el nombre de la tabla de nuestro DataSet
        TableStyle1.MappingName = ds.Tables(0).TableName
        'TableStyle1.AlternatingBackColor = Color.LightGray

        Dim TextCol2 As New DataGridTextBoxColumn
        TextCol2.MappingName = "Codigo"
        TextCol2.HeaderText = "Código"
        TextCol2.Width = 80
        TextCol2.ReadOnly = False
        TextCol2.NullText = " "
        TableStyle1.GridColumnStyles.Add(TextCol2)

        ''Dim TextCol3 As New DataGridTextBoxColumn
        ''TextCol3.MappingName = "descripcion"
        ''TextCol3.HeaderText = "Descripcion"
        ''TextCol3.Width = 400
        ''TextCol3.ReadOnly = True
        ''TextCol3.NullText = ""

        ''TableStyle1.GridColumnStyles.Add(TextCol3)

        Dim TextCol4 As New DataGridTextBoxColumnSoloNumeros
        TextCol4.MappingName = "copias"
        TextCol4.HeaderText = "Copias"
        TextCol4.Width = 80
        TextCol4.Format = "g"
        TextCol4.ReadOnly = False
        TextCol4.NullText = ""
        TableStyle1.GridColumnStyles.Add(TextCol4)

        Me.DGCodigos.TableStyles.Add(TableStyle1)
    End Sub

    Private Sub btnPasaArticulosC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPasaArticulosC.Click
        Dim dts As DataSet = DGCodigos.DataSource
        Dim t As DataTable = dts.Tables.Item(0)

        If t.HasErrors Then
            MsgBox("Debe corregir los errores antes de continuar.", MsgBoxStyle.Critical, mTitulo)
        ElseIf t.Rows.Count = 0 Then
            MsgBox("Debe introducir al menos un valor.", MsgBoxStyle.Critical, mTitulo)
        Else
            Select Case mModoEjecución
                Case MODO_IMPRESION
                    Dim lFrm As New frmImpEtiquetas(Me)
                    lFrm.ShowDialog()

                Case MODO_INVENTARIO
                    Dim lFrm As New frmInventario(Me)
                    lFrm.ShowDialog()
            End Select
        End If

    End Sub

    Public Sub New(ByVal ModoEjecucion As Integer)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        'POR DEFECTO MODO IMPRESION
        mModoEjecución = ModoEjecucion
        If mModoEjecución = MODO_IMPRESION Then
            mTitulo = "Impresión etiquetas"
        ElseIf mModoEjecución = MODO_INVENTARIO Then
            mTitulo = "Inventario diferencial"
        End If

    End Sub

    Private Sub Button11_Click(sender As System.Object, e As System.EventArgs) Handles Button11.Click
        Dim lFrm As New frmLot1(Me)
        lFrm.ShowDialog()
    End Sub

    Private Sub Button10_Click(sender As System.Object, e As System.EventArgs) Handles Button10.Click
        Dim lFrm As New frmLot2(Me)
        lFrm.ShowDialog()
    End Sub

    Private Sub Button9_Click(sender As System.Object, e As System.EventArgs) Handles Button9.Click
        Dim lFrm As New frmAlbB1(Me)
        lFrm.ShowDialog()
    End Sub

    Private Sub Button8_Click(sender As System.Object, e As System.EventArgs) Handles Button8.Click
        Dim lFrm As New frmAlbB2(Me)
        lFrm.ShowDialog()
    End Sub

    Private Sub CB5_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CB5.CheckedChanged
        If CB5.Checked Then
            CB1.Checked = False
            CB2.Checked = False
            CB3.Checked = False
            CB4.Checked = False
        End If
    End Sub

    Private Sub CB6_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CB6.CheckedChanged
        If CB6.Checked Then
            CB1.Checked = False
            CB2.Checked = False
            CB3.Checked = False
            CB4.Checked = False
        End If
    End Sub

    Private Sub btnBorrarTodo_Click(sender As System.Object, e As System.EventArgs)

    End Sub


    Private Sub BorrarControles(Control As Control)
        Dim i As Integer

        If TypeOf (Control) Is TextBox Then
            Control.Text = ""
        ElseIf TypeOf (Control) Is CheckBox Then
            TryCast(Control, CheckBox).Checked = False
        End If

        If Control.HasChildren Then
            For i = 0 To Control.Controls.Count - 1
                BorrarControles(Control.Controls(i))
            Next
        End If

    End Sub


    Private Sub btnBorrarSeleccion_Click(sender As System.Object, e As System.EventArgs) Handles btnBorrarSeleccion.Click
        Dim i As Integer

        For i = 0 To Me.Controls.Count - 1
            BorrarControles(Me.Controls(i))
        Next

    End Sub
End Class