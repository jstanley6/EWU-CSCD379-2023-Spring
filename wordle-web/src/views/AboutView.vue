<template>

{{ isDialogOpen }}

  <WeatherDialog v-model="isDialogOpen" :weather="currentWeather!"></WeatherDialog>

  <v-card v-for="item in weatherData" :key="item.date" @click="setCurrentWeather(item)">
    {{ item.date }} - {{ item.temperatureC }} - {{ item.summary }}
  </v-card>
</template>

<script setup lang="ts">
import WeatherDialog from "@/components/WeatherDialog.vue"
import type { WeatherData } from "../types/WeatherData"
import Axios from "axios"
import { ref } from "vue"


const isDialogOpen = ref(false)
const weatherData = ref<WeatherData[]>()
const currentWeather = ref<WeatherData>()

function setCurrentWeather(weather: WeatherData) {
  currentWeather.value = weather
  isDialogOpen.value = true
}

Axios.get("https://localhost:7043/WeatherForecast")
.then((response) => {
  console.log(response.data)
  weatherData.value = response.data
})
.catch((err) => { 
  console.log(err)
}) 

</script>

