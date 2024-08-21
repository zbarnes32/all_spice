<script setup>
import { Recipe } from '@/models/Recipe.js';
import { recipesService } from '@/services/RecipesService.js';


const props = defineProps({
    recipeProp: { type: Recipe, required: true }
})

function setActiveRecipe() {
    recipesService.setActiveRecipe(props.recipeProp)
}

</script>


<template>

<div class="card text-light recipe-card" data-bs-toggle="modal" data-bs-target="#recipeModal" @click="setActiveRecipe()">
  <img :src="recipeProp.img" class="card-img" :alt="recipeProp.title">
  <div class="card-img-overlay">
    <h5 class="recipe-title fw-bold rounded p-2">{{ recipeProp.title }}</h5>
    <p class="recipe-category fw-bold rounded-pill p-2">{{ recipeProp.category }}</p>
  </div>
</div>

</template>


<style lang="scss" scoped>

.card {
    height: 20em;
}

.recipe-card {
    box-shadow: 1px 1px rgba(0, 0, 0, 0.502);
}

.card-img {
    height: 100%;
}

.recipe-title{
    background-color: rgba(83, 82, 82, 0.750);
    width: 90%;
    position: absolute;
    bottom: 0%;
    left: 50%;
    transform: translate(-50%, -50%);
}

.recipe-category {
    background-color: rgba(83, 82, 82, 0.750);
    width: 7.5em;
    text-align: center;
    position: absolute;
    top: 5%;
    left: 5%;
}


</style>