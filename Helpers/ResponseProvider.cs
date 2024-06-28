using DemoRestAPI.Brands.Response;
using DemoRestAPI.Categories.Response;
using DemoRestAPI.Devices;
using DemoRestAPI.Helpers;
using DemoRestAPI.Models.Response;
using DemoRestAPI.Products.Responses;
using DemoRestAPI.Storages.Responses;
using DemoRestAPI.Users.Response;
using DemoRestAPI.Warehouses.Response;

namespace AudioShopInventoryManagementRestAPI.Helpers
{
    public class ResponseProvider
    {
        public static BaseResponse GetBaseResponse(ResponseEnum e)
        {
            string messageType = "";
            string messageBody = "";
            int statusCode = -1;

            switch (e)
            {
                case ResponseEnum.BRAND_SAVE_SUCCESSFUL:
                {
                    messageType = Responses.BRAND_SAVE_SUCCESS_TYPE;
                    messageBody = Responses.BRAND_SAVE_SUCCESS_MESSAGE;
                    statusCode = StatusCodes.Status200OK;
                    break;
                }
                case ResponseEnum.BRAND_FOUND_SUCCESSFUL:
                {
                    messageType = Responses.BRAND_FOUND_SUCCESSFUL_TYPE;
                    messageBody = Responses.BRAND_FOUND_SUCCESSFUL_MESSAGE;
                    statusCode = StatusCodes.Status200OK;
                    break;
                }
                case ResponseEnum.BRAND_SAVE_FAILED:
                {
                    messageType = Responses.BRAND_SAVE_FAILED_TYPE;
                    messageBody = Responses.BRAND_SAVE_FAILED_MESSAGE;
                    statusCode = StatusCodes.Status400BadRequest;
                    break;
                }
                case ResponseEnum.BRAND_ALREADY_EXIST:
                {
                    messageType = Responses.BRAND_ALREADY_EXIST_TYPE;
                    messageBody = Responses.BRAND_ALREADY_EXIST_MESSAGE;
                    statusCode = StatusCodes.Status409Conflict;
                    break;
                }
                case ResponseEnum.BRAND_NOT_EXIST:
                {
                    messageType = Responses.BRAND_ALREADY_EXIST_TYPE;
                    messageBody = Responses.BRAND_ALREADY_EXIST_MESSAGE;
                    statusCode = StatusCodes.Status409Conflict;
                    break;
                }
                case ResponseEnum.CATEGORY_SAVE_SUCCESSFUL:
                {
                    messageType = Responses.CATEGORY_SAVE_SUCCESS_TYPE;
                    messageBody = Responses.CATEGORY_SAVE_SUCCESS_MESSAGE;
                    statusCode = StatusCodes.Status200OK;
                    break;
                }
                case ResponseEnum.CATEGORY_FOUND_SUCCESSFUL:
                {
                    messageType = Responses.CATEGORY_FOUND_SUCCESSFUL_TYPE;
                    messageBody = Responses.CATEGORY_FOUND_SUCCESSFUL_MESSAGE;
                    statusCode = StatusCodes.Status200OK;
                    break;
                }
                case ResponseEnum.CATEGORY_SAVE_FAILED:
                {
                    messageType = Responses.CATEGORY_SAVE_FAILED_TYPE;
                    messageBody = Responses.CATEGORY_SAVE_FAILED_MESSAGE;
                    statusCode = StatusCodes.Status400BadRequest;
                    break;
                }
                case ResponseEnum.CATEGORY_ALREADY_EXIST:
                {
                    messageType = Responses.CATEGORY_ALREADY_EXIST_TYPE;
                    messageBody = Responses.CATEGORY_ALREADY_EXIST_MESSAGE;
                    statusCode = StatusCodes.Status409Conflict;
                    break;
                }
                case ResponseEnum.CATEGORY_NOT_EXIST:
                {
                    messageType = Responses.CATEGORY_NOT_EXIST_TYPE;
                    messageBody = Responses.CATEGORY_NOT_EXIST_MESSAGE;
                    statusCode = StatusCodes.Status409Conflict;
                    break;
                }
                case ResponseEnum.MODEL_SAVE_SUCCESSFUL:
                {
                    messageType = Responses.MODEL_SAVE_SUCCESS_TYPE;
                    messageBody = Responses.MODEL_SAVE_SUCCESS_MESSAGE;
                    statusCode = StatusCodes.Status200OK;
                    break;
                }
                case ResponseEnum.MODEL_FOUND_SUCCESSFUL:
                {
                    messageType = Responses.MODEL_FOUND_SUCCESSFUL_TYPE;
                    messageBody = Responses.MODEL_FOUND_SUCCESSFUL_MESSAGE;
                    statusCode = StatusCodes.Status200OK;
                    break;
                }
                case ResponseEnum.MODEL_SAVE_FAILED:
                {
                    messageType = Responses.MODEL_SAVE_FAILED_TYPE;
                    messageBody = Responses.MODEL_SAVE_FAILED_MESSAGE;
                    statusCode = StatusCodes.Status400BadRequest;
                    break;
                }
                case ResponseEnum.MODEL_ALREADY_EXIST:
                {
                    messageType = Responses.MODEL_ALREADY_EXIST_TYPE;
                    messageBody = Responses.MODEL_ALREADY_EXIST_MESSAGE;
                    statusCode = StatusCodes.Status409Conflict;
                    break;
                }
                case ResponseEnum.MODEL_NOT_EXIST:
                {
                    messageType = Responses.MODEL_NOT_EXIST_TYPE;
                    messageBody = Responses.MODEL_NOT_EXIST_MESSAGE;
                    statusCode = StatusCodes.Status409Conflict;
                    break;
                }
                case ResponseEnum.STORAGE_SAVE_SUCCESSFUL:
                {
                    messageType = Responses.STORAGE_SAVE_SUCCESSFUL_TYPE;
                    messageBody = Responses.STORAGE_SAVE_SUCCESSFUL_MESSAGE;
                    statusCode = StatusCodes.Status200OK;
                    break;
                }
                case ResponseEnum.STORAGE_SAVE_FAILED:
                {
                    messageType = Responses.STORAGE_SAVE_FAILED_TYPE;
                    messageBody = Responses.STORAGE_SAVE_FAILED_MESSAGE;
                    statusCode = StatusCodes.Status400BadRequest;
                    break;
                }
                case ResponseEnum.STORAGE_NOT_EXIST:
                {
                    messageType = Responses.STORAGE_NOT_EXIST_TYPE;
                    messageBody = Responses.STORAGE_NOT_EXIST_MESSAGE;
                    statusCode = StatusCodes.Status409Conflict;
                    break;
                }
                case ResponseEnum.STORAGE_QUANTITY_INCREMENT_FAILED:
                {
                    messageType = Responses.STORAGE_QUANTITY_INCREASED_FAILED_TYPE;
                    messageBody = Responses.STORAGE_QUANTITY_INCREASED_FAILED_MESSAGE;
                    statusCode = StatusCodes.Status400BadRequest;
                    break;
                }
                case ResponseEnum.STORAGE_QUANTITY_DECREMENT_FAILED:
                {
                    messageType = Responses.STORAGE_QUANTITY_DECREMENT_FAILED_TYPE;
                    messageBody = Responses.STORAGE_QUANTITY_DECREMENT_FAILED_MESSAGE;
                    statusCode = StatusCodes.Status400BadRequest;
                    break;
                }
                case ResponseEnum.STORAGE_PRICEVALUES_INCREMENT_FAILED:
                {
                    messageType = Responses.STORAGE_PRICEVALUES_INCREMENT_FAILED_TYPE;
                    messageBody = Responses.STORAGE_PRICEVALUES_INCREMENT_FAILED_MESSAGE;
                    statusCode = StatusCodes.Status400BadRequest;
                    break;
                }
                case ResponseEnum.STORAGE_PRICEVALUES_DECREMENT_FAILED:
                {
                    messageType = Responses.STORAGE_PRICEVALUES_DECREMENT_FAILED_TYPE;
                    messageBody = Responses.STORAGE_PRICEVALUES_DECREMENT_FAILED_MESSAGE;
                    statusCode = StatusCodes.Status400BadRequest;
                    break;
                }
                case ResponseEnum.WAREHOUSE_SAVE_SUCCESSFUL:
                {
                    messageType = Responses.WAREHOUSE_SAVE_SUCCESS_TYPE;
                    messageBody = Responses.WAREHOUSE_SAVE_SUCCESS_MESSAGE;
                    statusCode = StatusCodes.Status200OK;
                    break;
                }
                case ResponseEnum.WAREHOUSE_SAVE_FAILED:
                {
                    messageType = Responses.WAREHOUSE_SAVE_FAILED_TYPE;
                    messageBody = Responses.WAREHOUSE_SAVE_FAILED_MESSAGE;
                    statusCode = StatusCodes.Status400BadRequest;
                    break;
                }
                case ResponseEnum.WAREHOUSE_FOUND_SUCCESSFUL:
                {
                    messageType = Responses.WAREHOUSE_FOUND_SUCCESSFUL_TYPE;
                    messageBody = Responses.WAREHOUSE_FOUND_SUCCESSFUL_MESSAGE;
                    statusCode = StatusCodes.Status200OK;
                    break;
                }
                case ResponseEnum.WAREHOUSE_NOT_EXIST:
                {
                    messageType = Responses.WAREHOUSE_NOT_EXIST_TYPE;
                    messageBody = Responses.WAREHOUSE_NOT_EXIST_MESSAGE;
                    statusCode = StatusCodes.Status409Conflict;
                    break;
                }
                case ResponseEnum.WAREHOUSE_NOT_INCREMENTED:
                {
                    messageType = Responses.WAREHOUSE_NOT_INCREMENTED_TYPE;
                    messageBody = Responses.WAREHOUSE_NOT_INCREMENTED_MESSAGE;
                    statusCode = StatusCodes.Status400BadRequest;
                    break;
                }
                case ResponseEnum.WAREHOUSE_PRICEVALUES_INCREMENT_FAILED:
                {
                    messageType = Responses.WAREHOUSE_PRICEVALUES_INCREMENT_FAILED_TYPE;
                    messageBody = Responses.WAREHOUSE_PRICEVALUES_INCREMENT_FAILED_MESSAGE;
                    statusCode = StatusCodes.Status400BadRequest;
                    break;
                }
                case ResponseEnum.WAREHOUSE_PRICEVALUES_DECREMENT_FAILED:
                {
                    messageType = Responses.WAREHOUSE_PRICEVALUES_DECREMENT_FAILED_TYPE;
                    messageBody = Responses.WAREHOUSE_PRICEVALUES_DECREMENT_FAILED_MESSAGE;
                    statusCode = StatusCodes.Status400BadRequest;
                    break;
                }
                case ResponseEnum.PRODUCT_SAVE_SUCCESSFUL:
                {
                    messageType = Responses.PRODUCT_SAVE_SUCCESSFUL_TYPE;
                    messageBody = Responses.PRODUCT_SAVE_SUCCESSFUL_MESSAGE;
                    statusCode = StatusCodes.Status200OK;
                    break;
                }
                case ResponseEnum.PRODUCT_SAVE_FAILED:
                {
                    messageType = Responses.PRODUCT_SAVE_FAILED_TYPE;
                    messageBody = Responses.PRODUCT_SAVE_FAILED_MESSAGE;
                    statusCode = StatusCodes.Status400BadRequest;
                    break;
                }
                case ResponseEnum.PRODUCT_FOUND_SUCCESSFUL:
                {
                    messageType = Responses.PRODUCT_EXISTED_TYPE;
                    messageBody = Responses.PRODUCT_EXISTED_MESSAGE;
                    statusCode = StatusCodes.Status409Conflict;
                    break;
                }
                case ResponseEnum.PRODUCT_NOT_EXIST:
                {
                    messageType = Responses.PRODUCT_NOT_EXISTED_TYPE;
                    messageBody = Responses.PRODUCT_NOT_EXISTED_MESSAGE;
                    statusCode = StatusCodes.Status400BadRequest;
                    break;
                }
                case ResponseEnum.PRODUCT_ID_GENERATION_FAILED:
                {
                    messageType = Responses.PRODUCT_ID_GENERATION_FAILED_TYPE;
                    messageBody = Responses.PRODUCT_ID_GENERATION_FAILED_MESSAGE;
                    statusCode = StatusCodes.Status409Conflict;
                    break;
                }
                case ResponseEnum.PRODUCT_DELETED_SUCCESS:
                {
                    messageType = Responses.PRODUCT_DELETED_SUCCESS_TYPE;
                    messageBody = Responses.PRODUCT_DELETED_SUCCESS_MESSAGE;
                    statusCode = StatusCodes.Status409Conflict;
                    break;
                }
                case ResponseEnum.PRODUCT_DELETED_FAILED:
                {
                    messageType = Responses.PRODUCT_DELETED_FAILED_TYPE;
                    messageBody = Responses.PRODUCT_DELETED_FAILED_MESSAGE;
                    statusCode = StatusCodes.Status409Conflict;
                    break;
                }
                case ResponseEnum.DEVICE_FOUND_SUCCESSFUL:
                {
                    messageType = Responses.DEVICE_FOUND_SUCCESSFUL_TYPE;
                    messageBody = Responses.DEVICE_FOUND_SUCCESSFUL_MESSAGE;
                    statusCode = StatusCodes.Status200OK;
                    break;
                }
                case ResponseEnum.DEVICE_FOUND_FAILED:
                {
                    messageType = Responses.DEVICE_FOUND_FAILED_TYPE;
                    messageBody = Responses.DEVICE_FOUND_FAILED_MESSAGE;
                    statusCode = StatusCodes.Status400BadRequest;
                    break;
                }
                case ResponseEnum.USER_REGISTER_SUCCESS:
                {
                    messageType = Responses.USER_REGISTER_SUCCESS_TYPE;
                    messageBody = Responses.USER_REGISTER_SUCCESS_MESSAGE;
                    statusCode = StatusCodes.Status200OK;
                    break;
                }
                case ResponseEnum.USER_REGISTER_FAILED:
                {
                    messageType = Responses.USER_REGISTER_FAILED_TYPE;
                    messageBody = Responses.USER_REGISTER_FAILED_MESSAGE;
                    statusCode = StatusCodes.Status400BadRequest;
                    break;
                }
                case ResponseEnum.USER_NOT_FOUND:
                {
                    messageType = Responses.USER_NOT_FOUND_TYPE;
                    messageBody = Responses.USER_NOT_FOUND_MESSAGE;
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

            return new BaseResponse
            {
                timestamp = DateTime.Now.AddHours(2),
                httpStatusCode = statusCode,
                messageType = messageType,
                messageBody = messageBody
            };
        }

        public static BrandListResponse GetBrandListResponse(ResponseEnum e)
        {
            string messageType = "";
            string messageBody = "";
            int statusCode = -1;

            switch (e)
            {
                case ResponseEnum.BRAND_LIST_SUCCESS:
                {
                    messageType = Responses.BRAND_LIST_SUCCESS_TYPE;
                    messageBody = Responses.BRAND_LIST_SUCCESS_MESSAGE;
                    statusCode = StatusCodes.Status200OK;
                    break;
                }
                case ResponseEnum.BRAND_NOT_EXIST:
                {
                    messageType = Responses.BRAND_NOT_EXIST_TYPE;
                    messageBody = Responses.BRAND_NOT_EXIST_MESSAGE;
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

        public static CategoryListResponse GetCategoryListResponse(ResponseEnum e)
        {
            string messageType = "";
            string messageBody = "";
            int statusCode = -1;

            switch (e)
            {
                case ResponseEnum.CATEGORY_LIST_SUCCESS:
                {
                    messageType = Responses.CATEGORY_LIST_SUCCESS_TYPE;
                    messageBody = Responses.CATEGORY_LIST_SUCCESS_MESSAGE;
                    statusCode = StatusCodes.Status200OK;
                    break;
                }
                case ResponseEnum.CATEGORY_NOT_EXIST:
                {
                    messageType = Responses.CATEGORY_NOT_EXIST_TYPE;
                    messageBody = Responses.CATEGORY_NOT_EXIST_MESSAGE;
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

            return new CategoryListResponse()
            {
                timestamp = DateTime.Now.AddHours(2),
                httpStatusCode = statusCode,
                messageType = messageType,
                messageBody = messageBody,
                categoryDetails = null,
            };
        }

        public static ModelListResponse GetModelListResponse(ResponseEnum e)
        {
            string messageType = "";
            string messageBody = "";
            int statusCode = -1;

            switch (e)
            {
                case ResponseEnum.MODEL_LIST_SUCCESS:
                {
                    messageType = Responses.MODEL_LIST_SUCCESS_TYPE;
                    messageBody = Responses.MODEL_LIST_SUCCESS_MESSAGE;
                    statusCode = StatusCodes.Status200OK;
                    break;
                }
                case ResponseEnum.MODEL_NOT_EXIST:
                {
                    messageType = Responses.MODEL_NOT_EXIST_TYPE;
                    messageBody = Responses.MODEL_NOT_EXIST_MESSAGE;
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

        public static StorageListResponse GetStorageListResponse(ResponseEnum e)
        {
            string messageType = "";
            string messageBody = "";
            int statusCode = -1;

            switch (e)
            {
                case ResponseEnum.STORAGE_NOT_EXIST:
                {
                    messageType = Responses.STORAGE_NOT_EXIST_TYPE;
                    messageBody = Responses.STORAGE_NOT_EXIST_MESSAGE;
                    statusCode = StatusCodes.Status409Conflict;
                    break;
                }
                case ResponseEnum.WAREHOUSE_NOT_EXIST:
                {
                    messageType = Responses.WAREHOUSE_NOT_EXIST_TYPE;
                    messageBody = Responses.WAREHOUSE_NOT_EXIST_MESSAGE;
                    statusCode = StatusCodes.Status400BadRequest;
                    break;
                }
                case ResponseEnum.STORAGE_FOUND_SUCCESSFUL:
                {
                    messageType = Responses.STORAGE_FOUND_SUCCESSFUL_TYPE;
                    messageBody = Responses.STORAGE_FOUND_SUCCESSFUL_MESSAGE;
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

        public static WareHouseListResponse GetWarehouseListResponse(ResponseEnum e)
        {
            string messageType = "";
            string messageBody = "";
            int statusCode = -1;

            switch (e)
            {
                case ResponseEnum.WAREHOUSE_NOT_EXIST:
                {
                    messageType = Responses.WAREHOUSE_NOT_EXIST_TYPE;
                    messageBody = Responses.WAREHOUSE_NOT_EXIST_MESSAGE;
                    statusCode = StatusCodes.Status409Conflict;
                    break;
                }
                case ResponseEnum.WAREHOUSE_FOUND_SUCCESSFUL:
                {
                    messageType = Responses.WAREHOUSE_FOUND_SUCCESSFUL_TYPE;
                    messageBody = Responses.WAREHOUSE_FOUND_SUCCESSFUL_MESSAGE;
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

            return new WareHouseListResponse()
            {
                timestamp = DateTime.Now.AddHours(2),
                httpStatusCode = statusCode,
                messageType = messageType,
                messageBody = messageBody,
                warehouseDetails = null
            };
        }

        public static ProductListResponse GetProductListResponse(ResponseEnum e)
        {
            string messageType = "";
            string messageBody = "";
            int statusCode = -1;

            switch (e)
            {
                case ResponseEnum.PRODUCT_LIST_SUCCESS:
                {
                    messageType = Responses.PORDUCT_LIST_SUCCESS_TYPE;
                    messageBody = Responses.PORDUCT_LIST_SUCCESS_MESSAGE;
                    statusCode = StatusCodes.Status200OK;
                    break;
                }
                case ResponseEnum.PRODUCT_NOT_EXIST:
                {
                    messageType = Responses.PRODUCT_NOT_EXISTED_TYPE;
                    messageBody = Responses.PRODUCT_NOT_EXISTED_MESSAGE;
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

        public static LoginUserResponse GetLoginUserResponse(ResponseEnum e)
        {
            string messageType = "";
            string messageBody = "";
            int statusCode = -1;

            switch (e)
            {
                case ResponseEnum.USER_LOGIN_SUCCESS:
                {
                    messageType = Responses.USER_LOGIN_SUCCESS_TYPE;
                    messageBody = Responses.USER_LOGIN_SUCCESS_MESSAGE;
                    statusCode = StatusCodes.Status200OK;
                    break;
                }
                case ResponseEnum.USER_LOGIN_FAILED:
                {
                    messageType = Responses.USER_LOGIN_FAILED_TYPE;
                    messageBody = Responses.USER_LOGIN_FAILED_MESSAGE;
                    statusCode = StatusCodes.Status401Unauthorized;
                    break;
                }
                case ResponseEnum.USER_PRINCIPAL_NOT_FOUND:
                {
                    messageType = Responses.USER_PRINCIPAL_NOT_FOUND_TYPE;
                    messageBody = Responses.USER_PRINCIPAL_NOT_FOUND_MESSAGE;
                    statusCode = StatusCodes.Status401Unauthorized;
                    break;
                }
                case ResponseEnum.USER_PRINCIPAL_NAME_NOT_FOUND:
                {
                    messageType = Responses.USER_PRINCIPAL_NAME_NOT_FOUND_TYPE;
                    messageBody = Responses.USER_PRINCIPAL_NAME_NOT_FOUND_MESSAGE;
                    statusCode = StatusCodes.Status401Unauthorized;
                    break;
                }
                case ResponseEnum.USER_NOT_FOUND:
                {
                    messageType = Responses.USER_NOT_FOUND_TYPE;
                    messageBody = Responses.USER_NOT_FOUND_MESSAGE;
                    statusCode = StatusCodes.Status401Unauthorized;
                    break;
                }
                case ResponseEnum.USER_NOT_UPDATED:
                {
                    messageType = Responses.USER_NOT_UPDATED_TYPE;
                    messageBody = Responses.USER_NOT_UPDATED_MESSAGE;
                    statusCode = StatusCodes.Status401Unauthorized;
                    break;
                }
                case ResponseEnum.USER_REFRESHTOKEN_NOT_SAME:
                {
                    messageType = Responses.USER_REFRESHTOKEN_NOT_SAME_TYPE;
                    messageBody = Responses.USER_REFRESHTOKEN_NOT_SAME_MESSAGE;
                    statusCode = StatusCodes.Status401Unauthorized;
                    break;
                }
                case ResponseEnum.USER_REFRESHTOKEN_NOT_EXPIRED:
                {
                    messageType = Responses.USER_REFRESHTOKEN_NOT_EXPIRED_TYPE;
                    messageBody = Responses.USER_REFRESHTOKEN_NOT_EXPIRED_MESSAGE;
                    statusCode = StatusCodes.Status401Unauthorized;
                    break;
                }
                case ResponseEnum.USER_REFRESHTOKEN_GENERATION_FAILED:
                {
                    messageType = Responses.USER_REFRESHTOKEN_GENERATION_FAILED_TYPE;
                    messageBody = Responses.USER_REFRESHTOKEN_GENERATION_FAILED_MESSAGE;
                    statusCode = StatusCodes.Status401Unauthorized;
                    break;
                }
                case ResponseEnum.USER_ACCESSTOKEN_GENERATION_FAILED:
                {
                    messageType = Responses.USER_ACCESSTOKEN_GENERATION_FAILED_TYPE;
                    messageBody = Responses.USER_ACCESSTOKEN_GENERATION_FAILED_MESSAGE;
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
