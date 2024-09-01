Public Module BackEndRunner


Public Function launchProcess(
        ByVal sCommand As String,
        ByVal sArguments As String,
        ByVal workDir As String) As Boolean
''--------------------------------------------------------------------
''
''--------------------------------------------------------------------
Dim readerOut As System.IO.StreamReader
Dim readerErr As System.IO.StreamReader
Dim textOut As String
Dim textErr As String
Dim bResult As Boolean

    Using process As New System.Diagnostics.Process()
        With process
            With .StartInfo
                .Arguments = sArguments
                .CreateNoWindow = True
                .FileName = sCommand
                .RedirectStandardInput = False
                .RedirectStandardError = True
                .RedirectStandardOutput = True
                .UseShellExecute = False
                .WorkingDirectory = workDir
            End With

            .Start()

            readerOut = .StandardOutput
            readerErr = .StandardError
            textOut = readerOut.ReadToEnd()
            textErr = readerErr.ReadToEnd()

            ' txtOutput.Text = output
            .WaitForExit()
            textErr = textErr & .ExitCode & vbCrLf

            If .ExitCode <> 0 Then
                MessageBox.Show(
                    sCommand & vbCrLf & sArguments & vbCrLf &
                    "STDERR: " & vbCrLf & textErr)
                bResult = False
            Else
                bResult = True
            End If
            .Close()
        End With
    End Using

    launchProcess = bResult
End Function


Public Function performVideoEdit(
        ByVal viInputs() As InputInfo,
        ByVal outFile As String,
        ByVal workDir As String) As Boolean
''--------------------------------------------------------------------
''
''--------------------------------------------------------------------
Dim i As Integer, lastInputs As Integer
Dim outWork As String
Dim workFiles() as String
Dim bResult As Boolean

    workDir = uniformDirName(workDir)

    lastInputs = viInputs.Length - 1
    ReDim workFiles(lastInputs)
    For i = 0 To lastInputs
        outWork = workDir & String.Format("Part{0:000}.wmv", i)
        runSegmentCommand(viInputs(i), outWork, workDir)
        workFiles(i) = outWork
    Next

    bResult = runConcatCommand(workFiles, lastInputs, outFile, workDir)
    performVideoEdit = bResult
End Function


Public Function runConcatCommand(
        ByVal workFiles() As String,
        ByVal lastInputs As Integer,
        ByVal outFile As String,
        ByVal workDir As String) As Boolean
''--------------------------------------------------------------------
''
''--------------------------------------------------------------------
Dim i As Integer
Dim sbArgs As System.Text.StringBuilder
Dim str2 As String
Dim enc As System.Text.Encoding
Dim workCatFile As String
Dim bResult As Boolean

    enc = New System.Text.UTF8Encoding(False)
    workCatFile = workDir & "workconcatlist.txt"

    Using sw As New System.IO.StreamWriter(workCatFile, False, enc)
        For i = 0 To lastInputs
            sw.WriteLine("file '" & workFiles(i) & "'")
        Next i
    End Using

    sbArgs = New System.Text.StringBuilder()
    With sbArgs
        .Append("- f concat -accurate_seek -safe 0 -i """)
        .Append(workCatFile)
        .Append("""  -c:v copy -c:a copy -map 0:v -map 0:a")
        .Append("  -y -loglevel verbose  """)
        .Append(outFile)
        .Append("""")
    End With

    str2 = sbArgs.ToString()
    bResult = launchProcess("ffmpeg", str2, workDir)
    runConcatCommand = bResult
End Function


Public Function runSegmentCommand(
        ByVal viSrcInfo As InputInfo, _
        ByVal workOutFile As String, _
        ByVal workDir As String) As Boolean
''--------------------------------------------------------------------
''
''--------------------------------------------------------------------
Dim sbArgs As System.Text.StringBuilder
Dim str2 As String
Dim bResult As Boolean

    sbArgs = New System.Text.StringBuilder()
    With sbArgs
        .Append(" -ss ")
        .Append(viSrcInfo.sStartTime)
        .Append(" -t """)
        .Append(viSrcInfo.sTimeDuration)
        .Append(""" -accurate_seek  -i """)
        .Append(viSrcInfo.sFileName)
        .Append("""  -c:v copy -c:a copy  -avoid_negative_ts make_zero")
        .Append("  -y -loglevel verbose  """)
        .Append(workOutFile)
        .Append("""")
    End With

    str2 = sbArgs.ToString()
    bResult = launchProcess("ffmpeg", str2, workDir)
    runSegmentCommand = launchProcess("ffmpeg", str2, workDir)
End Function


End Module
