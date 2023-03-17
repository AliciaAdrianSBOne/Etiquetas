Public Class frmArt1

#Region "Declaraciones privadas"
    Private mCnx As SqlClient.SqlConnection
    Private FS_local As frmSeleccion
#End Region

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If lvArticulos.SelectedIndices.Count <> 0 Then
            Dim i As Int16
            For Each i In lvArticulos.SelectedIndices
                FS_local.TextBox1.Text = lvArticulos.Items(i).SubItems(1).Text
            Next i
        End If
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub frmArt1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.lvArticulos.BringToFront()

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
            cmbTipo2.Items.Add("Descripcion")
            cmbTipo2.Items.Add("Codigo")

            cmbTipo2.SelectedItem = "Descripcion"

            'ArticulosCargar()

        Catch ex As Exception
            MessageBox.Show("frmArt1_Load: " & ex.Message)
        End Try
    End Sub


    Private Sub ArticulosCargar()
        Dim lCmd As New SqlClient.SqlCommand
        Dim lDR As SqlClient.SqlDataReader = Nothing
        Dim condicion As String = String.Empty

        'Condicion de búsqueda
        If cmbTipo2.SelectedItem.ToString.ToUpper.Equals("CODIGO") Then
            condicion = " T0.ItemCode LIKE '%" + TbBusca.Text + "%'"
        ElseIf cmbTipo2.SelectedItem.ToString.ToUpper.Equals("DESCRIPCION") Then
            condicion = " T0.ItemName LIKE '%" + TbBusca.Text + "%'"
        End If

        Try
            'vacia el listview
            lvArticulos.Items.Clear()

            With lCmd
                .Connection = mCnx
                .CommandType = CommandType.Text
                If TbBusca.Text.Equals(String.Empty) Then
                    .CommandText = " SELECT T0.Itemcode,T0.Itemname " & _
                                   " from OITM T0 " & _
                                   " ORDER BY T0.Itemcode "
                Else
                    .CommandText = " SELECT T0.Itemcode,T0.Itemname " & _
                                   " from OITM T0 " & _
                                   " WHERE " & _
                                   " " + condicion + " " & _
                                   " ORDER BY T0.Itemcode "
                End If

                lDR = .ExecuteReader
            End With

            While lDR.Read
                With lvArticulos
                    .Items.Add("")
                    .Items(.Items.Count - 1).SubItems.Add(lDR.Item("Itemcode").ToString)
                    .Items(.Items.Count - 1).SubItems.Add(lDR.Item("Itemname").ToString)
                End With
            End While

        Catch ex As Exception
            MessageBox.Show("frmArt1.ArticulosCargar: " & ex.Message)
        Finally
            If Not lDR Is Nothing Then
                lDR.Close()
            End If
            lDR = Nothing
            lCmd = Nothing
            GC.Collect()
        End Try
    End Sub

    Private Sub frmArt1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        If Not mCnx Is Nothing Then
            mCnx.Close()
        End If
        mCnx = Nothing

    End Sub


    Private Sub TbBusca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbBusca.TextChanged

    End Sub

    Private Sub lvArticulos_DoubleClick(sender As Object, e As System.EventArgs) Handles lvArticulos.DoubleClick
        Me.btnAceptar.PerformClick()
    End Sub


    Private Sub lvArticulos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvArticulos.SelectedIndexChanged
        If lvArticulos.SelectedIndices.Count <> 0 Then
            Dim i As Int16
            For Each i In lvArticulos.SelectedIndices
                TSelArt1.Text = lvArticulos.Items(i).SubItems(1).Text
            Next i
        End If
    End Sub

    Private Sub BBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BBuscar.Click
        ArticulosCargar()
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