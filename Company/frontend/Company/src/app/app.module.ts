import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './user/login/login.component';
import { LogoutComponent } from './user/logout/logout.component';
import { HomeComponent } from './pages/home/home.component';
import { ProfileComponent } from './user/profile/profile.component';
import { IndexComponent } from './pages/index/index.component';
import { RegisterComponent } from './user/register/register.component';
import { CompanyComponent } from './pages/company/company.component';
import { EmployeeComponent } from './pages/employee/employee.component';
import { MenuComponent } from './pages/menu/menu.component';
import { Material } from './material.module';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    LogoutComponent,
    HomeComponent,
    ProfileComponent,
    IndexComponent,
    RegisterComponent,
    CompanyComponent,
    EmployeeComponent,
    MenuComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    Material
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}
