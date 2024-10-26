<template>
  <div id="app" class="card">
      <div class="box">
        <ClubForm />
        <ClubList />
      </div>
      <div class="box">
        <EventForm />
        <EventList />
      </div>
  </div>
</template>

<script>
import ClubForm from './components/ClubForm.vue';
import ClubList from './components/ClubList.vue';
import EventForm from './components/EventForm.vue';
import EventList from './components/EventList.vue';

export default {
  components: {
    ClubForm,
    ClubList,
    EventForm,
    EventList,
  },
};
</script>

<style>
#app {
  margin: auto;
  padding: 20px;
  display: flex;
  flex-direction: row;
}

.box {
  flex: 1 1 50%;           /* Set each item to take up 50% of the container */
  padding: 20px;
  text-align: center;
  width: 800px;
}

.full-width {
    width: 100%;
}
</style>
