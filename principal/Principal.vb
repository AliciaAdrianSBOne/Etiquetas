
Public Class Principal
    Inherits System.Windows.Forms.Form
    Public Shared CodCompañia As String
    Public Shared CAgente As String
    Public Shared CEmpresa As String
    Public Shared Path As String
    Friend WithEvents btnDescarga As System.Windows.Forms.ToolBarButton
    Public Shared server As String
    Public Shared CuentaDeCaja As String
    Public Shared GruposGRANELL As String
    Public Shared GruposNINGRA As String
    Public Shared bd As String
    Public Shared SapUser As String
    Public Shared SapPwd As String
    Public Shared SQLUser As String
    Public Shared SQLPwd As String
    Public Shared Compañias As ArrayList
    Public Shared licencia As String
    Public Shared AlmCentral As String
    Private Shared VendDesde As Integer
    Private Shared VendHasta As Integer
    Public Shared Seleccion As frmSeleccion

    Public Shared empresa1 As String
    Friend WithEvents mnuAdicional As System.Windows.Forms.MenuItem
    Friend WithEvents btnAdicional As System.Windows.Forms.ToolBarButton

    Public Shared empresaDesde As String
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem6 As System.Windows.Forms.MenuItem
    Friend WithEvents SelImpresora As System.Windows.Forms.MenuItem
    Friend WithEvents btnSep2 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnInventario As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnValidar As System.Windows.Forms.ToolBarButton
    Public Shared empresaHasta As String

#Region " Windows Form Designer generated code "

    Public Sub New()

        MyBase.New()
        '  Conecta()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        CargaConfiguracion()


    End Sub

    Private Sub CargaConfiguracion()
        Try
            Dim lector As IO.StreamReader
            Dim a As String
            a = Application.StartupPath + "\config.cfg"
            lector = New IO.StreamReader(Application.StartupPath + "\config.cfg")

            Servidor = lector.ReadLine
            empresa1 = lector.ReadLine

            BaseDatos = empresa1
            UsuarioSap = lector.ReadLine
            PwdSap = lector.ReadLine
            SQLUser = lector.ReadLine
            SQLPwd = lector.ReadLine
            licencia = lector.ReadLine
            Dim companys As ArrayList
            companys = New ArrayList
            lector.Close()
            Compañias = companys
        Catch ex As Exception
            MessageBox.Show("Principal.CargaConfiguracion: " & ex.Message)
        End Try
    End Sub
    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents Impresion As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents Opciones As System.Windows.Forms.MenuItem
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents ToolBar1 As System.Windows.Forms.ToolBar
    Friend WithEvents imgList As System.Windows.Forms.ImageList
    Friend WithEvents btnSalir As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnHerramientas As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnImpre As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnSep As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolBarButton2 As System.Windows.Forms.ToolBarButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Principal))
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.MenuItem3 = New System.Windows.Forms.MenuItem()
        Me.MenuItem4 = New System.Windows.Forms.MenuItem()
        Me.Impresion = New System.Windows.Forms.MenuItem()
        Me.SelImpresora = New System.Windows.Forms.MenuItem()
        Me.MenuItem5 = New System.Windows.Forms.MenuItem()
        Me.MainMenu1 = New System.Windows.Forms.MainMenu(Me.components)
        Me.MenuItem2 = New System.Windows.Forms.MenuItem()
        Me.MenuItem6 = New System.Windows.Forms.MenuItem()
        Me.ToolBar1 = New System.Windows.Forms.ToolBar()
        Me.btnSalir = New System.Windows.Forms.ToolBarButton()
        Me.btnSep = New System.Windows.Forms.ToolBarButton()
        Me.btnImpre = New System.Windows.Forms.ToolBarButton()
        Me.btnSep2 = New System.Windows.Forms.ToolBarButton()
        Me.btnInventario = New System.Windows.Forms.ToolBarButton()
        Me.btnValidar = New System.Windows.Forms.ToolBarButton()
        Me.imgList = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem3})
        Me.MenuItem1.Text = "&Archivo"
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 0
        Me.MenuItem3.Text = "&Salir"
        '
        'MenuItem4
        '
        Me.MenuItem4.Index = 1
        Me.MenuItem4.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.Impresion, Me.SelImpresora})
        Me.MenuItem4.Text = "&Herramientas"
        '
        'Impresion
        '
        Me.Impresion.Index = 0
        Me.Impresion.Text = "&Impresion Etiquetas"
        '
        'SelImpresora
        '
        Me.SelImpresora.Index = 1
        Me.SelImpresora.Text = "Seleccionar Impresora"
        '
        'MenuItem5
        '
        Me.MenuItem5.Index = -1
        Me.MenuItem5.Text = ""
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1, Me.MenuItem4, Me.MenuItem2})
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 2
        Me.MenuItem2.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem6})
        Me.MenuItem2.Text = "Version"
        '
        'MenuItem6
        '
        Me.MenuItem6.Index = 0
        Me.MenuItem6.Text = "Version"
        '
        'ToolBar1
        '
        Me.ToolBar1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ToolBar1.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnSalir, Me.btnSep, Me.btnImpre, Me.btnSep2, Me.btnInventario, Me.btnValidar})
        Me.ToolBar1.ButtonSize = New System.Drawing.Size(35, 25)
        Me.ToolBar1.DropDownArrows = True
        Me.ToolBar1.ImageList = Me.imgList
        Me.ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar1.Name = "ToolBar1"
        Me.ToolBar1.ShowToolTips = True
        Me.ToolBar1.Size = New System.Drawing.Size(544, 29)
        Me.ToolBar1.TabIndex = 1
        Me.ToolBar1.TabStop = True
        '
        'btnSalir
        '
        Me.btnSalir.ImageIndex = 2
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Tag = "Salir"
        Me.btnSalir.ToolTipText = "Salir"
        '
        'btnSep
        '
        Me.btnSep.Name = "btnSep"
        Me.btnSep.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnImpre
        '
        Me.btnImpre.ImageIndex = 3
        Me.btnImpre.Name = "btnImpre"
        Me.btnImpre.Tag = "Impresion"
        Me.btnImpre.ToolTipText = "Impresion Etiquetas"
        '
        'btnSep2
        '
        Me.btnSep2.Name = "btnSep2"
        Me.btnSep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        Me.btnSep2.Visible = False
        '
        'btnInventario
        '
        Me.btnInventario.ImageIndex = 7
        Me.btnInventario.Name = "btnInventario"
        Me.btnInventario.Tag = "btnInventario"
        Me.btnInventario.ToolTipText = "Inventario diferencial"
        Me.btnInventario.Visible = False
        '
        'btnValidar
        '
        Me.btnValidar.ImageIndex = 6
        Me.btnValidar.Name = "btnValidar"
        Me.btnValidar.Tag = "btnValidar"
        Me.btnValidar.ToolTipText = "Validar inventario"
        Me.btnValidar.Visible = False
        '
        'imgList
        '
        Me.imgList.ImageStream = CType(resources.GetObject("imgList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgList.TransparentColor = System.Drawing.Color.Transparent
        Me.imgList.Images.SetKeyName(0, "")
        Me.imgList.Images.SetKeyName(1, "")
        Me.imgList.Images.SetKeyName(2, "")
        Me.imgList.Images.SetKeyName(3, "")
        Me.imgList.Images.SetKeyName(4, "")
        Me.imgList.Images.SetKeyName(5, "")
        Me.imgList.Images.SetKeyName(6, "")
        Me.imgList.Images.SetKeyName(7, "")
        '
        'Principal
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(544, 401)
        Me.Controls.Add(Me.ToolBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Menu = Me.MainMenu1
        Me.Name = "Principal"
        Me.Text = "Módulo Etiquetas"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region "propiedades configuracion"
    Public Shared Property Servidor()
        Get
            Return server
        End Get
        Set(ByVal Value)
            server = Value
        End Set
    End Property


    Public Shared Property BaseDatos()
        Get
            Return bd
        End Get
        Set(ByVal Value)
            bd = Value
        End Set
    End Property
    Public Shared Property UsuarioSap()
        Get
            Return SapUser
        End Get
        Set(ByVal Value)
            SapUser = Value
        End Set
    End Property
    Public Shared Property PwdSap() As String
        Get
            Return SapPwd
        End Get
        Set(ByVal Value As String)
            SapPwd = Value
        End Set
    End Property
    Public Shared Property ServidorLicencias() As String
        Get
            Return licencia
        End Get
        Set(ByVal Value As String)
            licencia = Value
        End Set
    End Property
    Public Shared Property UserSql() As String
        Get
            Return SQLUser
        End Get
        Set(ByVal Value As String)
            SQLUser = Value
        End Set
    End Property
    Public Shared Property PwdSql() As String
        Get
            Return SQLPwd
        End Get
        Set(ByVal value As String)
            SQLPwd = value
        End Set
    End Property
    Public Shared Property Company() As ArrayList
        Get
            Return Compañias
        End Get
        Set(ByVal value As ArrayList)
            Compañias = value
        End Set
    End Property
#End Region



    Private Sub MenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem3.Click
        Application.Exit()
    End Sub






    Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick
        Select Case e.Button.Tag
            Case "Salir"
                MenuItem3_Click(Nothing, Nothing)
            Case "Impresion"
                Dim lFrm As New frmSeleccion(MODO_IMPRESION)
                lFrm.ShowDialog()
            Case "btnInventario"
                Dim lFrm As New frmSeleccion(MODO_INVENTARIO)
                lFrm.ShowDialog()
            Case "btnValidar"
                Dim lFrm As New frmValidacion()
                lFrm.ShowDialog()
        End Select
    End Sub



    Private Sub Principal_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Version() As String
        Dim mCnx As SqlClient.SqlConnection
        Dim lCmd As New SqlClient.SqlCommand
        Dim lDR As SqlClient.SqlDataReader

        Try

            Version = Application.ProductVersion.Split(".")

            mCnx = New SqlClient.SqlConnection
            With mCnx
                .ConnectionString = "Persist Security Info=False;" & _
                                    "Data Source = " & Principal.Servidor & "; " & _
                                    "Initial Catalog = " & Principal.empresa1 & "; " & _
                                    "User ID = " & Principal.SQLUser & "; " & _
                                    "Password = " & Principal.SQLPwd & "; "
                .Open()
            End With
            With lCmd
                .Connection = mCnx
                .CommandType = CommandType.Text
                .CommandText = "SELECT * FROM [@OPNVERSION]"
                lDR = .ExecuteReader
            End With

            Dim VersionOk As Boolean = True

            If lDR.Read Then
                If Version(0) < lDR.Item("P3_Imp_Exp_V0") Then
                    VersionOk = False
                Else
                    If Version(0) > lDR.Item("P3_Imp_Exp_V0") Then
                        Exit Sub
                    End If
                End If
                If Version(1) < lDR.Item("P3_Imp_Exp_V1") Then
                    VersionOk = False
                Else
                    If Version(1) > lDR.Item("P3_Imp_Exp_V1") Then
                        Exit Sub
                    End If
                End If
                If Version(2) < lDR.Item("P3_Imp_Exp_V2") Then
                    VersionOk = False
                Else
                    If Version(2) > lDR.Item("P3_Imp_Exp_V2") Then
                        Exit Sub
                    End If
                End If
                If Version(3) < lDR.Item("P3_Imp_Exp_V3") Then
                    VersionOk = False
                Else
                    If Version(3) > lDR.Item("P3_Imp_Exp_V3") Then
                        Exit Sub
                    End If
                End If
                If Not VersionOk Then
                    MsgBox("Su versión está caducada, por favor actualicela y vuelva a ejecutar la aplicación", MsgBoxStyle.Critical)
                    End
                End If
            Else
                MsgBox("No se ha encontrado información acerca de la versión. Puede que la ejecución no sea correcta")
            End If

        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        Finally
            mCnx = Nothing
        End Try


        SeleccionarImpresoras()



    End Sub

    Private Sub MenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem6.Click
        MsgBox("Versión:" & Application.ProductVersion, MsgBoxStyle.Information)


    End Sub

    Private Sub Impresion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Impresion.Click
        Dim lFrm As New frmSeleccion(MODO_IMPRESION)
        lFrm.ShowDialog()
    End Sub

    Private Sub SelImpresora_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelImpresora.Click

        SeleccionarImpresoras()

    End Sub

    Public Sub SeleccionarImpresoras()
        Try
            Dim frmPrint As New frmPrinter
            frmPrint.ShowDialog()
        Catch ex As Exception
            Throw New Exception("SeleccionarImpresoras->" & ex.Message)
        End Try
    End Sub

    Private Sub mnuInventario_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim lFrm As New frmSeleccion(MODO_INVENTARIO)
        lFrm.ShowDialog()
    End Sub
End Class
