using mRemoteNG.Tools;

namespace mRemoteNG.Connection.Protocol
{
	public enum ProtocolType
	{
        [LocalizedAttributes.LocalizedDescription("strRDP")]
        RDP = 0,
        [LocalizedAttributes.LocalizedDescription("strVnc")]
        VNC = 1,
        [LocalizedAttributes.LocalizedDescription("strSsh1")]
        SSH1 = 2,
        [LocalizedAttributes.LocalizedDescription("strSsh2")]
        SSH2 = 3,
        [LocalizedAttributes.LocalizedDescription("strTelnet")]
        Telnet = 4,
        [LocalizedAttributes.LocalizedDescription("strRlogin")]
        Rlogin = 5,
        [LocalizedAttributes.LocalizedDescription("strRAW")]
        RAW = 6,
        [LocalizedAttributes.LocalizedDescription("strHttp")]
        HTTP = 7,
        [LocalizedAttributes.LocalizedDescription("strHttps")]
        HTTPS = 8,
        [LocalizedAttributes.LocalizedDescription("strICA")]
        ICA = 9,
        [LocalizedAttributes.LocalizedDescription("strExtApp")]
        IntApp = 20
	}

	// Citrix ICA 支援已移除 - 保留 enum 定義以維持相容性
	namespace ICA
	{
		public class IcaProtocol
		{
			public enum Defaults
			{
				Port = 1494,
				EncryptionStrength = 0
			}

			public enum EncryptionStrength
			{
				[LocalizedAttributes.LocalizedDescription("strEncBasic")]
				EncrBasic = 1,
				[LocalizedAttributes.LocalizedDescription("strEnc128BitLogonOnly")]
				Encr128BitLogonOnly = 127,
				[LocalizedAttributes.LocalizedDescription("strEnc40Bit")]
				Encr40Bit = 40,
				[LocalizedAttributes.LocalizedDescription("strEnc56Bit")]
				Encr56Bit = 56,
				[LocalizedAttributes.LocalizedDescription("strEnc128Bit")]
				Encr128Bit = 128
			}
		}
	}
}