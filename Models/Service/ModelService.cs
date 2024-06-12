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
                return ModelHelper.GetBaseResponse(ModelEnum.EXISTED);
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
                return ModelHelper.GetBaseResponse(ModelEnum.SAVE_FAILED);
            }

            return ModelHelper.GetBaseResponse(ModelEnum.SAVE_SUCCESSFUL);
        }

        public async Task<ModelListResponse> GetAllModel()
        {
            List<Model> models = await _modelRepository.GetModels();
            if (models == null)
            {
                return ModelHelper.GetModelListResponse(ModelEnum.NOT_EXISTED);
            }

            List<Model> modelList = models.ToList();
            List<ModelDetails> modelsDetailsList = new List<ModelDetails>();
            modelList.ForEach(m =>
            {
                ModelDetails mappedObject = Helper.MappingToModelDetailsObject(m);
                if (mappedObject != null)
                {
                    modelsDetailsList.Add(mappedObject);
                }
            });

            ModelListResponse response = ModelHelper.GetModelListResponse(ModelEnum.MODEL_LIST_SUCCESS);
            response.modelDetails = modelsDetailsList;

            return response;
        }
    }
}
