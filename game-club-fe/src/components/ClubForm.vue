<template>
    <div class="form-container">
        <h2>Create Game Club</h2>
        <form @submit.prevent="createClub">
            <div class="mb-2">
                <InputText class="full-width" v-model="name" placeholder="Club Name" required />
            </div>
            <div class="mb-2">
                <InputText class="full-width" v-model="description" placeholder="Description" required></InputText>
            </div>
            <div>
                <Button class="full-width" label="Create Club" type="submit"></Button>
            </div>
            
            <Toast ref="toast" />
        </form>
    </div>
</template>

<script>
import { ref } from 'vue';
import apiService from '../apiService';
import Toast from 'primevue/toast';
import InputText from 'primevue/inputtext';
import Button from 'primevue/button';

export default {
    components: { Toast, InputText, Button },
    setup() {
        const name = ref('');
        const description = ref('');
        const toast = ref(null);

        const createClub = async () => {
            try {
                await apiService.createClub({ name: name.value, description: description.value });
                name.value = '';
                description.value = '';
                toast.value.add({ severity: 'success', summary: 'Success', detail: 'Club created!' });
            } catch (err) {
                toast.value.add({ severity: 'error', summary: 'Error', detail: err.response?.data?.message || 'An error occurred.' });
            }
        };

        return { name, description, createClub, toast };
    }
};
</script>

<style scoped>
.form-container {
    margin: 20px;
}
</style>