using AudioShopInventoryManagementRestAPI.Helpers;
using DemoRestAPI.Brands;
using DemoRestAPI.Categories.Repository;
using DemoRestAPI.Categories.Request;
using DemoRestAPI.Categories.Response;
using DemoRestAPI.Helpers;

namespace DemoRestAPI.Categories.Service
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<BaseResponse> SaveCategory(SaveCategoryRequest request)
        {
            Category existedCategory = await _categoryRepository.SearchByName(request.Name);
            if (existedCategory != null)
            {
                return ResponseProvider.GetBaseResponse(ResponseEnum.CATEGORY_ALREADY_EXIST);
            }

            Category newCategory = new Category
            {
                CategoryId = request.CategoryId,
                Name = request.Name,
                Products = null
            };

            Category resultCategory = await _categoryRepository.Add(newCategory);
            if (resultCategory == null)
            {
                return ResponseProvider.GetBaseResponse(ResponseEnum.CATEGORY_SAVE_FAILED);
            }

            return ResponseProvider.GetBaseResponse(ResponseEnum.CATEGORY_SAVE_SUCCESSFUL);
        }

        public async Task<CategoryListResponse> GetAllCategory()
        {
            List<Category> categories = await _categoryRepository.GetCategories();
            if (categories == null)
            {
                return ResponseProvider.GetCategoryListResponse(ResponseEnum.CATEGORY_NOT_EXIST);
            }

            List<Category> categoryList = categories.ToList();
            List<CategoryDetails> categoryDetailsList = new List<CategoryDetails>();
            categoryList.ForEach(c =>
            {
                CategoryDetails mappedObject = DetailsMapper.MappingToCategoryDetailsObject(c);             
                if (mappedObject != null)
                {
                    categoryDetailsList.Add(mappedObject);
                }
            });

            CategoryListResponse response = ResponseProvider.GetCategoryListResponse(ResponseEnum.CATEGORY_LIST_SUCCESS);
            response.categoryDetails = categoryDetailsList;

            return response;
        }
    }
}
