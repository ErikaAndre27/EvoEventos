import axios from 'axios'
import { useAuthStore } from '../store/auth'

const baseURL = import.meta.env.VITE_API_URL || 'http://localhost:5031/api'

const EvoEventosApi = axios.create({
  baseURL,
  withCredentials: true
})

EvoEventosApi.interceptors.request.use(config => {
  const token = useAuthStore.getState().token
  config.headers = {
    Authorization: `Bearer ${token}`
  }
  return config
})

export default EvoEventosApi