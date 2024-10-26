<template>
    <div class="form-container">
        <h2>Create Event for Club</h2>
        <form @submit.prevent="createEvent">
            <div class="mb-2">
                <Dropdown class="full-width md:w-14rem" v-model="clubId" :options="clubs" optionLabel="name" placeholder="Select Club"
                @change="fetchClubs" />
            </div>
            <div class="mb-2">
                <InputText class="full-width" v-model="title" placeholder="Event Title" required />
            </div>
            <div class="mb-2">
                <InputText class="full-width" v-model="description" placeholder="Event Description" required rows="3" />
            </div>
            <div class="mb-2">
                <InputText class="full-width" type="datetime-local" v-model="dateTime" required />
            </div>
            <div class="mb-2">
                <Button class="full-width" label="Create Event" type="submit" />
            </div>
            
        </form>
    </div>
</template>

<script>
import { ref, onMounted } from 'vue';
import apiService from '../apiService';
import Dropdown from 'primevue/dropdown';
import InputText from 'primevue/inputtext';
import Button from 'primevue/button';

export default {
    components: { Dropdown, InputText, Button },
    setup() {
        const clubs = ref([]);
        const clubId = ref(null);
        const title = ref('');
        const description = ref('');
        const dateTime = ref('');

        const fetchClubs = async () => {
            const response = await apiService.getAllClubs();
            clubs.value = response;
        };

        const createEvent = async () => {
            await apiService.createEvent(clubId.value.id, {
                title: title.value,
                description: description.value,
                scheduledDateTime: dateTime.value,
            });
            title.value = '';
            description.value = '';
            dateTime.value = '';
        };

        onMounted(() => {
            fetchClubs();
        });

        return { clubs, clubId, title, description, dateTime, createEvent };
    }
};
</script>

<style scoped>
.form-container {
    margin: 20px;
}

.p-dropdown-label {
    display: flex;
    justify-content: left;
}
</style>