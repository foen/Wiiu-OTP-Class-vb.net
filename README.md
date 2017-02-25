# Wiiu-OTP-Class-vb.net
read the wiiu OTP.bin

Dim OTPBIN As New WiiU_OTP(filename)
label.Text = OTPBIN.Wii_common_key

if you need them in bytes use 

    Public Shared Function StringToByteArray(ByVal hex As String) As Byte()
        Return Enumerable.Range(0, hex.Length).Where(Function(x) x Mod 2 = 0).Select(Function(x) Convert.ToByte(hex.Substring(x, 2), 16)).ToArray()
    End Function
