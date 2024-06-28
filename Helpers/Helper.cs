using System.Text;

namespace AudioShopInventoryManagementRestAPI.Helpers
{
    public class Helper
    {
        private const char DIVIDER = '-';

        public static string GetProductId(String brandId, String categoryId, String modelId)
        {
            if (brandId == null) return null;
            if (categoryId == null) return null;
            if (modelId == null) return null;

            StringBuilder sb = new StringBuilder();
            return sb
                .Append(brandId)
                .Append(DIVIDER)
                .Append(categoryId)
                .Append(DIVIDER)
                .Append(modelId)
                .ToString();
        }
    }
}
