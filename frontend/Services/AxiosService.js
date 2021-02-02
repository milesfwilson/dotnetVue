import Axios from 'axios'

export const api = Axios.create({
    baseURL: 'https://localhost:44395/api/',
    timeout: 10000
  });