<script setup>
import { AppState } from '@/AppState.js';
import { computed } from 'vue';


const recipe = computed(() => AppState.activeRecipe)

</script>


<template>

<div class="modal fade" id="recipeModal" tabindex="-1" aria-labelledby="recipeModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-xl">
    <div v-if="recipe" class="modal-content">
        <div class="card">
            <div class="row g-0">
            <div class="col-md-6">
                <img :src=recipe.img class="img-fluid rounded-start modal-img" :alt=recipe.title>
            </div>
                <div class="col-md-6">
                    <div class="card-body">
                        <div class="d-flex justify-content-between">
                          <div class="d-flex">
                            <h3 class="card-title fw-bold me-3">{{ recipe.title }}</h3>
                            <div class="dropdown">
                            <i class="mdi mdi-dots-horizontal fs-3 " type="button" id="dropdownMenu" data-bs-toggle="dropdown" aria-expanded="false">
                            </i>
                            <ul class="dropdown-menu" aria-labelledby="dropdownMenu">
                              <li role="button">Edit Recipe</li>
                              <li role="button">Delete Recipe</li>
                              
                            </ul>
                            </div>
                          </div>
                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <!-- FIXME: Add in creator info -->
                        <small class="recipe-creator">by:{{ recipe.creatorId }}</small>
                        <p class="recipe-category fw-bold rounded-pill my-3">{{ recipe.category }}</p>
                        <div>
                            <h5 class="fw-bold">Ingredients</h5>
                            <p>The ingredients will go here</p>
                        </div>
                        <div>
                            <h5 class="fw-bold">Instructions</h5>
                            <p class="card-text">{{ recipe.instructions }}</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
      <!-- <div class="modal-header">
        <h1 class="modal-title" id="recipeModalLabel">{{ recipe.title }}</h1>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div class="modal-body">
        ...
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
        <button type="button" class="btn btn-primary">Save changes</button>
      </div> -->
    </div>
  </div>
</div>

</template>


<style lang="scss" scoped>

.recipe-creator {
    color: gray;
}

.recipe-category {
    background-color: gray;
    width: 20%;
    text-align: center;
    color: white;
//     position: absolute;
//     top: 5%;
//     left: 5%;
}

.modal-img {
    max-height: 100%;
    width: 100%;
}

</style>