using DemoRestAPI.Helpers;
using DemoRestAPI.Models;
using Microsoft.AspNetCore.Http;

namespace DemoRestAPI.Warehouses.Response
{
    public class WarehouseHelper
    {
        private static readonly string SAVE_SUCCESS_TYPE = "Warehouse Save Successful";
        private static readonly string SAVE_SUCCESS_MESSAGE = "The warehouse has been successfully saved to the database!";

        private static readonly string SAVE_FAILED_TYPE = "Warehouse Save Failed";
        private static readonly string SAVE_FAILED_MESSAGE = "The warehouse has not been saved to the database!";

        private static readonly string FOUND_SUCCESSFUL_TYPE = "Warehouse Search Successful";
        private static readonly string FOUND_SUCCESSFUL_MESSAGE = "The warehouse has been successfully found in the database!";

        private static readonly string FOUND_FAILED_TYPE = "Warehouse Search Failed";
        private static readonly string FOUND_FAILED_MESSAGE = "The warehouse has not been found in the database!";

        private static readonly string NOT_EXISTED_TYPE = "Warehouse Already Exist";
        private static readonly string NOT_EXISTED_MESSAGE = "The warehouse has already exist in the database!";

        private static readonly string NOT_INCREMENTED_TYPE = "Warehouse Stock Capacity Incrementaion Failed";
        private static readonly string NOT_INCREMENTED_MESSAGE = "The stock capacity of the warehouse has not been incremented in the database!";

        public static BaseResponse GetBaseResponse(WarehouseEnum e)
        {
            string messageType = "";
            string messageBody = "";
            int statusCode = -1;

            switch (e)
            {
                case WarehouseEnum.SAVE_SUCCESSFUL:
                    {
                        messageType = SAVE_SUCCESS_TYPE;
                        messageBody = SAVE_SUCCESS_MESSAGE;
                        statusCode = StatusCodes.Status200OK;
                        break;
                    }
                case WarehouseEnum.SAVE_FAILED:
                    {
                        messageType = SAVE_FAILED_TYPE;
                        messageBody = SAVE_FAILED_MESSAGE;
                        statusCode = StatusCodes.Status400BadRequest;
                        break;
                    }
                case WarehouseEnum.FOUND_SUCCESSFUL:
                    {
                        messageType = FOUND_SUCCESSFUL_TYPE;
                        messageBody = FOUND_SUCCESSFUL_MESSAGE;
                        statusCode = StatusCodes.Status200OK;
                        break;
                    }
                case WarehouseEnum.FOUND_FAILED:
                    {
                        messageType = FOUND_FAILED_TYPE;
                        messageBody = FOUND_FAILED_MESSAGE;
                        statusCode = StatusCodes.Status400BadRequest;
                        break;
                    }
                case WarehouseEnum.NOT_EXISTED:
                    {
                        messageType = NOT_EXISTED_TYPE;
                        messageBody = NOT_EXISTED_MESSAGE;
                        statusCode = StatusCodes.Status409Conflict;
                        break;
                    }
                case WarehouseEnum.NOT_INCREMENTED:
                    {
                        messageType = NOT_INCREMENTED_TYPE;
                        messageBody = NOT_INCREMENTED_MESSAGE;
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



        public static WareHouseListResponse GetWarehouseListResponse(WarehouseEnum e)
        {
            string messageType = "";
            string messageBody = "";
            int statusCode = -1;

            switch (e)
            {
                case WarehouseEnum.FOUND_SUCCESSFUL:
                    {
                        messageType = FOUND_SUCCESSFUL_TYPE;
                        messageBody = FOUND_SUCCESSFUL_MESSAGE;
                        statusCode = StatusCodes.Status200OK;
                        break;
                    }
                case WarehouseEnum.NOT_EXISTED:
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

            return new WareHouseListResponse()
            {
                timestamp = DateTime.Now.AddHours(2),
                httpStatusCode = statusCode,
                messageType = messageType,
                messageBody = messageBody,
                warehouseDetails = null
            };
        }
    }
}
