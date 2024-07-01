using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;

namespace DemoRestAPI.Users.Authentication
{
    public class RsaKeyGenerator
    {
        private readonly IConfiguration _config;
        private readonly RSA rsaKey;
        private static readonly int rsaKeySize = 512;

        public RsaKeyGenerator(IConfiguration config)
        {
            _config = config;
            rsaKey = RSA.Create(rsaKeySize);
        }

        public void GeneratePrivateRsaKey()
        {
            string keyDirectorypath = Path.Combine(Environment.CurrentDirectory, "Keys");
            if (!Directory.Exists(keyDirectorypath))
            {
                Directory.CreateDirectory(keyDirectorypath);
            }

            string privateKeyXml = rsaKey.ToXmlString(true);
            string publicKeyXml = rsaKey.ToXmlString(false);

            using var privateFile = File.Create(Path.Combine(keyDirectorypath, "PrivateKey.xml"));
            using var publicFile = File.Create(Path.Combine(keyDirectorypath, "PublicKey.xml"));

            privateFile.Write(Encoding.UTF8.GetBytes(privateKeyXml));
            publicFile.Write(Encoding.UTF8.GetBytes(publicKeyXml));
        }

        public RsaSecurityKey? GetRsaAudienceSigningKey()
        {
            string path = _config.GetSection("Jwt:PrivateKeyPath").Value;
            if (path == null) return null;

            string xmlKey = File.ReadAllText(path);
            rsaKey.FromXmlString(xmlKey);
            RsaSecurityKey rsaSecurityKey = new RsaSecurityKey(rsaKey);

            return rsaSecurityKey;
        }

        public RsaSecurityKey? GetRsaIssurerSigningKey()
        {
            string path = _config.GetSection("Jwt:PublicKeyPath").Value;
            if (path == null) return null;

            string xmlKey = File.ReadAllText(path);
            rsaKey.FromXmlString(xmlKey);
            RsaSecurityKey rsaSecurityKey = new RsaSecurityKey(rsaKey);

            return rsaSecurityKey;
        }
    }
}
