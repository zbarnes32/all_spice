<script setup>
import { recipesService } from '@/services/RecipesService.js';
import Pop from '@/utils/Pop.js';
import { Modal } from 'bootstrap';
import { ref } from 'vue';

const categories = ['breakfast', 'lunch', 'dinner', 'snack', 'dessert']

const editableRecipeData = ref({
    title: '',
    category: '',
    img: '',
    instructions: ''
})


async function createRecipe() {
  try {
    await recipesService.createRecipe(editableRecipeData.value)
    Modal.getOrCreateInstance('#createRecipeModal').hide()
    editableRecipeData.value = {
    title: '',
    category: '',
    img: '',
    instructions: ''
}
  } catch (error){
    Pop.error(error);
  }
}

</script>


<template>

<form class="container-fluid" @submit.prevent="createRecipe()">
    <div>
        <div class="mb-2">
            <label for="title" class="w-25">Recipe Title</label>
            <input v-model="editableRecipeData.title" type="text" id="title" class="w-75" maxlength="255" required>
        </div>
        <div class="mb-2 d-flex justify-content-between">
            <label for="category" class="w-40">Category</label>
            <select v-model="editableRecipeData.category" id="category" class="form-select w-55" title="Choose the category" required>
            <option v-for="category in categories" :key="category" :value="category" class="text-capitalize">
                {{ category }}
            </option>
            </select> 
        </div>
        <div class="mb-2">
            <label for="img" class="w-25">Image URL</label>
            <input v-model="editableRecipeData.img" type="text" id="img" class="w-75" maxlength="255" required>
        </div>
        <div class="text-end">
            <button type="submit" class="btn btn-success">Submit</button>
        </div>

    </div>
</form>

</template>


<style lang="scss" scoped>

</style>