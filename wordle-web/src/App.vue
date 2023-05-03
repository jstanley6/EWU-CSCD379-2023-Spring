<script setup lang="ts">
import { RouterView } from 'vue-router'
import ThemeSelector from './components/ThemeSelector.vue'
</script>

<template>


        <v-toolbar density="compact" class="elevation-4">
          <v-toolbar-title style="cursor: pointer" @click="$router.push('/')">
            <v-icon icon="mdi-gamepad-square" class="mx-1" color="teal"></v-icon>
            Wordle
          </v-toolbar-title>
          <v-spacer></v-spacer>
          <ThemeSelector />
          <v-menu location="bottom">
            <template v-slot:activator="{ props }">
              <v-btn v-bind="props"> <v-icon icon="mdi-menu" size="x-large"></v-icon> </v-btn>
            </template>


            
            <v-list flat>
              <v-list-item>
                <v-btn variant="plain" to="/"> Home </v-btn>
              </v-list-item>
              <v-list-item>
                <v-btn variant="plain" to="/about"> About </v-btn>
              </v-list-item>
              <v-list-item>
                <v-btn variant="plain" to="/game"> Game </v-btn>
              </v-list-item>
            </v-list>
          </v-menu>

         
        </v-toolbar>
    <v-container fluid class="pa-0">
    
        <RouterView />
  </v-container>
</template>