Public Module VideoInfo

Public Class InputInfo
    Public sFileName As String
    Public sStartTime As String
    Public sEndTime As String
    Public sTimeDuration As String
    Public bConcat As Boolean
End Class

Public Function getMiliSeconds(ByVal sTimeText As String) As Long
''--------------------------------------------------------------------
''
''--------------------------------------------------------------------
Dim parts1 As String()
Dim parts2 As String()
Dim tpHour As Integer, tpMin As Integer, tpSec As Integer
Dim tpMs As Integer

    parts1 = Strings.Split(sTimeText, ": ", 3, CompareMethod.Binary)
    parts2 = Strings.Split(parts1(2), ". ", 2, CompareMethod.Binary)

    tpHour = CInt(Val(parts1(0)))
    tpMin = CInt(Val(parts1(1)))
    tpSec = CInt(Val(parts2(0)))
    tpMs = CInt(Val(parts2(1)))

    getMiliSeconds = ((tpHour * 60 + tpMin) * 60 + tpSec) * 1000 + tpMs
End Function

Public Function getTimeTextFromMiliSeconds(ByVal msTime As Long) As String
''--------------------------------------------------------------------
''
''--------------------------------------------------------------------
Dim tpMs As Integer
Dim tpSec As Integer, tpMin As Integer, tpHour As Integer
Dim tpQuat As Long

    tpMs = (msTime Mod 1000)
    tpQuat = (msTime \ 1000)

    tpSec = tpQuat Mod 60
    tpQuat = (tpQuat \ 60)

    tpMin = (tpQuat Mod 60)
    tpHour = (tpQuat \ 60)

    getTimeTextFromMiliSeconds = String.Format(
            "{0:00}:{1:00}:{2:00}.{3:000}", tpHour, tpMin, tpSec, tpMs)
End Function

Public Function setTimeInfo(
        ByVal targetInfo As InputInfo,
        ByVal startTime As String,
        ByVal endTime As String) As Boolean
''--------------------------------------------------------------------
''
''--------------------------------------------------------------------
Dim tmStart As Long
Dim tmEnd As Long

    tmStart = getMiliSeconds(startTime)
    tmEnd = getMiliSeconds(endTime)
    If (tmEnd <= tmStart) Then
        setTimeInfo = False
        Exit Function
    End If

    With targetInfo
        .sStartTime = getTimeTextFromMiliSeconds(tmStart)
        .sEndTime = getTimeTextFromMiliSeconds(tmEnd)
        .sTimeDuration = getTimeTextFromMiliSeconds(tmEnd - tmStart)
    End With

    setTimeInfo = True
End Function

End Module
