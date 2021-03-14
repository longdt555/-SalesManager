namespace Lib.Common
{
    public static class Constants
    {
        public const string CookieKey = "FLCDigiLinkAPIDBContext_cookiekey";
        public const string CookieName = "FLCDigiLinkAPIDBContext_cookiename";
        #region Delimiter
        public static string Comma = ",";
        #endregion

        public const string UltimateKey = "lu140815";
        public const string ProApiSecretEg = "PRO_API_SECRET_EG";
        public const string ProApiKeyEg = "PRO_API_SECRET_EG";
        #region subscriber status
        public const int ReceiveNews = 1;
        public const int NotReceived = 0;
        #endregion
        #region newsletter
        public const int Sent = 1;
        public const int Unsent = 0;
        #endregion
    }

    public static class BannerLocation
    {
        public const string MixedMain = "Mixed-Main";
        public const string MixedLeft = "Mixed-Left";
        public const string MixedRight = "Mixed-Right";
        public const string Main = "Main";
        public const string Left = "Left";
        public const string Right = "Right";
        public const string Below = "Below";
        public const string Small = "Small";
    }
    public static class TokenType
    {
        public const string Google = "Google";
        public const string Facebook = "Facebook";
    }

    public class MasterData
    {
        public const string ShippingFee = "ShippingFee";
    }

    public static class CardStatus
    {
        public const int Inactive = 0;
        public const int Active = 1;
        public const int Disabled = 2;
    }
    public static class Status
    {
        public const int Inactive = 0;
        public const int Active = 1;
        public const int Locked = 2;
    }
    public static class Action
    {
        public const string Create = "CREATE";
        public const string Update = "UPDATE";
        public const string Delete = "DELETE";
        public const string Get = "GET";
        public const int CreateAndSendEmailNum = 1; // when a newsletter created then the user choose send email for subscribe
    }
    public static class Permission
    {
        public const string Create = "CREATE";
        public const string Update = "UPDATE";
        public const string Delete = "DELETE";
        public const string Get = "GET";
    }
    public static class Roles
    {
        public const string Administrator = "Administrator";
        public const string Editor = "Editor";
        public const string Supporter = "Supporter";
        public const string Client = "Client";
    }

    public static class AppCodeStatus
    {
        #region success
        public const string SuccessActiveAccepted = "SUCCESS.ACTIVE.ACCEPTED";
        public const string SuccessSendMail = "SUCCESS.MAIL.SENT";
        public const string SuccessChangePassword = "SUCCESS.CHANGE.PASSWORD";
        public const string SuccessUpdate = "SUCCESS.UPDATE";
        public const string SuccessPayment = "SUCCESS.PAYMENT";
        #endregion

        #region invalid
        public const string RegisterUserNameInvalid = "ERROR.REGISTER.USERNAME_INVALID";
        public const string ContainsSpecialCharacter = "ERROR.CONTAINS.SPECIAL_CHARACTER";
        public const string RegisterEmailInvalid = "ERROR.REGISTER.EMAIL_INVALID";
        public const string EmailInvalid = "ERROR.EMAIL_INVALID";
        public const string RegisterPasswordInvalid = "ERROR.REGISTER.PASSWORD_INVALID";
        public const string TokenInvalid = "ERROR.TOKEN.INVALID";
        public const string TokenExpired = "ERROR.TOKEN.EXPIRED";
        public const string RegisterPasswordNotMatch = "ERROR.REGISTER.PASSWORD_NOT_MATCH";
        public const string OutOfStock = "ERROR.ADD.OUT_OF_STOCK";
        public const string CartEmpty = "ERROR.ADD.CART_EMPTY";
        public const string TransactionCancelled = "ERROR.TRANSACTION.CANCELLED";
        public const string TransactionCompleted = "ERROR.TRANSACTION.COMPLETED";
        #endregion

        #region length ckecking
        public const string TextLengthInvalid = "ERROR.TEXT.LENGTH_2_255";
        public const string TextMaxLengthInvalid = "ERROR.TEXT.MAX_LENGTH_500";
        #endregion

        #region required
        public const string RegisterLocationIdRequired = "ERROR.REGISTER.LOCATION_ID_REQUIRED";
        public const string RegisterBannerIdRequired = "ERROR.REGISTER.BANNER_ID_REQUIRED";
        public const string RegisterBannerTypeIdRequired = "ERROR.REGISTER.BANNER_TYPE_ID_REQUIRED";
        public const string RegisterAddressRequired = "ERROR.REGISTER.ADDRESS_REQUIRED";
        public const string RegisterIdRequired = "ERROR.REGISTER.ID_REQUIRED";
        public const string RegisterCodeRequired = "ERROR.REGISTER.CODE_REQUIRED";
        public const string RegisterLocationRequired = "ERROR.REGISTER.LOCATION_REQUIRED";
        public const string RegisterTitleRequired = "ERROR.REGISTER.TITLE_REQUIRED";
        public const string CreateUserIdRequired = "ERROR.CREATE.USER_ID_REQUIRED";
        public const string CreateCardTypeIdRequired = "ERROR.CREATE.CARD_TYPE_ID_REQUIRED";
        public const string CreateNameRequired = "ERROR.CREATE.NAME_REQUIRED";
        public const string CreateValueRequired = "ERROR.CREATE.VALUE_REQUIRED";
        public const string CreateEmailRequired = "ERROR.CREATE.EMAIL_REQUIRED";
        public const string EmailRequired = "ERROR.EMAIL_REQUIRED";
        public const string CreateFirstNameRequired = "ERROR.CREATE.FIRSTNAME_REQUIRED";
        public const string CreateLastNameRequired = "ERROR.CREATE.LASTNAME_REQUIRED";
        public const string CreateDateOfBirthRequired = "ERROR.CREATE.DATE_OF_BIRTH_REQUIRED";
        public const string CreateUserNameRequired = "ERROR.CREATE.USERNAME_REQUIRED";
        public const string CreateImageRequired = "ERROR.CREATE.IMAGE_REQUIRED";
        public const string CreateTransferableRequired = "ERROR.CREATE.TRANSFERABLE_REQUIRED";
        public const string CreateTransferFeeRequired = "ERROR.CREATE.TRANSFER_FEE_REQUIRED";
        public const string CreateTargetClientRequired = "ERROR.CREATE.TARGET_CLIENT_REQUIRED";
        public const string CreateExpiredRequired = "ERROR.CREATE.EXPIRED_REQUIRED";
        public const string CreateActivationDateRequired = "ERROR.CREATE.ACTIVATION_DATE_REQUIRED";
        public const string CreateDurationRequired = "ERROR.CREATE.DURATION_REQUIRED";
        public const string CreatePasswordRequired = "ERROR.REGISTER.PASSWORD_REQUIRED";
        public const string PasswordRequired = "ERROR.PASSWORD_REQUIRED";
        public const string CreateTokenOrPasswordRequired = "ERROR.REGISTER.TOKEN_OR_PASSWORD_REQUIRED";
        public const string CreateOwnerIdentificationRequired = "ERROR.CREATE.OWNER_IDENTIFICATION_REQUIRED";
        public const string CreateTokenRequired = "ERROR.CREATE.TOKEN_REQUIRED";
        #endregion

        #region exist
        public const string CreateNameExist = "ERROR.CREATE.NAME_EXISTS";
        public const string CreateUserNameExist = "ERROR.CREATE.USERNAME_EXISTS";
        public const string CreateEmailExist = "ERROR.CREATE.EMAIL_EXISTS";
        public const string EmailExist = "ERROR.EMAIL_EXISTS";
        public const string FacebookIdExist = "ERROR.FACEBOOK_ID_EXISTS";
        public const string CreateRecordExist = "ERROR.CREATE.RECORD_EXISTS";
        public const string CreateObjectExist = "ERROR.CREATE.OBJECT_EXISTS";
        #endregion

        #region not found
        public const string ObjectNotFound = "OBJECT.NOT_FOUND";
        public const string TokenNotFound = "ERROR.TOKEN.NOT_FOUND";
        #endregion

        #region permission checking

        public const string Forbidden = "PERMISSION.FORBIDDEN";

        #endregion
    }
}