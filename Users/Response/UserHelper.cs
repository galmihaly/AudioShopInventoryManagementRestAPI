using DemoRestAPI.Helpers;
using DemoRestAPI.Warehouses;

namespace DemoRestAPI.Users.Response
{
    public class UserHelper
    {
        private static readonly string REGISTER_SUCCESS_TYPE = "User Register Successful";
        private static readonly string REGISTER_SUCCESS_MESSAGE = "The user has been successfully registered to the database!";

        private static readonly string REGISTER_FAILED_TYPE = "User Register Failed";
        private static readonly string REGISTER_FAILED_MESSAGE = "The user has not been registered to the database!";

        private static readonly string LOGIN_SUCCESS_TYPE = "User Authorization Successful";
        private static readonly string LOGIN_SUCCESS_MESSAGE = "The user has been successfully authorized!";

        private static readonly string LOGIN_FAILED_TYPE = "User Authorization Failed";
        private static readonly string LOGIN_FAILED_MESSAGE = "The user has not been authorized!";

        private static readonly string PRINCIPAL_NOT_FOUND_TYPE = "User Principal Found Failed";
        private static readonly string PRINCIPAL_NOT_FOUND_MESSAGE = "The principal of the user has not been found!";

        private static readonly string PRINCIPAL_NAME_NOT_FOUND_TYPE = "User Principal Name Is Empty";
        private static readonly string PRINCIPAL_NAME_NOT_FOUND_MESSAGE = "The principal name of the user has been empty!";

        private static readonly string USER_NOT_FOUND_TYPE = "User Found Failed";
        private static readonly string USER_NOT_FOUND_MESSAGE = "The user has not been found!";

        private static readonly string DEVICE_NOT_FOUND_TYPE = "Device Found Failed";
        private static readonly string DEVICE_NOT_FOUND_MESSAGE = "The device of the user has not been found!";

        private static readonly string WAREHOUSE_NOT_FOUND_TYPE = "Warehouse Found Failed";
        private static readonly string WAREHOUSE_NOT_FOUND_MESSAGE = "The warehouse of the user has not been found!";

        private static readonly string USER_NOT_UPDATED_TYPE = "User Updation Failed";
        private static readonly string USER_NOT_UPDATED_MESSAGE = "The user has not been updated!";

        private static readonly string REFRESHTOKEN_NOT_SAME_TYPE = "User Refresh Token Same Failed";
        private static readonly string REFRESHTOKEN_NOT_SAME_MESSAGE = "The request refresh token is not the same as the refresh token of the searched user in the database!";

        private static readonly string REFRESHTOKEN_NOT_EXPIRED_TYPE = "User Refresh Token Expiration Failed";
        private static readonly string REFRESHTOKEN_NOT_EXPIRED_MESSAGE = "The refresh token of the user has not been expired!";

        private static readonly string REFRESHTOKEN_GENERATION_FAILED_TYPE = "User Refresh Token Generation Failed";
        private static readonly string REFRESHTOKEN_GENERATION_FAILED_MESSAGE = "The refresh token of the user has not been generated!";

        private static readonly string ACCESSTOKEN_GENERATION_FAILED_TYPE = "User Access Token Generation Failed";
        private static readonly string ACCESSTOKEN_GENERATION_FAILED_MESSAGE = "The access token of the user has not been generated!";

        public static BaseResponse GetBaseResponse(UserEnum e)
        {
            string messageType = "";
            string messageBody = "";
            int statusCode = -1;

            switch (e)
            {
                case UserEnum.REGISTER_SUCCESS:
                    {
                        messageType = REGISTER_SUCCESS_TYPE;
                        messageBody = REGISTER_SUCCESS_MESSAGE;
                        statusCode = StatusCodes.Status200OK;
                        break;
                    }
                case UserEnum.REGISTER_FAILED:
                    {
                        messageType = REGISTER_FAILED_TYPE;
                        messageBody = REGISTER_FAILED_MESSAGE;
                        statusCode = StatusCodes.Status400BadRequest;
                        break;
                    }
                case UserEnum.USER_NOT_FOUND:
                    {
                        messageType = USER_NOT_FOUND_TYPE;
                        messageBody = USER_NOT_FOUND_MESSAGE;
                        statusCode = StatusCodes.Status400BadRequest;
                        break;
                    }
                default:
                    {
                        messageType = "";
                        messageBody = "";
                        statusCode = -1;
                        break;
                    }
            }

            return new BaseResponse()
            {
                timestamp = DateTime.Now.AddHours(2),
                httpStatusCode = statusCode,
                messageType = messageType,
                messageBody = messageBody
            };
        }

        public static LoginUserResponse GetLoginUserResponse(UserEnum e)
        {
            string messageType = "";
            string messageBody = "";
            int statusCode = -1;

            switch (e)
            {
                case UserEnum.LOGIN_SUCCESS:
                    {
                        messageType = LOGIN_SUCCESS_TYPE;
                        messageBody = LOGIN_SUCCESS_MESSAGE;
                        statusCode = StatusCodes.Status200OK;
                        break;
                    }
                case UserEnum.LOGIN_FAILED:
                    {
                        messageType = LOGIN_FAILED_TYPE;
                        messageBody = LOGIN_FAILED_MESSAGE;
                        statusCode = StatusCodes.Status401Unauthorized;
                        break;
                    }
                case UserEnum.PRINCIPAL_NOT_FOUND:
                    {
                        messageType = PRINCIPAL_NOT_FOUND_TYPE;
                        messageBody = PRINCIPAL_NOT_FOUND_MESSAGE;
                        statusCode = StatusCodes.Status401Unauthorized;
                        break;
                    }
                case UserEnum.PRINCIPAL_NAME_NOT_FOUND:
                    {
                        messageType = PRINCIPAL_NAME_NOT_FOUND_TYPE;
                        messageBody = PRINCIPAL_NAME_NOT_FOUND_MESSAGE;
                        statusCode = StatusCodes.Status401Unauthorized;
                        break;
                    }
                case UserEnum.USER_NOT_FOUND:
                    {
                        messageType = USER_NOT_FOUND_TYPE;
                        messageBody = USER_NOT_FOUND_MESSAGE;
                        statusCode = StatusCodes.Status401Unauthorized;
                        break;
                    }
                case UserEnum.DEVICE_NOT_FOUND:
                    {
                        messageType = DEVICE_NOT_FOUND_TYPE;
                        messageBody = DEVICE_NOT_FOUND_MESSAGE;
                        statusCode = StatusCodes.Status401Unauthorized;
                        break;
                    }
                case UserEnum.WAREHOUSE_NOT_FOUND:
                    {
                        messageType = WAREHOUSE_NOT_FOUND_TYPE;
                        messageBody = WAREHOUSE_NOT_FOUND_MESSAGE;
                        statusCode = StatusCodes.Status401Unauthorized;
                        break;
                    }
                case UserEnum.USER_NOT_UPDATED:
                    {
                        messageType = USER_NOT_UPDATED_TYPE;
                        messageBody = USER_NOT_UPDATED_MESSAGE;
                        statusCode = StatusCodes.Status401Unauthorized;
                        break;
                    }
                case UserEnum.REFRESHTOKEN_NOT_SAME:
                    {
                        messageType = REFRESHTOKEN_NOT_SAME_TYPE;
                        messageBody = REFRESHTOKEN_NOT_SAME_MESSAGE;
                        statusCode = StatusCodes.Status401Unauthorized;
                        break;
                    }
                case UserEnum.REFRESHTOKEN_NOT_EXPIRED:
                    {
                        messageType = REFRESHTOKEN_NOT_EXPIRED_TYPE;
                        messageBody = REFRESHTOKEN_NOT_EXPIRED_MESSAGE;
                        statusCode = StatusCodes.Status401Unauthorized;
                        break;
                    }
                case UserEnum.REFRESHTOKEN_GENERATION_FAILED:
                    {
                        messageType = REFRESHTOKEN_GENERATION_FAILED_TYPE;
                        messageBody = REFRESHTOKEN_GENERATION_FAILED_MESSAGE;
                        statusCode = StatusCodes.Status401Unauthorized;
                        break;
                    }
                case UserEnum.ACCESSTOKEN_GENERATION_FAILED:
                    {
                        messageType = ACCESSTOKEN_GENERATION_FAILED_TYPE;
                        messageBody = ACCESSTOKEN_GENERATION_FAILED_MESSAGE;
                        statusCode = StatusCodes.Status401Unauthorized;
                        break;
                    }
                default:
                    {
                        messageType = "";
                        messageBody = "";
                        statusCode = -1;
                        break;
                    }
            }

            return new LoginUserResponse()
            {
                timestamp = DateTime.Now.AddHours(2),
                httpStatusCode = statusCode,
                messageType = messageType,
                messageBody = messageBody,
                loginUserDetails = null
            };
        }
    }
}
