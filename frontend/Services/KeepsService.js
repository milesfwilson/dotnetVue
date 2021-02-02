import { api } from "./AxiosService";
import { AppState } from "../src/AppState";


class KeepsService {
  async getKeeps() {
    try {
      const res = await api.get("/Keeps")
      AppState.keeps = res.data
      console.log(res.data)
    } catch (error) {
        console.error(error)
    }
  }
}

export const keepsService = new KeepsService();
