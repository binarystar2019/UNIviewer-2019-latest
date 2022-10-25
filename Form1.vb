Public Class Form1

    ' IP Webcam, BYOD & OneLAN viewer utility
    ' Guy Tittley @ LTSTS University of Edinburgh = Sept 2022 VS2010
    ' https://github.com/binarystar2019 '

    ' **************************************************************

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Populate ComboBox1, ComboBox2, ComboBox3 and ComboBox4 from four text files at C:\temp\***.txt

        Dim fff1 As String() 'webcams
        Dim fff2 As String() 'onelans
        Dim fff3 As String() 'byod
        Dim fff4 As String() 'mlc plus panels

        fff1 = System.IO.File.ReadAllLines("C:\temp\WEBCAMS.txt")
        Me.ComboBox1.Items.AddRange(fff1)
        If ComboBox1.Text = "" Then
            ComboBox1.Text = "http://"
        End If


        fff2 = System.IO.File.ReadAllLines("C:\temp\ONELANS.txt")
        Me.ComboBox2.Items.AddRange(fff2)
        If ComboBox2.Text = "" Then
            ComboBox2.Text = "http://"
        End If


        fff3 = System.IO.File.ReadAllLines("C:\temp\BYOD.txt")
        Me.ComboBox3.Items.AddRange(fff3)
        If ComboBox3.Text = "" Then
            ComboBox3.Text = "http://"
        End If


        fff4 = System.IO.File.ReadAllLines("C:\temp\MLC.txt")
        Me.ComboBox4.Items.AddRange(fff4)
        If ComboBox4.Text = "" Then
            ComboBox4.Text = "http://"
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' View Webcam in web browser

        Dim LineOfText As String
        Dim urlTextFile() As String ' for future use'

        LineOfText = ComboBox1.Text
        urlTextFile = LineOfText.Split(",")
        Process.Start("https://" + urlTextFile(0))

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' View OneLAN in web browser

        Dim LineOfText2 As String
        Dim urlTextFile() As String

        LineOfText2 = ComboBox2.Text
        urlTextFile = LineOfText2.Split(",")
        Process.Start("https://" + urlTextFile(0))

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' View OneLAN status/screen_snap_shot shot in web browser

        Dim LineOfText2 As String
        Dim urlTextFile() As String
        Dim words() As String

        LineOfText2 = ComboBox2.Text
        urlTextFile = LineOfText2.Split(",")

        words = Split(ComboBox2.Text, ",")

        For n = 0 To UBound(words)
            words(n) = words(n).Trim()
        Next

        words(0) = words(0) & ("/status/screen_snap_shot")

        Process.Start("https://" + words(0))


    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ' Show OneLAN Password

        MessageBox.Show("remote: darw1nonelan / 9999 / whisky ", "OneLAN Password")

    End Sub

    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click
        ' Show Webcam Password

        MessageBox.Show("root: darw1nwebcam / darw1nptzcam", "WebCam Password")

    End Sub

    Private Sub Button6_Click_1(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        ' VIEW BYOD in web browser

        Dim LineOfText3 As String
        Dim urlTextFile() As String

        LineOfText3 = ComboBox3.Text
        urlTextFile = LineOfText3.Split(",")
        ' System.Diagnostics.Process.Start(urlTextFile(0))

        Process.Start("https://" + urlTextFile(0))


    End Sub

    Private Sub Button7_Click_1(sender As System.Object, e As System.EventArgs) Handles Button7.Click
        ' Show BYOD Password

        MessageBox.Show("admin:  darw1nbyod / admin ", "BYOD Password")

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged

    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged

    End Sub

    Private Sub Button8_Click(sender As System.Object, e As System.EventArgs) Handles Button8.Click

        ' run traceroute cmd
        RunCMDCom("dir", "/W", True)

    End Sub

    Public Sub RunCMDCom(command As String, arguments As String, permanent As Boolean)

        Dim TR() As String
        TR = (ComboBox3.Text.Split(","))

        Dim p As Process = New Process()
        Dim pi As ProcessStartInfo = New ProcessStartInfo()
        pi.Arguments = " " + If(permanent = True, "/K", "/C") + " " + "tracert" + " " + TR(0) ' make command string tracert + IP address from ComboBox.3

        ' run traceroute cmd with IP address from ComboBox.3
        pi.FileName = "cmd.exe"
        p.StartInfo = pi
        p.Start()

        ' MessageBox.Show(TR(0), "TraceRT")


    End Sub
    Private Sub Button12_Click(sender As System.Object, e As System.EventArgs) Handles Button12.Click

        ' run traceroute cmd
        RunCMD2Com("dir", "/W", True)

    End Sub

    Public Sub RunCMD2Com(command As String, arguments As String, permanent As Boolean)

        Dim TR2() As String
        TR2 = (ComboBox2.Text.Split(","))

        Dim p As Process = New Process()
        Dim pi As ProcessStartInfo = New ProcessStartInfo()
        pi.Arguments = " " + If(permanent = True, "/K", "/C") + " " + "tracert" + " " + TR2(0) ' make command string tracert + IP address from ComboBox.2

        ' run traceroute cmd with IP address from ComboBox.2
        pi.FileName = "cmd.exe"
        p.StartInfo = pi
        p.Start()

        ' MessageBox.Show(TR2(0), "TraceRT")


    End Sub

    Private Sub Label4_Click(sender As System.Object, e As System.EventArgs) Handles Label4.Click

    End Sub

    Private Sub Button9_Click(sender As System.Object, e As System.EventArgs) Handles Button9.Click
        ' View MLC PLUS WEB CONTROL in web browser - ie + silverlight

        Dim LineOfText9 As String
        Dim urlTextFile() As String
        Dim words() As String

        LineOfText9 = ComboBox4.Text
        ' urlTextFile = LineOfText9.Split(",")

        words = Split(ComboBox4.Text, ",")

        For n = 0 To UBound(words)
            words(n) = words(n).Trim()
        Next

        words(0) = words(0) & ("/web/vtlp/ae881ce2-c22a-49d8-9e67-b2607c419607/vtlp.html") ' 8-4-4-4-12 UUID cert may be different - how generated?? IP and date??  MAC and date??


        Process.Start("https://" + words(0))

        ' /web/vtlp/f13066c9-ffc5-4706-9ebd-37a44f92d125/vtlp.html

        ' Process.Start("https://" + words(0))
        ' check MLC Plus 100 same as MLC Plus 200
        ' check how 8-4-4-4-12 number GUI created


    End Sub

    Private Sub Button10_Click(sender As System.Object, e As System.EventArgs) Handles Button10.Click
        ' Show MLC Plus panel Password

        MessageBox.Show("admin: extron / darw1nmlc", "MLC Plus Password")

    End Sub
      
    Private Sub Button11_Click(sender As System.Object, e As System.EventArgs) Handles Button11.Click

        ' FTP access to OneLAN in web browser

        Dim LineOfText2 As String
        Dim urlTextFile() As String
        Dim words() As String

        LineOfText2 = ComboBox2.Text
        urlTextFile = LineOfText2.Split(",")

        words = Split(ComboBox2.Text, ",")

        For n = 0 To UBound(words)
            words(n) = words(n).Trim()
        Next

        words(0) = ("ftp://") & words(0)

        Process.Start("https://" + words(0))  ' Access OneLAN via FTP in default browser


    End Sub
End Class
