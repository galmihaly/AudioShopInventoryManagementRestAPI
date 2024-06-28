using AudioShopInventoryManagementRestAPI.Helpers;
using DemoRestAPI.Categories;
using DemoRestAPI.Categories.Response;
using DemoRestAPI.Helpers;
using DemoRestAPI.Models.Repository;
using DemoRestAPI.Models.Request;
using DemoRestAPI.Models.Response;

namespace DemoRestAPI.Models.Service
{
    public class ModelService : IModelService
    {
        private IModelRepository _modelRepository;

        public ModelService(IModelRepository modelRepository)
        {
            _modelRepository = modelRepository;
        }

        public async Task<BaseResponse> SaveModel(SaveModelRequest request)
        {
            Model existedModel = await _modelRepository.SearchByName(request.Name);
            if (existedModel != null)
            {
                return ResponseProvider.GetBaseResponse(ResponseEnum.MODEL_ALREADY_EXIST);
            }

            Model NewModel = new Model
            {
                ModelId = request.ModelId,
                Name = request.Name,
                Products = null
            };

            Model ResultModel = await _modelRepository.Add(NewModel);
            if (ResultModel == null)
            {
                return ResponseProvider.GetBaseResponse(ResponseEnum.MODEL_SAVE_FAILED);
            }

            return ResponseProvider.GetBaseResponse(ResponseEnum.MODEL_SAVE_SUCCESSFUL);
        }

        public async Task<ModelListResponse> GetAllModel()
        {
            List<Model> models = await _modelRepository.GetModels();
            if (models == null)
            {
                return ResponseProvider.GetModelListResponse(ResponseEnum.MODEL_NOT_EXIST);
            }

            List<Model> modelList = models.ToList();
            List<ModelDetails> modelsDetailsList = new List<ModelDetails>();
            modelList.ForEach(m =>
            {
                ModelDetails mappedObject = DetailsMapper.MappingToModelDetailsObject(m);
                if (mappedObject != null)
                {
                    modelsDetailsList.Add(mappedObject);
                }
            });

            ModelListResponse response = ResponseProvider.GetModelListResponse(ResponseEnum.MODEL_LIST_SUCCESS);
            response.modelDetails = modelsDetailsList;

            return response;
        }
    }
}
