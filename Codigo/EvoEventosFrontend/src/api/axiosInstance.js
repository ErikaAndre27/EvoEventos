import axios from "axios";
import { useAuthStore } from "../store/auth";

// Crear instancia de axios para comunicarse con el Backend
const EvoEventosApi = axios.create({
  // CAMBIO IMPORTANTE: Usar variable de entorno VITE_API_URL
  // - En Docker: será "http://backend:8080/api" (definida en docker-compose.yml)
  // - En desarrollo local: será "http://localhost:5031/api" (valor por defecto)
  // Esto permite que la misma imagen funcione en diferentes ambientes sin cambiar código
  baseURL: import.meta.env.VITE_API_URL || "http://localhost:5031/api",
  withCredentials: true,
});

// Interceptor: Agregar token JWT a cada petición automáticamente
// Esto asegura que todas las peticiones al Backend lleven el token de autenticación
EvoEventosApi.interceptors.request.use((config) => {
  const token = useAuthStore.getState().token;
  config.headers = {
    Authorization: `Bearer ${token}`,
  };
  return config;
});

export default EvoEventosApi;
