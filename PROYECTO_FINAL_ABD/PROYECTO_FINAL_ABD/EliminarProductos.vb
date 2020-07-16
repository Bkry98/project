Imports System.Data.SqlClient
Public Class EliminarProductos
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim Cn As New SqlConnection
        Cn.ConnectionString = "Server= (Local); Database=proyecto_abd; Integrated Security = SSPI"

        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "ELIMINARPRODUCTO"
        cmd.Connection = Cn

        Dim Id As New SqlParameter("@IdProducto", SqlDbType.Char, 5)

        Id.Value = txtId.Text
        cmd.Parameters.Add(Id)

        Cn.Open()

        Dim N As New Integer

        N = cmd.ExecuteNonQuery

        If N = 1 Then
            MsgBox("Registro Eliminado Correctamente", vbInformation)
            txtId.Clear()
            txtId.Focus()
        Else
            Exit Sub
        End If

        Cn.Close()
    End Sub
End Class