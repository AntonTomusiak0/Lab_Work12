namespace ConsoleApp19
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*var str = new[] { "a", "b", "c", "d" };
            var FileName = "name.txt";
            using (StreamWriter writer = new StreamWriter(FileName, append: true))
            {
                foreach (var item in str)
                {
                    writer.WriteLine(item);
                }
            }
            using (StreamReader reader = new StreamReader(FileName))
            {
                string strg;
                while ((strg = reader.ReadLine()) != null)
                {
                    Console.WriteLine(strg);
                }   
            }
            File.WriteAllText(FileName, "Name text");
            var res = File.ReadAllText(FileName);
            Console.WriteLine(res);*/
            Recipe rcp = new Recipe();
            RecipeBase rcp1 = new RecipeBase("Name1", "Cuisine1", new List<string> { "Ingredients1", "Ingredients1", "Ingredients1", "Ingredients1" }, new List<string> { "calor1", "calor1", "calor1", "calor1" }, 60, "Type1" , "Info1");
            RecipeBase rcp2 = new RecipeBase("Name2", "Cuisine2", new List<string> { "Ingredients2", "Ingredients2", "Ingredients2", "Ingredients2", "Ingredients2" }, new List<string> { "calor2", "calor2", "calor2", "calor2" }, 60, "Type2", "Info2");

            rcp.AddRecipe(rcp1);
            rcp.AddRecipe(rcp2);
            Console.WriteLine("Show:");
            rcp.Show();
            Console.WriteLine();

            List<RecipeBase> found = rcp.SearchName("Name2");
            Console.WriteLine($"{found}");
            foreach (RecipeBase recipe in found)
            {
                Console.WriteLine($"Name: {recipe.Name}");
                Console.WriteLine($"Cuisine: {recipe.Cuisine}");
                Console.WriteLine($"Ingredients: {string.Join(", ", recipe.Ingredients)}");
                Console.WriteLine($"CookTime: {recipe.CookTime}");
                Console.WriteLine($"Info: {recipe.Info}");
                Console.WriteLine();
            }
            Console.WriteLine();
            rcp.RemoveRecipe("Name1");

            RecipeBase update = new RecipeBase("Name2", "Cuisine3", new List<string> { "Ingredients2", "Ingredients2", "Ingredients2", "Ingredients2", "Ingredients2" }, new List<string> { "calor2", "calor2", "calor2", "calor2" }, 60, "Type2", "Info2");
            rcp.UpdateRecipe("Name2", update);
            rcp.SaveRecipe("recipes.txt");

            rcp.SaveRecipe("recipes.txt");
            Recipe nrcp = new Recipe();
            nrcp.LoadRecipe("recipes.txt");
            nrcp.Show();

            string report = "report.txt";
            string reportNameFile = "reportName.txt";
            string reportCuisineFile = "reportCuisine.txt";
            string reportCookTimeFile = "reportCookTime.txt";
            string reportIngredientFile = "reportIngredient.txt";
            rcp.ReportName(reportNameFile);
            Console.WriteLine($"Report Name'{reportNameFile}'.");

            rcp.ReportCuisine(reportCuisineFile);
            Console.WriteLine($"Report Cuisine'{reportCuisineFile}'.");

            rcp.ReportCookTime(reportCookTimeFile);
            Console.WriteLine($"Report CookTime'{reportCookTimeFile}'.");

            rcp.ReportIngredient(reportIngredientFile);
            Console.WriteLine($"Report Ingredient'{reportIngredientFile}'.");

            rcp.ReportCalories(report);
            Console.WriteLine($"Report'{report}'.");

            rcp.ReportDishType(report);
            Console.WriteLine($"Report'{report}'.");

            rcp.ReportDishCombination(report);
            Console.WriteLine($"Report'{report}'.");
        }
    }
}