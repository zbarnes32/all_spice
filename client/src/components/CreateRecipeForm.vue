<script setup>

</script>


<template>

<form>
    <div class="mb-2">
        <label for="title">Recipe Title</label>
        <input type="text" id="title" maxlength="255" required>
    </div>
    <div class="mb-2">
        <label for="category">Category</label>
        <input type="text" id="category" maxlength="255" required>
    </div>
    <div class="mb-2">
        <label for="img">Image URL</label>
        <input type="text" id="img" maxlength="255" required>
    </div>
    <div class="text-end">
        <button type="submit" class="btn btn-success">Submit</button>
    </div>
</form>

</template>


<style lang="scss" scoped>

</style>