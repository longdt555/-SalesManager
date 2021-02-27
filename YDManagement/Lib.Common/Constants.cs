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
        public const string PRO_API_SECRET_EG = "PRO_API_SECRET_EG";
        public const string PRO_API_KEY_EG = "PRO_API_SECRET_EG";
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
        #region sucess
        public const string SuccessActiveAccepted = "SUCESS.ACTIVE.ACCEPTED";
        public const string SuccessSendMail = "SUCESS.MAIL.SENT";
        public const string SuccessChangePassword = "SUCESS.CHANGE.PASSWORD";
        public const string SuccessUpdate = "SUCESS.UPDATE";
        public const string SuccessPayment = "SUCESS.PAYMENT";
        #endregion

        #region invalid
        public const string ErrorRegisterUserNameInvalid = "ERROR.REGISTER.USERNAME_INVALID";
        public const string ErrorContainsSpecialCharacter = "ERROR.CONTAINS.SPECIAL_CHARACTER";
        public const string ErrorRegisterEmailInvalid = "ERROR.REGISTER.EMAIL_INVALID";
        public const string ErrorRegisterPasswordInvalid = "ERROR.REGISTER.PASSWORD_INVALID";
        public const string ErrorTokenInvalid = "ERROR.TOKEN.INVALID";
        public const string ErrorTokenExpired = "ERROR.TOKEN.EXPIRED";
        public const string ErrorRegisterPasswordNotMatch = "ERROR.REGISTER.PASSWORD_NOT_MATCH";
        public const string ErrorOutOfStock = "ERROR.ADD.OUT_OF_STOCK";
        public const string ErrorCartEmpty = "ERROR.ADD.CART_EMPTY";
        public const string ErrorTransactionCancelled = "ERROR.TRANSACTION.CANCELLED";
        public const string ErrorTransactionCompleted = "ERROR.TRANSACTION.COMPLETED";
        #endregion

        #region length ckecking
        public const string ErrorTextLengthInvalid = "ERROR.TEXT.LENGTH_2_255";
        public const string ErrorTextMaxLengthInvalid = "ERROR.TEXT.MAX_LENGTH_500";
        #endregion

        #region required
        public const string ErrorRegisterLocationIdRequired = "ERROR.REGISTER.LOCATION_ID_REQUIRED";
        public const string ErrorRegisterBannerIdRequired = "ERROR.REGISTER.BANNER_ID_REQUIRED";
        public const string ErrorRegisterBannerTypeIdRequired = "ERROR.REGISTER.BANNER_TYPE_ID_REQUIRED";
        public const string ErrorRegisterAddressRequired = "ERROR.REGISTER.ADDRESS_REQUIRED";
        public const string ErrorRegisterIdRequired = "ERROR.REGISTER.ID_REQUIRED";
        public const string ErrorRegisterCodeRequired = "ERROR.REGISTER.CODE_REQUIRED";
        public const string ErrorRegisterLocationRequired = "ERROR.REGISTER.LOCATION_REQUIRED";
        public const string ErrorRegisterTitleRequired = "ERROR.REGISTER.TITLE_REQUIRED";
        public const string ErrorCreateUserIdRequired = "ERROR.CREATE.USER_ID_REQUIRED";
        public const string ErrorCreateCardTypeIdRequired = "ERROR.CREATE.CARD_TYPE_ID_REQUIRED";
        public const string ErrorCreateNameRequired = "ERROR.CREATE.NAME_REQUIRED";
        public const string ErrorCreateValueRequired = "ERROR.CREATE.VALUE_REQUIRED";
        public const string ErrorCreateEmailRequired = "ERROR.CREATE.EMAIL_REQUIRED";
        public const string ErrorCreateFirstNameRequired = "ERROR.CREATE.FIRSTNAME_REQUIRED";
        public const string ErrorCreateLastNameRequired = "ERROR.CREATE.LASTNAME_REQUIRED";
        public const string ErrorCreateDateOfBirthRequired = "ERROR.CREATE.DATE_OF_BIRTH_REQUIRED";
        public const string ErrorCreateUserNameRequired = "ERROR.CREATE.USERNAME_REQUIRED";
        public const string ErrorCreateImageRequired = "ERROR.CREATE.IMAGE_REQUIRED";
        public const string ErrorCreateTransferableRequired = "ERROR.CREATE.TRANSFERABLE_REQUIRED";
        public const string ErrorCreateTransferFeeRequired = "ERROR.CREATE.TRANSFER_FEE_REQUIRED";
        public const string ErrorCreateTargetClientRequired = "ERROR.CREATE.TARGET_CLIENT_REQUIRED";
        public const string ErrorCreateExpiredRequired = "ERROR.CREATE.EXPIRED_REQUIRED";
        public const string ErrorCreateActivationDateRequired = "ERROR.CREATE.ACTIVATION_DATE_REQUIRED";
        public const string ErrorCreateDurationRequired = "ERROR.CREATE.DURATION_REQUIRED";
        public const string ErrorCreatePasswordRequired = "ERROR.REGISTER.PASSWORD_REQUIRED";
        public const string ErrorCreateTokenOrPasswordRequired = "ERROR.REGISTER.TOKEN_OR_PASSWORD_REQUIRED";
        public const string ErrorCreateOwnerIdentificationRequired = "ERROR.CREATE.OWNER_IDENTIFICATION_REQUIRED";
        public const string ErrorCreateTokenRequired = "ERROR.CREATE.TOKEN_REQUIRED";
        #endregion

        #region exist
        public const string ErrorCreateNameExist = "ERROR.CREATE.NAME_EXISTS";
        public const string ErrorCreateUserNameExist = "ERROR.CREATE.USERNAME_EXISTS";
        public const string ErrorCreateEmailExist = "ERROR.CREATE.EMAIL_EXISTS";
        public const string ErrorEmailExist = "ERROR.EMAIL_EXISTS";
        public const string ErrorFacebookIdExist = "ERROR.FACEBOOK_ID_EXISTS";
        public const string ErrorCreateRecordExist = "ERROR.CREATE.RECORD_EXISTS";
        public const string ErrorCreateObjectExist = "ERROR.CREATE.OBJECT_EXISTS";
        #endregion

        #region not found
        public const string ObjectNotFound = "OBJECT.NOT_FOUND";
        public const string ErrorTokenNotFound = "ERROR.TOKEN.NOT_FOUND";
        #endregion

        #region permission checking

        public const string Forbidden = "PERMISSION.FORBIDDEN";

        #endregion
    }
}