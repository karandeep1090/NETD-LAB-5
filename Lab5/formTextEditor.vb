'Programmer:- KARANDEEP.
'Date :   - July 26, 2019
'File Name :- Lab5
'Description:- Text Editor 


Option Strict On
Imports System.IO

Public Class frmTextEditor

    Private Sub OpenCtrlOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles openToolStripMenuItem.Click
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            Try
                Dim reader As New StreamReader(OpenFileDialog1.FileName)
                txtEditor.Text = reader.ReadToEnd
                reader.Close()
            Catch ex As Exception
                Throw New ApplicationException(ex.ToString)
            End Try
        End If
    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles closeToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub SaveCtrlSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles saveToolStripMenuItem.Click
        Dim saveFile As New SaveFileDialog
        saveFile.Title = "Save File"
        saveFile.CheckPathExists = True
        saveFile.DefaultExt = "txt"
        saveFile.RestoreDirectory = True
        saveFile.Filter = "Text Files (*.txt)|*txt|All files (*.*)|*.*"
        saveFile.FilterIndex = 1
        saveFile.ShowDialog()
        Try
            Dim Write As New StreamWriter(saveFile.FileName)
            Write.Write(txtEditor.Text)
            Write.Close()
        Catch ex As Exception

        End Try


    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles saveAsToolStripMenuItem.Click
        Dim saveFile As New SaveFileDialog
        saveFile.Title = "Save Files"
        saveFile.DefaultExt = "txt"
        saveFile.Filter = "Text Files (*.txt)|*txt|All files (*.*)|*.*"
        saveFile.FilterIndex = 1
        saveFile.RestoreDirectory = True
        If (saveFile.ShowDialog() = DialogResult.OK) Then
            Dim Write As New StreamWriter(saveFile.FileName)
            Write.Write(txtEditor.Text)
            Write.Close()
        End If

    End Sub

    Private Sub VScrollBar1_Scroll(sender As Object, e As ScrollEventArgs)

    End Sub

    Private Sub NewCtrlNToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles newToolStripMenuItem.Click
        Dim nextForm As New frmTextEditor
        nextForm.ShowDialog()
    End Sub

    Private Sub CopyCtrlCToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles copyToolStripMenuItem.Click
        If txtEditor.SelectionLength > 0 Then
            txtEditor.Copy()
        End If
    End Sub

    Private Sub CutCtrlXToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles cutToolStripMenuItem.Click
        If txtEditor.SelectionLength > 0 Then
            txtEditor.Cut()
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles exitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub PasteCtrlVToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles pasteToolStripMenuItem.Click
        txtEditor.Paste()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles aboutToolStripMenuItem.Click
        MsgBox("NETD-2202-01" & vbNewLine _
               & "LAB 5 : Text Editor " & vbNewLine _
               & "KARANDEEP", MsgBoxStyle.OkOnly, "About")
    End Sub
End Class
