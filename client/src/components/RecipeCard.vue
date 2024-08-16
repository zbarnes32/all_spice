<script setup>
import { Recipe } from '@/models/Recipe.js';


defineProps({
    recipeProp: { type: Recipe, required: true }
})

</script>


<template>

    <p>{{ recipeProp.title }}</p>
    
</template>


<style lang="scss" scoped>

</style>