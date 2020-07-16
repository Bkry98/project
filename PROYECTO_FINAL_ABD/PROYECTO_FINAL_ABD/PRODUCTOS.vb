Imports System.Data.SqlClient

Public Class PRODUCTOS
    Dim cn As New SqlConnection("Server=(local); DataBase=proyecto_abd; Integrated Security=SSPI")

    Private Sub PRODUCTOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim da As New SqlDataAdapter("productos", cn)
        Dim ds As New DataSet

        da.Fill(ds)
        listprod.DataSource = ds.Tables(0)

    End Sub
    Sub Mostrar()
        Dim da As New SqlDataAdapter("PRODUCTOS", cn)
        Dim ds As New DataSet
        da.Fill(ds)
        listprod.DataSource = ds.Tables(0)
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Mostrar()
    End Sub
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        AgregarProductos.Show()

    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        EliminarProductos.Show()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim da As New SqlDataAdapter("SELECT * FROM PRODUCTO WHERE NOMBRE LIKE '%" & txtBuscar.Text & "%'", cn)
        Dim ds As New DataSet
        cn.Open()
        da.Fill(ds)
        listprod.DataSource = ds.Tables(0)

        cn.Close()
    End Sub
End Class