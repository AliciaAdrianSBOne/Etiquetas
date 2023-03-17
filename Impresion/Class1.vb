Option Strict Off
Option Explicit On

Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class DataGridTextBoxColumnSoloNumeros

    Inherits DataGridTextBoxColumn



    Public Sub New()
        MyBase.New()
        AddHandler Me.TextBox.KeyPress, New System.Windows.Forms.KeyPressEventHandler(AddressOf HandleKeyPress)

    End Sub



    Private Sub HandleKeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        'Aquí puede cambiar el código para que el usuario unicamente presione letras
        'o para cambiar las letras minúsculas por MAYÚSCULAS con el ejemplo siguiente
        'If e.KeyChar.IsLower(e.KeyChar) Then
        '   e.KeyChar.ToUpper(e.KeyChar)
        'End If

        'Ignora la tecla presionada si no es dígito o tecla de control
        If e.KeyChar.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        'Ignora la tecla presionada si el valor es mas grande de cuatro dígitos
        If ((Me.TextBox.Text.Length >= 4) AndAlso Not (e.KeyChar.IsControl(e.KeyChar)) AndAlso Me.TextBox.SelectionLength = 0) Then
            e.Handled = True
        End If

    End Sub

End Class
