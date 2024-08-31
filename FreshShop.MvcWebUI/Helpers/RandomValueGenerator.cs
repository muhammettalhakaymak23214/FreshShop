namespace FreshShop.MvcWebUI.Helpers
{
    public static class RandomValueGenerator
    {
        public static string GeneratorFileName(string extension)
        {
            return Guid.NewGuid().ToString().Replace("-","") + extension;
        }

    }
}
