import axios from "axios";

const instance = axios.create({
    baseURL: "http://10.0.2.2:5123/api/",
    headers: {
        Accept: 'application/json',
        "Content-Type": "application/json"
    }
});

export default instance;