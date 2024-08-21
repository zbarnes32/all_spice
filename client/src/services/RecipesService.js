import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { Recipe } from "@/models/Recipe.js"
import { AppState } from "@/AppState.js"



class RecipesService {
    async createRecipe(recipeData) {
      const response = await api.post('api/recipes', recipeData)
      logger.log("Creating a recipe", response.data)
      
    }
    setActiveRecipe(recipeProp) {
        AppState.activeRecipe = recipeProp
    }
    async getAllRecipes(){
        const response = await api.get('api/recipes')
        logger.log('Getting all recipes', response.data)
        const recipes = response.data.map(recipePOJO => new Recipe(recipePOJO))
        AppState.recipes = recipes
    }
}

export const recipesService = new RecipesService()