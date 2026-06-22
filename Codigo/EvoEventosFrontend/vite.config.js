import { defineConfig, loadEnv } from 'vite'
import react from '@vitejs/plugin-react'
import path from 'path'
import { fileURLToPath } from 'url';

const __dirname = path.dirname(fileURLToPath(import.meta.url));

// https://vite.dev/config/
export default defineConfig(({ mode }) => {
  const env = loadEnv(mode, process.cwd(), '')
  const useDockerProxy = env.VITE_API_URL === '/api'

  return {
    plugins: [react()],
    resolve: {
      alias: {
        '@assets': path.resolve(__dirname, './src/assets'),
        '@': path.resolve(__dirname, './src')
      }
    },
    server: {
      watch: {
        usePolling: true
      },
      proxy: useDockerProxy
        ? {
          '/api': {
            target: 'http://backend:8080',
            changeOrigin: true,
            secure: false
          }
        }
        : undefined
    }
  }
})
