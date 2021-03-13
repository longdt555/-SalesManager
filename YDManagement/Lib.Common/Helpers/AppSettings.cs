namespace Lib.Common.Helpers
{
    public class AppSettings
    {
        public string Secret { get; set; }
    }
    public class Jwt
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
    public class EmailSetting
    {
        public string SmtpServer { get; set; }
        public int MailPort { get; set; }
        public bool EnableSsl { get; set; }
        public string MailUserName { get; set; }
        public string MailPassword { get; set; }
    }

    public class SimpleEmailServiceSetting
    {
        public string SenderName { get; set; }
        public string Secret { get; set; }
        public int RefreshTokenTtl { get; set; }
        public string EmailFrom { get; set; }
        public string SmtpHost { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpUser { get; set; }
        public string SmtpPass { get; set; }
    }

    public class AwsProfileName
    {
        public string UserName { get; set; }
        public string BucketName { get; set; }
        public string AwsAccessKey { get; set; }
        public string AwsSecretKey { get; set; }
        public string Region { get; set; }
    }
    public class UploadFolder
    {
        public string Name { get; set; }
    }
    public class NapasSettings
    {
        public string ApiOauthUrl { get; set; }
        public string ApiPaymentUrl { get; set; }
    }

    public class SocialAuthentication
    {
        public string Facebook { get; set; }
        public string Google { get; set; }
    }
}
