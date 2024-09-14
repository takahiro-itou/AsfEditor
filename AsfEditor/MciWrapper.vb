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
    ERR_FAILURE
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
        m_lastError = errMsg
        openAsfFile = OpenErrorCode.FILE_NOT_FOUND
        Exit Function
    End If

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
