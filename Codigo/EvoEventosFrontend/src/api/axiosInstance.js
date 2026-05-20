import axios from 'axios'
import { useAuthStore } from '../store/auth'

const EvoEventosApi = axios.create({
  baseURL: "http://localhost:5031/api",
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