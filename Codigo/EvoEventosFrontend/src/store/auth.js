import { create } from 'zustand'
import { persist } from 'zustand/middleware'


export const useAuthStore = create(persist(
  (set) => ({
    token: null,
    profile: null,
    isAuth: false,
    setToken: (token) => set({
      token,
      isAuth: true
    }),
    setProfile: (profile) => set({ profile }),
    logout: () => set({
      token: '',
      isAuth: false,
      profile: null,
    })
  }), {
  name: 'auth' // nombre con el que se guarda en localStorage
}))

