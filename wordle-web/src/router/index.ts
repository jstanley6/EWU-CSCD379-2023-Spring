import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import Wordle from '../views/WordleView.vue'
import About from '../views/AboutView.vue'
import LeaderBoardView from '../views/LeaderBoardView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView
    },
    {
      path: '/about',
      name: 'about',
      component: About
    },
    {
      path: '/game',
      name: 'game',
      component: Wordle
    },
    {
      path: '/leaderboard',
      name: 'leaderboard',
      component: LeaderBoardView
    }
  ]
})

export default router
