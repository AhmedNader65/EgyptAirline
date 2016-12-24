
Public Structure hagz

    Dim trip_no As Integer
    Dim trip_date As String
    Dim trip_time As String
    Dim arrive_time As String
    Dim city As String
    Dim city1 As String

    <VBFixedArray(149)> Dim seat() As Integer
    <VBFixedArray(149)> Dim passenger() As String
    <VBFixedArray(149)> Dim phone() As String
    <VBFixedArray(149)> Dim address() As String

End Structure
Public Class Form1

    Dim buttons(149) As Button
    Dim i, j, z, x, s As Integer
    Dim position As Integer
    Dim m, n, l As String
    Public prec As hagz
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FileOpen(1, "c:asmaa.txt", OpenMode.Random, , , Len(prec))
        prec.seat = New Integer(149) {}
        prec.passenger = New String(149) {}
        prec.phone = New String(149) {}
        prec.address = New String(149) {}
        Label1.Text = Now()
        For i = 1 To 150
            buttons(i - 1) = Me.Controls("button" & i)
            AddHandler buttons(i - 1).Click, AddressOf seat_no
        Next
    End Sub
    Private Sub newTrip(sender As Object, e As EventArgs) Handles Button152.Click
        position = Loc(1)
        Seek(1, Val(TextBox1.Text))
        prec.trip_no = Val(TextBox1.Text)
        prec.trip_date = TextBox2.Text
        prec.trip_time = TextBox4.Text
        prec.arrive_time = TextBox5.Text
        prec.city = TextBox3.Text
        prec.city1 = TextBox6.Text

        For i = 0 To 149
            prec.seat(i) = 0
            prec.passenger(i) = "0"
            prec.phone(i) = "0"
            prec.address(i) = "0"
        Next
        s = Val(TextBox1.Text)
        FilePut(1, prec, s)
        clear()

    End Sub
    Private Sub Book(sender As Object, e As EventArgs) Handles Button153.Click

        view()
        x = MsgBox("هل تريد حجز هذا الكرسى", MsgBoxStyle.OkCancel)
        If x = 1 Then
            buttons(j).BackColor = Color.Orange
            z = 1
            FileGet(1, prec, Val(TextBox1.Text))
            prec.seat(j) = z
            prec.passenger(j) = TextBox7.Text
            prec.phone(j) = TextBox8.Text
            prec.address(j) = TextBox9.Text
            s = Val(TextBox1.Text)
            FilePut(1, prec, s)

        ElseIf x = 2 Then
            buttons(j).BackColor = Color.Lime
            Exit Sub
        End If
        clear2()

    End Sub
    Private Sub ConfirmBook(sender As Object, e As EventArgs) Handles Button154.Click

        view()
        If z = 0 Then
            MsgBox("لم يسبق حجزه")
        ElseIf z = 1 Then
            x = MsgBox("هل تريد تاكيد حجز هذا الكرسي", MsgBoxStyle.OkCancel)
            If x = 1 Then
                buttons(j).BackColor = Color.Red
                z = 2
                FileGet(1, prec, Val(TextBox1.Text))

                prec.seat(j) = z
                s = Val(TextBox1.Text)
                FilePut(1, prec, s)
            ElseIf x = 2 Then
                buttons(j).BackColor = Color.Orange
                Exit Sub
            End If
        End If
        clear2()

    End Sub

    Sub view()
        Try


        FileGet(1, prec, Val(TextBox1.Text))

        Catch ex As Exception
            prec.trip_no = 4324324
        End Try

        If prec.trip_no = Val(TextBox1.Text) Then
            'MsgBox(prec.trip_no & "No trip exists under this number ! " & Val(TextBox1.Text))
            'FileClose(1)
            TextBox2.Text = prec.trip_date
            TextBox3.Text = prec.city
            TextBox4.Text = prec.trip_time
            TextBox5.Text = prec.arrive_time
            TextBox6.Text = prec.city1

            For i = 0 To 149
                If prec.seat(i) = 1 Then
                    buttons(i).BackColor = Color.Orange
                ElseIf prec.seat(i) = 2 Then
                    buttons(i).BackColor = Color.Red
                Else
                    buttons(i).BackColor = Color.Lime
                End If
            Next

            Exit Sub
        Else
            Try

                For i = 0 To 149
                    If prec.seat(i) = 1 Then
                        buttons(i).BackColor = Color.Transparent
                    ElseIf prec.seat(i) = 2 Then
                        buttons(i).BackColor = Color.Transparent
                    Else
                        buttons(i).BackColor = Color.Transparent
                    End If
                Next

            Catch ex As Exception

            End Try
        End If
       
    End Sub
    Public Sub seat_no(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FileGet(1, prec, Val(TextBox1.Text))
        For i = 0 To buttons.Length - 1
            If buttons(i) Is sender Then
                j = i
                Exit For
            End If
        Next
        z = prec.seat(j)
        If z = 0 Then

        Else
            TextBox7.Text = prec.passenger(j)
            TextBox8.Text = prec.phone(j)
            TextBox9.Text = prec.address(j)
        End If

        If j <= 15 Then
            TextBox10.Text = "First class"
        Else
            TextBox10.Text = "Economy class"
        End If

    End Sub
    Private Sub deleteBook(sender As Object, e As EventArgs) Handles Button155.Click

        view()
        If z = 1 Then
            x = MsgBox("هل تريد الغاء حجز هذا الكرسي", MsgBoxStyle.OkCancel)
            If x = 1 Then
                buttons(j).BackColor = Color.Lime
                z = 0
                prec.seat(j) = 0
                prec.passenger(j) = "0"
                prec.phone(j) = "0"
                prec.address(j) = "0"

            ElseIf x = 2 Then
                buttons(j).BackColor = Color.Orange
                Exit Sub
            End If

        ElseIf z = 2 Then
            MsgBox("لا يمكن الغاء حجز هذا الكرسي")
        End If
        clear2()

    End Sub

    Sub clear()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
    End Sub

    Sub clear2()
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
        TextBox10.Clear()
    End Sub

    Private Sub Button141_Click(sender As Object, e As EventArgs) Handles Button156.Click
        Application.Exit()

    End Sub


End Class
