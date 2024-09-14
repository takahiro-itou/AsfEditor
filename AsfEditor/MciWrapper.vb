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


''========================================================================
''    コンストラクタとデストラクタ
''========================================================================


''========================================================================
''    プロパティプロシージャ
''========================================================================


''========================================================================
''    メンバ関数
''========================================================================

Public Sub setFileName(ByVal asfFileName As String)
    m_asfFileName = asfFileName
End Sub

Public Sub setVideoId(ByVal videoId As Integer)
    m_videoId = videoId
    m_aliasName = String.Format("vid{0:000001}", videoId)
End Sub


End Class
