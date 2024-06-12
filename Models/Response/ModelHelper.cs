using DemoRestAPI.Categories;
using DemoRestAPI.Categories.Response;
using DemoRestAPI.Helpers;

namespace DemoRestAPI.Models.Response
{
    public class ModelHelper
    {
        private static readonly string SAVE_SUCCESS_TYPE = "Model Save Successful";
        private static readonly string SAVE_SUCCESS_MESSAGE = "The model has been successfully saved to the database!";

        private static readonly string SAVE_FAILED_TYPE = "Model Save Failed";
        private static readonly string SAVE_FAILED_MESSAGE = "The model has not been saved to the database!";

        private static readonly string FOUND_SUCCESSFUL_TYPE = "Model Search Successful";
        private static readonly string FOUND_SUCCESSFUL_MESSAGE = "The model has been successfully found in the database!";

        private static readonly string FOUND_FAILED_TYPE = "Model Search Failed";
        private static readonly string FOUND_FAILED_MESSAGE = "The model has not been found in the database!";

        private static readonly string NOT_EXISTED_TYPE = "Model Already Exist";
        private static readonly string NOT_EXISTED_MESSAGE = "The model has already exist in the database!";

        private static readonly string MODEL_LIST_SUCCESS_TYPE = "Models Read Successful";
        private static readonly string MODEL_LIST_SUCCESS_MESSAGE = "The read of the model list has been successful!";

        public static BaseResponse GetBaseResponse(ModelEnum e)
        {
            string messageType = "";
            string messageBody = "";
            int statusCode = -1;

            switch (e)
            {
                case ModelEnum.SAVE_SUCCESSFUL:
                {
                    messageType = SAVE_SUCCESS_TYPE;
                    messageBody = SAVE_SUCCESS_MESSAGE;
                    statusCode = StatusCodes.Status200OK;
                    break;
                }
                case ModelEnum.SAVE_FAILED:
                {
                    messageType = SAVE_FAILED_TYPE;
                    messageBody = SAVE_FAILED_MESSAGE;
                    statusCode = StatusCodes.Status400BadRequest;
                    break;
                }
                case ModelEnum.FOUND_SUCCESSFUL:
                {
                    messageType = FOUND_SUCCESSFUL_TYPE;
                    messageBody = FOUND_SUCCESSFUL_MESSAGE;
                    statusCode = StatusCodes.Status200OK;
                    break;
                }
                case ModelEnum.FOUND_FAILED:
                {
                    messageType = FOUND_FAILED_TYPE;
                    messageBody = FOUND_FAILED_MESSAGE;
                    statusCode = StatusCodes.Status400BadRequest;
                    break;
                }
                case ModelEnum.EXISTED:
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

        internal static ModelListResponse GetModelListResponse(ModelEnum e)
        {
            string messageType = "";
            string messageBody = "";
            int statusCode = -1;

            switch (e)
            {
                case ModelEnum.MODEL_LIST_SUCCESS:
                {
                    messageType = MODEL_LIST_SUCCESS_TYPE;
                    messageBody = MODEL_LIST_SUCCESS_MESSAGE;
                    statusCode = StatusCodes.Status200OK;
                    break;
                }
                case ModelEnum.NOT_EXISTED:
                {
                    messageType = NOT_EXISTED_TYPE;
                    messageBody = NOT_EXISTED_MESSAGE;
                    statusCode = StatusCodes.Status400BadRequest;
                    break;
                }
            }

            return new ModelListResponse()
            {
                timestamp = DateTime.Now.AddHours(2),
                httpStatusCode = statusCode,
                messageType = messageType,
                messageBody = messageBody,
                modelDetails = null,
            };
        }
    }
}
