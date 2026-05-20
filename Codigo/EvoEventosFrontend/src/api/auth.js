import axios from './axiosInstance'

export const loginRequest = async (identifier, password) => {
  return axios.post('/Auth/Login', {
    identifier,
    password
  })
}
