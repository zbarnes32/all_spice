<script setup>
import { AppState } from '@/AppState.js';
import CreateRecipeForm from '@/components/CreateRecipeForm.vue';
import RecipeCard from '@/components/RecipeCard.vue';
import ReuseableModal from '@/components/ReuseableModal.vue';
import { recipesService } from '@/services/RecipesService.js';
import Pop from '@/utils/Pop.js';
import { computed, onMounted } from 'vue';

const recipes = computed(() => AppState.recipes)


onMounted(() => { getAllRecipes() })


async function getAllRecipes() {
  try {
    await recipesService.getAllRecipes()
  }
  catch (error){
    Pop.error(error);
  }
}

</script>

<template>
  <section class="container-fluid">
    <div class="row">
      <div class="col-12 bg-hero justify-content-center">
        <h1>All Spice</h1>
        <p>Cherish Your Family</p>
        <p>And Their Cooking</p>
      </div>
    </div>
  </section>
  <section class="container">
    <div class="row">
      <div v-for="recipe in recipes" :key="recipe.id" class="col-md-4 my-3">
        <RecipeCard :recipeProp="recipe" />
      </div>
    </div>
  </section>
  <footer class="container-fluid">
    <div class="row">
      <div class="col-12 justify-content-end fixed-bottom text-end">
        <button class="btn btn-success mb-5 me-5 create-recipe-button" data-bs-toggle="modal" data-bs-target="#createRecipeModal"><i class="mdi mdi-plus fs-1"></i></button>
      </div>
    </div>
  </footer>

<ReuseableModal modalId="createRecipeModal">
  <template #modalHeader>New Recipe</template>
  <template #modalBody> <CreateRecipeForm /> </template>
</ReuseableModal>
</template>

<style scoped lang="scss">

.bg-hero {
  background-image: url("/img/forzach.jpg");
  background-size: cover;
  background-position: center;
  height: 40vh;
}

.create-recipe-button {
  border-radius: 50%;
}
</style>
