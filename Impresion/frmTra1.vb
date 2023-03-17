Public Class frmTra1

#Region "Declaraciones privadas"
    Private mCnx As SqlClient.SqlConnection
    Private FS_local As frmSeleccion
#End Region


    Private Sub frmTra1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.lvTraslados.BringToFront()

            mCnx = New SqlClient.SqlConnection
            With mCnx
                .ConnectionString = "Persist Security Info=False;" & _
                                    "Data Source = " & Principal.Servidor & "; " & _
                                    "Initial Catalog = " & Principal.empresa1 & "; " & _
                                    "User ID = " & Principal.SQLUser & "; " & _
                                    "Password = " & Principal.SQLPwd & "; "
                .Open()
            End With
            cmbTipo2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            cmbTipo2.Items.Add("Traslado")
            cmbTipo2.Items.Add("AlmacenD")
            cmbTipo2.Items.Add("Codigo Proveedor")
            cmbTipo2.Items.Add("Desc. Proveedor")

            cmbTipo2.SelectedItem = "Traslado"

        Catch ex As Exception
            MessageBox.Show("frmTra1_Load: " & ex.Message)
        End Try
    End Sub

    Private Sub TrasladosCargar()
        Dim lCmd As New SqlClient.SqlCommand
        Dim lDR As SqlClient.SqlDataReader = Nothing
        Dim condicion As String = String.Empty

        'Condicion de búsqueda
        If cmbTipo2.SelectedItem.ToString.ToUpper.Equals("TRASLADO") Then
            condicion = " T0.DocNum LIKE '%" + TbBusca.Text + "%'"
        End If
        If cmbTipo2.SelectedItem.ToString.ToUpper.Equals("ALMACEND") Then
            condicion = " T0.Filler LIKE '%" + TbBusca.Text + "%'"
        End If
        If cmbTipo2.SelectedItem.ToString.ToUpper.Equals("CODIGO PROVEEDOR") Then
            condicion = " T0.CardCode LIKE '%" + TbBusca.Text + "%'"
        End If
        If cmbTipo2.SelectedItem.ToString.ToUpper.Equals("DESC. PROVEEDOR") Then
            condicion = " T0.CardName LIKE '%" + TbBusca.Text + "%'"
        End If
        Try
            'vacia el listview
            lvTraslados.Items.Clear()

            With lCmd
                .Connection = mCnx
                .CommandType = CommandType.Text
                If TbBusca.Text.Equals(String.Empty) Then
                    .CommandText = " SELECT T0.DocNum, T0.DocDate, T0.Filler, T0.CardCode, T0.CardName " & _
                                   " from OWTR T0 " & _
                                   " ORDER BY T0.DocNum "
                Else
                    .CommandText = " SELECT T0.DocNum, T0.DocDate, T0.Filler, T0.CardCode, T0.CardName " & _
                                   " from OWTR T0 " & _
                                   " WHERE " & _
                                   " " + condicion + " " & _
                                   " ORDER BY T0.DocNum "
                End If

                lDR = .ExecuteReader
            End With

            While lDR.Read
                With lvTraslados
                    .Items.Add("")
                    .Items(.Items.Count - 1).SubItems.Add(lDR.Item("DocNum").ToString)
                    .Items(.Items.Count - 1).SubItems.Add(CDate(lDR.Item("DocDate")).ToString("dd/MM/yyyy"))
                    .Items(.Items.Count - 1).SubItems.Add(lDR.Item("Filler").ToString)
                    .Items(.Items.Count - 1).SubItems.Add(lDR.Item("CardCode").ToString)
                    .Items(.Items.Count - 1).SubItems.Add(lDR.Item("CardName").ToString)

                End With
            End While

        Catch ex As Exception
            MessageBox.Show("frmTra1.TrasladosCargar: " & ex.Message)
        Finally
            If Not lDR Is Nothing Then
                lDR.Close()
            End If
            lDR = Nothing
            lCmd = Nothing
            GC.Collect()
        End Try
    End Sub
    Private Sub frmTra1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        If Not mCnx Is Nothing Then
            mCnx.Close()
        End If
        mCnx = Nothing

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

    Private Sub lvTraslados_DockChanged(sender As Object, e As System.EventArgs) Handles lvTraslados.DockChanged

    End Sub

    Private Sub lvTraslados_DoubleClick(sender As Object, e As System.EventArgs) Handles lvTraslados.DoubleClick
        Me.btnAceptar.PerformClick()
    End Sub


    Private Sub lvTraslados_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvTraslados.SelectedIndexChanged
        If lvTraslados.SelectedIndices.Count <> 0 Then
            Dim i As Int16
            For Each i In lvTraslados.SelectedIndices
                TSelTra1.Text = lvTraslados.Items(i).SubItems(1).Text
            Next i
        End If
    End Sub

    Private Sub btnAceptar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If lvTraslados.SelectedIndices.Count <> 0 Then
            Dim i As Int16
            For Each i In lvTraslados.SelectedIndices
                FS_local.TextBox11.Text = lvTraslados.Items(i).SubItems(1).Text
                FS_local.CB3.Checked = True
            Next i
        End If
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub BBuscar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BBuscar.Click
        TrasladosCargar()
    End Sub
End Class