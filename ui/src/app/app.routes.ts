import { Routes } from '@angular/router';
import { LoginPageComponent } from './page/login-page/login-page.component';
import { ProfilePageComponent } from './page/profile-page/profile-page.component';
import { RegisterPageComponent } from './page/register-page/register-page.component';

export const routes: Routes = [
    { path: 'login', component: LoginPageComponent },
    { path: 'profile', component: ProfilePageComponent },
    { path: 'register', component: RegisterPageComponent },
];
