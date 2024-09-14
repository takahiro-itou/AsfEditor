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
''    メンバ変数宣言
''========================================================================

Private m_asfFileName As String
Private m_videoId As Integer
Private m_aliasName As String

Private m_videoLength As Long
Private m_curPosition As Long


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
