import { Routes, RouterModule } from '@angular/router';
import { IndexComponent } from '../pages/index/index.component';
import { LoginComponent } from '../user/login/login.component';
import { LogoutComponent } from '../user/logout/logout.component';
import { ProfileComponent } from '../user/profile/profile.component';
import { RegisterComponent } from '../user/register/register.component';
import { HomeComponent } from '../pages/home/home.component';
import { CompanyComponent } from '../pages/company/company.component';
import { EmployeeComponent } from '../pages/employee/employee.component';

const routes: Routes = [
  { path: '/index', component: IndexComponent },
  { path: '/home', component: HomeComponent },
  { path: '/login', component: LoginComponent },
  { path: '/logout', component: LogoutComponent },
  { path: '/profile', component: ProfileComponent },
  { path: '/register', component: RegisterComponent },
  { path: '/company', component: CompanyComponent },
  { path: '/employee', component: EmployeeComponent },
];

export const RoutesRoutes = RouterModule.forChild(routes);
