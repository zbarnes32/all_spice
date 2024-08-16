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
      <div v-for="recipe in recipes" :key="recipe.id" class="col-md-4 my-3">
        <RecipeCard :recipeProp="recipe" />
      </div>
    </div>
  </section>
</template>

<style scoped lang="scss">

.bg-hero {
  background-image: url("/img/forzach.jpg");
  background-size: cover;
  background-position: center;
  height: 40vh;
}
</style>
