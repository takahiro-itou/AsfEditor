Public Class MciWrapper

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


End Class
