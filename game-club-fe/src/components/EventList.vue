<template>
    <div class="event-list">
        <h2>Events for Club</h2>
        <Dropdown v-model="clubId" :options="clubs" optionLabel="name" placeholder="Select Club" class="full-width"
            @change="fetchEvents" />
        <ul>
            <li v-for="event in events" :key="event.id">
                <h3>{{ event.title }}</h3>
                <p>{{ event.scheduledDateTime }}</p>
            </li>
        </ul>
    </div>
</template>

<script>
import { ref, onMounted } from 'vue';
import apiService from '../apiService';
import Dropdown from 'primevue/dropdown';

export default {
    components: { Dropdown },
    setup() {
        const clubs = ref([]);
        const clubId = ref(null);
        const events = ref([]);

        const fetchClubs = async () => {
            const response = await apiService.getAllClubs();
            clubs.value = response;
        };

        const fetchEvents = async () => {
            if (clubId.value) {
                const response = await apiService.getEventsForClub(clubId.value.id);
                events.value = response;
            }
        };

        onMounted(() => {
            fetchClubs();
        });

        return { clubs, clubId, events, fetchEvents };
    }
};
</script>

<style scoped>
.event-list {
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