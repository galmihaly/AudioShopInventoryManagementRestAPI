using DemoRestAPI.Helpers;
using DemoRestAPI.Warehouses;
using DemoRestAPI.Warehouses.Response;

namespace DemoRestAPI.Storages.Responses
{
    public class StorageHelper
    {
        private static readonly string SAVE_SUCCESSFUL_TYPE = "Storage Save Succesful";
        private static readonly string SAVE_SUCCESSFUL_MESSAGE = "The storage has been succesfully saved to the database!";

        private static readonly string SAVE_FAILED_TYPE = "Storage Save Failed";
        private static readonly string SAVE_FAILED_MESSAGE = "The storage has not been saved to the database!";

        private static readonly string NOT_EXISTED_TYPE = "Storage Already Exist";
        private static readonly string NOT_EXISTED_MESSAGE = "The storage has already existed in the database!";

        private static readonly string STORAGE_FOUND_FAILED_TYPE = "Storage Search Failed";
        private static readonly string STORAGE_FOUND_FAILED_MESSAGE = "The storage has not been found in the database!";

        private static readonly string WAREHOUSE_FOUND_FAILED_TYPE = "Warehouse Search Failed";
        private static readonly string WAREHOUSE_FOUND_FAILED_MESSAGE = "The warehouse has not been found in the database!";

        private static readonly string FOUND_SUCCESSFUL_TYPE = "Storage Search Successful";
        private static readonly string FOUND_SUCCESSFUL_MESSAGE = "The storage has been successfully found in the database!";

        private static readonly string QUANTITY_INCREASED_FAILED_TYPE = "Storage Quantity Incrementaion Failed";
        private static readonly string QUANTITY_INCREASED_FAILED_MESSAGE = "The quantity of the storage has not been incremented in the database!";

        private static readonly string QUANTITY_DECREMENT_FAILED_TYPE = "Storage Quantity Decrementation Failed";
        private static readonly string QUANTITY_DECREMENT_FAILED_MESSAGE = "The quantity of the storage has not been decremented in the database!";

        public static BaseResponse GetBaseResponse(StorageEnum e)
        {
            string messageType = "";
            string messageBody = "";
            int statusCode = -1;

            switch (e)
            {
                case StorageEnum.SAVE_SUCCESSFUL:
                    {
                        messageType = SAVE_SUCCESSFUL_TYPE;
                        messageBody = SAVE_SUCCESSFUL_MESSAGE;
                        statusCode = StatusCodes.Status200OK;
                        break;
                    }
                case StorageEnum.SAVE_FAILED:
                    {
                        messageType = SAVE_FAILED_TYPE;
                        messageBody = SAVE_FAILED_MESSAGE;
                        statusCode = StatusCodes.Status400BadRequest;
                        break;
                    }
                case StorageEnum.NOT_EXISTED:
                    {
                        messageType = NOT_EXISTED_TYPE;
                        messageBody = NOT_EXISTED_MESSAGE;
                        statusCode = StatusCodes.Status409Conflict;
                        break;
                    }
                case StorageEnum.QUANTITY_INCREMENT_FAILED:
                    {
                        messageType = QUANTITY_INCREASED_FAILED_TYPE;
                        messageBody = QUANTITY_INCREASED_FAILED_MESSAGE;
                        statusCode = StatusCodes.Status400BadRequest;
                        break;
                    }
                case StorageEnum.QUANTITY_DECREMENT_FAILED:
                    {
                        messageType = QUANTITY_DECREMENT_FAILED_TYPE;
                        messageBody = QUANTITY_DECREMENT_FAILED_MESSAGE;
                        statusCode = StatusCodes.Status400BadRequest;
                        break;
                    }
                case StorageEnum.FOUND_FAILED:
                    {
                        messageType = STORAGE_FOUND_FAILED_TYPE;
                        messageBody = STORAGE_FOUND_FAILED_MESSAGE;
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

        public static StorageListResponse GetStorageListResponse(StorageEnum e)
        {
            string messageType = "";
            string messageBody = "";
            int statusCode = -1;

            switch (e)
            {
                case StorageEnum.NOT_EXISTED:
                    {
                        messageType = NOT_EXISTED_TYPE;
                        messageBody = NOT_EXISTED_MESSAGE;
                        statusCode = StatusCodes.Status409Conflict;
                        break;
                    }
                case StorageEnum.FOUND_FAILED:
                    {
                        messageType = WAREHOUSE_FOUND_FAILED_TYPE;
                        messageBody = WAREHOUSE_FOUND_FAILED_MESSAGE;
                        statusCode = StatusCodes.Status400BadRequest;
                        break;
                    }
                case StorageEnum.FOUND_SUCCESSFUL:
                    {
                        messageType = FOUND_SUCCESSFUL_TYPE;
                        messageBody = FOUND_SUCCESSFUL_MESSAGE;
                        statusCode = StatusCodes.Status200OK;
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

            return new StorageListResponse()
            {
                timestamp = DateTime.Now.AddHours(2),
                httpStatusCode = statusCode,
                messageType = messageType,
                messageBody = messageBody,
                storageDetailsList = null
            };
        }

        public static StorageListResponse GetStorageListResponse(WarehouseEnum e)
        {
            string messageType = "";
            string messageBody = "";
            int statusCode = -1;

            switch (e)
            {
                case WarehouseEnum.FOUND_FAILED:
                    {
                        messageType = WAREHOUSE_FOUND_FAILED_TYPE;
                        messageBody = WAREHOUSE_FOUND_FAILED_MESSAGE;
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

            return new StorageListResponse()
            {
                timestamp = DateTime.Now.AddHours(2),
                httpStatusCode = statusCode,
                messageType = messageType,
                messageBody = messageBody,
                storageDetailsList = null
            };
        }
    }
}
