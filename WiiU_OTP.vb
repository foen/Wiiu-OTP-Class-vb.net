Imports System.IO
Imports System.Text

Public Class WiiU_OTP
    'Wii keys 
    Private _Wii_Sha1 As String
    Public ReadOnly Property Wii_Sha1() As String
        Get
            Return _Wii_Sha1
        End Get
    End Property

    Private _Wii_common_key As String
    Public ReadOnly Property Wii_common_key() As String
        Get
            Return _Wii_common_key
        End Get
    End Property

    Private _wii_ng_id As String
    Public ReadOnly Property wii_ng_id() As String
        Get
            Return _wii_ng_id
        End Get
    End Property

    Private _wii_ng_priv_key As String
    Public ReadOnly Property wii_ng_priv_key() As String
        Get
            Return _wii_ng_priv_key
        End Get
    End Property

    Private _wii_nand_hmac As String
    Public ReadOnly Property wii_nand_hmac() As String
        Get
            Return _wii_nand_hmac
        End Get
    End Property

    Private _wii_nand_key As String
    Public ReadOnly Property wii_nand_key() As String
        Get
            Return _wii_nand_key
        End Get
    End Property

    Private _wii_rng_key As String
    Public ReadOnly Property wii_rng_key() As String
        Get
            Return _wii_rng_key
        End Get
    End Property

    Private _wii_root_cert_ms_id_0x00000002 As String
    Public ReadOnly Property wii_root_cert_ms_id_0x00000002() As String
        Get
            Return _wii_root_cert_ms_id_0x00000002
        End Get
    End Property

    Private _wii_root_cert_ms_id_0x00000001 As String
    Public ReadOnly Property wii_root_cert_ms_id_0x00000001() As String
        Get
            Return _wii_root_cert_ms_id_0x00000001
        End Get
    End Property

    Private _wii_root_cert_ng_key_id As String
    Public ReadOnly Property wii_root_cert_ng_key_id() As String
        Get
            Return _wii_root_cert_ng_key_id
        End Get
    End Property

    Private _wii_root_cert_ng_signature As String
    Public ReadOnly Property wii_root_cert_ng_signature() As String
        Get
            Return _wii_root_cert_ng_signature
        End Get
    End Property



    'WiiU keys 
    Private _wiiu_starbuck_ancast_key As String
    Public ReadOnly Property wiiu_starbuck_ancast_key() As String
        Get
            Return _wiiu_starbuck_ancast_key
        End Get
    End Property


    Private _vwii_common_key As String
    Public ReadOnly Property vwii_common_key() As String
        Get
            Return _vwii_common_key
        End Get
    End Property

    Private _wiiu_common_key As String
    Public ReadOnly Property wiiu_common_key() As String
        Get
            Return _wiiu_common_key
        End Get
    End Property


    Private _usb_storage_key_seed_encryption_key As String
    Public ReadOnly Property usb_storage_key_seed_encryption_key() As String
        Get
            Return _usb_storage_key_seed_encryption_key
        End Get
    End Property

    Private _encrypt_decrypt_shdd_key As String
    Public ReadOnly Property encrypt_decrypt_shdd_key() As String
        Get
            Return _encrypt_decrypt_shdd_key
        End Get
    End Property

    Private _encryption_key_for_drh_wlan_data As String
    Public ReadOnly Property encryption_key_for_drh_wlan_data() As String
        Get
            Return _encryption_key_for_drh_wlan_data
        End Get
    End Property

    Private _encrypt_decrypt_ssl_rsa_key As String
    Public ReadOnly Property encrypt_decrypt_ssl_rsa_key() As String
        Get
            Return _encrypt_decrypt_ssl_rsa_key
        End Get
    End Property

    Private _otp_version_and_revision As String
    Public ReadOnly Property otp_version_and_revision() As String
        Get
            Return _otp_version_and_revision
        End Get
    End Property

    Private _otp_date_code As String
    Public ReadOnly Property otp_date_code() As String
        Get
            Return _otp_date_code
        End Get
    End Property

    Public Sub New(ByVal Filename As String)
        Using er = New BinaryReader(File.OpenRead(Filename))

            _Wii_Sha1 = Bytes_To_String(er.ReadBytes(20))

            er.BaseStream.Position = &H14
            _Wii_common_key = Bytes_To_String(er.ReadBytes(16))

            er.BaseStream.Position = &H24
            _wii_ng_id = Bytes_To_String(er.ReadBytes(4))
            _wii_ng_priv_key = Bytes_To_String(er.ReadBytes(29))

            er.BaseStream.Position = &H44
            _wii_nand_hmac = Bytes_To_String(er.ReadBytes(20))

            er.BaseStream.Position = &H58
            _wii_nand_key = Bytes_To_String(er.ReadBytes(16))

            er.BaseStream.Position = &H68
            _wii_rng_key = Bytes_To_String(er.ReadBytes(16))

            er.BaseStream.Position = &H300
            _wii_root_cert_ms_id_0x00000002 = Bytes_To_String(er.ReadBytes(4))
            _wii_root_cert_ms_id_0x00000001 = Bytes_To_String(er.ReadBytes(4))
            _wii_root_cert_ng_key_id = Bytes_To_String(er.ReadBytes(4))
            _wii_root_cert_ng_signature = Bytes_To_String(er.ReadBytes(60))

            er.BaseStream.Position = &H120
            _encrypt_decrypt_ssl_rsa_key = Bytes_To_String(er.ReadBytes(60))

            er.BaseStream.Position = &H90
            _wiiu_starbuck_ancast_key = Bytes_To_String(er.ReadBytes(16))
            er.BaseStream.Position = &HD0
            _vwii_common_key = Bytes_To_String(er.ReadBytes(16))
            er.BaseStream.Position = &HE0
            _wiiu_common_key = Bytes_To_String(er.ReadBytes(16))
            er.BaseStream.Position = &H130
            _usb_storage_key_seed_encryption_key = Bytes_To_String(er.ReadBytes(16))

            er.BaseStream.Position = &H190
            _encrypt_decrypt_shdd_key = Bytes_To_String(er.ReadBytes(16))
            er.BaseStream.Position = &H1A0
            _encryption_key_for_drh_wlan_data = Bytes_To_String(er.ReadBytes(16))

            er.BaseStream.Position = &H3E4
            _otp_version_and_revision = Bytes_To_String(er.ReadBytes(4))
            _otp_date_code = Bytes_To_String(er.ReadBytes(4))
        End Using
    End Sub

    Private Function Bytes_To_String(ByVal bytes_Input As Byte()) As String
        Dim strTemp As New StringBuilder(bytes_Input.Length * 2)
        For Each b As Byte In bytes_Input
            strTemp.Append(b.ToString("X02"))
        Next
        Return strTemp.ToString()
    End Function

End Class
