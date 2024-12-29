import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Result } from "../model/result";
import { UserLoginModel } from "../model/user-login-model";
import { UserProfileMode } from "../model/user-profile-model";
import { UserAddModel } from "../model/user-add-model";

@Injectable({ providedIn: 'root' })
export class UserService {
    constructor(private http: HttpClient) { }

    getProfile() {
        let jwt = sessionStorage.getItem('jwt');
        let url = "http://localhost:52745/user/profile";
        return this.http.get<Result<UserProfileMode>>(url, {
            headers: {
                "Authorization": `Bearer ${jwt}`
            }
        });
    }

    postLogin(request: UserLoginModel) {
        let url = "http://localhost:52745/user/login";
        return this.http.post<Result<string>>(url, request);
    }
    
    postRegister(request: UserAddModel) {
        let url = "http://localhost:52745/user/register";
        return this.http.post<Result<Number>>(url, request);
    }
}
