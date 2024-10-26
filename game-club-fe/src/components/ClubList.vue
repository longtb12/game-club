<template>
    <div class="club-list">
        <h2>Game Clubs</h2>
        <InputText class="full-width" v-model="searchTerm" @input="searchClubs" placeholder="Search Clubs" />
        <ul>
            <li v-for="club in clubs" :key="club.id">
                <h3>{{ club.name }}</h3>
                <p>{{ club.description }}</p>
            </li>
        </ul>
    </div>
</template>

<script>
import { ref, onMounted } from 'vue';
import apiService from '../apiService';
import InputText from 'primevue/inputtext';

export default {
    components: { InputText },
    setup() {
        const clubs = ref([]);
        const searchTerm = ref('');

        const fetchClubs = async () => {
            const response = await apiService.getAllClubs();
            clubs.value = response;
        };

        const searchClubs = async () => {
            const response = await apiService.searchClubs(searchTerm.value);
            clubs.value = response;
        };

        onMounted(() => {
            fetchClubs();
        });

        return { clubs, searchTerm, searchClubs };
    }
};
</script>

<style scoped>
.club-list {
    margin: 20px;
}

ul {
    list-style-type: none;
    padding: 0;
}

li {
    border: 1px solid #ddd;
    margin: 5px 0;
    padding: 10px;
}
</style>