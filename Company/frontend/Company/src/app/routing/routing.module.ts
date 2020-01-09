import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from '../pages/home/home.component';

import { Routes, RouterModule } from '@angular/router';
import { CompanyComponent } from '../pages/company/company.component';
import { EmployeeComponent } from '../pages/employee/employee.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'company', component: CompanyComponent },
  { path: 'employee', component: EmployeeComponent },
  // { path: '/index', component: IndexComponent },
  // { path: '/login', component: LoginComponent },
  // { path: '/logout', component: LogoutComponent },
  // { path: '/profile', component: ProfileComponent },
  // { path: '/register', component: RegisterComponent },
];


@NgModule({
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports: [
    RouterModule
  ],
  declarations: []
})
export class RoutingModule { }
