Public Class MciWrapper


''========================================================================
''    API 宣言
''========================================================================

<System.Runtime.InteropServices.DllImport("winmm.dll",
    CharSet:=System.Runtime.InteropServices.CharSet.Auto)>
Private Shared Function mciSendString(
        ByVal lpszCommand As String,
        ByVal lpszReturnString As System.Text.StringBuilder,
        ByVal cchReturn As Integer,
        ByVal hwndCallback As IntPtr) As Integer
End Function

<System.Runtime.InteropServices.DllImport("winmm.dll",
    CharSet:=System.Runtime.InteropServices.CharSet.Auto)>
Private Shared Function mciGetErrorString(
        ByVal fdwError As Integer,
        ByVal lpszErrorText As System.Text.StringBuilder,
        ByVal cchErrorText As Integer) As Integer
End Function


''========================================================================
''    型宣言
''========================================================================

Public Enum OpenErrorCode
    SUCCESS = 0
    FAILURE
    NOT_INITIALIZED
    FILE_NOT_FOUND
End Enum


''========================================================================
''    メンバ変数宣言
''========================================================================

Private m_asfFileName As String
Private m_videoId As Integer
Private m_aliasName As String

Private m_videoLength As Long
Private m_curPosition As Long

Private m_lastError As String


''========================================================================
''    コンストラクタとデストラクタ
''========================================================================

Public Sub New()
    m_asfFileName = ""
    m_videoId = -1
    m_aliasName = ""

    m_videoLength = 0
    m_curPosition = 0
End Sub

Public Sub New(ByVal asfFileName As String)
    MyClass.New()
    setFileName(asfFileName)
    setVideoId(-1)
End Sub

Public Sub New(ByVal asfFileName As String, ByVal videoId As Integer)
    MyClass.New()
    setFileName(asfFileName)
    setVideoId(videoId)
End Sub

''========================================================================
''    プロパティプロシージャ
''========================================================================

Public ReadOnly Property Length() As Long
    Get
        Return  m_videoLength
    End Get
End Property


''========================================================================
''    メンバ関数
''========================================================================

Public Function closeVideo() As Integer
''--------------------------------------------------------------------
''    現在操作しているビデオを閉じる
''--------------------------------------------------------------------
Dim mciCmd As String

    mciCmd = String.Format("close {0}", m_aliasName)
    closeVideo = sendMciCommand(mciCmd)
End Function


Public Function bindToPictureBox(
        ByVal targetWindow As PictureBox) As Boolean
''--------------------------------------------------------------------
''    指定したピクチャボックスにビューを割り当てる
''--------------------------------------------------------------------
Dim mciCmd As String
Dim result As Integer
Dim dsClientSize As Drawing.Size

    mciCmd = String.Format(
                "window {0} handle {1}",
                m_aliasName, targetWindow.Handle.ToString)
    result = sendMciCommand(mciCmd)
    If result <> 0 Then
        bindToPictureBox = False
        Exit Function
    End If

    dsClientSize = targetWindow.ClientSize
    mciCmd = String.Format("put {0} destination at 0 0 {1} {2}",
                m_aliasName, dsClientSize.Width, dsClientSize.Height)
    result = sendMciCommand(mciCmd)
    If result <> 0 Then
        bindToPictureBox = False
        Exit Function
    End If

    bindToPictureBox = True
End Function


Public Function getCurrentPosition() As Long
''--------------------------------------------------------------------
''    ビデオの現在位置を取得する
''--------------------------------------------------------------------
Dim mciCmd As String
Dim ret As Integer
Dim resText As String

    mciCmd = String.Format("status {0} position", m_aliasName)
    resText = ""
    ret = sendMciCommand(mciCmd, resText)
    If ret = 0 Then
        m_videoLength = parseTimeValue(resText)
    End If

    getCurrentPosition = m_videoLength

End Function


Private Function getMciError(ByVal fdwError As Integer) As String
''--------------------------------------------------------------------
''    MCI エラー文字列を取得する
''--------------------------------------------------------------------
Dim textBuf As System.Text.StringBuilder
Dim errorText As String

    textBuf = New System.Text.StringBuilder(512)
    mciGetErrorString(fdwError, textBuf, textBuf.Capacity)
    errorText = textBuf.ToString()
    getMciError = errorText
End Function


Public Function getVideoGuid(ByVal videoId As Integer) As String
''--------------------------------------------------------------------
''    ビデオにユニークな文字列を割り当てる
''--------------------------------------------------------------------
Dim videoGuid As Guid
Dim guidString As String
Dim resultText As String

    videoGuid = System.Guid.NewGuid()
    guidString = videoGuid.ToString()
    If (videoId < 0) Then
        getVideoGuid = guidString
        Exit Function
    End If

    resultText = String.Format("vid{0:000000}-{1}", videoId, guidString)
    getVideoGuid = resultText
End Function


Public Function getVideoLength() As Long
''--------------------------------------------------------------------
''    ビデオの長さを取得する
''--------------------------------------------------------------------
Dim mciCmd As String
Dim ret As Integer
Dim resText As String

    mciCmd = String.Format("status {0} length", m_aliasName)
    resText = ""
    ret = sendMciCommand(mciCmd, resText)
    If ret = 0 Then
        m_videoLength = parseTimeValue(resText)
    End If

    getVideoLength = m_videoLength

End Function


Public Function openAsfFile() As OpenErrorCode
''--------------------------------------------------------------------
''    ファイルを開く
''--------------------------------------------------------------------
Dim mciCmd As String
Dim result As Integer

    If m_aliasName = "" Then
        ' インスタンスが未初期化
        openAsfFile = OpenErrorCode.NOT_INITIALIZED
        Exit Function
    End If

    ' ファイルを開く
    mciCmd = String.Format(
                "open ""{0}"" alias {1}", m_asfFileName, m_aliasName,)

    result = sendMciCommand(mciCmd)
    If result <> 0 Then
        openAsfFile = OpenErrorCode.FILE_NOT_FOUND
        Exit Function
    End If

    ' 時間の単位をミリ秒に設定する
    mciCmd = String.Format( "set {0} time format milliseconds", m_aliasName)
    result = sendMciCommand(mciCmd)
    If result <> 0 Then
        openAsfFile = OpenErrorCode.FAILURE
        Exit Function
    End If

    openAsfFile = OpenErrorCode.SUCCESS
End Function


Public Function openAsfFile(
        ByVal targetWindow As PictureBox) As OpenErrorCode
''--------------------------------------------------------------------
''    ファイルを開く
''--------------------------------------------------------------------
Dim result As OpenErrorCode

    result = openAsfFile()
    If (result <> OpenErrorCode.SUCCESS) Then
        openAsfFile = result
        Exit Function
    End If

    If bindToPictureBox(targetWindow) = False Then
        openAsfFile = OpenErrorCode.FAILURE
        Exit Function
    End If

    openAsfFile = True
End Function


Public Function playVideo() As Integer
''--------------------------------------------------------------------
''    ビデオを再生する
''--------------------------------------------------------------------
Dim cmd As String

    cmd = "play " & m_aliasName
    playVideo = sendMciCommand(cmd)
End Function


Public Function seekVideo(ByVal toPos As Long) As Integer
''--------------------------------------------------------------------
''    再生位置を設定する
''--------------------------------------------------------------------
Dim cmd As String

    cmd = String.Format("seek {0} to {1}", m_aliasName, toPos)
    seekVideo = sendMciCommand(cmd)
End Function


Public Function sendMciCommand(
        ByVal mciCmd As String) As Integer
''--------------------------------------------------------------------
''    MCI コマンド文字列を送信する
''--------------------------------------------------------------------
Dim commandResult As Integer
Dim errMsg As String

    commandResult = mciSendString(mciCmd, Nothing, 0, IntPtr.Zero)

    If commandResult <> 0 Then
        errMsg = getMciError(commandResult)
        m_lastError = m_lastError & vbCrLf
        sendMciCommand = commandResult
        Exit Function
    End If

    sendMciCommand = commandResult
End Function


Public Function sendMciCommand(
        ByVal mciCmd As String, ByRef retStr As String) As Integer
''--------------------------------------------------------------------
''    MCI コマンド文字列を送信し結果を得る
''--------------------------------------------------------------------
Dim commandResult As Integer
Dim textBuf As System.Text.StringBuilder
Dim errMsg As String

    textBuf = New System.Text.StringBuilder(512)
    commandResult = mciSendString(mciCmd, textBuf, textBuf.Capacity, IntPtr.Zero)

    If commandResult <> 0 Then
        errMsg = getMciError(commandResult)
        m_lastError = m_lastError & vbCrLf
        sendMciCommand = commandResult
        Exit Function
    End If

    retStr = textBuf.ToString()
    sendMciCommand = commandResult
End Function


Public Sub setFileName(ByVal asfFileName As String)
''--------------------------------------------------------------------
''    このインスタンスで扱うファイルを指定する
''--------------------------------------------------------------------
    m_asfFileName = asfFileName
End Sub


Public Sub setVideoId(ByVal videoId As Integer)
''--------------------------------------------------------------------
''    このインスタンスで扱うビデオの ID を指定する
''--------------------------------------------------------------------
    m_videoId = videoId
    m_aliasName = getVideoGuid(videoId)
End Sub


Public Function stopVideo() As Integer
''--------------------------------------------------------------------
''    ビデオを停止する
''--------------------------------------------------------------------
Dim cmd As String

    cmd = "stop " & m_aliasName
    stopVideo = sendMciCommand(cmd)
End Function


''========================================================================
''    For Internal Use Only.
''========================================================================

Private Function parseTimeValue(ByVal tvText As String) As Long
''--------------------------------------------------------------------
''
''--------------------------------------------------------------------

    If Not IsNumeric(tvText) Then
        Return  0
    End If

    If Long.Parse(tvText) < 0 Then
        Return ((Long.Parse(tvText) And &H7FFF) + 2 ^ 15)
    End If
    Return  Long.Parse(tvText)

End Function


End Class
