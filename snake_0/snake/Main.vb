Imports System.Drawing.Drawing2D

Public Class main
    Private Structure structSnake
        Dim rect As Rectangle
        Dim x As Integer
        Dim y As Integer
    End Structure

    Private Enum Direction
        Rightward
        Downward
        Leftward
        Upward
    End Enum

    ' Set initial snake length to a smaller value
    Private Const INITIAL_SNAKE_RECT_COUNT As Integer = 2

    Private Const COLUMN_COUNT As Integer = 65
    Private Const ROW_COUNT As Integer = 47

    ' all of this called Declare a variable
    Private curRecCount As Integer
    Private rects(,) As Rectangle
    Private isSnakePart(,) As Boolean
    Private snake As Collection
    Private snakeBrush As Brush = New SolidBrush(Color.FromArgb(0, 255, 0))
    Private backBrush As Brush = New SolidBrush(Color.FromArgb(1, 1, 1))
    Private tokenBrush As Brush = New SolidBrush(Color.Red)
    Private curDirection As Direction
    Private buffer As Bitmap
    Private columnCount As Integer
    Private rowCount As Integer
    Private snakePoints As Integer
    Private snakeSpeed As Double
    Private snakeLength As Integer
    Private token As Rectangle
    Private target As Rectangle
    Private secondTarget As Rectangle

    Private appleImage As Image ' Declare a variable to hold the apple image
    Private orangeImage As Image ' Declare a variable to hold the orange image
    Private watermelonImage As Image ' Declare a variable to hold the watermelon image
    Private difficultyForm As DifficultySelectionForm ' Declare difficultyForm variable

    Private Function xyToRectIndex(ByVal X As Integer, ByVal Y As Integer) As Integer
        Return (Y * (columnCount)) + X
    End Function

    Private Sub rectIndexToXY(ByVal Index As Integer, ByRef X As Integer, ByRef Y As Integer)
        X = Index Mod (columnCount)
        Y = Index \ (columnCount)
    End Sub

    Private Sub initSnake()
        Dim x As Integer
        Dim y As Integer
        Dim i As Integer
        Dim index As Integer
        Dim sSnake As structSnake
        snake = New Collection

        x = ((columnCount) - 10) \ 2
        y = ((rowCount) - 6) \ 2

        Dim snakePosition As Point = New Point(x, y)
        index = xyToRectIndex(x, y)

        ' Initialize the snake with the initial length
        For i = 1 To INITIAL_SNAKE_RECT_COUNT
            rectIndexToXY(index + (i - 1), x, y)
            sSnake.rect = rects(x, y)
            sSnake.x = x
            sSnake.y = y
            snake.Add(sSnake)
        Next

        snakeLength = INITIAL_SNAKE_RECT_COUNT
        snakeSpeed = 100
    End Sub

    Private Sub selectRectangles()
        Dim g As Graphics = Graphics.FromImage(My.Resources.back)
        Dim i As Integer
        Dim sSnake As structSnake

        ' Draw the initial snake
        For i = 1 To snake.Count
            sSnake = snake(i)
            g.FillRectangle(snakeBrush, sSnake.rect)
            isSnakePart(sSnake.x, sSnake.y) = True
        Next

        buffer = New Bitmap(My.Resources.back)

        g.Dispose()
        Refresh()
    End Sub

    Private Sub initRectangles()
        Dim i As Integer
        Dim j As Integer

        columnCount = COLUMN_COUNT
        rowCount = ROW_COUNT

        ReDim rects(columnCount, rowCount)
        ReDim isSnakePart(columnCount, rowCount)

        For j = 0 To rowCount
            For i = 0 To columnCount
                rects(i, j) = New Rectangle((i * 10) + 1, (j * 10) + 1, 9, 9)
                isSnakePart(i, j) = False
            Next
        Next

        ss.Items("tss0").Text = "Screen Size: " & CStr(columnCount) & " X " & CStr(rowCount)
    End Sub

    Private Sub initialize()
        appleImage = My.Resources.Resource1.apple
        orangeImage = My.Resources.Resource2.orange
        watermelonImage = My.Resources.Resource3.pakwan

        ' Initialize difficultyForm
        difficultyForm = New DifficultySelectionForm()

        ' Show difficulty selection form
        If difficultyForm.ShowDialog() = DialogResult.OK Then
            Select Case difficultyForm.SelectedDifficulty
                Case "Easy"
                    tmr.Interval = 200 ' Slower speed for easy
                Case "Medium"
                    tmr.Interval = 100 ' Normal speed for medium
                Case "Hard"
                    tmr.Interval = 50 ' Faster speed for hard
            End Select
        Else
            ' Default to medium if the user closes the form without selecting
            tmr.Interval = 100
        End If

        curRecCount = INITIAL_SNAKE_RECT_COUNT
        curDirection = Direction.Leftward
        snakePoints = 0
        initRectangles()
        initSnake()
        selectRectangles()
        setToken()
        setPoints()
        setTarget()
        setSecondTarget()

        ' Set initial speed
        tmr.Enabled = True
    End Sub

    Private Sub setPoints()
        ss.Items("tss3").Text = "Total Points: " & CStr(snakePoints)
    End Sub

    Private Sub setToken()
        Randomize()
        Dim x As Integer
        Dim y As Integer
        Dim g As Graphics = Graphics.FromImage(buffer)

        x = CInt(Rnd() * columnCount)
        Do While x >= columnCount OrElse isSnakePart(x, y)
            x = CInt(Rnd() * columnCount)
        Loop

        y = CInt(Rnd() * rowCount)
        Do While y >= rowCount OrElse isSnakePart(x, y)
            y = CInt(Rnd() * rowCount)
        Loop

        token = rects(x, y)

        ' Select token type based on difficulty level
        If difficultyForm.SelectedDifficulty = "Easy" Then
            g.DrawImage(appleImage, token)
        ElseIf difficultyForm.SelectedDifficulty = "Medium" Then
            g.DrawImage(orangeImage, token)
        ElseIf difficultyForm.SelectedDifficulty = "Hard" Then
            g.DrawImage(watermelonImage, token)
        End If

        Refresh()
        g.Dispose()
    End Sub

    Private Sub setTarget()
        Randomize()
        Dim x As Integer
        Dim y As Integer
        Dim g As Graphics = Graphics.FromImage(buffer)

        x = CInt(Rnd() * columnCount)
        Do While x >= columnCount OrElse isSnakePart(x, y)
            x = CInt(Rnd() * columnCount)
        Loop

        y = CInt(Rnd() * rowCount)
        Do While y >= rowCount OrElse isSnakePart(x, y) OrElse rects(x, y).Equals(token)
            y = CInt(Rnd() * rowCount)
        Loop

        target = rects(x, y)

        ' Draw the target using the orange image
        g.DrawImage(orangeImage, target)

        Refresh()
        g.Dispose()
    End Sub

    Private Sub setSecondTarget()
        Randomize()
        Dim x As Integer
        Dim y As Integer
        Dim g As Graphics = Graphics.FromImage(buffer)

        x = CInt(Rnd() * columnCount)
        Do While x >= columnCount OrElse isSnakePart(x, y)
            x = CInt(Rnd() * columnCount)
        Loop

        y = CInt(Rnd() * rowCount)
        Do While y >= rowCount OrElse isSnakePart(x, y) OrElse rects(x, y).Equals(token) OrElse rects(x, y).Equals(target)
            y = CInt(Rnd() * rowCount)
        Loop

        secondTarget = rects(x, y)

        ' Draw the target using the watermelon image
        g.DrawImage(watermelonImage, secondTarget)

        Refresh()
        g.Dispose()
    End Sub

    Private Sub main_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        initialize()
    End Sub

    Private Sub main_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Down
                If Not (curDirection = Direction.Downward Or curDirection = Direction.Upward) Then
                    curDirection = Direction.Downward
                End If
            Case Keys.Left
                If Not (curDirection = Direction.Leftward Or curDirection = Direction.Rightward) Then
                    curDirection = Direction.Leftward
                End If
            Case Keys.Right
                If Not (curDirection = Direction.Rightward Or curDirection = Direction.Leftward) Then
                    curDirection = Direction.Rightward
                End If
            Case Keys.Up
                If Not (curDirection = Direction.Upward Or curDirection = Direction.Downward) Then
                    curDirection = Direction.Upward
                End If
        End Select
    End Sub

    Private Sub moveSnake()
        ' Check if columnCount and rowCount are valid
        If columnCount <= 0 OrElse rowCount <= 0 Then
            ' Log or handle the error appropriately
            Return
        End If

        Dim sSnake As structSnake
        Dim x As Integer
        Dim y As Integer
        Dim rect As Rectangle = New Rectangle()

        ' Check if buffer is null, create a new bitmap if necessary
        If buffer Is Nothing Then
            Try
                buffer = New Bitmap(columnCount * 10, rowCount * 10)
            Catch ex As Exception
                ' Log or handle the exception appropriately
                Return
            End Try
        End If

        Using g As Graphics = Graphics.FromImage(buffer)
            tmr.Enabled = False

            ' Remove the last snake square.
            sSnake = snake(snake.Count)
            g.FillRectangle(backBrush, sSnake.rect)
            snake.Remove(snake.Count)
            isSnakePart(sSnake.x, sSnake.y) = False

            ' Get the index of the snake's first square.
            sSnake = snake.Item(1)

            x = sSnake.x
            y = sSnake.y

            Select Case curDirection
                Case Direction.Downward
                    y = y + 1
                    If y > rowCount Then y = 0
                Case Direction.Leftward
                    x = x - 1
                    If x < 0 Then x = columnCount
                Case Direction.Rightward
                    x = x + 1
                    If x > columnCount Then x = 0
                Case Direction.Upward
                    y = y - 1
                    If y < 0 Then y = rowCount
            End Select

            If isSnakePart(x, y) Then
                tmr.Enabled = False

                If MessageBox.Show("Game Over!", "Snake", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    initialize()
                    Exit Sub
                Else
                    End
                End If
            End If

            rect = rects(x, y)

            sSnake.x = x
            sSnake.y = y
            sSnake.rect = rect
            isSnakePart(x, y) = True

            g.FillRectangle(snakeBrush, sSnake.rect)
            Me.BackgroundImage = buffer

            ' Add the snake square to the beginning of the collection.
            snake.Add(sSnake, , 1)

            If rects(x, y).Equals(token) Then
                snakePoints += 1
                setPoints()

                ' Only increase length by 1
                sSnake = snake.Item(snake.Count)
                Select Case curDirection
                    Case Direction.Downward
                        sSnake.y -= 1
                    Case Direction.Leftward
                        sSnake.x += 1
                    Case Direction.Rightward
                        sSnake.x -= 1
                    Case Direction.Upward
                        sSnake.y += 1
                End Select

                sSnake.rect = rects(sSnake.x, sSnake.y)
                g.FillRectangle(snakeBrush, sSnake.rect)
                Me.BackgroundImage = buffer
                snake.Add(sSnake, , , snake.Count)
                snakeLength = snake.Count

                tmr.Interval -= 2
                If tmr.Interval < 0 Then tmr.Interval = 1

                snakeSpeed = 100 + (((50 - tmr.Interval) / 50) * 100)

                setToken()
            End If

            ' Check if the snake hits the first target
            If rects(x, y).Equals(target) Then
                snakePoints += 3 ' Add more points for hitting the target
                setPoints()

                ' Add a new section to the snake
                sSnake = snake.Item(snake.Count)
                Select Case curDirection
                    Case Direction.Downward
                        sSnake.y -= 1
                    Case Direction.Leftward
                        sSnake.x += 1
                    Case Direction.Rightward
                        sSnake.x -= 1
                    Case Direction.Upward
                        sSnake.y += 1
                End Select

                sSnake.rect = rects(sSnake.x, sSnake.y)
                g.FillRectangle(snakeBrush, sSnake.rect)
                Me.BackgroundImage = buffer
                snake.Add(sSnake, , , snake.Count)
                snakeLength = snake.Count

                ' Reposition the first target
                setTarget()
            End If

            ' Check if the snake hits the second target
            If rects(x, y).Equals(secondTarget) Then
                snakePoints += 5 ' Add more points for hitting the second target
                setPoints()

                ' Add a new section to the snake
                sSnake = snake.Item(snake.Count)
                Select Case curDirection
                    Case Direction.Downward
                        sSnake.y -= 1
                    Case Direction.Leftward
                        sSnake.x += 1
                    Case Direction.Rightward
                        sSnake.x -= 1
                    Case Direction.Upward
                        sSnake.y += 1
                End Select

                sSnake.rect = rects(sSnake.x, sSnake.y)
                g.FillRectangle(snakeBrush, sSnake.rect)
                Me.BackgroundImage = buffer
                snake.Add(sSnake, , , snake.Count)
                snakeLength = snake.Count

                ' Reposition the second target
                setSecondTarget()
            End If

            Refresh()
            tmr.Enabled = True
        End Using ' Dispose of graphics object
    End Sub

    Private Sub tmr_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr.Tick
        moveSnake()
        Application.DoEvents()
    End Sub
End Class
