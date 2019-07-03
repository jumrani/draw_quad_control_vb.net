Imports System.Drawing
Public Class Draw_quad
    Dim _edge1 As New Point(0, 0)
    Dim _edge2 As New Point(50, 0)
    Dim _edge3 As New Point(50, 50)
    Dim _edge4 As New Point(0, 50)
    Dim _thickness As Single = 1
    Dim _color As System.Drawing.Color = color.Black
    Dim _control As New Windows.Forms.Control
    Dim sqaurecount As Integer = 0
    ''' <summary>
    ''' Represent the firstpoint of the quad.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property edge1() As Point
        Get
            Return _edge1
        End Get
        Set(ByVal value As Point)
            _edge1 = value
        End Set
    End Property
    ''' <summary>
    ''' Represent the secondpoint of the quad.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property edge2() As Point
        Get
            Return _edge2
        End Get
        Set(ByVal value As Point)
            _edge2 = value
        End Set
    End Property
    ''' <summary>
    ''' Represent the thirdpoint of the quad.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property edge3() As Point
        Get
            Return _edge3
        End Get
        Set(ByVal value As Point)
            _edge3 = value
        End Set
    End Property
    ''' <summary>
    ''' Represent the fourthpoint of the quad.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property edge4() As Point
        Get
            Return _edge4
        End Get
        Set(ByVal value As Point)
            _edge4 = value
        End Set
    End Property
    ''' <summary>
    ''' Reprents the thickness for the line   
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property thickness() As Single
        Get
            Return _thickness
        End Get
        Set(ByVal value As Single)
            _thickness = value
        End Set
    End Property
    ''' <summary>
    ''' Reprents the color for the line   
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property color() As System.Drawing.Color
        Get
            Return _color
        End Get
        Set(ByVal value As System.Drawing.Color)
            _color = value
        End Set
    End Property
    ''' <summary>
    ''' Reprents the  container control  for the line 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Parent_control() As Windows.Forms.Control
        Get
            Return _control
        End Get
        Set(ByVal value As Windows.Forms.Control)
            _control = value
            _control.Controls.Add(Me)
        End Set
    End Property
    Private Sub Draw_quad_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        'sqaurecount is used as in case of simple rectangle or square ,in it 4 will come.
        sqaurecount = 0
        'the below code is done to get all the 4 point of usercontrol and then calculate size and location.
        Dim small_x As Integer = 0
        Dim small_y As Integer = 0
        Dim large_x As Integer = 0
        Dim large_y As Integer = 0
        Dim size_x As Integer = 0
        Dim size_y As Integer = 0
        Dim first_point As New Point(0, 0)
        Dim second_point As New Point(0, 0)
        Dim third_point As New Point(0, 0)
        Dim fourth_point As New Point(0, 0)
        Dim first_end_point As New Point(0, 0)
        Dim second_end_point As New Point(0, 0)
        Dim third_end_point As New Point(0, 0)
        Dim fourth_end_point As New Point(0, 0)
        Dim pointx_list As New List(Of Integer)
        Dim xpoint As Integer() = {edge1.X, edge2.X, edge3.X, edge4.X}
        Dim pointy_list As New List(Of Integer)
        Dim ypoint As Integer() = {edge1.Y, edge2.Y, edge3.Y, edge4.Y}
        pointx_list.AddRange(xpoint)
        pointx_list.Sort()
        pointy_list.AddRange(ypoint)
        pointy_list.Sort()
        small_x = pointx_list(0)
        small_y = pointy_list(0)
        large_x = pointx_list(pointx_list.Count - 1)
        large_y = pointy_list(pointy_list.Count - 1)
        first_point = New Point(small_x, small_y)
        second_point = New Point(large_x, small_y)
        third_point = New Point(large_x, large_y)
        fourth_point = New Point(small_x, large_y)
        Me.Location = first_point
        size_x = Math.Abs(large_x - small_x)
        size_y = Math.Abs(large_y - small_y)
        Me.Size = New Point(size_x + 1, size_y + 1)
        Dim UserList As Point() = {edge1, edge2, edge3, edge4}
        Dim QuadList As Point() = {first_point, second_point, third_point, fourth_point}
        'the below code is done as,if both list QuadList,UserList has same point then square or rectangle will form else some other figure.
        For i = 0 To QuadList.Length - 1
            Dim QuadVal As Point = QuadList(i)
            For j = 0 To UserList.Length - 1
                Dim UserVal As Point = UserList(j)
                If QuadVal = UserVal Then
                    sqaurecount += 1
                End If
            Next
        Next
        If sqaurecount = 4 Then
            'then all the four point are calculated and line is drawn between each of them.
            first_end_point = New Point(0, 0)
            second_end_point = New Point(size_x - 1, 0)
            third_end_point = New Point(size_x - 1, size_y - 1)
            fourth_end_point = New Point(0, size_y - 1)
            GetLine(e, first_end_point, second_end_point)
            _thickness = _thickness - 1
            GetLine(e, second_end_point, third_end_point)
            GetLine(e, third_end_point, fourth_end_point)
            GetLine(e, fourth_end_point, first_end_point)
        Else
            'in case of other figure, all the four point are calculated and line is drawn between each of them.
            first_end_point = New Point(edge1.X - small_x, edge1.Y - small_y)
            second_end_point = New Point(edge2.X - small_x, edge2.Y - small_y)
            third_end_point = New Point(edge3.X - small_x, edge3.Y - small_y)
            fourth_end_point = New Point(edge4.X - small_x, edge4.Y - small_y)
            GetLine(e, first_end_point, second_end_point)
            GetLine(e, second_end_point, third_end_point)
            GetLine(e, third_end_point, fourth_end_point)
            GetLine(e, fourth_end_point, first_end_point)
        End If
    End Sub
    ''' <summary>
    ''' To draw  a line  on the container   
    ''' </summary>
    ''' <param name="e"></param>Reprents the object of the container  
    ''' <param name="StartPoint"></param>Reprents the start point for the line   
    ''' <param name="EndPoint"></param> Reprents the end  point for the line  
    ''' <remarks></remarks>
    Sub GetLine(ByVal e As System.Windows.Forms.PaintEventArgs, ByVal StartPoint As Point, ByVal EndPoint As Point)
        Dim myPen As Pen
        myPen = New Pen(_color, _thickness)
        e.Graphics.DrawLine(myPen, StartPoint, EndPoint)
    End Sub
End Class

