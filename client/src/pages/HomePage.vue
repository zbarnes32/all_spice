<script setup>
import { AppState } from '@/AppState.js';
import RecipeCard from '@/components/RecipeCard.vue';
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
      <div v-for="recipe in recipes" :key="recipe.id" class="col-md-4">
        <RecipeCard :recipeProp="recipe" />
      </div>
    </div>
  </section>
</template>

<style scoped lang="scss">

.bg-hero {
  background-image: url('https://images.unsplash.com/photo-1478369402113-1fd53f17e8b4?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MzV8fGZvb2R8ZW58MHx8MHx8fDA%3D');
  background-size: cover;
  background-position: center;
  height: 40vh;
}
</style>
