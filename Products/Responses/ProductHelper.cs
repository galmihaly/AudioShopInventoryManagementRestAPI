using DemoRestAPI.Helpers;

namespace DemoRestAPI.Products.Responses
{
    public class ProductHelper
    {
        private static readonly string SAVE_SUCCESS_TYPE = "Product Save Successful";
        private static readonly string SAVE_SUCCESS_MESSAGE = "The product has been successfully saved to the database!";

        private static readonly string SAVE_FAILED_TYPE = "Product Save Failed";
        private static readonly string SAVE_FAILED_MESSAGE = "The product has not been saved to the database!";

        private static readonly string EXISTED_TYPE = "Product Already Exist";
        private static readonly string EXISTED_MESSAGE = "The product has already existed in the database!";

        private static readonly string NOT_EXISTED_TYPE = "Product Not Exist";
        private static readonly string NOT_EXISTED_MESSAGE = "The product has not exist in the database!";

        private static readonly string ID_GENERATION_FAILED_TYPE = "Product Id Generation Failed";
        private static readonly string ID_GENERATION_FAILED_MESSAGE = "Something went wrong when the id of product has been created!";

        private static readonly string PORDUCT_LIST_SUCCESS_TYPE = "Products Read Successful";
        private static readonly string PORDUCT_LIST_SUCCESS_MESSAGE = "The read of the product list has been successful!";

        private static readonly string DELETED_SUCCESS_TYPE = "Product Delete Successful";
        private static readonly string DELETED_SUCCESS_MESSAGE = "The product has been deleted successful!";

        private static readonly string DELETED_FAILED_TYPE = "Product Delete Failed";
        private static readonly string DELETED_FAILED_MESSAGE = "The product has not been deleted!";

        public static BaseResponse GetBaseResponse(ProductEnum e)
        {
            string messageType = "";
            string messageBody = "";
            int statusCode = -1;

            switch (e)
            {
                case ProductEnum.SAVE_SUCCESSFUL:
                {
                    messageType = SAVE_SUCCESS_TYPE;
                    messageBody = SAVE_SUCCESS_MESSAGE;
                    statusCode = StatusCodes.Status200OK;
                    break;
                }
                case ProductEnum.SAVE_FAILED:
                {
                    messageType = SAVE_FAILED_TYPE;
                    messageBody = SAVE_FAILED_MESSAGE;
                    statusCode = StatusCodes.Status400BadRequest;
                    break;
                }
                case ProductEnum.EXISTED:
                {
                    messageType = EXISTED_TYPE;
                    messageBody = EXISTED_MESSAGE;
                    statusCode = StatusCodes.Status409Conflict;
                    break;
                }
                case ProductEnum.NOT_EXISTED:
                {
                    messageType = NOT_EXISTED_TYPE;
                    messageBody = NOT_EXISTED_MESSAGE;
                    statusCode = StatusCodes.Status400BadRequest;
                    break;
                }
                case ProductEnum.ID_GENERATION_FAILED:
                {
                    messageType = ID_GENERATION_FAILED_TYPE;
                    messageBody = ID_GENERATION_FAILED_MESSAGE;
                    statusCode = StatusCodes.Status409Conflict;
                    break;
                }
                case ProductEnum.DELETED_SUCCESS:
                {
                    messageType = DELETED_SUCCESS_TYPE;
                    messageBody = DELETED_SUCCESS_MESSAGE;
                    statusCode = StatusCodes.Status409Conflict;
                    break;
                }
                case ProductEnum.DELETED_FAILED:
                {
                    messageType = DELETED_FAILED_TYPE;
                    messageBody = DELETED_FAILED_MESSAGE;
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

        internal static ProductListResponse GetProductListResponse(ProductEnum e)
        {
            string messageType = "";
            string messageBody = "";
            int statusCode = -1;

            switch (e)
            {
                case ProductEnum.PORDUCT_LIST_SUCCESS:
                {
                    messageType = PORDUCT_LIST_SUCCESS_TYPE;
                    messageBody = PORDUCT_LIST_SUCCESS_MESSAGE;
                    statusCode = StatusCodes.Status200OK;
                    break;
                }
                case ProductEnum.NOT_EXISTED:
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

            return new ProductListResponse()
            {
                timestamp = DateTime.Now.AddHours(2),
                httpStatusCode = statusCode,
                messageType = messageType,
                messageBody = messageBody,
                productDetails = null
            };
        }
    }
}
