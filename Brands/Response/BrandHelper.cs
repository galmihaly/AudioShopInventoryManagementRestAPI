using DemoRestAPI.Helpers;
using DemoRestAPI.Products.Responses;
using System.Net;

namespace DemoRestAPI.Brands.Response
{
    public static class BrandHelper
    {
        private static readonly string SAVE_SUCCESS_TYPE = "Brand Save Successful";
        private static readonly string SAVE_SUCCESS_MESSAGE = "The brand has been successfully saved to the database!";

        private static readonly string SAVE_FAILED_TYPE = "Brand Save Failed";
        private static readonly string SAVE_FAILED_MESSAGE = "The brand has not been saved to the database!";

        private static readonly string FOUND_SUCCESSFUL_TYPE = "Brand Search Successful";
        private static readonly string FOUND_SUCCESSFUL_MESSAGE = "The brand has been successfully found in the database!";

        private static readonly string FOUND_FAILED_TYPE = "Brand Search Failed";
        private static readonly string FOUND_FAILED_MESSAGE = "The brand has not been found in the database!";

        private static readonly string NOT_EXISTED_TYPE = "Brand Already Exist";
        private static readonly string NOT_EXISTED_MESSAGE = "The brand has already exist in the database!";

        private static readonly string BRAND_LIST_SUCCESS_TYPE = "Brands Read Successful";
        private static readonly string BRAND_LIST_SUCCESS_MESSAGE = "The read of the brand list has been successful!";

        public static BaseResponse GetBaseResponse(BrandEnum e)
        {
            string messageType = "";
            string messageBody = "";
            int statusCode = -1;

            switch (e)
            {
                case BrandEnum.SAVE_SUCCESSFUL:
                    {
                        messageType = SAVE_SUCCESS_TYPE;
                        messageBody = SAVE_SUCCESS_MESSAGE;
                        statusCode = StatusCodes.Status200OK;
                        break;
                    }
                case BrandEnum.SAVE_FAILED:
                    {
                        messageType = SAVE_FAILED_TYPE;
                        messageBody = SAVE_FAILED_MESSAGE;
                        statusCode = StatusCodes.Status400BadRequest;
                        break;
                    }
                case BrandEnum.FOUND_SUCCESSFUL:
                    {
                        messageType = FOUND_SUCCESSFUL_TYPE;
                        messageBody = FOUND_SUCCESSFUL_MESSAGE;
                        statusCode = StatusCodes.Status200OK;
                        break;
                    }
                case BrandEnum.FOUND_FAILED:
                    {
                        messageType = FOUND_FAILED_TYPE;
                        messageBody = FOUND_FAILED_MESSAGE;
                        statusCode = StatusCodes.Status400BadRequest;
                        break;
                    }
                case BrandEnum.EXISTED:
                    {
                        messageType = NOT_EXISTED_TYPE;
                        messageBody = NOT_EXISTED_MESSAGE;
                        statusCode = StatusCodes.Status409Conflict;
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

            return new BaseResponse
            {
                timestamp = DateTime.Now.AddHours(2),
                httpStatusCode = statusCode,
                messageType = messageType,
                messageBody = messageBody
            };
        }

        public static BrandListResponse GetBrandListResponse(BrandEnum e)
        {
            string messageType = "";
            string messageBody = "";
            int statusCode = -1;

            switch (e)
            {
                case BrandEnum.BRAND_LIST_SUCCESS:
                {
                    messageType = BRAND_LIST_SUCCESS_TYPE;
                    messageBody = BRAND_LIST_SUCCESS_MESSAGE;
                    statusCode = StatusCodes.Status200OK;
                    break;
                }
                case BrandEnum.NOT_EXISTED:
                {
                    messageType = NOT_EXISTED_TYPE;
                    messageBody = NOT_EXISTED_MESSAGE;
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

            return new BrandListResponse
            {
                timestamp = DateTime.Now.AddHours(2),
                httpStatusCode = statusCode,
                messageType = messageType,
                messageBody = messageBody,
                brandDetails = null
            };
        }
    }
}
