Imports System.Data.SqlClient
Public Class AgregarProductos
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnAñadir_Click(sender As Object, e As EventArgs) Handles btnAñadir.Click
        Dim Cn As New SqlConnection
        Cn.ConnectionString = "Server= (Local); Database=proyecto_abd; Integrated Security = SSPI"

        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "INSERTARPRODUCTO"
        cmd.Connection = Cn

        Dim idproducto As New SqlParameter("@idproducto", SqlDbType.Char, 5)
        Dim idcategoria As New SqlParameter("@idcategoria", SqlDbType.VarChar, 100)
        Dim nombre As New SqlParameter("@nombre", SqlDbType.VarChar, 50)
        Dim descripcion As New SqlParameter("@descripcion", SqlDbType.VarChar, 60)
        Dim stock As New SqlParameter("@stock", SqlDbType.Int)
        Dim preciocompra As New SqlParameter("@preciocompra", SqlDbType.Int)
        Dim precioventa As New SqlParameter("@precioventa", SqlDbType.Int)

        idproducto.Value = StrConv(txtId.Text, VbStrConv.Uppercase)
        idcategoria.Value = Val(cmbCategoria.Text)
        nombre.Value = StrConv(txtNombre.Text, VbStrConv.ProperCase)
        descripcion.Value = StrConv(txtDescripcion.Text, VbStrConv.ProperCase)
        stock.Value = Val(txtStock.Text)
        preciocompra.Value = Val(txtPrecCompra.Text)
        precioventa.Value = Val(txtPrecVenta.Text)

        cmd.Parameters.Add(idproducto)
        cmd.Parameters.Add(idcategoria)
        cmd.Parameters.Add(nombre)
        cmd.Parameters.Add(descripcion)
        cmd.Parameters.Add(stock)
        cmd.Parameters.Add(preciocompra)
        cmd.Parameters.Add(precioventa)

        Cn.Open()

        Dim N As New Integer
        N = cmd.ExecuteNonQuery

        If N = 1 Then
            MsgBox("Registro Insertado Correctamente", vbInformation)
            txtId.Clear()
            'txtCategoria.Clear()
            txtNombre.Clear()
            txtDescripcion.Clear()
            txtStock.Clear()
            txtPrecCompra.Clear()
            txtPrecVenta.Clear()
            txtId.Focus()
        Else
            Exit Sub
        End If

        Cn.Close()

    End Sub
End Class