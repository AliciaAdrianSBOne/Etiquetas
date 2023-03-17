'15-04-2011. T00956. Seleccionar impresora.
Imports System
Imports System.Drawing.Printing


Public Class frmPrinter


    Private Sub frmPrinter_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Dim NombrImpresora As String = String.Empty
            Dim pd As New PrintDocument
            Dim Impresoras As String

            ' Default printer       
            Dim s_Default_Printer As String = pd.PrinterSettings.PrinterName
            PrinterDefault = s_Default_Printer

            Dim i As Integer = 0


            '' '' '' Deshabilita el Command de cerrar, y no permite que se redimensione _   
            '' '' ''y mueva el formulario   
            ' '' ''Aplicar_Cambios(Me, True, True, True)

            lbPrinterDefault.Text = s_Default_Printer
            lbTickets.Text = PrinterTickets


            ' Asignar lo valores predeterminados
            With lvPrintTickets
                '' Las pruebas serán en modo "detalle"
                '.View = lvwReport
                ' al seleccionar un elemento, seleccionar la línea completa
                .FullRowSelect = True
                ' Mostrar las líneas de la cuadrícula
                .GridLines = True
                ' No permitir la edición automática del texto
                .LabelEdit = False
                ' Permitir múltiple selección
                .MultiSelect = False
                ' Para que al perder el foco,
                ' se siga viendo el que está seleccionado
                .HideSelection = False
            End With

            ' El valor asignado al TAG es para saber que tipo de clasificación
            ' hay que realizar, el ListView siempre los ordena como cadenas
            With lvPrintTickets.Columns.Add("Nombre impresora", 500, HorizontalAlignment.Left)
                .Tag = "Texto"
            End With

            lvPrintTickets.Items.Clear()

            ' Dim x As ListViewItem


            ' recorre las impresoras instaladas   
            For Each Impresoras In PrinterSettings.InstalledPrinters
                lvPrintTickets.Items.Add(Impresoras.ToString)

                i += 1
            Next


        Catch ex As Exception
            Throw New Exception("frmPrinter_Load->" & ex.Message)

        End Try
    End Sub


    Private Sub btTickets_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btTickets.Click

        If lvPrintTickets.SelectedItems.Count > 0 Then
            PrinterTickets = lvPrintTickets.SelectedItems.Item(0).Text
            lbTickets.Text = PrinterTickets

            lvPrintTickets.Items.Item(0).Focused = False

        Else
            MsgBox("Debes seleccionar una impresora.")
        End If

    End Sub


    Private Sub btPrinterDoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If lvPrintTickets.SelectedItems.Count > 0 Then

            PrinterDocuments = lvPrintTickets.SelectedItems.Item(0).Text

        Else
            MsgBox("Debes seleccionar una impresora.")
        End If

    End Sub


    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        If PrinterTickets = "" Then
            MsgBox("Debes seleccionar una impresora para las Etiquetas.")
        Else
            PrinterDocuments = lbPrinterDefault.Text
            Me.Close()
        End If
    End Sub


#Region "Deshabilitar boton de cerrar del formulario. No se está utilizando ya que la propiedad de form ControlBox ya lo hace."

    'Declaraciones del api   
    '------------------------------------------------------   

    ' PAra deshabilitar el menú y otros   
    Private Declare Function DeleteMenu Lib "user32" ( _
        ByVal hMenu As Long, _
        ByVal nPosition As Long, _
        ByVal wFlags As Long) As Long

    ' Obtiene el Handle al menú del sistema de la ventana   
    Private Declare Function GetSystemMenu Lib "user32" ( _
        ByVal hwnd As Long, _
        ByVal bRevert As Long) As Long


    Private Const MF_BYPOSITION As Long = &H400&


    Private Sub Aplicar_Cambios(ByVal El_Formulario As Form, _
                                ByVal Menu_Cerrar As Boolean, _
                                ByVal Redimensionar As Boolean, _
                                ByVal Mover As Boolean)

        Dim Hwnd_Menu As Long

        ' Obtiene el Hwnd del menú para usar con el Api DeleteMenu   
        Hwnd_Menu = GetSystemMenu(Me.Handle.ToString, False)

        ' botón Cerrar   
        If Menu_Cerrar Then
            Call DeleteMenu(Hwnd_Menu, 6, MF_BYPOSITION)
        End If

        'Hace que la ventana no se pueda cambiar de tamaño   
        If Redimensionar Then
            Call DeleteMenu(Hwnd_Menu, 2, MF_BYPOSITION)
        End If

        ' No permite que la ventana se pueda mover   
        If Mover Then
            Call DeleteMenu(Hwnd_Menu, 1, MF_BYPOSITION)
        End If
    End Sub

#End Region

    Private Sub lvPrintTickets_DoubleClick(sender As Object, e As System.EventArgs) Handles lvPrintTickets.DoubleClick
        Me.btTickets.PerformClick()
    End Sub

  
    Private Sub lvPrintTickets_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvPrintTickets.SelectedIndexChanged

    End Sub
End Class