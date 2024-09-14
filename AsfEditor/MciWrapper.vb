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


''========================================================================
''    プロパティプロシージャ
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
''    メンバ関数
''========================================================================

Public Function bindToPictureBox(
        ByVal targetWindow As PictureBox) As Boolean
''--------------------------------------------------------------------
''    指定したピクチャボックスにビューを割り当てる
''--------------------------------------------------------------------
Dim cmd As String
Dim result As Integer
Dim errMsg As String
Dim cs As Drawing.Size

    cmd = "window " & m_aliasName & " handle " & targetWindow.Handle.ToString
    result = sendMciCommand(cmd)
    If result <> 0 Then
        errMsg = getMciError(result)
        bindToPictureBox = False
        Exit Function
    End If

    cs = targetWindow.ClientSize
    cmd = String.Format("put {0} destination at 0 0 {1} {2}",
            m_aliasName, cs.Width, cs.Height)
    result = sendMciCommand(cmd)
    If result <> 0 Then
        errMsg = getMciError(result)
        bindToPictureBox = False
        Exit Function
    End If

    bindToPictureBox = True
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


Public Function openAsfFile() As OpenErrorCode
''--------------------------------------------------------------------
''    ファイルを開く
''--------------------------------------------------------------------
Dim cmd As String
Dim result As Integer
Dim errMsg As String

    If m_aliasName = "" Then
        ' インスタンスが未初期化
        openAsfFile = OpenErrorCode.NOT_INITIALIZED
        Exit Function
    End If

    ' ファイルを開く
    cmd = "open """ + m_asfFileName + """ alias " + m_aliasName
    result = mciSendString(cmd, Nothing, 0, IntPtr.Zero)
    If result <> 0 Then
        openAsfFile = OpenErrorCode.FILE_NOT_FOUND
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


Public Function sendMciCommand(
        ByVal mciCmd As String) As Boolean
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
        ByVal mciCmd As String, ByRef retStr As String) As Boolean
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


End Class
