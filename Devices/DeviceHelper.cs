using DemoRestAPI.Helpers;
using DemoRestAPI.Models.Response;

namespace DemoRestAPI.Devices
{
    public class DeviceHelper
    {
        private static readonly string FOUND_SUCCESSFUL_TYPE = "Device Search Successful";
        private static readonly string FOUND_SUCCESSFUL_MESSAGE = "The device has been successfully found in the database!";

        private static readonly string FOUND_FAILED_TYPE = "Device Search Failed";
        private static readonly string FOUND_FAILED_MESSAGE = "The device has not been found in the database!";

        public static BaseResponse GetBaseResponse(DeviceEnum e)
        {
            string messageType = "";
            string messageBody = "";
            int statusCode = -1;

            switch (e)
            {
                case DeviceEnum.FOUND_SUCCESSFUL:
                    {
                        messageType = FOUND_SUCCESSFUL_TYPE;
                        messageBody = FOUND_SUCCESSFUL_MESSAGE;
                        statusCode = StatusCodes.Status200OK;
                        break;
                    }
                case DeviceEnum.FOUND_FAILED:
                    {
                        messageType = FOUND_FAILED_TYPE;
                        messageBody = FOUND_FAILED_MESSAGE;
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
    }
}
