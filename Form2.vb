﻿Imports Microsoft.Win32
'Gestor de Redes Virtuais para Windows 8 e Windows 10'
'Desenvolvido por Emanuel Alves'
'Código fonte disponível em https://github.com/emannxx/Gestor-de-Redes-Virtuais'
Public Class defaultconfig
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Function setValue(ByVal regname As String, ByVal regval As String) As Integer
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\GestorRedesVirtuais", regname, regval)
        Return vbNull
    End Function

    Function getValue(ByVal regname As String) As String
        Dim localvar As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\GestorRedesVirtuais", regname, Nothing)
        Return localvar
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ssiddefault.Text = "" Or pswdefault.Text = "" Then
            MsgBox("Nenhum dos campos 'Nome da Rede' ou 'Password' podem estar vazios. Introduza a configuração pretendida e tente novamente.", MessageBoxIcon.Warning)
        Else
            If Len(pswdefault.Text) < 8 Then
                MsgBox("A password tem de ter mais de 8 caracteres. Tente novamente.", MessageBoxIcon.Warning)

            Else
                setValue("ssidPadrao", ssiddefault.Text)
                setValue("pswPadrao", pswdefault.Text)
            End If
        End If

        If (CheckBox1.Checked = True) Then
            setValue("defaultStartup", "yes")
        Else setValue("defaultStartup", "no")
        End If
        If (CheckBox2.Checked = True) Then
            setValue("autoNetwork", "yes")
        Else setValue("autoNetwork", "no")
        End If
        If (CheckBox3.Checked = True) Then
            setValue("autoUpdate", "yes")
        Else setValue("autoUpdate", "no")
        End If
        If CheckBox4.Checked = True Then
            setValue("showPopup", "yes")
        Else setValue("showPopup", "no")
        End If
        Me.Close()
    End Sub

    Private Sub defaultconfig_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If (getValue("ssidPadrao") Is Nothing And getValue("pswPadrao") Is Nothing) Then
        Else
            ssiddefault.Text = getValue("ssidPadrao")
            pswdefault.Text = getValue("pswPadrao")
        End If
        If (getValue("defaultStartup") = "no") Or (getValue("defaultStartup") = "") Then
            CheckBox1.Checked = False
        Else
            CheckBox1.Checked = True
        End If
        If (getValue("autoNetwork") = "no") Or (getValue("autoNetwork") = "") Then
            CheckBox2.Checked = False
        Else
            CheckBox2.Checked = True
        End If
        If (getValue("autoUpdate") = "no") Or (getValue("autoUpdate") = "") Then
            CheckBox3.Checked = False
        Else
            CheckBox3.Checked = True
        End If

        If getValue("showPopup") = "no" Or getValue("showPopup") = "" Then
            CheckBox4.Checked = False
        Else
            CheckBox4.Checked = True
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            CheckBox1.Checked = True
            CheckBox1.Enabled = False
        ElseIf CheckBox2.Checked = False Then
            CheckBox1.Enabled = True
        End If
    End Sub

    Private Sub CheckBox4_Click(sender As Object, e As EventArgs) Handles CheckBox4.Click
        MsgBox("Esta alteração será refletida na próxima vez que iniciar a aplicação.", MessageBoxIcon.Information)
    End Sub
End Class