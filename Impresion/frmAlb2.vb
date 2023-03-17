Public Class frmAlb2

#Region "Declaraciones privadas"
    Private mCnx As SqlClient.SqlConnection
    Private FS_local As frmSeleccion
#End Region

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If lvAlbaranes.SelectedIndices.Count <> 0 Then
            Dim i As Int16
            For Each i In lvAlbaranes.SelectedIndices
                FS_local.TextBox6.Text = lvAlbaranes.Items(i).SubItems(1).Text
                FS_local.CB1.Checked = True
            Next i
        End If
        Me.Close()
    End Sub

    Private Sub frmAlb2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.lvAlbaranes.BringToFront()

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
            cmbTipo2.Items.Add("Albaran")
            cmbTipo2.Items.Add("Codigo Proveedor")
            cmbTipo2.Items.Add("Desc. Proveedor")

            cmbTipo2.SelectedItem = "Albaran"

        Catch ex As Exception
            MessageBox.Show("frmAlb2_Load: " & ex.Message)
        End Try
    End Sub

    Private Sub AlbaranesCargar()
        Dim lCmd As New SqlClient.SqlCommand
        Dim lDR As SqlClient.SqlDataReader = Nothing
        Dim condicion As String = String.Empty

        'Condicion de búsqueda
        If cmbTipo2.SelectedItem.ToString.ToUpper.Equals("ALBARAN") Then
            condicion = " T0.DocNum LIKE '%" + TbBusca.Text + "%'"
        End If
        If cmbTipo2.SelectedItem.ToString.ToUpper.Equals("CODIGO PROVEEDOR") Then
            condicion = " T0.CardCode LIKE '%" + TbBusca.Text + "%'"
        End If
        If cmbTipo2.SelectedItem.ToString.ToUpper.Equals("DESC. PROVEEDOR") Then
            condicion = " T0.CardName LIKE '%" + TbBusca.Text + "%'"
        End If
        Try
            'vacia el listview
            lvAlbaranes.Items.Clear()

            With lCmd
                .Connection = mCnx
                .CommandType = CommandType.Text
                If TbBusca.Text.Equals(String.Empty) Then
                    .CommandText = " SELECT T0.DocNum, T0.DocDate, T0.CardCode, T0.CardName, T0.DocTotal " & _
                                   " from OPDN T0 " & _
                                   " ORDER BY T0.DocNum "
                Else
                    .CommandText = " SELECT T0.DocNum, T0.DocDate, T0.CardCode, T0.CardName, T0.DocTotal " & _
                                   " from OPDN T0 " & _
                                   " WHERE " & _
                                   " " + condicion + " " & _
                                   " ORDER BY T0.DocNum "
                End If

                lDR = .ExecuteReader
            End With

            While lDR.Read
                With lvAlbaranes
                    .Items.Add("")
                    .Items(.Items.Count - 1).SubItems.Add(lDR.Item("DocNum").ToString)
                    .Items(.Items.Count - 1).SubItems.Add(CDate(lDR.Item("DocDate")).ToString("dd/MM/yyyy"))
                    .Items(.Items.Count - 1).SubItems.Add(lDR.Item("CardCode").ToString)
                    .Items(.Items.Count - 1).SubItems.Add(lDR.Item("CardName").ToString)
                    .Items(.Items.Count - 1).SubItems.Add(String.Format("{0:N}", lDR.Item("DocTotal")))

                End With
            End While

        Catch ex As Exception
            MessageBox.Show("frmAlb2.AlbaranesCargar: " & ex.Message)
        Finally
            If Not lDR Is Nothing Then
                lDR.Close()
            End If
            lDR = Nothing
            lCmd = Nothing
            GC.Collect()
        End Try
    End Sub
    Private Sub frmAlb2_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

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

    Private Sub BBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BBuscar.Click
        AlbaranesCargar()
    End Sub

    Private Sub lvAlbaranes_DoubleClick(sender As Object, e As System.EventArgs) Handles lvAlbaranes.DoubleClick
        Me.btnAceptar.PerformClick()
    End Sub

    Private Sub lvAlbaranes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvAlbaranes.SelectedIndexChanged
        If lvAlbaranes.SelectedIndices.Count <> 0 Then
            Dim i As Int16
            For Each i In lvAlbaranes.SelectedIndices
                TSelAlb2.Text = lvAlbaranes.Items(i).SubItems(1).Text
            Next i
        End If
    End Sub
End Class