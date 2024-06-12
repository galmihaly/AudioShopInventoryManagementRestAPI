using DemoRestAPI.Brands;
using DemoRestAPI.Brands.Response;
using DemoRestAPI.Helpers;

namespace DemoRestAPI.Categories.Response
{
    public class CategoryHelper
    {
        private static readonly string SAVE_SUCCESS_TYPE = "Category Save Successful";
        private static readonly string SAVE_SUCCESS_MESSAGE = "The category has been successfully saved to the database!";

        private static readonly string SAVE_FAILED_TYPE = "Category Save Failed";
        private static readonly string SAVE_FAILED_MESSAGE = "The category has not been saved to the database!";

        private static readonly string FOUND_SUCCESSFUL_TYPE = "Category Search Successful";
        private static readonly string FOUND_SUCCESSFUL_MESSAGE = "The category has been successfully found in the database!";

        private static readonly string FOUND_FAILED_TYPE = "Category Search Failed";
        private static readonly string FOUND_FAILED_MESSAGE = "The category has not been found in the database!";

        private static readonly string NOT_EXISTED_TYPE = "Category Already Exist";
        private static readonly string NOT_EXISTED_MESSAGE = "The category has already exist in the database!";

        private static readonly string CATEGORY_LIST_SUCCESS_TYPE = "Categories Read Successful";
        private static readonly string CATEGORY_LIST_SUCCESS_MESSAGE = "The read of the category list has been successful!";

        public static BaseResponse GetBaseResponse(CategoryEnum e)
        {
            string messageType = "";
            string messageBody = "";
            int statusCode = -1;

            switch (e)
            {
                case CategoryEnum.SAVE_SUCCESSFUL:
                {
                    messageType = SAVE_SUCCESS_TYPE;
                    messageBody = SAVE_SUCCESS_MESSAGE;
                    statusCode = StatusCodes.Status200OK;
                    break;
                }
                case CategoryEnum.SAVE_FAILED:
                {
                    messageType = SAVE_FAILED_TYPE;
                    messageBody = SAVE_FAILED_MESSAGE;
                    statusCode = StatusCodes.Status400BadRequest;
                    break;
                }
                case CategoryEnum.FOUND_SUCCESSFUL:
                {
                    messageType = FOUND_SUCCESSFUL_TYPE;
                    messageBody = FOUND_SUCCESSFUL_MESSAGE;
                    statusCode = StatusCodes.Status200OK;
                    break;
                }
                case CategoryEnum.FOUND_FAILED:
                {
                    messageType = FOUND_FAILED_TYPE;
                    messageBody = FOUND_FAILED_MESSAGE;
                    statusCode = StatusCodes.Status400BadRequest;
                    break;
                }
                case CategoryEnum.EXISTED:
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

            return new BaseResponse()
            {
                timestamp = DateTime.Now.AddHours(2),
                httpStatusCode = statusCode,
                messageType = messageType,
                messageBody = messageBody
            };
        }

        public static CategoryListResponse GetCategoryListResponse(CategoryEnum e)
        {
            string messageType = "";
            string messageBody = "";
            int statusCode = -1;

            switch (e)
            {
                case CategoryEnum.CATEGORY_LIST_SUCCESS:
                {
                    messageType = CATEGORY_LIST_SUCCESS_TYPE;
                    messageBody = CATEGORY_LIST_SUCCESS_MESSAGE;
                    statusCode = StatusCodes.Status200OK;
                    break;
                }
                case CategoryEnum.NOT_EXISTED:
                {
                    messageType = NOT_EXISTED_TYPE;
                    messageBody = NOT_EXISTED_MESSAGE;
                    statusCode = StatusCodes.Status400BadRequest;
                    break;
                }
            }

            return new CategoryListResponse()
            {
                timestamp = DateTime.Now.AddHours(2),
                httpStatusCode = statusCode,
                messageType = messageType,
                messageBody = messageBody,
                categoryDetails = null,
            };
        }
    }
}
