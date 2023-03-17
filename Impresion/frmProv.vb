Public Class frmProv

#Region "Declaraciones privadas"
    Private mCnx As SqlClient.SqlConnection
    Private FS_local As frmSeleccion
#End Region

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If lvProveedores.SelectedIndices.Count <> 0 Then
            Dim i As Int16
            For Each i In lvProveedores.SelectedIndices
                FS_local.TextBox4.Text = lvProveedores.Items(i).SubItems(1).Text
            Next i
        End If

        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub frmProv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.lvProveedores.BringToFront()

            mCnx = New SqlClient.SqlConnection
            With mCnx
                .ConnectionString = "Persist Security Info=False;" & _
                                    "Data Source = " & Principal.Servidor & "; " & _
                                    "Initial Catalog = " & Principal.empresa1 & "; " & _
                                    "User ID = " & Principal.SQLUser & "; " & _
                                    "Password = " & Principal.SQLPwd & "; "
                .Open()
            End With
            cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            cmbTipo.Items.Add("Descripcion")
            cmbTipo.Items.Add("Codigo")

            cmbTipo.SelectedItem = "Descripcion"

            ProveedoresCargar()

            'btnBuscar.Enabled = False

        Catch ex As Exception
            MessageBox.Show("frmProv_Load: " & ex.Message)
        End Try
    End Sub


    Private Sub ProveedoresCargar()
        Dim lCmd As New SqlClient.SqlCommand
        Dim lDR As SqlClient.SqlDataReader = Nothing
        Dim condicion As String = String.Empty

        'Condicion de búsqueda
        If cmbTipo.SelectedItem.ToString.ToUpper.Equals("CODIGO") Then
            condicion = " AND T0.CardCode LIKE '%" + TbBusca.Text + "%'"
        ElseIf cmbTipo.SelectedItem.ToString.ToUpper.Equals("DESCRIPCION") Then
            condicion = " AND T1.CardName LIKE '%" + TbBusca.Text + "%'"
        End If

        Try
            'vacia el listview
            lvProveedores.Items.Clear()

            With lCmd
                .Connection = mCnx
                .CommandType = CommandType.Text
                If TbBusca.Text.Equals(String.Empty) Then
                    .CommandText = " SELECT distinct(T0.cardcode),T1.Cardname " & _
                                   " from OITM T0 INNER JOIN OCRD T1 ON T1.Cardcode=T0.Cardcode " & _
                                   " WHERE T0.cardcode <> '' " & _
                                   " ORDER BY T0.cardcode "
                Else
                    .CommandText = " SELECT distinct(T0.cardcode),T1.Cardname " & _
                                   " from OITM T0 INNER JOIN OCRD T1 ON T1.Cardcode=T0.Cardcode " & _
                                   " WHERE T0.cardcode <> '' " & _
                                   " " + condicion + " " & _
                                   " ORDER BY T0.cardcode "
                End If

                lDR = .ExecuteReader
            End With

            While lDR.Read
                With lvProveedores
                    .Items.Add("")
                    .Items(.Items.Count - 1).SubItems.Add(lDR.Item("Cardcode").ToString)
                    .Items(.Items.Count - 1).SubItems.Add(lDR.Item("Cardname").ToString)
                End With
            End While

        Catch ex As Exception
            MessageBox.Show("frmProv.ProveedoresCargar: " & ex.Message)
        Finally
            If Not lDR Is Nothing Then
                lDR.Close()
            End If
            lDR = Nothing
            lCmd = Nothing
            GC.Collect()
        End Try
    End Sub

    Private Sub frmProv_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        If Not mCnx Is Nothing Then
            mCnx.Close()
        End If
        mCnx = Nothing

    End Sub


    Private Sub TbBusca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbBusca.TextChanged

    End Sub

    Private Sub lvProveedores_DoubleClick(sender As Object, e As System.EventArgs) Handles lvProveedores.DoubleClick
        Me.btnAceptar.PerformClick()
    End Sub

    Private Sub lvProveedores_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvProveedores.SelectedIndexChanged

        If lvProveedores.SelectedIndices.Count <> 0 Then
            Dim i As Int16
            For Each i In lvProveedores.SelectedIndices
                TSelProv.Text = lvProveedores.Items(i).SubItems(1).Text
            Next i
        End If

    End Sub

    Private Sub BBuscar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BBuscar2.Click
        ProveedoresCargar()
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
End Class