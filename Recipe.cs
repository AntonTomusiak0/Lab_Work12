
namespace ConsoleApp19
{
    public class RecipeBase
    {
        public string Name { get; set; }
        public string Cuisine { get; set; }
        public List<string> Ingredients { get; set; }
        public List<string> Ingredcalor { get; set; }
        public int CookTime { get; set; }
        public string Type { get; set; }
        public string Info { get; set; }

        public RecipeBase(string name, string cuisine, List<string> ingredients, List<string> ingredcalor, int cookTime, string type, string info)
        {
            Name = name;
            Cuisine = cuisine;
            Ingredients = ingredients;
            Ingredcalor = ingredcalor;
            CookTime = cookTime;
            Type = type;
            Info = info;
        }
    }
    public class Recipe
    {
        private List<RecipeBase> recipes;
        public Recipe()
        {
            recipes = new List<RecipeBase>();
        }
        public void AddRecipe(RecipeBase recipe)
        {
            recipes.Add(recipe);
        }
        public void RemoveRecipe(string recipeName)
        {
            recipes.RemoveAll(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
        }
        public void UpdateRecipe(string recipeName, RecipeBase updatedRecipe)
        {
            var index = recipes.FindIndex(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (index != -1)
            {
                recipes[index] = updatedRecipe;
            }
        }
        public List<RecipeBase> SearchName(string name)
        {
            return recipes.Where(r => r.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        public void SaveRecipe(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (RecipeBase recipe in recipes)
                {
                    writer.WriteLine(recipe.Name);
                    writer.WriteLine(recipe.Cuisine);
                    writer.WriteLine(string.Join(",", recipe.Ingredients));
                    writer.WriteLine(string.Join(",", recipe.Ingredcalor));
                    writer.WriteLine(recipe.CookTime);
                    writer.WriteLine(recipe.Type);
                    writer.WriteLine(recipe.Info);
                }
            }
        }
        public void LoadRecipe(string filePath)
        {
            recipes.Clear();
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string name = line;
                    string cuisine = reader.ReadLine();
                    string[] ingredients = reader.ReadLine().Split(',');
                    string[] ingredcalor = reader.ReadLine().Split(',');
                    int cookTime = int.Parse(reader.ReadLine());
                    string type = reader.ReadLine();
                    string info = reader.ReadLine();

                    RecipeBase recipe = new RecipeBase(name, cuisine, ingredients.ToList(), ingredcalor.ToList(), cookTime, type, info);
                    recipes.Add(recipe);
                }
            }
        }
        public void Show()
        {
            foreach (RecipeBase recipe in recipes)
            {
                Console.WriteLine($"Name: {recipe.Name}");
                Console.WriteLine($"Cuisine: {recipe.Cuisine}");
                Console.WriteLine($"Ingredients: {string.Join(", ", recipe.Ingredients)}");
                Console.WriteLine($"Ingredients calories: {string.Join(", ", recipe.Ingredcalor)}");
                Console.WriteLine($"CookTime: {recipe.CookTime}");
                Console.WriteLine($"Type: {recipe.Type}");
                Console.WriteLine($"Info: {recipe.Info}");
                Console.WriteLine();
            }
        }
        public void ReportName(string filePath)
        {
            string report = "All recipe:\n";
            foreach (RecipeBase recipe in recipes)
            {
                report += $"Name: {recipe.Name}\n";
                report += $"Cuisine: {recipe.Cuisine}\n";
                report += $"Ingredients: {string.Join(", ", recipe.Ingredients)}\n";
                report += $"Ingredients calories: {string.Join(", ", recipe.Ingredcalor)}\n";
                report += $"CookTime: {recipe.CookTime}\n";
                report += $"Type: {recipe.Type}\n";
                report += $"Info: {recipe.Info}\n\n";
            }
            if (!string.IsNullOrEmpty(filePath))
            {
                File.WriteAllText(filePath, report);
            }
            Console.WriteLine(report);
        }
        public void ReportCuisine(string filePath)
        {
            var grRecipes = recipes.GroupBy(r => r.Cuisine);
            string report = "";
            foreach (var group in grRecipes)
            {
                report += $"Cuisine: {group.Key}\n";
                foreach (RecipeBase recipe in group)
                {
                    report += $"Name: {recipe.Name}\n";
                }
                report += $"All recipe: {group.Count()}\n\n";
            }
            if (!string.IsNullOrEmpty(filePath))
            {
                File.WriteAllText(filePath, report);
            }
            Console.WriteLine(report);
        }
        public void ReportCookTime(string filePath)
        {
            var grRecipes = recipes.GroupBy(r => r.CookTime);
            string report = "";
            foreach (var group in grRecipes)
            {
                report += $"CookTime: {group.Key} min\n";
                foreach (RecipeBase recipe in group)
                {
                    report += $"Name: {recipe.Name}\n";
                }
                report += $"All recipe: {group.Count()}\n\n";
            }
            if (!string.IsNullOrEmpty(filePath))
            {
                File.WriteAllText(filePath, report);
            }
            Console.WriteLine(report);
        }
        public void ReportIngredient(string filePath)
        {
            var ingDict = new Dictionary<string, int>();
            foreach (RecipeBase recipe in recipes)
            {
                foreach (string ingredient in recipe.Ingredients)
                {
                    if (ingDict.ContainsKey(ingredient))
                    {
                        ingDict[ingredient]++;
                    }
                    else
                    {
                        ingDict.Add(ingredient, 1);
                    }
                }
            }
            string report = "";
            foreach (var pair in ingDict)
            {
                report += $"Ingredient: {pair.Key}\n";
            }
            if (!string.IsNullOrEmpty(filePath))
            {
                File.WriteAllText(filePath, report);
            }
            Console.WriteLine(report);
        }
        public void ReportCalories(string filePath)
        {
            var grRecipes = recipes.GroupBy(r => r.Ingredcalor);
            string report = "";
            foreach (var group in grRecipes)
            {
                report += $"Sum: {group.Key}\n";
                foreach (RecipeBase recipe in group)
                {
                    report += $"Name: {recipe.Name}\n";
                }
                report += $"All recipe: {group.Count()}\n\n";
            }
            if (!string.IsNullOrEmpty(filePath))
            {
                File.WriteAllText(filePath, report);
            }
            Console.WriteLine(report);
        }
        public void ReportDishType(string filePath)
        {
            var grRecipes = recipes.GroupBy(r => r.Type);
            string report = "";
            foreach (var group in grRecipes)
            {
                report += $"Type: {group.Key}\n";
                foreach (RecipeBase recipe in group)
                {
                    report += $"Name: {recipe.Name}\n";
                }
                report += $"All recipe: {group.Count()}\n\n";
            }
            if (!string.IsNullOrEmpty(filePath))
            {
                File.WriteAllText(filePath, report);
            }

            Console.WriteLine(report);
        }
        public void ReportDishCombination(string filePath)
        {
            var grRecipes = recipes.GroupBy(r => r.Type).ToList();
            int[] indexes = new int[grRecipes.Count];
            string report = "";
            while (true)
            {
                string combination = "";
                for (int i = 0; i < grRecipes.Count; i++)
                {
                    combination += $"{grRecipes[i].Key}: {grRecipes[i].ElementAt(indexes[i]).Name}\n";
                }
                report += $"{combination}\n";
                int j = grRecipes.Count - 1;
                while (j >= 0 && ++indexes[j] == grRecipes[j].Count())
                {
                    indexes[j] = 0;
                    j--;
                }
                if (j < 0) break;
            }
            if (!string.IsNullOrEmpty(filePath))
            {
                File.WriteAllText(filePath, report);
            }
            Console.WriteLine(report);
        }
    }
}